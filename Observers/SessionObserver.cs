namespace LIN.Access.Notes.Observers;

public class SessionObserver
{

    /// <summary>
    /// Evento al actualizar.
    /// </summary>
    public static event EventHandler<Sessions.Session>? OnUpdate;


    /// <summary>
    /// Limpiar el observador.
    /// </summary>
    public static void Dispose()
    {
        OnUpdate = null;
    }


    /// <summary>
    /// Invocar.
    /// </summary>
    public static void Invoke(Sessions.Session e)
    {
        OnUpdate?.Invoke(null, e);
    }


}