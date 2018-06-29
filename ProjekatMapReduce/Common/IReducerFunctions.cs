using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [ServiceContract]
    public interface IReducerFunctions
    {

        [OperationContract]
        void Reduce(Dictionary<ProductionCompany, double> MapResultDictionary, string fileId);

        [OperationContract]
        void ReduceAll();

        [OperationContract]
        void PrintReduced(Dictionary<ProductionCompany, double> ReducedDictionary);
    }
}
