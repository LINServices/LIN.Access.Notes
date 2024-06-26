namespace LIN.Access.Notes.Observers;


public class SessionObserver
{


    /// <summary>
    /// Evento al actualizar.
    /// </summary>
    public static event EventHandler<Session>? OnUpdate;



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
    public static void Invoke(Session e)
    {
        OnUpdate?.Invoke(null, e);
    }


}