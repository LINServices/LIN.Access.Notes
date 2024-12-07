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
        return service;
    }

}