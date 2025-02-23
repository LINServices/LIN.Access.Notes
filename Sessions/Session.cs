using LIN.Access.Notes.Controllers;
using LIN.Access.Notes.Sessions.Abstractions;

namespace LIN.Access.Notes.Sessions;

public class Session : ISession
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
    public string Token { get; set; } = string.Empty;


    /// <summary>
    /// Información del usuario
    /// </summary>
    public AccountModel Account { get; set; } = new();


    /// <summary>
    /// Token de la cuenta.
    /// </summary>
    public string AccountToken { get; set; } = string.Empty;


    /// <summary>
    /// Si la sesión es activa
    /// </summary>
    public bool IsAccountOpen { get => Account.Id != 0; }


    /// <summary>
    /// Si la sesión es activa
    /// </summary>
    public bool IsLocalOpen { get => Profile.Id != 0; }


    /// <summary>
    /// Recarga o inicia una sesión
    /// </summary>
    internal async Task<Responses> LoginWith(string user, string password, bool safe)
    {

        // Cierra la sesión Actual
        if (!safe)
            CloseSession();

        // Validación de user
        var response = await Authentication.Login(user, password);

        if (response.Response != Responses.Success)
            return response.Response;

        // Datos de la instancia
        Profile = response.Model.Profile;
        Account = response.Model.Account;

        Token = response.Token;
        AccountToken = response.Model.TokenCollection["identity"];
        Type = SessionType.Connected;
        return Responses.Success;

    }


    /// <summary>
    /// Recarga o inicia una sesión
    /// </summary>
    internal async Task<Responses> LoginWith(string token)
    {

        // Cierra la sesión Actual
        CloseSession();

        // Validación de user
        var response = await Authentication.Login(token);


        if (response.Response != Responses.Success)
            return response.Response;

        // Datos de la instancia
        Profile = response.Model.Profile;
        Account = response.Model.Account;

        Token = response.Token;
        AccountToken = response.Model.TokenCollection["identity"];
        Type = SessionType.Connected;

        return Responses.Success;

    }


    /// <summary>
    /// Cierra la sesión
    /// </summary>
    public void CloseSession()
    {
        Profile = new();
        Account = new();
    }

}

public enum SessionType
{
    Local,
    Connected,
    Sync
}