using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace E18I4DABH32D1Gr4.Models
{
   
    public class Person
    {
        // Person Properties
        [JsonProperty(PropertyName = "id")]
        public string PersonId { get; set; }

        [Required, StringLength(128)]
        public string FullName { get; set; }

        // Email Relation
        public int EmailId { get; set; }

        public virtual Email Email { get; set; }

        // Address Relation
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

    }


    
}
