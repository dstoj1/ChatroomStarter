using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Client
    {
        Server server;
        NetworkStream stream;
        TcpClient client;
        public string UserId;
        public string recievedMessageString;

        public Client(NetworkStream Stream, TcpClient Client, Server server, int user)
        {
            this.server = server;
            stream = Stream;
            client = Client;
            UserId = user.ToString();
        }
        public void Send(string Message)
        {
                byte[] message = Encoding.ASCII.GetBytes(Message);
                stream.Write(message, 0, message.Count());
        }
        public void Recieve()
        {
            while (true)
            {
                byte[] recievedMessage = new byte[256];
                stream.Read(recievedMessage, 0, recievedMessage.Length);
                recievedMessageString = Encoding.ASCII.GetString(recievedMessage);
                Console.WriteLine(recievedMessageString);
                server.messagesQueue.Enqueue(recievedMessageString);
            }
        }
    }
}