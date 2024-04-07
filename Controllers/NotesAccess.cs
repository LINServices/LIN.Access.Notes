﻿using LIN.Access.Notes;
using LIN.Types.Notes.Enumerations;
using LIN.Types.Notes.Models;
using LIN.Types.Notes.Transient;

namespace LIN.Access.Notes.Controllers;


public static class NotesAccess
{


    /// <summary>
    /// Crear acceso a un inventario.
    /// </summary>
    /// <param name="modelo">Modelo de acceso.</param>
    /// <param name="token">Token de acceso.</param>
    public async static Task<CreateResponse> Create(NoteAccessDataModel modelo, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("notes/access");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Post<CreateResponse>(modelo);

        // Retornar.
        return Content;

    }



    /// <summary>
    /// Actualizar estado.
    /// </summary>
    /// <param name="token">Token de acceso.</param>
    /// <param name="id">Id de la invitación.</param>
    /// <param name="estado">Nuevo estado.</param>
    public async static Task<ResponseBase> UpdateState(string token, int id, NoteAccessState estado)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("notes/access/update/state");

        // Headers.
        client.AddHeader("id", id);
        client.AddHeader("estado", (int)estado);
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Put<ResponseBase>();

        // Retornar.
        return Content;

    }



    /// <summary>
    /// Obtener las invitaciones.
    /// </summary>
    /// <param name="token">Token de acceso.</param>
    public async static Task<ReadAllResponse<Notificacion>> ReadNotifications(string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("inventory/access/read/all");

        // Headers.
        client.AddHeader("token", token);

        // Resultado.
        var Content = await client.Get<ReadAllResponse<Notificacion>>();

        // Retornar.
        return Content;

    }



    /// <summary>
    /// Obtener una invitación.
    /// </summary>
    /// <param name="id">Id de la invitación.</param>
    /// <param name="token">Token de acceso.</param>
    public async static Task<ReadOneResponse<Notificacion>> ReadNotification(int id, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("inventory/access/read");

        // Headers.
        client.AddHeader("token", token);
        client.AddHeader("id", id);

        // Resultado.
        var Content = await client.Get<ReadOneResponse<Notificacion>>();

        // Retornar.
        return Content;

    }




    /// <summary>
    /// Obtener los integrantes de un inventario.
    /// </summary>
    /// <param name="inv">Id del inventario.</param>
    /// <param name="tokenLocal">Token de acceso [Inventario]</param>
    /// <param name="token">Token de acceso [LIN Identity]</param>
    public async static Task<ReadAllResponse<IntegrantDataModel>> GetMembers(int inv, string tokenLocal, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("notes/access/members");

        // Headers.
        client.AddHeader("token", tokenLocal);
        client.AddHeader("tokenAuth", token);
        client.AddHeader("inventario", inv);

        // Resultado.
        var Content = await client.Get<ReadAllResponse<IntegrantDataModel>>();

        // Retornar.
        return Content;

    }



    /// <summary>
    /// Eliminar a alguien de un inventario.
    /// </summary>
    /// <param name="inv">Id del inventario.</param>
    /// <param name="user">Id del usuario a eliminar</param>
    /// <param name="token">Token de acceso.</param>
    public async static Task<ResponseBase> DeleteSomeOne(int inv, int user, string token)
    {

        // Cliente HTTP.
        Client client = Service.GetClient("notes/access/delete/one");

        // Headers.
        client.AddHeader("token", token);
        client.AddHeader("inventario", inv);
        client.AddHeader("usuario", user);

        // Resultado.
        var Content = await client.Delete<ResponseBase>();

        // Retornar.
        return Content;

    }



}