using System.Windows;
namespace Observer
{
    // an event subscription can lead to a memory
    // leak if you hold on to it past the object's
    // lifetime

    // weak events help with this

    public class Button
    {
        public event EventHandler Clicked;

        public void Fire()
        {
            Clicked?.Invoke(this, EventArgs.Empty);
        }
    }

    public class Window
    {
        public Window(Button button)
        {
            button.Clicked += ButtonOnClicked;
        }

        private void ButtonOnClicked(object sender, EventArgs eventArgs)
        {
            Console.WriteLine("Button clicked (Window handler)");
        }

        ~Window()
        {
            Console.WriteLine("Window finalized");
        }
    }

    public class Window2
    {
        public Window2(Button button)
        {
            //WeakEventManager<Button, EventArgs>
            //  .AddHandler(button, "Clicked", ButtonOnClicked);
        }

        private void ButtonOnClicked(object sender, EventArgs eventArgs)
        {
            Console.WriteLine("Button clicked (Window2 handler)");
        }

        ~Window2()
        {
            Console.WriteLine("Window2 finalized");
        }
    }
}
