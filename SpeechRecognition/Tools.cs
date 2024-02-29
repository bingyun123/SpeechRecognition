using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpeechRecognition
{
    class Tools
    {
        public static void delayMs(int delay_time)
        {
            int time_start = System.Environment.TickCount;
            int time_stamp = 0;
            do
            {
                Application.DoEvents();
                time_stamp = System.Environment.TickCount - time_start;
            }
            while (time_stamp < delay_time);
        }
    }
}
