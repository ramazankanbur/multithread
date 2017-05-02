using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace multithreadExample
{
    public class MailLoop
    {
        #region Singleton Implementation
        private static MailLoop _mailLoop;
        public static MailLoop Instance
        {
            get
            {
                if (_mailLoop == null)
                {
                    _mailLoop = new MailLoop();
                }
                return _mailLoop;
            }
        }
        #endregion

        public static void StartMailLoop()
        {
            int mailLoopPeriod = 1;
            //config dosyasına mailLoopPeriod adında appSetting ekleyerek çalışma periyodunu belirleyebiliriz
            if (!Int32.TryParse(ConfigurationManager.AppSettings["MailLoopPeriod"], out mailLoopPeriod))
            {
                mailLoopPeriod = 1;
            }

            while (true)
            {
                Instance.SendMail();
                Thread.Sleep(TimeSpan.FromSeconds(mailLoopPeriod));
            }
        }
        private void SendMail()
        {
            Console.WriteLine("Mail gönderimi başladı");
            var timer = new Stopwatch();
            timer.Start();
            Thread.Sleep(3000);
            timer.Stop();
            Console.WriteLine(string.Format("mail gönderildi. mail gönderme süresi {0}",timer.Elapsed));
        }
    }
}
