using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HalloWCF
{
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public IEnumerable<Klasse> GetKlassen()
        {
            yield return new Klasse() { MyBroperty = 8, MyString = "Das ist ein Text" };
            yield return new Klasse() { MyBroperty = -55, MyString = "Das ist ein Text" };
            yield return new Klasse() { MyBroperty = 33544, MyString = "Das ist ein Text" };
            yield return new Klasse() { MyBroperty = 0, MyString = "Das ist ein Text" };
        }
    }
}
