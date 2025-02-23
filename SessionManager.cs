using LIN.Access.Notes.Sessions;

namespace LIN.Access.Notes;

public class SessionManager
{

    /// <summary>
    /// Session default;
    /// </summary>
    public Session? Default { get; set; }


    /// <summary>
    /// Lista de sesiones.
    /// </summary>
    public List<Session> Sessions { get; set; } = [];


    /// <summary>
    /// Iniciar sesion.
    /// </summary>
    /// <param name="user">Usuario.</param>
    /// <param name="password">Contraseña.</param>
    /// <param name="safe">Es seguro.</param>
    public async Task<(Session session, Responses responses)> StarSession(string user, string password, bool safe)
    {

        // Nueva sesion.
        var session = new Sessions.Session();

        // Iniciar.
        var response = await session.LoginWith(user, password, safe);

        // Agregar sesion.
        Sessions.Add(session);

        // Default.
        SetDefault(session);

        return (session, response);
    }


    /// <summary>
    /// Iniciar sesion.
    /// </summary>
    /// <param name="token">Token.</param>
    public async Task<(Session session, Responses responses)> StarSession(string token)
    {

        // Nueva sesion.
        var session = new Sessions.Session();

        // Iniciar.
        var response = await session.LoginWith(token);

        // Agregar sesion.
        Sessions.Add(session);

        // Default.
        SetDefault(session);

        return (session, response);
    }


    /// <summary>
    /// Generar sesión local.
    /// </summary>
    /// <param name="account">Cuenta.</param>
    /// <param name="type">Tipo.</param>
    public void GenerateLocal(AccountModel account, SessionType type)
    {

        // Nueva sesion.
        var session = new Session
        {
            Type = type,
            Account = account
        };

        Sessions.Add(session);
    }


    /// <summary>
    /// Establecer sesión por defecto.
    /// </summary>
    /// <param name="force">Forzar.</param>
    public void SetDefault(Session session, bool force = false)
    {

        if (!force && session is null)
            return;

        Default = session;

    }


    //==================== Singleton ====================//

    private readonly static SessionManager _instance = new();

    private SessionManager() { }

    public static SessionManager Instance => _instance;

}