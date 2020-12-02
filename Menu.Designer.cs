
namespace Minesweeper
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.lblTitle = new System.Windows.Forms.Label();
            this.radioEasy = new System.Windows.Forms.RadioButton();
            this.radioMedium = new System.Windows.Forms.RadioButton();
            this.radioHard = new System.Windows.Forms.RadioButton();
            this.groupBoxDifficulty = new System.Windows.Forms.GroupBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBoxInformation = new System.Windows.Forms.GroupBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.groupBoxDifficulty.SuspendLayout();
            this.groupBoxInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Britannic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(342, 23);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Minesweeper";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // radioEasy
            // 
            this.radioEasy.AutoSize = true;
            this.radioEasy.Checked = true;
            this.radioEasy.Location = new System.Drawing.Point(6, 21);
            this.radioEasy.Name = "radioEasy";
            this.radioEasy.Size = new System.Drawing.Size(60, 21);
            this.radioEasy.TabIndex = 1;
            this.radioEasy.TabStop = true;
            this.radioEasy.Text = "Easy";
            this.radioEasy.UseVisualStyleBackColor = true;
            // 
            // radioMedium
            // 
            this.radioMedium.AutoSize = true;
            this.radioMedium.Location = new System.Drawing.Point(6, 46);
            this.radioMedium.Name = "radioMedium";
            this.radioMedium.Size = new System.Drawing.Size(78, 21);
            this.radioMedium.TabIndex = 2;
            this.radioMedium.Text = "Medium";
            this.radioMedium.UseVisualStyleBackColor = true;
            // 
            // radioHard
            // 
            this.radioHard.AutoSize = true;
            this.radioHard.Location = new System.Drawing.Point(6, 73);
            this.radioHard.Name = "radioHard";
            this.radioHard.Size = new System.Drawing.Size(60, 21);
            this.radioHard.TabIndex = 3;
            this.radioHard.Text = "Hard";
            this.radioHard.UseVisualStyleBackColor = true;
            // 
            // groupBoxDifficulty
            // 
            this.groupBoxDifficulty.Controls.Add(this.radioMedium);
            this.groupBoxDifficulty.Controls.Add(this.radioHard);
            this.groupBoxDifficulty.Controls.Add(this.radioEasy);
            this.groupBoxDifficulty.Location = new System.Drawing.Point(12, 54);
            this.groupBoxDifficulty.Name = "groupBoxDifficulty";
            this.groupBoxDifficulty.Size = new System.Drawing.Size(200, 100);
            this.groupBoxDifficulty.TabIndex = 4;
            this.groupBoxDifficulty.TabStop = false;
            this.groupBoxDifficulty.Text = "Difficulty Selector";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(258, 68);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(80, 80);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // groupBoxInformation
            // 
            this.groupBoxInformation.Controls.Add(this.labelDescription);
            this.groupBoxInformation.Enabled = false;
            this.groupBoxInformation.Location = new System.Drawing.Point(12, 171);
            this.groupBoxInformation.Name = "groupBoxInformation";
            this.groupBoxInformation.Size = new System.Drawing.Size(342, 92);
            this.groupBoxInformation.TabIndex = 6;
            this.groupBoxInformation.TabStop = false;
            this.groupBoxInformation.Text = "Information";
            this.groupBoxInformation.UseWaitCursor = true;
            // 
            // labelDescription
            // 
            this.labelDescription.Location = new System.Drawing.Point(7, 22);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(329, 55);
            this.labelDescription.TabIndex = 0;
            this.labelDescription.Text = "Game created by Ben Smith, Harry Musther, Ahmed Saaed and Kieran Foy.";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 285);
            this.Controls.Add(this.groupBoxInformation);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBoxDifficulty);
            this.Controls.Add(this.lblTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Menu";
            this.Text = "Menu";
            this.groupBoxDifficulty.ResumeLayout(false);
            this.groupBoxDifficulty.PerformLayout();
            this.groupBoxInformation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.RadioButton radioEasy;
        private System.Windows.Forms.RadioButton radioMedium;
        private System.Windows.Forms.RadioButton radioHard;
        private System.Windows.Forms.GroupBox groupBoxDifficulty;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox groupBoxInformation;
        private System.Windows.Forms.Label labelDescription;
    }
}