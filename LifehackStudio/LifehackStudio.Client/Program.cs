using LifehackStudio.Common.Models;
using LifehackStudio.Common.Models.Net;
using System;
using System.Text;

namespace LifehackStudio.Client
{
    class Program
    {
        static void Main(string[] args)
        {

            Client client;
            try
            {
                client = new Client();
                client.Run();
            }catch(Exception e)
            {
                Console.WriteLine("I cant connect to the server");
                return;
            }

            Console.WriteLine(CommandsMessages.Close + " - stop current application");

            Console.WriteLine("Your name:");
            string name = Console.ReadLine();

            client.Send(new Request() { Message = $"{RequestMessages.IAm} {name}"});
            client.Send(new Request() { Message = RequestMessages.GetAllCommands });

            bool exit = false;
            while(!exit)
            {
                string input = Console.ReadLine();
                if(input == CommandsMessages.Close)
                {
                    exit = true;
                    continue;
                }

                client.Send(new Request() { Message = input});
            }
        }
    }
}
