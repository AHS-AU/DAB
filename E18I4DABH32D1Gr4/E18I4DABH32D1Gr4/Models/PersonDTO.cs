//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace E18I4DABH32D1Gr4.Models
//{
//    public class PersonDTO
//    {
//        public PersonDTO()
//        { }

//        public PersonDTO(Person person)
//        {
//            PersonId = person.PersonId;

//            FullName = person.FullName;

//            Email = new List<Email>();

//            PrimaryAddress = new AddressDTO(person.Address);

//            PersonAddresses = new List<PersonAddressDTO>();

//            PhoneNumbers = new List<PhoneNumberDTO>();

//            foreach (PersonAddress pa in person.PersonAddresses)
//            {
//                PersonAddresses.Add(new PersonAddressDTO(pa));
//            }
//        }

//        public Person ToPerson()
//        {
//            return new Person() { PersonId = PersonId, FullName = FullName, Email = Email, Address = PrimaryAddress.ToAddress(), PrimaryAddress_AddressId = PrimaryAddress.AddressId, PersonAddresses = PersonAddresses.Select(pa => pa.ToPersonAddress()).ToList(), PhoneNumbers = PhoneNumbers.Select(pn => pn.ToPhoneNumber()).ToList() };
//        }

//        public int PersonId { get; set; }

//        public string FullName { get; set; }

//        public string Email { get; set; }

//        public AddressDTO PrimaryAddress { get; set; }

//        public List<PersonAddressDTO> PersonAddresses { get; set; }
//    }
//}
