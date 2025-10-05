using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Media;

namespace RealStateRentSystem
{
    class AppointAlarmSound
    {
        public static SoundPlayer player = new SoundPlayer();
        public static System.Windows.Forms.Timer main_timer;

        public static void go()
        {
           // player.LoadCompleted += new EventHandler(LoadCompleted);
            main_timer = new System.Windows.Forms.Timer();
            main_timer.Interval = 2500;
            main_timer.Start();
            main_timer.Tick += new EventHandler(RunAlarm);
            play();
        }
        public static void play()
        {
            main_timer.Interval = 2500;
            main_timer.Start();
            player.SoundLocation = Utils.ProjectName + "\\ring.wav";
            player.LoadAsync();
            player.Play();
        }

       
        
        private static void RunAlarm(object sender, EventArgs eArgs)
        {

            play();

        }
    }
}
