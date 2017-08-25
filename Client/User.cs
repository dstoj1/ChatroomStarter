using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class User : ISubscriber
    {
        private string name;

        public string UserId
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public User (string userId)
        {
            this.name = userId;
        }
        public void Notify (ISubscriber chatter)
        {
            Console.WriteLine("Chatter {0} has joined the chatroom.");
        }
    }
}
