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
            // Checking for medium and hard, else remains as easy which is default created from constructor
            // This also bypasses any invalid input by always defaulting to easy if it doesn't recognise the two other inputs
            if (radioMedium.Checked) gameOptions.setDifficulty(2);
            else if (radioHard.Checked) gameOptions.setDifficulty(3);

            // To Do: Pass in the gameOptions object and use it in the main game application
            new Form1().ShowDialog();
        }
    }
}
