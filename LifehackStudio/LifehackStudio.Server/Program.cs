using LifehackStudio.Common.Models;
using LifehackStudio.Server.HandleRequest;
using LifehackStudio.Server.Models;
using System;

namespace LifehackStudio.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Host host = new Host(new HostOptions());
                host.Run();
            }catch(Exception e)
            {
                Console.WriteLine("Error on starting server\n " + e.Message);
            }


            Console.WriteLine(CommandsMessages.Close + " - stop current application");


            bool exit = false;
            while(!exit)
            {
                string input = Console.ReadLine();
                if(input == CommandsMessages.Close)
                {
                    exit = true;
                    continue;
                }
            }


        }
    }
}
