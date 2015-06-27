using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Asuro_AI;

namespace Platformer_AI_Test
{
    public partial class NeuronDisplay : UserControl
    {
        private static NeuronDisplay selectedNeuron;

        public Neuron linkedNeuron;

        public NeuronDisplay(Neuron neuron)
        {
            InitializeComponent();

            linkedNeuron = neuron;

            if (neuron.GetType() == typeof(InputNeuron))
            {
                this.BackColor = Color.Blue;
            }
            else if (neuron.GetType() == typeof(OutputNeuron))
            {
                this.BackColor = Color.Orange;
            }

            Form1.GetInstance().displays.Add(linkedNeuron, this);
        }

        public void Deselect()
        {
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
        }

        private void NeuronDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            Form1.GetInstance().DeselectEveryting();
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                selectedNeuron = this;
                Form1.GetInstance().UpdatePanel();
                this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (selectedNeuron != null)
                {
                    linkedNeuron.AddInput(selectedNeuron.linkedNeuron);
                    Form1.GetInstance().UpdatePanel();
                }
            }
        }
    }
}
