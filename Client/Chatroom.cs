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
            Console.WriteLine("{0} joined the chatroom", chatter.UserId);
        }

        public void LeaveChatroom (ISubscriber chatter)
        {
            chatters.Remove(chatter);
            Console.WriteLine("{0} left the chatroom", chatter.UserId);
        }

        public void EnterChatroom()
        {
            NotifyChatters();
        }
        public void NotifyChatters()
        {
            foreach (ISubscriber chatter in chatters)
            {
                chatter.Notify(chatter);
            }
        }
    }
}
