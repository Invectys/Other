using LifehackStudio.Common.Models;
using LifehackStudio.Common.Models.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifehackStudio.Server.HandleRequest
{
    public class RequestWhoAreYou : RequestHandler
    {
        ClientsStorage _clientsStorage;
        public RequestWhoAreYou(ClientsStorage clientsStorage)
        {
            _clientsStorage = clientsStorage;
        }

        public override string RequestText => RequestMessages.IAm;

        public override Response Handle(Request request,string from)
        {
            var storage = _clientsStorage.Storage;
            string name = "no name";
            if(request.Message.Length > RequestMessages.IAm.Length + 1)
                name = request.Message.Substring(RequestMessages.IAm.Length + 1);
            storage[from].Name  = name;
            return new Response() { Message = $"Now I know your name  Hello {name}!" };
        }
    }
}
