using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.Zeus.WindowsService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            ppedv.Zeus.Service.Host.Program.Main(null);
        }

        protected override void OnStop()
        {
            ppedv.Zeus.Service.Host.Program.host.Close();
        }
    }
}
