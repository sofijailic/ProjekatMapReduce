using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Reducer
{
    class Program
    {
        private static ServiceHost _serviceHost = null;
        static void Main(string[] args)
        {
            Console.WriteLine("Enter port:");
            string port = Console.ReadLine();
            Start(port);
            Console.ReadKey(true);
            Stop();
        }

        private static void Start(string port)
        {
            _serviceHost = new ServiceHost(typeof(ReducerFunctions));
            var binding = new NetTcpBinding();
            binding.TransactionFlow = true;
            _serviceHost.AddServiceEndpoint(typeof(IReducerFunctions), binding, new Uri("net.tcp://localhost:" + port + "/Reducer"));
            _serviceHost.Open();

            Console.WriteLine("Reducer WCF Service started");
        }

        private static void Stop()
        {
            _serviceHost.Close();

            Console.WriteLine("Reducer WCF Service stopped");
        }
    }
}
