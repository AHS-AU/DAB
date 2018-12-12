using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Key, StringLength(40)]
        public string ProsumerId { get; set; }
        [Required]
        public string Name { get; set; }

        public ProsumerType prosumerType { get; set; }

        public int KWhAmount { get; set; }
    }
}
