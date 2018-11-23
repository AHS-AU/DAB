using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace E18I4DABH32D1Gr4.Models
{
    [Table("City")]
    public class City
    {
        [Key]//, Index(IsUnique = true)]
        public virtual int cityId { get; set; }

        public virtual string cityName { get; set; }

        public virtual int zipCode { get; set; }

        public virtual string countryRegion { get; set; }

        public virtual List<Address> addressId { get; set; }

    }
}