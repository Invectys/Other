using LifehackStudio.Common.Models.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LifehackStudio.Server.HandleRequest
{
    public class RequestsHandlerScope
    {

        private List<RequestHandler> _handlers;

        public RequestsHandlerScope(RequestHandler[] handlers)
        {
            _handlers = handlers.ToList();
        }

        public Response Handle(Request request,string from)
        {
            foreach (var handler in _handlers)
            {
                if(handler.Suitable(request))
                {
                    return handler.Handle(request, from);
                }
            }
            return new Response() { Message = "I cant handle this request!" };
        }
    }
}
