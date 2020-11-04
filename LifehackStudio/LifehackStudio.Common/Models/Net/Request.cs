using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifehackStudio.Common.Models.Net
{
    public class Request
    {
        public string Message { get; set; }

        public byte[] GetBytes()
        {
            string jsonStr = JsonConvert.SerializeObject(this);
            return Encoding.UTF8.GetBytes(jsonStr);
        }

        public static Request GetFromBytes(byte[] data)
        {
            string msg = Encoding.UTF8.GetString(data);
            Request req = JsonConvert.DeserializeObject<Request>(msg);
            return req;
        }
    }
}
