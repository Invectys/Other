using LifehackStudio.Common.Models.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifehackStudio.Server.HandleRequest
{
    public class RequestHowAreYou : RequestHandler
    {
        public override string RequestText => RequestMessages.HowAreYou;

        public override Response Handle(Request request,string from)
        {
            return new Response() { Message = "I am fine" };
        }
    }
}
