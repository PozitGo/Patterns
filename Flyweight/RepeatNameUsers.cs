using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight
{
    //public class User
    //{
    //    public required string FullName { get; set; }

    //    public User(string FullName)
    //    {
    //        this.FullName = FullName;
    //    }
    //}

    public class User
    {
        public string FullName => string.Join(" ", Names.Select(i => strings[i]));
        private static List<string> strings;
        private int[] Names;

        static User()
        {
            User.strings = new List<string>();
        }

        public User(string FullName)
        {
            int getOrAdd (string s)
            {
                int idx = strings.IndexOf(s);
                
                if(idx != -1)
                {
                    return idx;
                }
                else
                {
                    strings.Add(s);
                    return strings.Count - 1;
                }
            }

            this.Names = FullName.Split(' ').Select(getOrAdd).ToArray();

        }
    }
}
