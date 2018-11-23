using E18I4DABH32D1Gr4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E18I4DABH32D1Gr4.DTO
{
    public class CityDTO
    {
        // Default Constructor
        public CityDTO(){

        }

        // Constructor with City Object
        public CityDTO(City city){
            CityId = city.cityId;
            CityName = city.cityName;
            ZipCode = city.zipCode;
            CountryRegion = city.countryRegion;
            AddressId = new List<AddressDTO>();
            foreach (AddressId addId in city.addressId){
                AddressId.Add(new AddressDTO(addId));
            }
        }

        // Variables
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int ZipCode { get; set; }
        public string CountryRegion{ get; set; }
        public List<AddressDTO> AddressId{ get; set; }

    }
}
