using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.Factory
{
    public class Address
    {
        public string? StreetAddress, City;
        public int Suite;

        public Address(string StreetAddress, string City, int Suite)
        {
            this.StreetAddress = StreetAddress;
            this.City = City;
            this.Suite = Suite;
        }
    }

    public class Employee
    {
        public string? Name;
        public Address Address;

        public Employee(string Name, Address address)
        {
            this.Name = Name;
            this.Address = address; 
        }
    }

    public class EmployeeFactory
    {
        private static Employee main = new(null, new Address("123 East Drive", "London", 12));
        private static Employee aux = new(null, new Address("123 East Drive", "Chicago", 212));

        private static Employee Copy(Employee proto, string Name, int Suite)
        {
            var copy = proto.DeepCopyXml();
            copy.Name = Name;
            copy.Address.Suite = Suite;

            return copy;
        }

        public static Employee NewMainOfficeEmployee(string Name, int Suite) => Copy(main, Name, Suite);
        public static Employee NewAuxOfficeEmployee(string Name, int Suite) => Copy(aux, Name, Suite);
    }
}
