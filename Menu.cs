using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Menu : Form
    {
        // Attributes
        GameOptions gameOptions = new GameOptions();

        // Functions
        public Menu()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            
            if (radioEasy.Checked) GameOptions.SetDifficulty(GameOptions.Difficulty.EASY);
            else if (radioMedium.Checked) GameOptions.SetDifficulty(GameOptions.Difficulty.MEDIUM);
            else if (radioHard.Checked) GameOptions.SetDifficulty(GameOptions.Difficulty.HARD);

            // To Do: Pass in the gameOptions object and use it in the main game application
            new Form1().ShowDialog();
        }
    }
}
