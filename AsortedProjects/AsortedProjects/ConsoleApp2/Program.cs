using ServiceReference1;

class Program
{
    static async Task Main(string[] args)
    {

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
        IService soapServiceChannel = new ServiceClient(ServiceClient.EndpointConfiguration.BasicHttpBinding_IService_soap);
        var sumResponse = await soapServiceChannel.SumAsync(new SumRequest()
        {
            Body = new SumRequestBody()
            {
                num1 = 2,
                num2 = 3
            }
        });
        Console.WriteLine(sumResponse.Body.SumResult);
    }
}