using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    public class Creature : IEnumerable<int>
    {
        public int[] Stats = new int[3];

        public int this[int index]
        {
            get => Stats[index];
            set => Stats[index] = value;
        }

        public const int strenght = 0;
        public int Strenght
        {
            get => Stats[strenght];
            set => Stats[strenght] = value;
        }
        public const int agility = 1;
        public int Agility
        {
            get => Stats[agility];
            set => Stats[agility] = value;
        }

        public const int intelligence = 2;
        public int Intelligence
        {
            get => Stats[intelligence];
            set => Stats[intelligence] = value;
        }

        public double SumOfStats => Stats.Sum();
        public double MaxStat => Stats.Max();
        public double AverageStat => Stats.Average();

        public IEnumerator<int> GetEnumerator() => Stats.AsEnumerable().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator () => GetEnumerator();
    }
}
