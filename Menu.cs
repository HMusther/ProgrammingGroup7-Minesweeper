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
            if (radioEasy.Checked)
            {
                gameOptions.setDifficulty(1);
            }
            else if (radioMedium.Checked)
            {
                gameOptions.setDifficulty(2);
            }
            else if (radioHard.Checked)
            {
                gameOptions.setDifficulty(3);
            }

            new Form1().ShowDialog();
        }
    }
}
