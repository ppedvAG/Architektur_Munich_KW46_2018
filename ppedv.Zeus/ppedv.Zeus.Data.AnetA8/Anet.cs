using Anet.A8;
using ppedv.Zeus.Model;
using System;

namespace ppedv.Zeus.Data.AnetA8
{
    public class Anet : I3dDrucker
    {
        private Printer printer = new Printer();

        public DruckerStatus Status
        {
            get
            {
                var stat = printer.GetStatus();
                if (stat < 0 || stat > 5)
                    return DruckerStatus.Error;

                return (DruckerStatus)Enum.GetValues(typeof(DruckerStatus)).GetValue(stat);
            }
        }

        public void Pause()
        {
            printer.Pause();
        }

        public void Resume()
        {
            printer.Resume();
        }

        public void Start(string gcode)
        {
            printer.PreheatNozzle(200);
            printer.PreheatBed(60);
            printer.MoveHome();
            printer.StartPrint(gcode);
        }

        public void Stop()
        {

            printer.Pause();
            printer.Pause();
            printer.Pause();
            printer = new Printer();
        }
    }
}
