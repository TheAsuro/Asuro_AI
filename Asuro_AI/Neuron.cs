using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asuro_AI
{
    public class Neuron
    {
        private static int hitCount = 0;
        public static int Hits { get { int val = hitCount; hitCount = 0; return val; } }

        private List<Neuron> inputs = new List<Neuron>();
        public Neuron[] Inputs { get { return inputs.ToArray(); } }

        private bool isBlocked = false;
        public bool Block
        {
            get { return isBlocked; }
            set { isBlocked = value; }
        }

        private float barrier = 0.1f;

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
            hitCount++;

            // Abort, active check went in a circle!
            if (isBlocked)
                return false;

            int activeInputs = 0;

            // Prevent endless cycling
            isBlocked = true;

            // Get input status (recursive)
            inputs.ForEach(
                (Neuron n) =>
                {
                    if (n.IsActive)
                    {
                        activeInputs++;
                    }
                });

            // Release the block, as this node could be accessed from another path
            //isBlocked = false;

            return ((float)activeInputs) / ((float)inputs.Count) >= barrier;
        }

        public bool IsInput
        {
            get { return this.GetType() == typeof(InputNeuron) || this.GetType().IsSubclassOf(typeof(InputNeuron)); }
        }

        public bool IsOutput
        {
            get { return this.GetType() == typeof(OutputNeuron) || this.GetType().IsSubclassOf(typeof(OutputNeuron)); }
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
