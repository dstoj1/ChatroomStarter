using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public interface ISubscriber
    {
        string UserId { get; set; }
        void Notify(ISubscriber chatter);
    }
}
