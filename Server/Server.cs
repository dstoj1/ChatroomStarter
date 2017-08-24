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
<<<<<<< HEAD
        Dictionary<string, int> listOfClients = new Dictionary<string, int>();
        //listOfClients.Add(Sara, 1);
        int clientCounter = 0;
        private string username = "Bill";
        Dictionary<string, int> clientList = new Dictionary<string, int>();
 
=======
        Dictionary<string, TcpClient> usersDictionary = new Dictionary<string, TcpClient>();
        public string username = "Bill";

>>>>>>> 08139aed02327ab87929e38f345b63acf1aea28b
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

        public void Broadcast()
        {
            foreach (KeyValuePair<string, TcpClient> item in usersDictionary)
            {
                Console.WriteLine();
            }
        }

        private void AcceptClient()
        {
<<<<<<< HEAD
            clientCounter++;
>>>>>>> 8284ad8fcfa1774267922ae807112ca14497aeb9
            TcpClient clientSocket = default(TcpClient);
            clientSocket = server.AcceptTcpClient();
            Console.WriteLine("Connected");
            NetworkStream stream = clientSocket.GetStream();
            client = new Client(stream, clientSocket);
<<<<<<< HEAD
            listOfClients.Add(username, clientCounter);
            broadCast();
=======
            clientList.Add(username, clientCounter);
            Broadcast();
>>>>>>> 8284ad8fcfa1774267922ae807112ca14497aeb9
=======
            while (true)
            {
                TcpClient clientSocket = default(TcpClient);
                clientSocket = server.AcceptTcpClient();
                Console.WriteLine("Connected");
                NetworkStream stream = clientSocket.GetStream();
                client = new Client(stream, clientSocket);
                usersDictionary.Add(username, clientSocket);
            }
>>>>>>> 08139aed02327ab87929e38f345b63acf1aea28b
        }
        private void Respond(string body)
        {
                client.Send(body);
        }

    }
}
