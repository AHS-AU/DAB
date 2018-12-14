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
            // Variables
            TradersRepoController mTradersRepoController = new TradersRepoController();
            ProsumerController mProsumerController = new ProsumerController();
            SmartGridsController mSmartGridsController = new SmartGridsController();

            // Clear SmartGrid
            ClearSmartGrid(mSmartGridsController);

            /// Clear Prosumers
            /// Only use this if you want to clear, otherwise comment it out.
            //ClearProsumers(mProsumerController);

            /// Populate Prosumers
            /// Only run this function the first time to populate the DB
            /// Comment it out if running program multiple times
            //PopulateProsumers(mProsumerController);

            // Find Producer and Consumer
            List<Prosumer> mProducerList = mProsumerController.GetProsumerWithProduction("Overproducing").Result.ToList();
            List<Prosumer> mConsumerList = mProsumerController.GetProsumerWithProduction("Underproducing").Result.ToList();

            // Insert Producers and Consumer into SmartGrid object
            SmartGrid mSmartGrid = new SmartGrid();
            mSmartGrid.Producers = mProducerList;
            mSmartGrid.Consumers = mConsumerList;

            // Post SmartGrid to SmartGrid Database
            mSmartGridsController.Post(mSmartGrid).Wait();

            // Get All from SmartGrid
            var AllSmartGrid = mSmartGridsController.GetAllSmartGridsAsync().Result.LastOrDefault();
            var mProducers = AllSmartGrid.Producers;
            var mConsumers = AllSmartGrid.Consumers;

            Console.WriteLine("Count Producers = " + mProducers);
            Console.WriteLine("Count Consumers = " + mConsumers);








            //List<Trader> GetAllTraders = mTradersRepoController.GetAllTradersAsync().Result.ToList();
            //foreach (var v in GetAllTraders)
            //{
            //    Console.WriteLine(v);
            //}
            //Trader mTrader = mTradersRepoController.GetTraderAsync(1).Result;
            //Console.WriteLine(mTrader);


            //List<Prosumer> GetAllProsumers = mProsumerController.GetAllProsumersAsync().Result.ToList();
            //foreach (var v in GetAllProsumers)
            //{
            //    Console.WriteLine(v);
            //}
            //Prosumer mProsumer = mProsumerController.GetProsumerAsync("2").Result;
            //Console.WriteLine(mProsumer);

            //// Underproducing
            //List<Prosumer> mProsumerList = mProsumerController.GetProsumerWithProduction("Underproducing").Result.ToList();
            //foreach (var v in mProsumerList)
            //{
            //    Console.WriteLine(v);
            //}
            //Console.WriteLine("\n");

            //// Overproducing
            //mProsumerList = mProsumerController.GetProsumerWithProduction("Overproducing").Result.ToList();
            //foreach (var v in mProsumerList)
            //{
            //    Console.WriteLine(v);
            //}


            List<SmartGrid> GetAllSmartGrids = mSmartGridsController.GetAllSmartGridsAsync().Result.ToList();
            foreach (var v in GetAllSmartGrids)
            {
                Console.WriteLine(v);
            }
            //SmartGrid mSmartGrid = mSmartGridsController.GetSmartGridAsync(1).Result;
            //Console.WriteLine(mSmartGrid);


        }

        private static void PopulateProsumers(ProsumerController prosumerController)
        {
            // Populate 33x Household Prosumer
            int householdSize = 33;
            Console.WriteLine("Populating Private Prosumers ...");
            for (int i = 0; i < householdSize; i++)
            {
                Random random = new Random();
                string name = "household" + (i + 1);

                Prosumer prosumer = new Prosumer();
                prosumer.Name = name;
                prosumer.prosumerType = Prosumer.ProsumerType.Private;
                prosumer.KWhAmount = random.Next(-200, 200);

                prosumerController.Post(prosumer).Wait();
                Console.WriteLine("Private Prosumer " + (i+1) + "/" + householdSize + " Completed");

            }

            // Populate 12x Company Prosumer
            int companySize = 12;
            Console.WriteLine("\nPopulating Company Prosumers ...");
            for (int i = 0; i < companySize; i++)
            {
                Random random = new Random();
                string name = "company" + (i + 1);

                Prosumer prosumer = new Prosumer();
                prosumer.Name = name;
                prosumer.prosumerType = Prosumer.ProsumerType.Company;
                prosumer.KWhAmount = random.Next(-200, 200);

                prosumerController.Post(prosumer).Wait();

                Console.WriteLine("Company Prosumer " + (i+1) + "/" + companySize + " Completed");

            }
        }

        private static void ClearProsumers(ProsumerController prosumerController)
        {
            List<Prosumer> GetAllProsumers = prosumerController.GetAllProsumersAsync().Result.ToList();
            int counter = 0;
            foreach (var v in GetAllProsumers)
            {
                counter++;
                prosumerController.Delete(v.ProsumerId).Wait();
                Console.WriteLine("Deleted " + counter + "/" + GetAllProsumers.Count + " Prosumer with id = " + v.ProsumerId);
            }
        }

        private static void ClearSmartGrid(SmartGridsController smartGridsController)
        {
            List<SmartGrid> GetAllSmartGrid = smartGridsController.GetAllSmartGridsAsync().Result.ToList();
            int counter = 0;
            foreach (var v in GetAllSmartGrid)
            {
                counter++;
                smartGridsController.Delete(v.SmartGridId).Wait();
                Console.WriteLine("Deleted " + counter + "/" + GetAllSmartGrid.Count + " SmartGrid with id = " + v.SmartGridId);
            }
        }



    }
}
