
namespace Mediator
{
    public class Person
    {
        public string Name;
        public ChatRoom Room;
        private List<string> chatLog = new List<string>();

        public Person(string Name)
        {
            this.Name = Name;
        }

        public void Recive(string sender, string message)
        {
            string formattedMessage = $"{sender}: {message}";
            Console.WriteLine($"[{this.Name}`s chat session] {formattedMessage}");
            chatLog.Add(formattedMessage);
        }

        public void Say(string message) => Room.Broadcast(this.Name, message);
        public void PrivateMessage(string who, string message) => Room.Message(Name, who, message);

    }

    public class ChatRoom
    {
        private List<Person> people = new List<Person>();


        public void Broadcast(string sourse, string message)
        {
            people.ForEach(p =>
            {
                if(p.Name != sourse)
                {
                    p.Recive(sourse, message);
                }
            });
        }

        public void Join(Person p)
        {
            string joinMsg = $"{p.Name} joins the chat";
            Broadcast("room", joinMsg);
            p.Room = this;
            people.Add(p);

        }

        public void Message(string sourse, string destination, string message) => people.FirstOrDefault(p => p.Name == destination)?.Recive(sourse, message);
    }
}
