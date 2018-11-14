using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HalloWCF
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        IEnumerable<Klasse> GetKlassen();
    }

    public class Klasse
    {
        public int MyBroperty { get; set; }
        public string MyString { get; set; }
    }
}
