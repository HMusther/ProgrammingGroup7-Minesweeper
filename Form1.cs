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
    public partial class Form1 : Form
    {
        Tile[] tiles;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var previousPosition = new Point(0, 0);
            var buttonSize = new Size(25, 25);

            int rows = 12;
            int columns = 13;

            for (int i = 0; i <= columns; i++)
            {
                for (int j = 0; j <= rows; j++)
                {
                    var button = new Button
                    {
                        Name = $"Button{i}",
                        Text = "",
                        Location = previousPosition,
                        Size = buttonSize
                    };

                    var tile = new Tile(previousPosition, false, button);

                    // Move the next button by the size of the buttons.
                    previousPosition.X += buttonSize.Width;

                    if (previousPosition.X > ClientSize.Width + buttonSize.Width)
                    {
                        // New line.
                        previousPosition.Y += buttonSize.Height;
                        // Start from the beginning.
                        previousPosition.X = 0;
                    }

                    Controls.Add(button);
                }
            }
        }
    }
}
