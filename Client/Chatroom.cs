using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Chatroom
    {
        private List<ISubscriber> chatters = new List<ISubscriber>();

        public void JoinChatroom (ISubscriber chatter)
        {
            chatters.Add(chatter);
            Console.WriteLine("{0} has joined the chatroom", chatter.UserId);

        }
    }
}
