﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedeljni_I_Bojana_Backo
{
    class ManagerPassword
    {
        public delegate void ApplicationStartedEventHandler(object source, string randomStr);

        public event ApplicationStartedEventHandler ApplicationStarted;

        private Random random = new Random();
        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public void WriteToFile()
        {
            string randomStr = RandomString(8);
            OnApplicationStarted(randomStr);
        }

        protected virtual void OnApplicationStarted(string randomStr)
        {
            if (ApplicationStarted != null)
                ApplicationStarted(this, randomStr);
        }
    }
}
