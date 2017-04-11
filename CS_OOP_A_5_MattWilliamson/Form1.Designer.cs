namespace CS_OOP_A_5_MattWilliamson
{
    partial class GameForm
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblWinLose = new System.Windows.Forms.Label();
            this.pnlWinLose = new System.Windows.Forms.Panel();
            this.btnTryAgain = new System.Windows.Forms.Button();
            this.pnlWinLose.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 12;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblWinLose
            // 
            this.lblWinLose.AutoSize = true;
            this.lblWinLose.BackColor = System.Drawing.Color.Transparent;
            this.lblWinLose.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWinLose.ForeColor = System.Drawing.Color.Brown;
            this.lblWinLose.Location = new System.Drawing.Point(63, 16);
            this.lblWinLose.Name = "lblWinLose";
            this.lblWinLose.Size = new System.Drawing.Size(180, 48);
            this.lblWinLose.TabIndex = 0;
            this.lblWinLose.Text = "You Win!";
            // 
            // pnlWinLose
            // 
            this.pnlWinLose.Controls.Add(this.btnTryAgain);
            this.pnlWinLose.Controls.Add(this.lblWinLose);
            this.pnlWinLose.Location = new System.Drawing.Point(294, 96);
            this.pnlWinLose.Name = "pnlWinLose";
            this.pnlWinLose.Size = new System.Drawing.Size(294, 150);
            this.pnlWinLose.TabIndex = 1;
            this.pnlWinLose.Visible = false;
            // 
            // btnTryAgain
            // 
            this.btnTryAgain.Location = new System.Drawing.Point(112, 100);
            this.btnTryAgain.Name = "btnTryAgain";
            this.btnTryAgain.Size = new System.Drawing.Size(75, 23);
            this.btnTryAgain.TabIndex = 1;
            this.btnTryAgain.Text = "Play Again";
            this.btnTryAgain.UseVisualStyleBackColor = true;
            this.btnTryAgain.Click += new System.EventHandler(this.btnTryAgain_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(781, 551);
            this.Controls.Add(this.pnlWinLose);
            this.DoubleBuffered = true;
            this.Name = "GameForm";
            this.Text = "Atari Breakin";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameForm_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyDown);
            this.pnlWinLose.ResumeLayout(false);
            this.pnlWinLose.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblWinLose;
        private System.Windows.Forms.Panel pnlWinLose;
        private System.Windows.Forms.Button btnTryAgain;
    }
}

