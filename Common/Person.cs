using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Person
    {
        public enum enFilters
        {
            none = 0, PersonID, NationalNo, FirstName, SecondName, ThirdName,
            LastName, NationalityCountryID, Gender, Phone, Email,
        }
        public int ID { get; set; }
        public string NationalID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public ushort NationalityID { get; set; }
        public string ImagePath { get; set; }
        public string FullName { get
            {
                return FirstName + " " + SecondName + " " + (ThirdName ?? "") +" " + LastName;
            } }
        public Person(int ID, string NationalID, string First, string Second, string Last,
            DateTime DateOfBirth, byte Gender, string Address, string Phone, string Email, ushort NationalityID, string Third = null, string ImagePath = null)
        {
            this.ID = ID;
            this.NationalID = NationalID;
            FirstName = First;
            SecondName = Second;
            ThirdName = Third;
            LastName = Last;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityID = NationalityID;
            this.ImagePath = ImagePath;
        }
        public Person()
        {
            ID = -1;
        }
    }
}
