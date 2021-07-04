using System.ServiceModel;

namespace Lab5Host
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(Lab5Service.Service1));
            sh.Open();
        }
    }
}
