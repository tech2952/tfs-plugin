using System;

namespace TaxAppClient.WCFServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            TACServiceHost.StartService();
            Console.ReadLine();
            TACServiceHost.StopService();
        }
    }
}
