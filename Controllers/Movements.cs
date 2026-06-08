namespace LIN.Access.Notes.Controllers;

public static class Movements
{

    public static async Task<ReadAllResponse<MovementDataModel>> ReadAll(string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("movements/read/all");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Get<ReadAllResponse<MovementDataModel>>();

        // Retornar.
        return Content;

    }
    public static async Task<CreateResponse> Create(MovementDataModel model, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("movements");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Post<CreateResponse>(model);

        // Retornar.
        return Content;

    }
    public static async Task<ResponseBase> Delete(int id, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("movements");

        // Headers.
        client.AddParameter("id", id);
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Delete<ResponseBase>();

        // Retornar.
        return Content;

    }


}