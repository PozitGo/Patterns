namespace Adapter
{
    public interface IInteger
    {
        int Value { get; }
    }

    public class Dimensions
    {
        public class Two : IInteger
        {
            public int Value => 2;
        }

        public class Three : IInteger
        {
            public int Value => 3;
        }
    }

    //T = float, D = 3
    public abstract class Vector<TSelf, T, D> where D : IInteger, new() where TSelf : Vector<TSelf, T, D>, new()
    {
        protected T[] data;

        public Vector()
        {
            data = new T[new D().Value];
        }

        public Vector(params T[] values)
        {
            var requiredSize = new D().Value;
            data = new T[requiredSize];

            var providedSize = values.Length;

            for (int i = 0; i < Math.Min(requiredSize, providedSize); i++)
            {
                data[i] = values[i];
            }
        }

        public static TSelf Create(params T[] values)
        {
            var result = new TSelf();
            var requiredSize = new D().Value;
            result.data = new T[requiredSize];

            var providedSize = values.Length;

            for (int i = 0; i < Math.Min(requiredSize, providedSize); i++)
            {
                result.data[i] = values[i];
            }

            return result;

        }

        public T this[int index]
        {
            get => data[index]; 
            set => data[index] = value; 
        }
    }

    public class VectorOfInt<TSelf, D> : Vector<TSelf, int, D> where D : IInteger, new() where TSelf : Vector<TSelf, int, D>, new()
    {
        public VectorOfInt(params int[] values) : base(values)
        {

        }
        public VectorOfInt() {}

        public static VectorOfInt<TSelf, D> operator +(VectorOfInt<TSelf, D> lhs, VectorOfInt<TSelf, D> rhs)
        {
            var result = new VectorOfInt<TSelf, D>();
            var dim = new D().Value;

            for (int i = 0; i < dim; i++)
            {
                result[i] = lhs[i] + rhs[i];
            }

            return result;
        }
    }

    public class Vector3f : Vector<Vector3f, float, Dimensions.Three>
    {
        public Vector3f(params float[] values) : base(values)
        {

        }

        public Vector3f()
        {
            
        }
    }

    public class Vector3i: VectorOfInt<Vector3i, Dimensions.Three>
    {
        public Vector3i(params int[] values) : base(values) 
        {
            
        }

        public Vector3i()
        {
            
        }
    }
}
