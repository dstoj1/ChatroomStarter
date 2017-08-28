using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    public class Client
    {
        TcpClient clientSocket;
        NetworkStream stream;
        public string username;
        public Client(string IP, int port)
        {
            //Console.WriteLine("Please enter your username.");
            //username = Console.ReadLine();
            clientSocket = new TcpClient();
            clientSocket.Connect(IPAddress.Parse("192.168.0.111"), 9999);
            stream = clientSocket.GetStream();
        }

        public void Send()
        {
            while (true)
            {
            string messageString = UI.GetInput();
            byte[] message = Encoding.ASCII.GetBytes(messageString);
            stream.Write(message, 0, message.Count());
            }
        }
        public void Recieve()
        {
            while (true)
            {
            byte[] recievedMessage = new byte[256];
            stream.Read(recievedMessage, 0, recievedMessage.Length);
            UI.DisplayMessage(Encoding.ASCII.GetString(recievedMessage));
            }
        }
    }
}
