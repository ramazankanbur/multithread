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
    public class SmsLoop
    {
        #region Singleton Implementation
        private static SmsLoop _smsLoop;
        public static SmsLoop Instance
        {
            get
            {
                if (_smsLoop == null)
                {
                    _smsLoop = new SmsLoop();
                }
                return _smsLoop;
            }
        }
        #endregion

        public static void StartSmsLoop()
        {
            int smsLoopPeriod = 1;
            //config dosyasına SmsLoopPeriod adında appSetting ekleyerek çalışma periyodunu belirleyebiliriz
            if (!Int32.TryParse(ConfigurationManager.AppSettings["SmsLoopPeriod"], out smsLoopPeriod))
            {
                smsLoopPeriod = 1;
            }

            while (true)
            {             
                Instance.SendSms(); 
                Thread.Sleep(TimeSpan.FromSeconds(smsLoopPeriod));
            }

        }
        private void SendSms()
        {
            Console.WriteLine("Sms gönderme işlemi başladı");
            var timer = new Stopwatch();
            timer.Start();
            Thread.Sleep(1000);
            timer.Stop();
            Console.WriteLine(string.Format("Sms gönderildi. Süresi {0}", timer.Elapsed));
        }
    }
}
