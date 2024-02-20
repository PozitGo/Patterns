using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public interface ICommand
    {
        void Execute();
    }

    public class SaveCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Saving current file");
        }
    }

    public class OpenCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Opening file");
        }
    }

    public class Button
    {
        private readonly ICommand command;
        private readonly string Name;

        public Button(ICommand command, string Name)
        {
            this.command = command;
            this.Name = Name;   
        }

        public void Click()
        {
            command.Execute();
        }

        public void PrintMe()
        {
            Console.WriteLine($"I am a button called {this.Name}");
        }

        public class Editor
        {
            public IEnumerable<Button> Buttons { get; }

            public Editor(IEnumerable<Button> buttons)
            {
                this.Buttons = buttons;
            }

            public void ClickAll() 
            {
                foreach (var button in Buttons)
                {
                    button.Click();
                }
            }
        }
    }
}
