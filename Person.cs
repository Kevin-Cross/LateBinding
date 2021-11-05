using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib
{
    [SpecialClass(1)]
    public class Person
    {
        public enum Genders
        {
            Male,
            Female,
            NotSupplied,
            Other
        }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime DOB { get; set; }
        public Genders Gender { get; set; }

        public Person()
        {

        }
        public Person(string lastName, string firstName, DateTime dob, Genders gender)
        {
            LastName = lastName;
            FirstName = firstName;
            DOB = dob;
            Gender = gender;

        }
        public override string ToString()
        {
            return string.Format("{0,-15} {1,-15} {2,5} {3,5}", LastName, FirstName, DOB, Gender);
        }
    }
}
