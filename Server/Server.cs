using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace Server
{
    class Server
    {
        public static Client client;
        TcpListener server;
        Dictionary<string, int> clientList = new Dictionary<string, int>();
        string username = "Bill";
        int clientCounter = 0;

        public Server()
        {
            server = new TcpListener(IPAddress.Any, 9999);
            server.Start();
        }
        public void Run()
        {
            AcceptClient();
            client.Recieve();
           // Respond(message);
        }

        public void Broadcast()
        {
            foreach (KeyValuePair<string, int> item in clientList)
            {
                Console.WriteLine();
            }
        }

        private void AcceptClient()
        {
            clientCounter++;
            TcpClient clientSocket = default(TcpClient);
            clientSocket = server.AcceptTcpClient();
            Console.WriteLine("Connected");
            NetworkStream stream = clientSocket.GetStream();
            client = new Client(stream, clientSocket);
            clientList.Add(username, clientCounter);
            Broadcast();
        }
        private void Respond(string body)
        {
                client.Send(body);
        }

    }
}
