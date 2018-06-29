using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public class MapperFunctions : IMapperFunctions
    {
        ChannelFactory<IReducerFunctions> reducerFactory;
        IReducerFunctions proxy;


        public void Map(List<Movie> Movies, string reducerPort)
        {
            Dictionary<ProductionCompany, double> MapResultDictionary = new Dictionary<ProductionCompany, double>(); // pravimo dic u koji cemo smestiti rezultate mapiranja
            foreach (var item in Movies) //prolazimo kroz sve filmove
            {
               
                double profit = item.revenue - item.budget; //profit
                foreach (ProductionCompany productionCompany in item.production_companies)
                {
                    MapResultDictionary.Add(productionCompany, profit); //novi dictionari (kljuc-kompanija,vrednost profit)
                }
            }

            foreach (var keyvaluepair in MapResultDictionary) //ispisi svaki rekord
            {
                Console.WriteLine(keyvaluepair.Key.name + "   :   " + keyvaluepair.Value);
            }


            //povezivanje sa reducerom
            var binding = new NetTcpBinding();
            binding.TransactionFlow = true;
            reducerFactory = new ChannelFactory<IReducerFunctions>(binding, new EndpointAddress("net.tcp://localhost:" + reducerPort + "/Reducer"));
            proxy = reducerFactory.CreateChannel();

            proxy.Reduce(MapResultDictionary, reducerPort); //izvrseno mapiranje zovi reduce funckiju
        }
    }
}
