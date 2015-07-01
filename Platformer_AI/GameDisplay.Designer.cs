namespace Platformer_AI
{
    partial class GameDisplay
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
            this.gamePanel = new System.Windows.Forms.Panel();
            this.bnMutate = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bnAdvance = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gamePanel
            // 
            this.gamePanel.Location = new System.Drawing.Point(0, 0);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(350, 250);
            this.gamePanel.TabIndex = 0;
            // 
            // bnMutate
            // 
            this.bnMutate.Location = new System.Drawing.Point(356, 3);
            this.bnMutate.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.bnMutate.Name = "bnMutate";
            this.bnMutate.Size = new System.Drawing.Size(202, 23);
            this.bnMutate.TabIndex = 1;
            this.bnMutate.Text = "Mutate";
            this.bnMutate.UseVisualStyleBackColor = true;
            this.bnMutate.Click += new System.EventHandler(this.bnMutate_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(356, 70);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(202, 180);
            this.textBox1.TabIndex = 2;
            // 
            // bnAdvance
            // 
            this.bnAdvance.Location = new System.Drawing.Point(356, 29);
            this.bnAdvance.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.bnAdvance.Name = "bnAdvance";
            this.bnAdvance.Size = new System.Drawing.Size(202, 23);
            this.bnAdvance.TabIndex = 3;
            this.bnAdvance.Text = ">>";
            this.bnAdvance.UseVisualStyleBackColor = true;
            this.bnAdvance.Click += new System.EventHandler(this.bnAdvance_Click);
            // 
            // GameDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 252);
            this.Controls.Add(this.bnAdvance);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.bnMutate);
            this.Controls.Add(this.gamePanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GameDisplay";
            this.Text = "sick gaem";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameDisplay_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel gamePanel;
        private System.Windows.Forms.Button bnMutate;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button bnAdvance;
    }
}

