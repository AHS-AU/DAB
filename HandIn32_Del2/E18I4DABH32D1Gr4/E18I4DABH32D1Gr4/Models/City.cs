using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace E18I4DABH32D1Gr4.Models
{
    public class City
    {
        // City Properties
        [Key]
        public int CityId { get; set; }

        [Required, StringLength(64)]
        public string CityName { get; set; }

        [Required, StringLength(64)]
        public string ZipCode { get; set; }

        [Required, StringLength(64)]
        public string CountryRegion { get; set; }

        // Address Relation
        public virtual List<Address> Addresses { get; set; }

    }
}
