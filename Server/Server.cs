using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class Server
    {
        public static Client client;
        TcpListener server;
        Dictionary<string, int> listOfClients = new Dictionary<string, int>();
        //listOfClients.Add(Sara, 1);
        int clientCounter = 0;
        private string username = "Bill";
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
        public void broadCast()
        {
            foreach (KeyValuePair<string, int> item in listOfClients)
            {

            }
        }
        private void AcceptClient()
        {
            clientCounter++;
           //Console.WriteLine("Please enter your name.");
           // username = Console.ReadLine();
            TcpClient clientSocket = default(TcpClient);
            clientSocket = server.AcceptTcpClient();
            Console.WriteLine("Connected");
            NetworkStream stream = clientSocket.GetStream();
            client = new Client(stream, clientSocket);
            listOfClients.Add(username, clientCounter);
            broadCast();
        }
        private void Respond(string body)
        {
                client.Send(body);
        }
    }
}
