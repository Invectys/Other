using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LifehackStudio.Common
{
    public class Configuration<T>
    {

        private static string _filePath = "appsettings.json";
        private static T _instance;

        public static T Get()
        {
            if(_instance == null)
            {
                bool exist = File.Exists(_filePath);
                if(exist)
                {
                    string jsonStr = File.ReadAllText(_filePath);
                    _instance = JsonConvert.DeserializeObject<T>(jsonStr);
                }
                else
                {
                    _instance = (T)Activator.CreateInstance(typeof(T));
                    using (var stream = File.Create(_filePath))
                    {
                        string json = JsonConvert.SerializeObject(_instance);
                        var bytes = Encoding.UTF8.GetBytes(json);
                        stream.Write(bytes, 0, bytes.Length);
                    }
                }
            }
            return _instance;
        }




    }
}
