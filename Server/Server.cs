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
        Dictionary<string, TcpClient> usersDictionary = new Dictionary<string, TcpClient>();
        public string username = "Bill";

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
            foreach (KeyValuePair<string, TcpClient> item in usersDictionary)
            {
                Console.WriteLine();
            }
        }

        private void AcceptClient()
        {
            while (true)
            {
                TcpClient clientSocket = default(TcpClient);
                clientSocket = server.AcceptTcpClient();
                Console.WriteLine("Connected");
                NetworkStream stream = clientSocket.GetStream();
                client = new Client(stream, clientSocket);
                usersDictionary.Add(username, clientSocket);
            }
        }
        private void Respond(string body)
        {
                client.Send(body);
        }

    }
}
