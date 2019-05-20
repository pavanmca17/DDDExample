using System;

namespace DDDExample
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceClient client = new ServiceClient();
            var returnValue = client.AddLineItem();
            Console.WriteLine(returnValue);
            returnValue = client.UpdateLineItem();
            Console.WriteLine(returnValue);
        }
    }
}
