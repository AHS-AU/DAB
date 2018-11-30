using E18I4DABH32D1Gr4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E18I4DABH32D1Gr4.DTO
{
    public class AddressDTO
    {
        // Default Constructor
        public AddressDTO(){}

        // Constructor with Address Object
        public AddressDTO(Address address)
        {
            AddressId = address.addressId;

            StreetAddress = address.streetAddress;

            CityAtAddress = new CityDTO (address.cityAtAddress);
        }

        // Variables
        public int AddressId { get; set; }

        public string StreetAddress { get; set; }

        public CityDTO CityAtAddress { get; set; }


    }
}
