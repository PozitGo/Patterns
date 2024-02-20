using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    public class Participant
    {
        private readonly Mediator mediator;
        public int Value { get; set; }

        public Participant(Mediator mediator)
        {
            this.mediator = mediator;
            mediator.Alert += Mediator_Alert;
        }

        private void Mediator_Alert(object sender, int e)
        {
            if (sender != this)
            {
                Value += e;
            }

        }

        public void Say(int n) => mediator.Broadcast(this, n);
    }

    public class Mediator
    {
        #nullable disable
        public event EventHandler<int> Alert;
        public void Broadcast(object sender, int n) => Alert?.Invoke(sender, n);
    }
}

