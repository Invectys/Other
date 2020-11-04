using LifehackStudio.Common;
using LifehackStudio.Common.Models;
using LifehackStudio.Common.Models.Net;
using LifehackStudio.Server.HandleRequest;
using LifehackStudio.Server.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WatsonTcp;

namespace LifehackStudio.Server
{
    public class Host
    {

        private RequestsHandlerScope _requestHandler;
        private HostOptions _options;
        private WatsonTcpServer _tcpServer;
        private ClientsStorage _clientsStorage = new ClientsStorage();
        

        public Host(HostOptions options)
        {
            _options = options;

            Create();
        }

        public void Run()
        {
            _tcpServer.Start();
        }

        private void Create()
        {
            var settings = Settings.Get();
            _tcpServer = new WatsonTcpServer(settings.ServerAddress,settings.ServerPort);
            _tcpServer.Events.ClientConnected += ClientConnected;
            _tcpServer.Events.ClientDisconnected += ClientDisconnected;
            _tcpServer.Events.MessageReceived += MessageReceived;
            _tcpServer.Callbacks.SyncRequestReceived += SyncRequestReceived;

            var requestsHandlerScope = new RequestsHandlerScope(new HandleRequest.RequestHandler[]
            {
                new RequestGetAllClients(_clientsStorage),
                new RequestHowAreYou(),
                new RequestWhoAreYou(_clientsStorage),
                new RequestGetAllCommands()
            });

            _requestHandler = requestsHandlerScope;

            Console.WriteLine($"Server started on {settings.ServerAddress}:{settings.ServerPort}");
        }


        private void ClientConnected(object sender, ClientConnectedEventArgs e)
        {
            Console.WriteLine("Client connected: " + e.IpPort);
            _clientsStorage.Storage.Add(e.IpPort, new ClientInfo());
        }

        private void ClientDisconnected(object sender,ClientDisconnectedEventArgs e)
        {
            Console.WriteLine("Client disconnected: " + e.IpPort + ": " + e.Reason.ToString());
            _clientsStorage.Storage.Remove(e.IpPort);
        }

        private void MessageReceived(object sender, MessageReceivedFromClientEventArgs e)
        {
            var request = Request.GetFromBytes(e.Data);
            var response = _requestHandler.Handle(request,e.IpPort);

            _tcpServer.Send(e.IpPort, response.GetBytes());
        }

        private SyncResponse SyncRequestReceived(SyncRequest request)
        {
            return new SyncResponse(request,"Hello back at you!");
        }

    }
}
