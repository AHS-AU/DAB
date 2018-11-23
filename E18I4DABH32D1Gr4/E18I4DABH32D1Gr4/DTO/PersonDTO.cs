using E18I4DABH32D1Gr4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E18I4DABH32D1Gr4.DTO
{
    public class PersonDTO
    {

        public PersonDTO()
        { }

        public int PersonId { get; set; }

        public string FullName { get; set; }

        public List<EmailDTO> Email { get; set; }

        public AddressDTO PrimaryAddress { get; set; }

        public List<AddressDTO> SecondaryAddresses { get; set; }
    }
}

//public PersonDTO()
//{ }

//public PersonDTO(Person person)
//{
//    PersonId = person.PersonId;

//    FullName = person.FullName;

//    Email = new List<EmailDTO>();

//    PrimaryAddress = new AddressDTO(person.PrimaryAddress);

//    SecondaryAddresses = new List<AddressDTO>();

//    foreach (streetAddress sa in person.SecondaryAddresses)
//    {
//        SecondaryAddresses.Add(new AddressDTO(sa));
//    }
//}

////public Person ToPerson()
////{
////    return new Person() {
////        PersonId = PersonId,
////        FullName = FullName,
////        Email = Email,
////        Address = PrimaryAddress.ToAddress(),
////        PrimaryAddress_AddressId = PrimaryAddress.AddressId,
////        PersonAddresses = PersonAddresses.Select(pa => pa.ToPersonAddress()).ToList(),
////        PhoneNumbers = PhoneNumbers.Select(pn => pn.ToPhoneNumber()).ToList() };
////}

//public int PersonId { get; set; }

//public string FullName { get; set; }

//public List<EmailDTO> Email { get; set; }

//public AddressDTO PrimaryAddress { get; set; }

//public List<AddressDTO> SecondaryAddresses { get; set; }