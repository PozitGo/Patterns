using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.CopyCtor
{

    public class Address 
    {
        public readonly string StreetName;
        public int HouseNumber;

        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public Address(Address address)
        {
            this.StreetName = address.StreetName;
            this.HouseNumber = address.HouseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }
    }

    public class Person 
    {
        public readonly string[] Names;
        public readonly Address Address;

        public Person(string[] names, Address address)
        {
            Names = names;
            Address = address;
        }

        public Person(Person person)
        {
            this.Names = new string[person.Names.Length];
            Array.Copy(person.Names, this.Names, person.Names.Length);
            this.Address = new Address(person.Address);
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(",", Names)}, {nameof(Address)}: {Address}";
        }
    }
}
