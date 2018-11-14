using ppedv.Zeus.Service.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ppedv.Zeus.Service.Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cf = new ChannelFactory<IService>(bind, new EndpointAddress(adr));
            bind.Security.Mode = SecurityMode.None;
        }
        NetTcpBinding bind = new NetTcpBinding();
        
        string adr = "net.tcp://192.168.16.48:1";
        ChannelFactory<IService> cf;
        private void button1_Click(object sender, EventArgs e)
        {
            var bind = new NetTcpBinding();

            var client = cf.CreateChannel();

            dataGridView1.DataSource = client.GetAllDrucker().ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var newDrucker = new DruckerWCF() { Hersteller = "WCF NEU" };
            var client = cf.CreateChannel();
            client.AddDrucker(newDrucker);
        }
    }
}
