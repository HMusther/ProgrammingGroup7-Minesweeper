using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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

        private void Menu_Load(object sender, EventArgs e)
        {
            string path = "difficulty.txt";
            if (File.Exists(path))
            {
                string difficulty = File.ReadAllText(path).Trim();
                switch (difficulty)
                {
                    case "EASY":
                        radioEasy.Checked = true;
                        break;
                    case "MEDIUM":
                        radioMedium.Checked = true;
                        break;
                    case "HARD":
                        radioHard.Checked = true;
                        break;
                    default:
                        break;
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (radioEasy.Checked) GameOptions.SetDifficulty(GameOptions.Difficulty.EASY);
            else if (radioMedium.Checked) GameOptions.SetDifficulty(GameOptions.Difficulty.MEDIUM);
            else if (radioHard.Checked) GameOptions.SetDifficulty(GameOptions.Difficulty.HARD);

            GameOptions.username = usernameInput.Text;

            //Hide menu
            Hide();
            new Form1().ShowDialog();
        }

        private void btnLeaderboard_Click(object sender, EventArgs e)
        {
            new Leaderboard().ShowDialog();
        }
    }
}
