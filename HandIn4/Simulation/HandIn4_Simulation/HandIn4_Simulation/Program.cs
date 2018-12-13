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
            ProsumerController mProsumerController = new ProsumerController();
            SmartGridsController mSmartGridsController = new SmartGridsController();

            //List<Trader> GetAllTraders = mTradersRepoController.GetAllTradersAsync().Result.ToList();
            //foreach (var v in GetAllTraders)
            //{
            //    Console.WriteLine(v);
            //}
            //Trader mTrader = mTradersRepoController.GetTraderAsync(1).Result;
            //Console.WriteLine(mTrader);


            //List<Prosumer> GetAllProsumers = mProsumerController.GetAllProsumersAsync().Result.ToList();
            //foreach(var v in GetAllProsumers)
            //{
            //    Console.WriteLine(v);
            //}
           

            //List<SmartGrid> GetAllSmartGrids = mSmartGridsController.GetAllSmartGridsAsync().Result.ToList();
            //foreach(var v in GetAllSmartGrids)
            //{
            //    Console.WriteLine(v);
            //}
            //SmartGrid mSmartGrid = mSmartGridsController.GetSmartGridAsync(1).Result;
            //Console.WriteLine(mSmartGrid);


        }
    }
}
