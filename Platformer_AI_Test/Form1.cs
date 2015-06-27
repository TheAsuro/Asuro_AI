using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Asuro_AI;

namespace Platformer_AI_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            instance = this;
        }

        private static Form1 instance;
        public static Form1 GetInstance()
        {
            return instance;
        }

        public Dictionary<Neuron, NeuronDisplay> displays = new Dictionary<Neuron, NeuronDisplay>();

        private NeuralNetwork myNetwork = new NeuralNetwork();

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Neuron spawnedNeuron;

                if (rbNeuron.Checked)
                {
                    spawnedNeuron = new Neuron();
                }
                else if (rbInputNeuron.Checked)
                {
                    spawnedNeuron = new InputNeuron();
                }
                else if (rbOutputNeuron.Checked)
                {
                    spawnedNeuron = new OutputNeuron();
                    ((OutputNeuron)spawnedNeuron).OutputEvent += (obj, args) => MessageBox.Show("AYY LMAO");
                }
                else
                {
                    throw new InvalidOperationException("No radio button is checked!");
                }

                myNetwork.AddNeuron(spawnedNeuron);
                NeuronDisplay disp = new NeuronDisplay(spawnedNeuron);
                disp.Location = new Point(Cursor.Position.X - this.Location.X, Cursor.Position.Y - this.Location.Y);
                this.Controls.Add(disp);
                disp.BringToFront();
            }
        }

        public void UpdatePanel()
        {
            panel1_Paint(this, null);
            panel1.Update();
        }

        public void DeselectEveryting()
        {
            foreach (NeuronDisplay disp in displays.Values)
            {
                disp.Deselect();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            foreach (KeyValuePair<Neuron, NeuronDisplay> pair in displays)
            {
                foreach (Neuron input in pair.Value.linkedNeuron.Inputs)
                {
                    Point iPoint = Substract(displays[input].Location, panel1.Location);
                    Point nPoint = Substract(pair.Value.Location, panel1.Location);
                    Point distance = Substract(iPoint, nPoint);
                    g.DrawLine(Pens.Black, iPoint, nPoint);
                    g.DrawEllipse(Pens.Black, iPoint.X - (int)(distance.X * 0.8f), iPoint.Y - (int)(distance.Y * 0.8f), 5, 5);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Observation[] obs = {new AlwaysOnObversation()};
            myNetwork.ApplyObservations(obs);
            myNetwork.FireOutputs();
        }

        private Point Substract(Point a, Point b)
        {
            return new Point(a.X - b.X, a.Y - b.Y);
        }
    }

    public class AlwaysOnObversation : Observation
    {
        public bool FitsNeuron(InputNeuron neuron)
        {
            return true;
        }
    }

    public class PanelPos : Position
    {
        private int x;
        private int y;

        public PanelPos(int xPos, int yPos) : base()
        {
            x = xPos;
            y = yPos;
        }

        public static bool operator ==(PanelPos a, PanelPos b)
        {
            return a.x == b.x && a.y == b.y;
        }

        public static bool operator !=(PanelPos a, PanelPos b)
        {
            return !(a == b);
        }
    }
}
