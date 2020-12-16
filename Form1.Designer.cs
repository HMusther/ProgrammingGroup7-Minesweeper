namespace Minesweeper
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
            this.LabelTimer = new System.Windows.Forms.Label();
            this.LabelFlags = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LabelClicks = new System.Windows.Forms.Label();
            this.LabelNonBombs = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LabelTimer
            // 
            this.LabelTimer.AutoSize = true;
            this.LabelTimer.Location = new System.Drawing.Point(51, 0);
            this.LabelTimer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelTimer.Name = "LabelTimer";
            this.LabelTimer.Size = new System.Drawing.Size(36, 17);
            this.LabelTimer.TabIndex = 0;
            this.LabelTimer.Text = "0:00";
            this.LabelTimer.Click += new System.EventHandler(this.LabelTimer_Click);
            // 
            // LabelFlags
            // 
            this.LabelFlags.AutoSize = true;
            this.LabelFlags.Location = new System.Drawing.Point(95, 0);
            this.LabelFlags.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelFlags.Name = "LabelFlags";
            this.LabelFlags.Size = new System.Drawing.Size(58, 17);
            this.LabelFlags.TabIndex = 1;
            this.LabelFlags.Text = "Flags: 0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Time: ";
            // 
            // LabelClicks
            // 
            this.LabelClicks.AutoSize = true;
            this.LabelClicks.Location = new System.Drawing.Point(193, 0);
            this.LabelClicks.Name = "LabelClicks";
            this.LabelClicks.Size = new System.Drawing.Size(0, 17);
            this.LabelClicks.TabIndex = 3;
            // 
            // LabelNonBombs
            // 
            this.LabelNonBombs.AutoSize = true;
            this.LabelNonBombs.Location = new System.Drawing.Point(229, 0);
            this.LabelNonBombs.Name = "LabelNonBombs";
            this.LabelNonBombs.Size = new System.Drawing.Size(0, 17);
            this.LabelNonBombs.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 402);
            this.Controls.Add(this.LabelNonBombs);
            this.Controls.Add(this.LabelClicks);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LabelFlags);
            this.Controls.Add(this.LabelTimer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Minesweeper";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelTimer;
        private System.Windows.Forms.Label LabelFlags;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LabelClicks;
        private System.Windows.Forms.Label LabelNonBombs;
    }
}

