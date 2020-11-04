using LifehackStudio.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifehackStudio.Server
{
    public class ClientsStorage
    {

        public Dictionary<string, ClientInfo> Storage { get { return _storage; } }

        private Dictionary<string, ClientInfo> _storage = new Dictionary<string, ClientInfo>();

    }
}
