namespace LIN.Access.Notes;

public class SessionManager
{

    /// <summary>
    /// Lista de sesiones.
    /// </summary>
    public List<Sessions.Session> Sessions { get; set; } = [];


    /// <summary>
    /// Iniciar sesion.
    /// </summary>
    /// <param name="user">Usuario.</param>
    /// <param name="password">Contraseña.</param>
    /// <param name="safe">Es seguro.</param>
    public async Task StarSession(string user, string password, bool safe)
    {

        // Nueva sesion.
        var session = new Sessions.Session();

        // Iniciar.
        await session.LoginWith(user, password, safe);

        // Agregar sesion.
        Sessions.Add(session);
    }


    /// <summary>
    /// Iniciar sesion.
    /// </summary>
    /// <param name="token">Token.</param>
    public async Task StarSession(string token)
    {

        // Nueva sesion.
        var session = new Sessions.Session();

        // Iniciar.
        await session.LoginWith(token);

        // Agregar sesion.
        Sessions.Add(session);
    }


    //==================== Singleton ====================//

    private readonly static SessionManager _instance = new();

    private SessionManager() { }

    public static SessionManager Instance => _instance;

}