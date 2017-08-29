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
    public class Server
    {
        Thread broadcaster;
        Thread acceptor;
        public Queue<string> messagesQueue;
        public Client client;
        TcpListener server;
        Dictionary<int, Client> usersDictionary = new Dictionary<int, Client>();
        private int user = 0;
        ILogger log;

        public Server(ILogger log)
        {
            this.log = log;
            messagesQueue = new Queue<string>();
            server = new TcpListener(IPAddress.Parse("127.0.0.1"), 9999);
            server.Start();
        }
        public void Run()
        {
            acceptor = new Thread(new ThreadStart(AcceptClient));
            acceptor.Start();
            broadcaster = new Thread(new ThreadStart(Broadcast));
            broadcaster.Start();
        }
        private void Broadcast()
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
        private void UpdateUserJoined(Client client)
        {
            string message = $"User {client.UserId} has joined the chatroom!";
            messagesQueue.Enqueue(message);
            log.Write(message);
        }
        private void UpdateUserLeft(Client client)
        {
            string message = $"User {client.UserId} has left the chatroom.";
            messagesQueue.Enqueue(message);
            log.Write(message);
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
                client = new Client(stream, clientSocket, this, user);
                usersDictionary.Add(user, client);
                UpdateUserJoined(client);
                Thread reciever = new Thread(new ThreadStart(client.Recieve));
                reciever.Start();                
            }
        }
        private void Respond(string body)
        {
            client.Send(body);
        }
    }
}