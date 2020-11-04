using LifehackStudio.Common.Models.Net;
using System;
using System.Collections.Generic;
using System.Text;
using WatsonTcp;

namespace LifehackStudio.Server.HandleRequest
{
    public class RequestGetAllClients : RequestHandler
    {
        private ClientsStorage _clientsStorage;

        public RequestGetAllClients(ClientsStorage clientsStorage)
        {
            _clientsStorage = clientsStorage;
        }

        public override string RequestText => RequestMessages.GetAllClients;

        public override Response Handle(Request request,string from)
        {
            var response = new Response();
            var clients = _clientsStorage.Storage;
            foreach (var client in clients)
            {
                response.Message += $"\n Address = {client.Key} Name = {client.Value.Name}";
            }
            return response;
        }
    }
}
