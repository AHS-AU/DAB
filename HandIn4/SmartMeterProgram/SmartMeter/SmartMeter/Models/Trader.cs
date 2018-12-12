using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SmartMeter.Models
{
    public class Trader
    {
        public int Id { get; set; }

        public string ProducerId { get; set; }

        public string ConsumerId { get; set; }

        public string KWhTransferred { get; set; }

        public DateTime TransferDate { get; set; }

        // Make the Model Serializable
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
