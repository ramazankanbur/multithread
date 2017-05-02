using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace multithreadExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread mailThread = new Thread(new ThreadStart(MailLoop.StartMailLoop));
            mailThread.Start();

            Thread.Sleep(1000);

            Thread smsThread = new Thread(new ThreadStart(SmsLoop.StartSmsLoop));
            smsThread.Start();
        }
    }
}
