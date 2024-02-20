using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public static class ExtensionMethods
    {
        public static void ConnectTo(this IEnumerable<Neuron> self, IEnumerable<Neuron> other)
        {
            if(ReferenceEquals(self, other)) return;

            foreach(Neuron neuron in self)
            {
                foreach(Neuron otherNeuron in other)
                {
                    neuron.Out?.Add(otherNeuron);
                    otherNeuron.In?.Add(neuron);
                }
            }
        }
    }

    public class Neuron : IEnumerable<Neuron>
    {
        public List<Neuron>? In, Out;

        //public void ConnectTo(Neuron other)
        //{
        //    Out?.Add(other);
        //    other.In?.Add(this);
        //}

        public IEnumerator<Neuron> GetEnumerator()
        {
            yield return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class NeuronLayer: Collection<Neuron>
    {
        public NeuronLayer(int count)
        {
            while (count --> 0)
            {
                Add(new Neuron());
            }
        }
    }
}
