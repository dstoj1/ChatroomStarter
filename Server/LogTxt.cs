using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Server
{
    public class LogTxt : ILogger
    {
        public void Write(string message)
        {
            string text = message;
            File.WriteAllText(@"C:\Program Files\WriteText.txt", message);
        }
        public void SaveToTxt()
        {
            throw new NotImplementedException();
        }
    }
}
