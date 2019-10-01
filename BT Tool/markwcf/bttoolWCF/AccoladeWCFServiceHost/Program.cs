using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AccoladeWCFService;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace AccoladeWCFServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = null;
            try
            {
                //base address for AccoladeWCFService
                Uri httpBaseAddress = new Uri("http://172.16.0.174:4321/AccoladeWCFService/IAccoladeService");

                //Instantiate ServiceHost
                host = new ServiceHost(typeof(AccoladeService), httpBaseAddress);

                //add endpoint to host
                host.AddServiceEndpoint(typeof(IAccoladeService), new WSHttpBinding(),"");

                //Metadata exchange
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior
                {
                    HttpGetEnabled = true
                };
                host.Description.Behaviors.Add(smb);
                //Open
                host.Open();
                Console.WriteLine("Service is live now at: "+httpBaseAddress);
                Console.WriteLine("Service is host at " + DateTime.Now.ToString());
                Console.WriteLine("Host is running... Press  key to stop");
            }
            catch (Exception ex)
            {
                host = null;
                Console.WriteLine("There is an issue with AccoladeWCFService " + ex.Message);
            }
            Console.ReadLine();
        }
    }
}
