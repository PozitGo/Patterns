using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public enum SubSystem
    {
        Main,
        Backup
    }
    //Набор Singleton по ключу
    public class Printer
    {
        private static readonly Dictionary<SubSystem, Printer> instances = new Dictionary<SubSystem, Printer>();
        private Printer() {}

        public static Printer Get(SubSystem subSystem)
        {
            if(instances.ContainsKey(subSystem))
            {
                return instances[subSystem];
            }

            instances[subSystem] = new Printer();

            return instances[subSystem];
        }
    }
}
