using Lab7Service;
using System;
using System.ServiceModel;

namespace Lab7Host
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(Feed));
            host.Open();
            string s = Console.ReadLine();
        }
    }
}
