using LIN.Access.Notes.Controllers;

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
    public bool IsLocal { get; set; }



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
    public static bool IsLocalOpen { get => Instance.Profile.ID != 0; }




    /// <summary>
    /// Recarga o inicia una sesión
    /// </summary>
    public static async Task<(Session? Sesion, Responses Response)> LoginWith(string user, string password)
    {

        // Cierra la sesión Actual
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
        Instance.IsLocal = false;
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
        Instance.IsLocal = false;

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



    public static void GenerateLocal(string name)
    {
        Instance.IsLocal = true;
        Instance.Account = new()
        {
            Id = -1,
            Name = name,
            Identity = new()
            {
                Unique = name
            }
        };
        Instance.Profile = new()
        {
            ID = -1
        };

    }


}
