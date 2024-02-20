using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
  //SoA = structure of arrays
  //AoS = array os structures

    public class BadCreature
    {
        public byte Age;
        public int X, Y;
    }

    public class Creatures
    {
        private int Size;
        private byte[] Age;
        private int[] X, Y;

        public Creatures(int Size)
        {
            this.Size = Size;
            Age = new byte[Size];   
            X = new int[Size];
            Y = new int[Size];
        }

        //Посредник для оптимизации хранения в памяти, в виде последовательных элементов каждого типа
        public struct Creature
        {
            private Creatures creatures;
            private int Index;

            public Creature(Creatures creatures, int Index)
            {
                this.creatures = creatures;
                this.Index = Index;
            }

            public ref byte Age => ref creatures.Age[Index];
            public ref int X => ref creatures.X[Index];
            public ref int Y => ref creatures.Y[Index];
        }

        public IEnumerable<Creature> GetEnumerator()
        {
            for (int pos = 0; pos < Size; ++pos)
            {
                yield return new Creature(this, pos);
            }
        }
    }
}
