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
        Thread reciever;
        TcpClient clientSocket;
        NetworkStream stream;
        public string username;
        public Client(string IP, int port)
        {
            clientSocket = new TcpClient();
            clientSocket.Connect(IPAddress.Parse(IP), 9999);
            stream = clientSocket.GetStream();
            reciever = new Thread(new ThreadStart(Recieve));
            reciever.Start();
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
