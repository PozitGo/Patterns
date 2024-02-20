namespace Proxy
{
	public class Property<T> where T : new()
	{
		private T value;
		private readonly string Name;

		public T Value
		{
			get => value;
			set 
			{
				if (Equals(this.value, value)) return;
                Console.WriteLine($"Assigning {value} to {Name}");
                this.value = value;
			}
		}

		public Property() : this(default(T)!)
        {
            
        }
        public Property(T value, string Name = "")
        {
			this.value = value;
			this.Name = Name;
        }

		public static implicit operator T(Property<T> p) => p.Value;
		public static implicit operator Property<T>(T value) => new Property<T>(value);

        public bool Equals(Property<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return EqualityComparer<T>.Default.Equals(value, other.value);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() != this.GetType()) return false;

            return Equals((Property<T>)obj);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<T>.Default.GetHashCode(value);
        }
    }

    public class Creature
    {
        private readonly Property<int> agility = new(10, nameof(Agility));
        public int Agility
        {
            get => agility.Value;
            set => agility.Value = value;
        }

        public Creature()
        {
            this.Agility = new();
        }
    }

    //   public class Creature
    //   {
    //	private int agility;

    //	public int Agility
    //	{
    //		get => agility;
    //		set 
    //		{ 
    //			//
    //			agility = value;
    //		}
    //	}
    //}
}
