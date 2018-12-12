using HandIn4_Simulation.Controllers;
using HandIn4_Simulation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandIn4_Simulation
{
    class Program
    {
        static void Main(string[] args)
        {
            TradersRepoController mTradersRepoController = new TradersRepoController();

            List<Trader> GetAllTraders = mTradersRepoController.GetTradersAsync().Result.ToList();

            foreach (var v in GetAllTraders)
            {
                Console.WriteLine(v);
            }


        }
    }
}
