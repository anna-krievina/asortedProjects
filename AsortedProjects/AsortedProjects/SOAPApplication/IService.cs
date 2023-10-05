using System.ServiceModel;
using static SoapCore.DocumentationWriter.SoapDefinition;

namespace SOAPApplication
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        string Sum(int num1, int num2);
    }
    public class Service : IService
    {
        public string Sum(int num1, int num2)
        {
            return $"Sum of two number is: {num1 + num2}";
        }

    }
}
