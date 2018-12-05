using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E18I4DABH4Gr4.Models
{
    public class Prosumer
    {
        public enum ProsumerType
        {
            Private, Company
        }
        private string ProsumerId { get; }

        public string Name { get; set; }

        public ProsumerType prosumerType { get; set; }

        public int KWhAmount { get; set; }
    }
}
