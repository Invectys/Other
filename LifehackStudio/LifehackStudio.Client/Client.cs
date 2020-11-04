using LifehackStudio.Client.Models;
using LifehackStudio.Common.Models.Net;
using System;
using System.Collections.Generic;
using System.Text;
using WatsonTcp;

namespace LifehackStudio.Client
{
    public class Client
    {

        private WatsonTcpClient _client;

        public Client()
        {
            Create();
        }


        public void Run()
        {
            
            _client.Start();
            
        }

        public void Send(Request request)
        {
            _client.Send(request.GetBytes());
        }

        private void Create()
        {
            var settings = Settings.Get();
            _client = new WatsonTcpClient(settings.ServerAddress, settings.ServerPort);
            _client.Events.ServerConnected += ServerConnected;
            _client.Events.ServerDisconnected += ServerDisconnected;
            _client.Events.MessageReceived += MessageReceived;
            _client.Callbacks.SyncRequestReceived = SyncRequestReceived;
        }

        private void MessageReceived(object sender, MessageReceivedFromServerEventArgs e)
        {
            var response = Response.GetFromBytes(e.Data);
            Console.WriteLine("Message from server: " + response.Message);
        }

        private void ServerConnected(object sender, EventArgs e)
        {
            Console.WriteLine("Server connected");
        }

        private void ServerDisconnected(object sender, EventArgs e)
        {
            Console.WriteLine("Server disconnected");
        }

        private SyncResponse SyncRequestReceived(SyncRequest req)
        {
            return new SyncResponse(req,"Hello back at you!");
        }
    }
}
