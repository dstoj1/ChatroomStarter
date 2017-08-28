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
        NetworkStream stream;
        TcpClient client;
        //Queue<string> messagesQueue;
        public string UserId;
        public string recievedMessageString;

        public Client(NetworkStream Stream, TcpClient Client)
        {
            //messagesQueue = new Queue<string>();
            stream = Stream;
            client = Client;
            UserId = "495933b6-1762-47a1-b655-483510072e73";
        }
        public void Send(string Message)
        {
            while (true)
            {
                byte[] message = Encoding.ASCII.GetBytes(Message);
                stream.Write(message, 0, message.Count());
            }
        }
        public void Recieve()
        {
            while (true)
            {
                byte[] recievedMessage = new byte[256];
                stream.Read(recievedMessage, 0, recievedMessage.Length);
                recievedMessageString = Encoding.ASCII.GetString(recievedMessage);
                Console.WriteLine(recievedMessageString);
                //messagesQueue.Enqueue(recievedMessageString);

                //foreach (string value in messagesQueue)
                //{
                //    Console.WriteLine(value);
                //}
            }
        }
    }
}