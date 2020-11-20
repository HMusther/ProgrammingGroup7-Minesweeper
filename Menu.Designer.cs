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
            this.radioButtonEasy = new System.Windows.Forms.RadioButton();
            this.radioButtonMedium = new System.Windows.Forms.RadioButton();
            this.radioButtonHard = new System.Windows.Forms.RadioButton();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelDiff = new System.Windows.Forms.Label();
            this.groupBoxGameInfo = new System.Windows.Forms.GroupBox();
            this.labelTutorial = new System.Windows.Forms.Label();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.groupBoxGameInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButtonEasy
            // 
            this.radioButtonEasy.AutoSize = true;
            this.radioButtonEasy.Checked = true;
            this.radioButtonEasy.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonEasy.Location = new System.Drawing.Point(17, 96);
            this.radioButtonEasy.Name = "radioButtonEasy";
            this.radioButtonEasy.Size = new System.Drawing.Size(64, 21);
            this.radioButtonEasy.TabIndex = 1;
            this.radioButtonEasy.TabStop = true;
            this.radioButtonEasy.Text = "Easy";
            this.radioButtonEasy.UseVisualStyleBackColor = true;
            // 
            // radioButtonMedium
            // 
            this.radioButtonMedium.AutoSize = true;
            this.radioButtonMedium.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonMedium.Location = new System.Drawing.Point(17, 123);
            this.radioButtonMedium.Name = "radioButtonMedium";
            this.radioButtonMedium.Size = new System.Drawing.Size(84, 21);
            this.radioButtonMedium.TabIndex = 2;
            this.radioButtonMedium.Text = "Medium";
            this.radioButtonMedium.UseVisualStyleBackColor = true;
            // 
            // radioButtonHard
            // 
            this.radioButtonHard.AutoSize = true;
            this.radioButtonHard.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonHard.Location = new System.Drawing.Point(17, 150);
            this.radioButtonHard.Name = "radioButtonHard";
            this.radioButtonHard.Size = new System.Drawing.Size(64, 21);
            this.radioButtonHard.TabIndex = 3;
            this.radioButtonHard.Text = "Hard";
            this.radioButtonHard.UseVisualStyleBackColor = true;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Broadway", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(107, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(193, 27);
            this.labelTitle.TabIndex = 4;
            this.labelTitle.Text = "Minesweeper";
            // 
            // labelDiff
            // 
            this.labelDiff.AutoSize = true;
            this.labelDiff.Font = new System.Drawing.Font("Broadway", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDiff.Location = new System.Drawing.Point(14, 77);
            this.labelDiff.Name = "labelDiff";
            this.labelDiff.Size = new System.Drawing.Size(180, 16);
            this.labelDiff.TabIndex = 5;
            this.labelDiff.Text = "Difficulty (Grid Size)";
            // 
            // groupBoxGameInfo
            // 
            this.groupBoxGameInfo.Controls.Add(this.labelTutorial);
            this.groupBoxGameInfo.Location = new System.Drawing.Point(17, 177);
            this.groupBoxGameInfo.Name = "groupBoxGameInfo";
            this.groupBoxGameInfo.Size = new System.Drawing.Size(352, 153);
            this.groupBoxGameInfo.TabIndex = 6;
            this.groupBoxGameInfo.TabStop = false;
            this.groupBoxGameInfo.Text = "Game Info";
            // 
            // labelTutorial
            // 
            this.labelTutorial.Location = new System.Drawing.Point(7, 22);
            this.labelTutorial.Name = "labelTutorial";
            this.labelTutorial.Size = new System.Drawing.Size(339, 128);
            this.labelTutorial.TabIndex = 0;
            this.labelTutorial.Text = resources.GetString("labelTutorial.Text");
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(233, 118);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(78, 31);
            this.buttonPlay.TabIndex = 7;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 342);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.groupBoxGameInfo);
            this.Controls.Add(this.labelDiff);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.radioButtonHard);
            this.Controls.Add(this.radioButtonMedium);
            this.Controls.Add(this.radioButtonEasy);
            this.Name = "Menu";
            this.Text = "Menu";
            this.groupBoxGameInfo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonEasy;
        private System.Windows.Forms.RadioButton radioButtonMedium;
        private System.Windows.Forms.RadioButton radioButtonHard;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelDiff;
        private System.Windows.Forms.GroupBox groupBoxGameInfo;
        private System.Windows.Forms.Label labelTutorial;
        private System.Windows.Forms.Button buttonPlay;
    }
}