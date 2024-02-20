using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    //public class MyClass
    //{
    //    public bool? All
    //    {
    //        get
    //        {
    //            bool areAllEqual = Pillars == Walls && Walls == Floors;
    //            return areAllEqual ? (bool?)areAllEqual : null;
    //        }

    //        set
    //        {
    //            if(value != null)
    //            {
    //                Pillars = Walls = Floors = value.Value;
    //            }
    //        }
    //    }


    //    public bool Pillars;
    //    public bool Walls;
    //    public bool Floors;
    //}

    //Поля массив
    public class MultiCheck
    {
        private bool[] Flags = new bool[3];

        public bool? All
        {
            get
            {
                if (Flags.Skip(1).All(flag => flag = Flags[0]))
                {
                    return Flags[0];
                }
                else
                {
                    return null;
                }
            }

            set
            {
                if (!value.HasValue) return;

                for (int i = 0; i < Flags.Length; ++i) 
                {
                    Flags[i] = value.Value;
                }
            }
        }
        public bool Pillars
        {
            get => Flags[0];
            set => Flags[0] = value;
        }

        public bool Walls
        {
            get => Flags[1];
            set => Flags[1] = value;
        }

        public bool Floors
        {
            get => Flags[2];
            set => Flags[2] = value;
        }
    }
}
