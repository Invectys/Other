using LifehackStudio.Common;
using LifehackStudio.Common.Models;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace LifehackStudio.Server.Models
{
    public class Settings : CommonSettings
    {

        public static Settings Get()
        {
            return Configuration<Settings>.Get();
        }

    }
}
