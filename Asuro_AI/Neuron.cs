using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asuro_AI
{
    public class Neuron
    {
        private static List<Neuron> checkedNeurons = new List<Neuron>();

        private List<Neuron> inputs = new List<Neuron>();
        public Neuron[] Inputs { get { return inputs.ToArray(); } }

        private float barrier = 0.5f;

        public void AddInput(Neuron inputNeuron)
        {
            inputs.Add(inputNeuron);
        }

        public void RemoveInputAt(int index)
        {
            inputs.RemoveAt(index);
        }

        public virtual bool IsActive
        {
            get
            {
                return IsActiveFromInput();
            }
        }

        protected bool IsActiveFromInput()
        {
            int activeInputs = 0;

            // Prevent endless cycling
            checkedNeurons.Add(this);

            // Get input status (recursive)
            inputs.ForEach(
                (Neuron n) =>
                {
                    if (!checkedNeurons.Contains(n) && n.IsActive)
                    {
                        activeInputs++;
                    }
                });

            // Release the block, as this node could be accessed from another path
            checkedNeurons.Remove(this);

            return ((float)activeInputs) / ((float)inputs.Count) >= barrier;
        }
    }

    public class InputNeuron : Neuron
    {
        private bool isInputActive = false;
        public bool IsInputActive
        {
            set { isInputActive = value; }
        }

        public InputNeuron() { }

        public override bool IsActive
        {
            get
            {
                return IsActiveFromInput() || isInputActive;
            }
        }
    }

    public class OutputNeuron : Neuron
    {
        public event EventHandler OutputEvent;

        public void FireOutput()
        {
            if (IsActive && OutputEvent != null)
            {
                OutputEvent(this, new EventArgs());
            }
        }
    }
}
