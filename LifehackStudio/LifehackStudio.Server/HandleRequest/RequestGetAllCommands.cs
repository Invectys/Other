using LifehackStudio.Common.Models.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifehackStudio.Server.HandleRequest
{
    public class RequestGetAllCommands : RequestHandler
    {
        public override string RequestText => RequestMessages.GetAllCommands;

        public override Response Handle(Request request, string from)
        {
            var response = new Response();
            response.Message += "\n" + RequestMessages.GetAllClients + " - get all clients";
            response.Message += "\n" + RequestMessages.HowAreYou + " - how are you?";

            return response;
        }

        
    }
}
