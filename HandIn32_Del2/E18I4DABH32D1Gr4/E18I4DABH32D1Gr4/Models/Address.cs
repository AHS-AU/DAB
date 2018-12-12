using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace E18I4DABH32D1Gr4.Models
{
    public class Address
    {
        // Address Properties
        [Key]
        public int AddressId { get; set; }

        [Required, StringLength(64)]
        public string StreetAddress { get; set; }

        public string AddressType { get; set; }

        // Person Relation
        public virtual List<Person> PeopleAtAddress { get; set; }

        // City Relation
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public virtual City City { get; set; }

    }
}
