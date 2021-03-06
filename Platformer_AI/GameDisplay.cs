﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Asuro_AI;

namespace Platformer_AI
{
    public partial class GameDisplay : Form
    {
        private int width = 45;
        private int height = 35;
        private Level level;
        private int leftCameraBound = 0;
        private int BlockWidth { get { return gamePanel.Width / width; } }
        private int BlockHeight { get { return gamePanel.Height / height; } }
        private bool leftPressed;
        private bool rightPressed;
        private bool upPressed;

        private bool running;

        private NeuralNetwork network;
        
        public GameDisplay()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            InitializeLevelAndNetwork();

            OutputNeuron left = new OutputNeuron();
            left.OutputEvent += (sender, args) => leftPressed = true;
            network.AddNeuron(left);

            OutputNeuron right = new OutputNeuron();
            right.OutputEvent += (sender, args) => rightPressed = true;
            network.AddNeuron(right);
            
            OutputNeuron up = new OutputNeuron();
            up.OutputEvent += (sender, args) => upPressed = true;
            network.AddNeuron(up);
        }

        private class LevelInputNeuron : InputNeuron
        {
            private GamePosition screenPosition;
            public GamePosition ScreenPosition { get { return new GamePosition(screenPosition.X, screenPosition.Y); } }
            private bool blockIsThere;
            public bool BlockIsThere { get { return blockIsThere; } }

            public LevelInputNeuron(GamePosition position, bool block) : base()
            {
                this.screenPosition = position;
                blockIsThere = block;
            }
        }

        private LevelInputNeuron GetRandomInputNeuron()
        {
            Random rnd = new Random();
            int x = rnd.Next(0, width - 1);
            int y = rnd.Next(0, height - 1);
            bool block = rnd.Next(0, 100) > 50;

            return new LevelInputNeuron(new GamePosition(x, y), block);
        }

        private class LevelObservation : Observation
        {
            private GamePosition position;
            private bool hasBlock;

            public LevelObservation(GamePosition position, bool hasBlock)
            {
                this.position = position;
                this.hasBlock = hasBlock;
            }

            public bool FitsNeuron(InputNeuron neuron)
            {
                if (neuron == null || !(neuron.IsInput))
                {
                    return false;
                }
                else
                {
                    LevelInputNeuron levelNeuron = (LevelInputNeuron)neuron;
                    return position == levelNeuron.ScreenPosition && hasBlock == levelNeuron.BlockIsThere;
                }
            }
        }

        private GamePosition ScreenToWorldPosition(GamePosition screenPos)
        {
            return screenPos; //TODO
        }

        private void GameDisplay_Paint(object sender, PaintEventArgs e)
        {
            Graphics dispGraphics = gamePanel.CreateGraphics();
            BufferedGraphics graphics = BufferedGraphicsManager.Current.Allocate(dispGraphics, gamePanel.Bounds);

            level.Draw(graphics.Graphics, leftCameraBound, width, height, BlockWidth, BlockHeight);

            graphics.Render(gamePanel.CreateGraphics());
        }

        private void bnMutate_Click(object sender, EventArgs e)
        {
            network.MutateNetwork();
        }

        private void bnAdvance_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                tempCounter = 0;
                tempX = 0;

                for (int i = 0; i < 10000; i++)
                {
                    running = true;
                    if (!Advance())
                    {
                        tempCounter = 0;
                        tempX = 0;
                        network.MutateNetwork();
                        level.ResetPlayer();
                    }

                    // What have I done...
                    if (!this.IsDisposed)
                        this.Invoke(new Action(() => this.RaisePaintEvent(typeof(PaintEventHandler), new PaintEventArgs(gamePanel.CreateGraphics(), gamePanel.DisplayRectangle))));
                }
                running = false;
                LogSafe("Finished");
            });
        }

        private void LogSafe(string text)
        {
            if (!this.IsDisposed && !lbLog.IsDisposed)
                this.Invoke(new Action(() => { lbLog.Items.Add(text); lbLog.SelectedIndex = lbLog.Items.Count - 1; }));
        }

        private int tempCounter = 0;
        private int tempX = 0;

        private bool Advance()
        {
            List<LevelObservation> obs = new List<LevelObservation>();

            for (int x = leftCameraBound; x < leftCameraBound + width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    GamePosition pos = new GamePosition(x, y);
                    if (level.Blocks.ContainsKey(pos))
                        obs.Add(new LevelObservation(pos, true));
                    else
                        obs.Add(new LevelObservation(pos, false));
                }
            }

            leftPressed = false;
            rightPressed = false;
            upPressed = false;

            network.ApplyObservations(obs.ToArray());
            network.FireOutputs();

            level.MovePlayer(leftPressed, rightPressed, upPressed);

            if (level.PlayerPosition.X > tempX)
                tempCounter = 0;
            else
                tempCounter++;

            MarkControlActive(pnlLeft, leftPressed);
            MarkControlActive(pnlRight, rightPressed);
            MarkControlActive(pnlUp, upPressed);

            if (tempCounter > 30)
            {
                LogSafe("Death by boredom, x-pos: " + level.PlayerPosition.X);
                return false;
            }

            if (level.PlayerPosition.Y < 0)
            {
                LogSafe("Death by falling, x-pos: " + level.PlayerPosition.X);
                return false;
            }

            return true;
        }

        private void InitializeLevelAndNetwork()
        {
            level = new Level(42);
            network = new NeuralNetwork(42, () => GetRandomInputNeuron(), 1, 10);
        }

        private void MarkControlActive(Control ctrl, bool active)
        {
            if (active)
                ctrl.BackColor = Color.DarkGreen;
            else
                ctrl.BackColor = SystemColors.Control;
        }
    }
}
