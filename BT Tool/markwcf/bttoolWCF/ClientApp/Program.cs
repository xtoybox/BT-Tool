using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AccoladeWCFService;
using System.ServiceModel;

namespace ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                
                AccoladeServiceProxy proxy = new AccoladeServiceProxy();
                Console.WriteLine("Client is running at " + DateTime.Now.ToString());
                while (true)
                {
                    
                    var ln = Console.ReadLine();
                    if (ln.ToLower() == "exit")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine(proxy.GetMessage(ln));
                    }
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
    public class AccoladeServiceProxy : ClientBase<IAccoladeService>, IAccoladeService
    {
        public string GetMessage(string msg)
        {
            return base.Channel.GetMessage(Environment.MachineName+"==> "+ msg);
        }
    }
}
