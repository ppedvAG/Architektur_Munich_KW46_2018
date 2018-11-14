using ppedv.Zeus.Model;
using System.Collections.Generic;
using System.ServiceModel;

namespace ppedv.Zeus.Service.Model
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        IEnumerable<DruckerWCF> GetAllDrucker();

        //[OperationContract]
        //IEnumerable<Auftrag> GetAllAuftrag();

        [OperationContract]
        void AddDrucker(DruckerWCF drucker);
    }
}
