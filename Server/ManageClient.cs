using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class ManageClient
    {
        TcpClient clientSocket;
        private int counter = 0;

        //public void startClient(TcpClient inClientSocket)
        //{
        //    this.clientSocket = inClientSocket; //keep count of how many tasks are running. add simple coutner, increase whenever fire off task, decremetn when task completes, when coutner hits zero end all.
        //    Thread ctThread = new Thread(x); //code has to run as a separate task on a thread.
        //    ctThread.Start(); // go (get task running)
        //}
    }
}
