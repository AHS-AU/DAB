using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using HandIn4_Simulation.Models;
using Newtonsoft.Json;

namespace HandIn4_Simulation.Controllers
{
    public class TradersRepoController
    {
        static string mApiUrl = "http://localhost:50955/api/TradersRepo";
        static HttpClient mHttpClient = new HttpClient();

        // GET: api/TradersRepo
        public async Task<List<Trader>> GetTradersAsync()
        {
            string responseBody = await mHttpClient.GetStringAsync(new Uri(mApiUrl));
            return JsonConvert.DeserializeObject<List<Trader>>(responseBody);
        }

        //// GET: api/TradersRepo/5
        //public Trader GetTrader(int id)
        //{
        //    return _context.GetById(id);
        //}

        //// PUT: api/TradersRepo/5
        //public void PutTrader(int id, Trader trader)
        //{
        //    _context.Update(trader);
        //}

        //// POST: api/TradersRepo
        //public void PostTrader(Trader trader)
        //{
        //    _context.Add(trader);
        //}

        //// DELETE: api/TradersRepo/5
        //public void DeleteTrader(int id)
        //{
        //    Trader trader = _context.GetById(id);
        //    _context.Delete(trader);
        //}

        //private bool TraderExists(int id)
        //{
        //    var Trader = _context.GetById(id);

        //    if (Trader == null)
        //    {
        //        return false;
        //    }
        //    return true;
        //}
    }
}