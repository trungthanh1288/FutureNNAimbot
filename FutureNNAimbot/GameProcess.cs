﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FutureNNAimbot
{
   public class GameProcess
    {
       public Settings s;

        public string ProcessName { get { return s.Game; } }

        private GameProcess(Settings settings)
        {
            s = settings;

        }

        public static  GameProcess Create(Settings settings)
        {
            var gp = new GameProcess(settings);
            var p = Process.GetProcessesByName(settings.Game).FirstOrDefault();
            if (p == null)
            {
                MessageBox.Show($"You have not launched {gp.s.Game}...");
                //Process.GetCurrentProcess().Kill();
                while (gp.isRunning() == false)
                {
                    Console.Clear();
                    Console.WriteLine($"Waiting for {gp.s.Game} to open. Press any enter to retry!");
                    Console.ReadLine();
                }
            }
            return gp;
        }

        

        public bool isRunning()
        {
            return Process.GetProcessesByName(s.Game).FirstOrDefault() != null;
        }
    }
}
