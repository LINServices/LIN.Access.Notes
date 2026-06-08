namespace LIN.Access.Notes.Controllers;

public static class Tasks
{

    public static async Task<CreateResponse> Create(TaskDataModel model, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("tasks");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Post<CreateResponse>(model);

        // Retornar.
        return Content;

    }

    public static async Task<ResponseBase> Update(TaskDataModel model, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("tasks");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Patch<ResponseBase>(model);

        // Retornar.
        return Content;

    }


    public static async Task<ResponseBase> Delete(int id, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("tasks");

        // Headers.
        client.AddParameter("id", id);
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Delete<ResponseBase>();

        // Retornar.
        return Content;

    }


}