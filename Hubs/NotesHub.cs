namespace LIN.Access.Notes.Hubs;

public sealed class NotesHub
{

    /// <summary>
    /// Recibe un comando.
    /// </summary>
    public event EventHandler<CommandModel>? OnReceiveCommand;


    /// <summary>
    /// Conexión del Hub
    /// </summary>
    private HubConnection? HubConnection { get; set; }


    /// <summary>
    /// Obtiene el Id de usuario asignado este dispositivo
    /// </summary>
    public string Id => HubConnection?.ConnectionId ?? string.Empty;


    /// <summary>
    /// Llave de la aplicación.
    /// </summary>
    private string Token { get; set; } = string.Empty;


    /// <summary>
    /// Constructor de un HUB
    /// </summary>
    public NotesHub(string token)
    {
        Token = token;
    }


    /// <summary>
    /// Reconecta la conexión.
    /// </summary>
    public async void Reconnect()
    {
        await Suscribe();
    }



    /// <summary>
    /// Cierra la conexión.
    /// </summary>
    public async void Disconnect()
    {
        try
        {
            if (HubConnection != null)
                await HubConnection.StopAsync();

        }
        catch
        {
        }

    }



    /// <summary>
    /// Conecta el Hub
    /// </summary>
    public async Task Suscribe()
    {
        try
        {

            // Crea la conexión al HUB
            HubConnection = new HubConnectionBuilder()
                .WithUrl(Service._Service.PathURL("realTime/notes"))
                .WithAutomaticReconnect()
                .Build();


            // Recibe un intento Admin
            HubConnection.On<CommandModel>("#command", (cm) =>
            {
                OnReceiveCommand?.Invoke(null, cm);
            });


            // Inicia la conexión
            await HubConnection.StartAsync();
            await HubConnection.InvokeAsync("Join", Token);

        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Error HUB Account: " + ex);
        }

    }






}