﻿using LIN.Access.Notes;
using LIN.Types.Notes.Models;

namespace LIN.Access.Notes.Controllers;


public static class Notes
{


    /// <summary>
    /// Crear inventario.
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
    /// Obtener los inventarios asociados a una cuenta.
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
    /// Obtener un inventario.
    /// </summary>
    /// <param name="id">Id del inventario.</param>
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
    /// Obtener un inventario.
    /// </summary>
    /// <param name="id">Id del inventario.</param>
    /// <param name="token">Token de acceso.</param>
    public async static Task<ResponseBase> Update(int id, string name, string description, int color, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("notes");

        // Headers.
        client.AddHeader("token", token);
        client.AddParameter("id", id);
        client.AddParameter("name", name);
        client.AddParameter("description", description);
        client.AddParameter("color", color);

        // Resultado.
        var Content = await client.Patch<ResponseBase>();

        // Retornar.
        return Content;


    }


}