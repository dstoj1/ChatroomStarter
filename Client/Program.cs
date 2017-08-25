using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client("192.168.0.114", 9999);

            Chatroom chatroom = new Chatroom();

            ISubscriber Mike = new User("Mike");
            ISubscriber Adam = new User("Adam");

            chatroom.JoinChatroom(Mike);
            chatroom.JoinChatroom(Adam);

            chatroom.EnterChatroom();

            //client.Send();
            //client.Recieve();
            //Console.ReadLine();
        }
    }
}
