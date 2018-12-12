using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace E18I4DABH32D1Gr4.Models
{
    //[Table("Email")]
    public class Email
    {
        [Key]//, Index(IsUnique = true)]
        public int emailId { get; set; }

        [Required]
        public virtual Person person { get; set; }

        //[Index(IsUnique = true), StringLength(64)]
        public string email { get; set; }
    }
}