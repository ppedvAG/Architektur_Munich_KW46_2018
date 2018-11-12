using System;
using System.Threading.Tasks;

namespace HalloSingelton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Parallel.For(0, 10, i => Logger.Instance.Log($"Hallo {i}"));

            Console.ReadLine();
        }
    }

    class Logger
    {
        private static object _syncObj = new object();
        private static Logger _instance;
        public static Logger Instance
        {
            get
            {
                lock (_syncObj)
                {
                    if (_instance == null)
                        _instance = new Logger();
                }
                return _instance;
            }
        }
        static int instCounter = 0;
        private Logger()
        {
            instCounter++;
        }

        public void Log(string msg)
        {
            Console.WriteLine($"[{instCounter}] [{DateTime.Now:T}] {msg}");
        }
    }
}
