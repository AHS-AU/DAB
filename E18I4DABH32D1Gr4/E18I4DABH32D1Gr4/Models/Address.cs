using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace E18I4DABH32D1Gr4.Models
{
    //[Table("Address")]
    public class Address
    {
        [Key]//, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int addressId { get; set; }

        public virtual string streetAddress { get; set; }

        //public virtual List<Person> PersonId { get; set; }

        [Required]
        public virtual City cityAtAddress { get; set; }

    }
}