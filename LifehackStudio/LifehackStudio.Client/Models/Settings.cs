using LifehackStudio.Common;
using LifehackStudio.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LifehackStudio.Client.Models
{
    public class Settings : CommonSettings
    {

        public static Settings Get()
        {
            return Configuration<Settings>.Get();
        }

    }
}
