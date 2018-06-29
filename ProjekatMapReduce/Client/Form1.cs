using Common;
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
using System.IO;
using Newtonsoft.Json;

namespace Client
{
    public partial class Form1 : Form
    {

        static IMapperFunctions mapperProxy;
        ChannelFactory<IMapperFunctions> mapperFactory;

        static IReducerFunctions reducerProxy;
        ChannelFactory<IReducerFunctions> reducerFactory;

        List<IMapperFunctions> proxyList = new List<IMapperFunctions>();
        private List<Movie> Movies = new List<Movie>();


        public Form1()
        {
            InitializeComponent();
        }

        private void Connect(string port) //konekcija klijenta sa maperom
        {
            var binding = new NetTcpBinding();
            binding.TransactionFlow = true;
            mapperFactory = new ChannelFactory<IMapperFunctions>(binding, new EndpointAddress("net.tcp://localhost:" + port + "/Mapper"));
            mapperProxy = mapperFactory.CreateChannel();

            MessageBox.Show("Connection established");
            proxyList.Add(mapperProxy);
        }

        private void btnConnectMapper1_Click(object sender, EventArgs e)
        {
            Connect(tbMapper1port.Text);
        }

        private void btnConnectMapper2_Click(object sender, EventArgs e)
        {
            Connect(tbMapper2port.Text);
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            LoadJson();
            MessageBox.Show("Load data");
        }

        private void LoadJson()
        {
            string json = File.ReadAllText("testdata.json"); ////ovo ispravitiii
            Movies = JsonConvert.DeserializeObject<List<Movie>>(json);
        }

        private void btnSendData_Click(object sender, EventArgs e)
        {
            int counter = 0;
            int reducerPort = 5002;
            int quota = 15;
            try
            {
                foreach (var prox in proxyList)
                {
                    prox.Map(Movies.Skip(counter).Take(quota).ToList(), reducerPort.ToString());
                    counter += quota;
                    reducerPort++;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnReduceData_Click(object sender, EventArgs e)
        {
            var binding = new NetTcpBinding();
            binding.TransactionFlow = true;
            reducerFactory = new ChannelFactory<IReducerFunctions>(binding,new EndpointAddress("net.tcp://localhost:5004/Reducer")); //ispraviti
            reducerProxy = reducerFactory.CreateChannel();

            reducerProxy.ReduceAll();

            MessageBox.Show("Reduced data ");
        }
    }
}
