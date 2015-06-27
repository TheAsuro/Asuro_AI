namespace Platformer_AI_Test
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rbNeuron = new System.Windows.Forms.RadioButton();
            this.rbInputNeuron = new System.Windows.Forms.RadioButton();
            this.rbOutputNeuron = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbNeuron
            // 
            this.rbNeuron.AutoSize = true;
            this.rbNeuron.Checked = true;
            this.rbNeuron.Location = new System.Drawing.Point(6, 19);
            this.rbNeuron.Name = "rbNeuron";
            this.rbNeuron.Size = new System.Drawing.Size(60, 17);
            this.rbNeuron.TabIndex = 0;
            this.rbNeuron.TabStop = true;
            this.rbNeuron.Text = "Neuron";
            this.rbNeuron.UseVisualStyleBackColor = true;
            // 
            // rbInputNeuron
            // 
            this.rbInputNeuron.AutoSize = true;
            this.rbInputNeuron.Location = new System.Drawing.Point(6, 42);
            this.rbInputNeuron.Name = "rbInputNeuron";
            this.rbInputNeuron.Size = new System.Drawing.Size(49, 17);
            this.rbInputNeuron.TabIndex = 1;
            this.rbInputNeuron.Text = "Input";
            this.rbInputNeuron.UseVisualStyleBackColor = true;
            // 
            // rbOutputNeuron
            // 
            this.rbOutputNeuron.AutoSize = true;
            this.rbOutputNeuron.Location = new System.Drawing.Point(6, 65);
            this.rbOutputNeuron.Name = "rbOutputNeuron";
            this.rbOutputNeuron.Size = new System.Drawing.Size(57, 17);
            this.rbOutputNeuron.TabIndex = 2;
            this.rbOutputNeuron.Text = "Output";
            this.rbOutputNeuron.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbNeuron);
            this.groupBox1.Controls.Add(this.rbOutputNeuron);
            this.groupBox1.Controls.Add(this.rbInputNeuron);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(102, 86);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Neuron Type";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(120, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(420, 250);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 104);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 274);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Neuron Test";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbNeuron;
        private System.Windows.Forms.RadioButton rbInputNeuron;
        private System.Windows.Forms.RadioButton rbOutputNeuron;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
    }
}

