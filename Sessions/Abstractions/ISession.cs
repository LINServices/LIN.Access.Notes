namespace LIN.Access.Notes.Sessions.Abstractions;

public interface ISession
{

    /// <summary>
    /// Información del usuario
    /// </summary>
    public ProfileModel Profile { get; }

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
    public AccountModel Account { get; set; }

    /// <summary>
    /// Token de la cuenta.
    /// </summary>
    public string AccountToken { get; set; }

    /// <summary>
    /// Si la sesión es activa
    /// </summary>
    public bool IsAccountOpen { get; }

    /// <summary>
    /// Si la sesión es activa
    /// </summary>
    public bool IsLocalOpen { get; }

}