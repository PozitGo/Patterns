namespace Factory
{
    public class Person
    {
        private Person(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
        public int Id { get; set; }
        public string? Name { get; set; }

        public static PersonFactory Factory = new();

        public override string ToString() => $"{Id} - {Name}";
        public class PersonFactory
        {
            private static int LastID;
            public Person Create(string Name) => new Person(LastID++, Name);
        }
    }
}
