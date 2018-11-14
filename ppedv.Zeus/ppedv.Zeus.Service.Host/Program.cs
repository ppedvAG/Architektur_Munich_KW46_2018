using ppedv.Zeus.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.Zeus.Service.Host
{
    public class Program
    {
        public static ServiceHost host = new ServiceHost(typeof(WebService));
        public static void Main(string[] args)
        {
            Console.WriteLine("*** WCF HOST ***");

            host = new ServiceHost(typeof(WebService));
            var bind = new NetTcpBinding();
            bind.Security.Mode = SecurityMode.None;
            host.AddServiceEndpoint(typeof(IService), bind, "net.tcp://localhost:1");
            //host.AddServiceEndpoint(typeof(IService), new BasicHttpBinding(), "http://localhost:2");

            host.Open();
            Console.WriteLine("Service läuft...");
            Console.ReadLine();


            host.Close();
            Console.WriteLine("Ende");

            Console.ReadLine();
        }
    }
}
