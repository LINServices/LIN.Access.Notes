using LIN.Access.Notes.Controllers;
using LIN.Access.Notes.Observers;

namespace LIN.Access.Notes;


public sealed class Session
{


    /// <summary>
    /// Información del usuario
    /// </summary>
    public ProfileModel Profile { get; private set; } = new();



    /// <summary>
    /// Es una sesión local.
    /// </summary>
    public SessionType Type { get; set; }



    /// <summary>
    /// Token de acceso.
    /// </summary>
    public string Token { get; set; }



    /// <summary>
    /// Información del usuario
    /// </summary>
    public AccountModel Account { get; private set; } = new();



    /// <summary>
    /// Token de la cuenta.
    /// </summary>
    public string AccountToken { get; set; }



    /// <summary>
    /// Si la sesión es activa
    /// </summary>
    public static bool IsAccountOpen { get => Instance.Account.Id != 0; }



    /// <summary>
    /// Si la sesión es activa
    /// </summary>
    public static bool IsLocalOpen { get => Instance.Profile.Id != 0; }




    /// <summary>
    /// Recarga o inicia una sesión
    /// </summary>
    public static async Task<(Session? Sesion, Responses Response)> LoginWith(string user, string password, bool safe)
    {

        // Cierra la sesión Actual
        if (!safe)
            CloseSession();

        // Validación de user
        var response = await Authentication.Login(user, password);

        if (response.Response != Responses.Success)
            return (null, response.Response);

        // Datos de la instancia
        Instance.Profile = response.Model.Profile;
        Instance.Account = response.Model.Account;

        Instance.Token = response.Token;
        Instance.AccountToken = response.Model.TokenCollection["identity"];
        Instance.Type = SessionType.Connected;
        SessionObserver.Invoke(Instance);
        return (Instance, Responses.Success);

    }



    /// <summary>
    /// Recarga o inicia una sesión
    /// </summary>
    public static async Task<(Session? Sesion, Responses Response)> LoginWith(string token)
    {

        // Cierra la sesión Actual
        CloseSession();

        // Validación de user
        var response = await Authentication.Login(token);


        if (response.Response != Responses.Success)
            return (null, response.Response);


        // Datos de la instancia
        Instance.Profile = response.Model.Profile;
        Instance.Account = response.Model.Account;

        Instance.Token = response.Token;
        Instance.AccountToken = response.Model.TokenCollection["identity"];
        Instance.Type = SessionType.Connected;

        SessionObserver.Invoke(Instance);
        return (Instance, Responses.Success);

    }






    /// <summary>
    /// Cierra la sesión
    /// </summary>
    public static void CloseSession()
    {
        Instance.Profile = new();
        Instance.Account = new();
    }






    //==================== Singleton ====================//


    private readonly static Session _instance = new();

    private Session()
    {
        Token = string.Empty;
        AccountToken = string.Empty;
        Profile = new();
    }


    public static Session Instance => _instance;



    public static void GenerateLocal(AccountModel account, SessionType type)
    {
        Instance.Type = type;
        Instance.Account = account;
        SessionObserver.Invoke(Instance);
    }


}


public enum SessionType
{
    Local,
    Connected,
    Sync
}