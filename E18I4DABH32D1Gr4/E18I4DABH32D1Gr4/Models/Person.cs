﻿namespace E18I4DABH32D1Gr4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    //using System.Data.Entity.Spatial;
    
    public class Person
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Person(){

        //}

        public Person()
        {
            PrimaryAddress = new Address();
            SecondaryAddresses = new List<Address>();
            Email = new List<Email>();
        }

        [Key]
        public int PersonId { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }
        //public int PrimaryAddress_AddressId { get; set; }

        public virtual Address PrimaryAddress { get; set; }

        public virtual List<Email> Email { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<Address> SecondaryAddresses { get; set; }

    }
}