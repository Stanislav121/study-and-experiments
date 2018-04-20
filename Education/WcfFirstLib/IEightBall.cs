using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WcfFirstLib
{
    [ServiceContract(Namespace = "http://Stas.com")]
    public interface IEightBall
    {
        [OperationContract]
        string GetAnswer(string question);
    }
}
