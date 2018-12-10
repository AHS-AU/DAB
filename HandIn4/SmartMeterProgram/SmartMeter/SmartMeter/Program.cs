using SmartMeter.Controllers;
using SmartMeter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMeter
{
    class Program
    {
        static void Main(string[] args)
        {
            TradersRepoController mTradersRepoController = new TradersRepoController();

            List<Trader> GetAllTraders = mTradersRepoController.GetTradersAsync().Result.ToList();

            foreach(var v in GetAllTraders)
            {
                Console.WriteLine(v);
            }


           
        }
    }
}
