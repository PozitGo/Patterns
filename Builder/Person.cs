namespace Builder
{
    public class Person
    {
        //address
        public string? StreetAddress, Postcode, City;

        //employment info
        public string? CompanyName, Position;
        public int AnnualIncome;

        public override string ToString() => $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(Postcode)}: {Postcode}, {nameof(City)}: {City}," +
            $" {nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}";
    }

    public class PersonBuilder
    {
        protected readonly Person person;

        public PersonBuilder()
        {
            this.person = new Person();
        }

        public PersonBuilder(Person person)
        {
            this.person = person;
        }

        public PersonAddressBuilder Lives => new(person);
        public PersonJobBuilder Works => new(person);

        public static implicit operator Person(PersonBuilder personBuilder) => personBuilder.person;
    }

    public class PersonAddressBuilder : PersonBuilder
    {
        public PersonAddressBuilder(Person person) : base(person)
        {

        }
        public PersonAddressBuilder At(string streetAddress)
        {
            person.StreetAddress = streetAddress;
            return this;
        }

        public PersonAddressBuilder WithPostcode(string postcode)
        {
            person.Postcode = postcode;
            return this;
        }

        public PersonAddressBuilder In(string city)
        {
            person.City = city;
            return this;
        }
    }


    public class PersonJobBuilder : PersonBuilder
    {
        public PersonJobBuilder(Person person) : base(person)
        {

        }

        public PersonJobBuilder At(string companyName)
        {
            person.CompanyName = companyName;
            return this;
        }

        public PersonJobBuilder AsA(string position)
        {
            person.Position = position;
            return this;
        }

        public PersonJobBuilder Earning(int annualIncome)
        {
            person.AnnualIncome = annualIncome;
            return this;
        }
    }
}
