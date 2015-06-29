using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asuro_AI
{
    public class NeuralNetwork
    {
        public delegate InputNeuron CreateInputNeuron();

        private CreateInputNeuron createRandomInput;
        private Ruleset rules = new Ruleset();
        private Random rng;
        private int minMutations;
        private int maxMutations;

        public NeuralNetwork(int seed, CreateInputNeuron randomInput, int minMutations = 0, int maxMutations = 5)
        {
            rng = new Random(seed);
            this.minMutations = minMutations;
            this.maxMutations = maxMutations;
            createRandomInput = randomInput;
        }

        public void AddNeuron(Neuron newNeuron)
        {
            rules.AddNeuron(newNeuron);
        }

        public void MutateNetwork()
        {
            // Do a random number of mutations
            int mutationCount = rng.Next(minMutations, maxMutations);
            for (int i = 0; i < mutationCount; i++)
            {
                Mutate();
            }
        }

        private void Mutate()
        {
            int type = rng.Next(0, 100);
            Console.WriteLine("Typ: " + type);

            if (type > 90)
            {
                AddRandomNeuron();
            }
            else if (type > 85)
            {
                // Remove neuron
            }
            else if (type > 20)
            {
                // Add connection
            }
            else
            {
                // Remove connection
            }
        }

        private Neuron GetRandomNeuron()
        {
            return rules.Neurons[rng.Next(0, rules.Neurons.Length - 1)];
        }

        private void AddRandomNeuron()
        {
            // Create neuron or InputNeuron
            Neuron n;
            int neuronType = rng.Next(0, 1);

            if (neuronType == 0)
            {
                n = new Neuron();
            }
            else
            {
                n = createRandomInput();
            }

            // Get random other neuron in network
            Neuron other = null;
            if (rules.Neurons.Length > 0)
                other = GetRandomNeuron();

            // Add neuron to network
            rules.AddNeuron(n);

            // Connect it to the other neuron
            if (other != null)
            {
                n.AddInput(other);
            }
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