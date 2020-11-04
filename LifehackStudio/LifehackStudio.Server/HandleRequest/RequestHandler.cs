using LifehackStudio.Common.Models.Net;
using LifehackStudio.Server.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace LifehackStudio.Server.HandleRequest
{
    public abstract class RequestHandler
    {
        public abstract string RequestText { get;}

        public bool Suitable(Request request)
        {
            return request.Message.StartsWith(RequestText);
        }

        public abstract Response Handle(Request request,string from);


    }
}
