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
        Queue<string> messagesQueue;
        public static Client client;
        TcpListener server;
        Dictionary<int, TcpClient> usersDictionary = new Dictionary<int, TcpClient>();
        public int user = 0;

        public Server()
        {
            messagesQueue = new Queue<string>();
            server = new TcpListener(IPAddress.Any, 9999);
            server.Start();
        }
        public void Run()
        {
            acceptor = new Thread(new ThreadStart(AcceptClient));
            acceptor.Start();
            //accept client thread-- server always open. sender and broadcaster.
            //string message =
            //Respond(message);
        }
        public void Broadcast()
        {
            while (true)
            {
                //if queue has something in it, deque that something.
                //string message = deque
                //string message = read.ReadString();
                foreach (KeyValuePair<int, TcpClient> item in usersDictionary)
                {
                    //send to each client in dictionary;
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
                usersDictionary.Add(user, clientSocket);
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