using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E18I4DABH32D1Gr4.Models
{
    public class Email
    {
        // Email Properties
        public int EmailId { get; set; }

        [Required, StringLength(64)]
        public string EmailAddress { get; set; }

        // Person Relation
        public virtual Person Person { get; set; }
    }
}
