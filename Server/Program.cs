using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            LogTxt log = new LogTxt();
            new Server(log).Run();
            Console.ReadLine();
        }
    }
}