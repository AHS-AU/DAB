using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using HandIn4_Simulation.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace HandIn4_Simulation.Controllers
{
    class SmartGridsController
    {
        static string mApiUrl = "http://localhost:50955/api/SmartGrids";

        static HttpClient mHttpClient = new HttpClient();

        // GET: api/SmartGrids
        public async Task<List<SmartGrid>> GetAllSmartGridsAsync()
        {
            string responseBody = await mHttpClient.GetStringAsync(new Uri(mApiUrl));
            return JsonConvert.DeserializeObject<List<SmartGrid>>(responseBody);
        }

        // GET: api/SmartGrids/5
        public async Task<SmartGrid> GetSmartGridAsync(int id)
        {
            string responseBody = await mHttpClient.GetStringAsync(new Uri(mApiUrl + "/" + id.ToString()));
            return JsonConvert.DeserializeObject<SmartGrid>(responseBody);
        }
    }
}
