using E18I4DABH32D1Gr4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E18I4DABH32D1Gr4.DTO
{
    public class EmailDTO
    {
        // Default Constructor
        public EmailDTO()
        {

        }

        // Constructor with Email Object
        public EmailDTO(Email email)
        {
            EmailId = email.emailId;
            Email = email.email;
        }

        // Variables
        public int EmailId{ get; set; }
        public string Email{ get; set; }
    }
}

