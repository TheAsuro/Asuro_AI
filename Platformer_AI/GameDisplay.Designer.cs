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
            this.bnAdvance = new System.Windows.Forms.Button();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lblLeft = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.lblRight = new System.Windows.Forms.Label();
            this.pnlUp = new System.Windows.Forms.Panel();
            this.lblUp = new System.Windows.Forms.Label();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlUp.SuspendLayout();
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
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lblLeft);
            this.pnlLeft.Location = new System.Drawing.Point(356, 225);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(25, 25);
            this.pnlLeft.TabIndex = 4;
            // 
            // lblLeft
            // 
            this.lblLeft.AutoSize = true;
            this.lblLeft.Font = new System.Drawing.Font("Arial", 11.25F);
            this.lblLeft.Location = new System.Drawing.Point(3, 3);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(23, 17);
            this.lblLeft.TabIndex = 0;
            this.lblLeft.Text = "←";
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.lblRight);
            this.pnlRight.Location = new System.Drawing.Point(418, 225);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(25, 25);
            this.pnlRight.TabIndex = 5;
            // 
            // lblRight
            // 
            this.lblRight.AutoSize = true;
            this.lblRight.Font = new System.Drawing.Font("Arial", 11.25F);
            this.lblRight.Location = new System.Drawing.Point(3, 3);
            this.lblRight.Name = "lblRight";
            this.lblRight.Size = new System.Drawing.Size(23, 17);
            this.lblRight.TabIndex = 0;
            this.lblRight.Text = "→";
            // 
            // pnlUp
            // 
            this.pnlUp.Controls.Add(this.lblUp);
            this.pnlUp.Location = new System.Drawing.Point(387, 191);
            this.pnlUp.Name = "pnlUp";
            this.pnlUp.Size = new System.Drawing.Size(25, 25);
            this.pnlUp.TabIndex = 5;
            // 
            // lblUp
            // 
            this.lblUp.AutoSize = true;
            this.lblUp.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUp.Location = new System.Drawing.Point(5, 4);
            this.lblUp.Margin = new System.Windows.Forms.Padding(4);
            this.lblUp.Name = "lblUp";
            this.lblUp.Size = new System.Drawing.Size(16, 17);
            this.lblUp.TabIndex = 0;
            this.lblUp.Text = "↑";
            // 
            // GameDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 252);
            this.Controls.Add(this.pnlUp);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.bnAdvance);
            this.Controls.Add(this.bnMutate);
            this.Controls.Add(this.gamePanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GameDisplay";
            this.Text = "sick gaem";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameDisplay_Paint);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.pnlUp.ResumeLayout(false);
            this.pnlUp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel gamePanel;
        private System.Windows.Forms.Button bnMutate;
        private System.Windows.Forms.Button bnAdvance;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label lblLeft;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblRight;
        private System.Windows.Forms.Panel pnlUp;
        private System.Windows.Forms.Label lblUp;
    }
}

