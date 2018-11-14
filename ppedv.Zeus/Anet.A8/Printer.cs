using System;

namespace Anet.A8
{
    public class Printer
    {
        public void PreheatNozzle(int temp)
        {
            Console.Beep(500, temp);
        }

        public void PreheatBed(int temp)
        {
            Console.Beep(700, temp);

        }

        public void MoveHome()
        {
            Console.Beep(400, 300);
            Console.Beep(460, 300);
            Console.Beep(490, 300);
        }

        public void StartPrint(string gcode)
        {
            Console.Beep();
        }

        public void Pause()
        {
            Console.Beep();
        }

        public void Resume()
        {
            Console.Beep();
        }

        static Random ran = new Random();
        public int GetStatus()
        {
            return ran.Next(0, 7);
        }
    }
}
