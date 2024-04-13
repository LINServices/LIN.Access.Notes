namespace LIN.Access.Notes.Controllers;


public static class Notes
{


    /// <summary>
    /// Crear nota.
    /// </summary>
    /// <param name="modelo">Modelo.</param>
    /// <param name="token">Token de acceso.</param>
    public async static Task<CreateResponse> Create(NoteDataModel modelo, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("notes/create");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Post<CreateResponse>(modelo);

        // Retornar.
        return Content;

    }



    /// <summary>
    /// Obtener las notas asociadas a un perfil.
    /// </summary>
    /// <param name="token">Token de acceso.</param>
    public async static Task<ReadAllResponse<NoteDataModel>> ReadAll(string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("notes/read/all");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Get<ReadAllResponse<NoteDataModel>>();

        // Retornar.
        return Content;

    }



    /// <summary>
    /// Obtener una nota.
    /// </summary>
    /// <param name="id">Id de la nota.</param>
    /// <param name="token">Token de acceso.</param>
    public async static Task<ReadOneResponse<NoteDataModel>> Read(int id, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("notes/read");

        // Headers.
        client.AddHeader("token", token);
        client.AddParameter("id", id);

        // Resultado.
        var Content = await client.Get<ReadOneResponse<NoteDataModel>>();

        // Retornar.
        return Content;


    }



    /// <summary>
    /// Actualizar una nota.
    /// </summary>
    /// <param name="id">Id de la nota.</param>
    /// <param name="name">Nuevo titulo.</param>
    /// <param name="description">Nuevo contenido.</param>
    /// <param name="color">Nuevo color.</param>
    /// <param name="token">Token de acceso.</param>
    public async static Task<ResponseBase> Update(NoteDataModel note, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("notes");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Patch<ResponseBase>(note);

        // Retornar.
        return Content;


    }



    /// <summary>
    /// Actualizar una nota.
    /// </summary>
    /// <param name="id">Id de la nota.</param>
    /// <param name="color">Nuevo color.</param>
    /// <param name="token">Token de acceso.</param>
    public async static Task<ResponseBase> Update(int id, int color, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("notes/update/color");

        // Headers.
        client.AddHeader("token", token);
        client.AddParameter("id", id);
        client.AddParameter("color", color);

        // Resultado.
        var Content = await client.Patch<ResponseBase>();

        // Retornar.
        return Content;


    }



    /// <summary>
    /// Eliminar una nota.
    /// </summary>
    /// <param name="id">Id de la nota.</param>
    /// <param name="token">Token de acceso.</param>
    public async static Task<ResponseBase> Delete(int id, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("notes");

        // Headers.
        client.AddHeader("token", token);
        client.AddParameter("id", id);

        // Resultado.
        var Content = await client.Delete<ResponseBase>();

        // Retornar.
        return Content;


    }


}