﻿using System;
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
<<<<<<< HEAD
        Thread acceptor;
=======
>>>>>>> 45f4afc930f63c9401f09b19c303e01fa860ab73
        Queue<string> messagesQueue;
        public static Client client;
        TcpListener server;
        Dictionary<string, TcpClient> usersDictionary = new Dictionary<string, TcpClient>();
        public string username = "Bill";
        public Server()
        {
            messagesQueue = new Queue<string>();
<<<<<<< HEAD
            server = new TcpListener(IPAddress.Any, 9999);
=======
            server = new TcpListener(IPAddress.Parse("127.0.0.1"), 9999);
>>>>>>> 45f4afc930f63c9401f09b19c303e01fa860ab73
            server.Start();
        }
        public void Run()
        {
<<<<<<< HEAD
            acceptor = new Thread(new ThreadStart(AcceptClient));
=======
            Thread acceptor = new Thread(new ThreadStart(AcceptClient));
>>>>>>> 45f4afc930f63c9401f09b19c303e01fa860ab73
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
                //string message = de
                //BinaryReader reader = new BinaryReader(clientSocket.GetStream());
                //string message = read.ReadString();
                    foreach (KeyValuePair<string, TcpClient> item in usersDictionary)
                    {
                        //send to each client in dictionary;
                    }
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