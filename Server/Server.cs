using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;

namespace Server
{
    class Server
    {
        Thread acceptor;
        public Queue<string> messagesQueue;
        public Client client;
        TcpListener server;
        Dictionary<int, Client> usersDictionary = new Dictionary<int, Client>();
        public int user = 0;

        public Server()
        {
            messagesQueue = new Queue<string>();
            server = new TcpListener(IPAddress.Parse("127.0.0.1"), 9999);
            server.Start();
        }
        public void Run()
        {
            acceptor = new Thread(new ThreadStart(AcceptClient));
            acceptor.Start();
        }
        public void Broadcast()
        {
            while (true)
            {
                if (messagesQueue.Count == 0)
                {
                    continue;
                }
                else
                {
                    string message = messagesQueue.Dequeue();
                    foreach (KeyValuePair<int, Client> item in usersDictionary)
                    {
                        item.Value.Send(message);
                    }
                }
            }
        }
        private void AcceptClient()
        {
            while (true)
            {
                user++;
                TcpClient clientSocket = default(TcpClient);
                clientSocket = server.AcceptTcpClient();
                Console.WriteLine("Connected");
                NetworkStream stream = clientSocket.GetStream();
                client = new Client(stream, clientSocket);
                usersDictionary.Add(user, client);
                Thread reciever = new Thread(new ThreadStart(client.Recieve));
                reciever.Start();                
            }
            //clientSocket.Close();
            //serverSocket.Stop();
            //Console.Writeline(" >> " + "exit");
            //Console.ReadLine();
        }
        private void Respond(string body)
        {
            client.Send(body);
        }

    }
}