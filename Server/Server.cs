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
            //string message =
            client.Recieve();
            //Respond(message);
        }
        public void Broadcast()
        {
            foreach (KeyValuePair<string, TcpClient> item in usersDictionary)
            {
                Console.WriteLine();
            }
        }
        //public void Broadcast()
        //{
        //    while (true)
        //    {
        //BinaryReader reader = new BinaryReader(clientSocket.GetStream());
        //string message = read.ReadString();
        //foreach (KeyValuePair<string, TcpClient> item in usersDictionary)
        //        {
        //            Console.WriteLine(message);
        //        }
        //    }

        //}
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