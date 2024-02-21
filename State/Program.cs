
using System.Formats.Asn1;

namespace State
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var ls = new Switch();
            //ls.On();
            //ls.Off();
            //ls.Off();
            //TestManualStateMachine();
            Switches.Switches.Execute();


        }

        public static void TestManualStateMachine()
        {
            Machine.Machine.State state = Machine.Machine.State.OffHook, exitState = Machine.Machine.State.OnHook;
            var queue = new Queue<int>(new[] { 0, 1, 2, 0, 0 });

            do
            {
                Console.WriteLine($"The phone is currently {state}");
                Console.WriteLine("Select a trigger:");

                if (Machine.Machine.rules.ContainsKey(state))
                {
                    for (int i = 0; i < Machine.Machine.rules[state].Count; ++i)
                    {
                        var (t, _) = Machine.Machine.rules[state][i];
                        Console.WriteLine($"{i}. {t}");
                    }

                    var input = queue.Dequeue();
                    Console.WriteLine(input);

                    if (input >= 0 && input < Machine.Machine.rules[state].Count)
                    {
                        var (_, s) = Machine.Machine.rules[state][input];
                        state = s;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, try again.");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine($"No rules defined for state {state}, exiting...");
                    break;
                }
            }
            while (state != exitState);

            Console.WriteLine("We are done using the phone");
        }
    }
}
