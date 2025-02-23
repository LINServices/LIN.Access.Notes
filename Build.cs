using LIN.Access.Notes.Sessions.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace LIN.Access.Notes;

public static class Build
{

    /// <summary>
    /// Utilizar LIN Notes.
    /// </summary>
    /// <param name="url">Ruta.</param>
    public static IServiceCollection AddNotesService(this IServiceCollection service, string? url = null)
    {
        Service._Service = new();
        Service._Service.SetDefault(url ?? "https://api.notes.linplatform.com/");

        // Sesión por defecto.
        service.AddSingleton<ISession>(type => SessionManager.Instance.Default!);
        service.AddSingleton<SessionManager>(type => SessionManager.Instance);

        return service;
    }

}