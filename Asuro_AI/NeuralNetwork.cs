using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asuro_AI
{
    public class NeuralNetwork
    {
        private Ruleset rules = new Ruleset();

        public void AddNeuron(Neuron newNeuron)
        {
            rules.AddNeuron(newNeuron);
        }

        public void ApplyObservations(Observation[] observations)
        {
            // Go through all inputs
            foreach (InputNeuron iNeuron in rules.Inputs)
            {
                // Deactivate them
                iNeuron.IsInputActive = false;

                // Look if any observation matches their input patterns
                foreach (Observation obs in observations)
                {
                    if (obs.FitsNeuron(iNeuron))
                    {
                        iNeuron.IsInputActive = true;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// This will go through all output neurons and fire their events as long as they are active
        /// </summary>
        public void FireOutputs()
        {
            foreach (OutputNeuron oNeuron in rules.Outputs)
            {
                oNeuron.FireOutput();
            }
        }
    }

    public interface Observation
    {
        bool FitsNeuron(InputNeuron neuron);
    }

    public abstract class Position
    {
        public static bool operator ==(Position a, Position b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Position a, Position b)
        {
            return !(a == b);
        }
    }

    public class Ruleset
    {
        private List<Neuron> allNeurons = new List<Neuron>();
        public Neuron[] Neurons { get { return allNeurons.ToArray(); } }

        private List<InputNeuron> inputs = new List<InputNeuron>();
        public InputNeuron[] Inputs { get { return inputs.ToArray(); } }

        private List<OutputNeuron> outputs = new List<OutputNeuron>();
        public OutputNeuron[] Outputs { get { return outputs.ToArray(); } }

        public Ruleset() { }

        public void AddNeuron(Neuron neuron)
        {
            if (neuron.GetType() == typeof(InputNeuron))
            {
                inputs.Add((InputNeuron)neuron);
            }
            else if (neuron.GetType() == typeof(OutputNeuron))
            {
                outputs.Add((OutputNeuron)neuron);
            }

            allNeurons.Add(neuron);
        }
    }
}