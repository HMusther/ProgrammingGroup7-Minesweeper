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
            this.SuspendLayout();
            // 
            // LabelTimer
            // 
            this.LabelTimer.AutoSize = true;
            this.LabelTimer.Location = new System.Drawing.Point(5, 0);
            this.LabelTimer.Name = "LabelTimer";
            this.LabelTimer.Size = new System.Drawing.Size(60, 13);
            this.LabelTimer.TabIndex = 0;
            this.LabelTimer.Text = "Timer: 0:00";
            // 
            // LabelFlags
            // 
            this.LabelFlags.AutoSize = true;
            this.LabelFlags.Location = new System.Drawing.Point(71, 0);
            this.LabelFlags.Name = "LabelFlags";
            this.LabelFlags.Size = new System.Drawing.Size(44, 13);
            this.LabelFlags.TabIndex = 1;
            this.LabelFlags.Text = "Flags: 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 327);
            this.Controls.Add(this.LabelFlags);
            this.Controls.Add(this.LabelTimer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
    }
}

