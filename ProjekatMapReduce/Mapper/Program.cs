using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Mapper
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
            _serviceHost = new ServiceHost(typeof(MapperFunctions));
            var binding = new NetTcpBinding();
            binding.TransactionFlow = true;
            _serviceHost.AddServiceEndpoint(typeof(IMapperFunctions), binding, new Uri("net.tcp://localhost:" + port + "/Mapper"));
            _serviceHost.Open();

            Console.WriteLine("Mapper WCF Service started");
        }

        private static void Stop()
        {
            _serviceHost.Close();

            Console.WriteLine("Mapper WCF Service stopped");
        }
    }
}
