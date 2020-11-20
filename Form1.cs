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
        private Dictionary<Button, Tile> tiles = new Dictionary<Button, Tile>();

        public Form1()
        {
            InitializeComponent();

            // Position the Form in the center of the screen.
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: resize the form properly after the buttons have been added.

            var previousPosition = new Point(0, 0);
            var buttonSize = new Size(40, 40);

            int rows = 10;
            int columns = 10;

            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    var button = new Button
                    {
                        Name = $"Tile{i}",
                        Text = $"{i.ToString()} {j.ToString()}",
                        Location = previousPosition,
                        Size = buttonSize
                    };

                    button.MouseClick += Button_MouseClick;

                    // TODO: generate until we reach a cap.
                    bool isMine = (new Random().Next(0, 2) == 1);

                    var tile = new Tile(previousPosition, isMine, button);
                    tiles.Add(button, tile);

                    // Move the next button by the size of the buttons.
                    previousPosition.X += buttonSize.Width;

                    // If the next button.X position goes out of bounds then make a new line.
                    if (previousPosition.X > ClientSize.Width + buttonSize.Width)
                    {
                        // New line.
                        previousPosition.Y += buttonSize.Height;

                        // Start from the beginning of the new line.
                        previousPosition.X = 0;
                    }

                    Controls.Add(button);
                }
            }
        }

        private void Button_MouseClick(object sender, MouseEventArgs e)
        {
            // If we clicked mouse1.
            if (e.Button == MouseButtons.Left)
            {
                // Get the button object.
                Button button = (Button)sender;

                // Find the KeyValuePair that corresponds to our button in tiles.
                foreach (KeyValuePair<Button, Tile> btn in tiles)
                {
                    // If the KeyValuePair we're checking against has our button, then we found it.
                    if (btn.Key.Equals(button))
                    {
                        // Get the tile object that corresponds to our Button.
                        Tile tile = btn.Value;

                        // DEBUG, REMOVE.
                        if (tile.isMine)
                            button.Text = "MINE";
                        else
                            button.Text = "NOT MINE";
                    }
                }
            }  
        }
    }
}
