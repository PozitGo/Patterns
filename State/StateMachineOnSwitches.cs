using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State.Switches
{
    public enum State
    {
        Locked, Failed, Unlocked
    }

    public static class Switches
    {
        public static void Execute()
        {
            string code = "1234";
            var state = State.Locked;
            var entry = new StringBuilder();
            var data = new Queue<int>(new[] { 1, 2, 3, 4 });

            while(true)
            {
                switch(state)
                {
                    case State.Locked:
                        var value = data.Dequeue();
                        Console.WriteLine(value);
                        entry.Append(value);

                        if(entry.ToString() == code)
                        {
                            goto case State.Unlocked;
                        }

                        if(!code.StartsWith(entry.ToString()))
                        {
                            goto case State.Failed;
                        }

                        break; 
                    case State.Failed:
                        Console.WriteLine("FAILED");
                        return;
                    case State.Unlocked:
                        Console.WriteLine("UNLOCKED");
                        return;
                    default: break;
                }
            }
        }
    }
}
