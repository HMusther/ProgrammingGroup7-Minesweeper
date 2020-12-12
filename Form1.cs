using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Media;

namespace Minesweeper
{
    public partial class Form1 : Form
    {
        private Dictionary<Button, Tile> tiles = new Dictionary<Button, Tile>();
        /// <summary>
        /// The size of our tiles on the Form.
        /// </summary>
        private readonly Size buttonSize = new Size(40, 40);

        /// <summary>
        /// A loaded image of the flag icon.
        /// </summary>
        private Image flagImage;

        /// <summary>
        /// Timer responsible for tracking time played.
        /// </summary>
        private Timer timer;

        /// <summary>
        /// Seconds since the user started playing.
        /// </summary>
        private int seconds;

        /// <summary>
        /// Minutes since the user started playing.
        /// </summary>
        private int minutes;

        private int flags;

        private int flagCap = 50;

        public Form1()
        {
            InitializeComponent();

            // Make the Form appear in the middle of your screen.
            StartPosition = FormStartPosition.CenterScreen;

            // TODO: embed the image so you don't need to search for it.
            // Search for the flag image.
            string path = Environment.CurrentDirectory + @"\flag_filled_40px.png";

            if (File.Exists(path))
                flagImage = Image.FromFile(path);

            // If flagImage is null and we're in debug mode, then throw an exception.
            Debug.Assert(flagImage != null, $"'flagImage' is null. Path: {path}");

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            seconds++;

            if (seconds == 60)
            {
                seconds = 0;
                minutes++;
            }

            // If seconds < 10 then format it like this: 01, 02, 03 etc...
            LabelTimer.Text = $"Time: {minutes}:{(seconds < 10 ? "0" : "")}{seconds}";
        }

        private void SetupTiles()
        {
            // TODO: scale the amount of tiles and mines up depending on difficulty. (DONE, needs testing)
            // TODO: make a cap for mines depending on difficulty. (DONE, needs testing)

            /*
             * Used for calculating the next position the button will be positioned.
             * Next position = previousPosition + buttonSize.
             */
            var previousPosition = new Point(0, 15);

            // The amount of tiles we want.
            //int buttons = 100;
            int buttons = GameOptions.Columns * GameOptions.Rows;
            var customFont = new Font("Sans Serif", 16f);

            for (int i = 0; i < buttons; i++)
            {
                var button = new Button
                {
                    Name = $"Tile{i}",
                    Text = "",
                    Location = previousPosition,
                    Size = buttonSize,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.Gray,
                    Font = customFont
                };

                // Subscribe to MouseClick to catch mouse1 clicks.
                button.MouseDown += Button_MouseDown;

                // Create a new tile object and append it to our dictionary.
                var tile = new Tile(button);
                tiles.Add(button, tile);

#if DEBUG       
                /* If in debug mode then show all mines.
                if (tile.isMine)
                    button.BackColor = Color.Red;*/
#endif
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

                // Add the button to the form.
                Controls.Add(button);
            }

            // TODO: automatically scale this, or have fixed values change depending on the difficulty.
            ClientSize = new Size(400, 398 + 15);
        }

        private void DisposeTiles()
        {
            // Remove all buttons from the UI.
            foreach (Button btn in tiles.Keys)
                Controls.Remove(btn);

            // Reset our tile storage.
            tiles.Clear();

            // TODO: remove the need to do this, have the tiles scale automatically.
            ClientSize = new Size(334, 327);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetupTiles();

            // If your remaining flags is less than 10, then add a 0 as the first digit to format it like this: 01, 02, 03 etc...
            LabelFlags.Text = $"Flags: {(flagCap - flags < 10 ? "0" : "")}{flagCap - flags}";
        }

        public void BombCheckAndfloodfill(Button button)
        {
            List<Button> buttons = tiles.Keys.ToList();
            /*
                If a condition is true below and a surrounding tile is a mine,
                this list gets added to, when all tiles surrounding have been 
                calculated the list is counted for the surrounding bombs and 
                this will determine the number on the tile.
            */
            Tile tile = default;
            foreach (KeyValuePair<Button, Tile> btn in tiles)
            {
                // If the KeyValuePair we're checking against has our button, then we found it.
                if (btn.Key.Equals(button))
                {
                    // Get the tile object that corresponds to our Button.
                    tile = btn.Value;
                }
            }

            List<Tile> MinesAround = new List<Tile>();

            // Get the button object.
            int index = buttons.IndexOf(button);

            // IMPORTANT
            // Here is logic for button anomalies below, these are positions that
            // must be treated differently becasuse they are on the edges of the grid

            // Tiles in relation to buttons
            Button TopLeft = buttons[index - 11];
            Button left = buttons[index - 1];
            Button BottomLeft = buttons[index + 9];
            Button above = buttons[index - 10];
            Button below = buttons[index + 10];
            Button right = buttons[index + 1];
            Button TopRight = buttons[index - 9];
            Button BottomRight = buttons[index + 11];

            // Adjacent tiles
            Tile TopLeftTile = tiles[TopLeft];
            Tile leftTile = tiles[left];
            Tile BottomLeftTile = tiles[BottomLeft];
            Tile aboveTile = tiles[above];
            Tile belowTile = tiles[below];
            Tile rightTile = tiles[right];
            Tile TopRightTile = tiles[TopRight];
            Tile BottomRightTile = tiles[BottomRight];

            //Checks Top Left Corner
            if (button == buttons[0])
            {
                if (rightTile.isMine == true) { MinesAround.Add(rightTile); }
                if (belowTile.isMine == true) { MinesAround.Add(belowTile); }
                if (BottomRightTile.isMine == true) { MinesAround.Add(BottomRightTile); }
            }
            //Checks Bottom Left Corner
            else if (button == buttons[90])
            {
                if (rightTile.isMine == true) { MinesAround.Add(rightTile); }
                if (aboveTile.isMine == true) { MinesAround.Add(aboveTile); }
                if (TopRightTile.isMine == true) { MinesAround.Add(TopRightTile); }
            }
            //Checks Top Right Corner
            else if (button == buttons[9])
            {
                if (leftTile.isMine == true) { MinesAround.Add(leftTile); }
                if (belowTile.isMine == true) { MinesAround.Add(belowTile); }
                if (BottomLeftTile.isMine == true) { MinesAround.Add(BottomLeftTile); }
            }
            //Checks Bottom Right Corner
            else if (button == buttons[99])
            {
                if (leftTile.isMine == true) { MinesAround.Add(leftTile); }
                if (aboveTile.isMine == true) { MinesAround.Add(aboveTile); }
                if (TopLeftTile.isMine == true) { MinesAround.Add(TopLeftTile); }
            }
            // Top row
            else if (button == buttons[1] || button == buttons[2] || button == buttons[3] || button == buttons[4] ||
                     button == buttons[5] || button == buttons[6] || button == buttons[7] || button == buttons[8])
            {
                if (belowTile.isMine == true) { MinesAround.Add(belowTile); }
                if (leftTile.isMine == true) { MinesAround.Add(leftTile); }
                if (rightTile.isMine == true) { MinesAround.Add(rightTile); }
                if (BottomLeftTile.isMine == true) { MinesAround.Add(BottomLeftTile); }
                if (BottomRightTile.isMine == true) { MinesAround.Add(BottomRightTile); }
            }
            // Bottom row
            else if (button == buttons[91] || button == buttons[92] || button == buttons[93] || button == buttons[94] ||
                     button == buttons[95] || button == buttons[96] || button == buttons[97] || button == buttons[98])
            {
                if (aboveTile.isMine == true) { MinesAround.Add(aboveTile); }
                if (leftTile.isMine == true) { MinesAround.Add(leftTile); }
                if (rightTile.isMine == true) { MinesAround.Add(rightTile); }
                if (TopLeftTile.isMine == true) { MinesAround.Add(TopLeftTile); }
                if (TopRightTile.isMine == true) { MinesAround.Add(TopRightTile); }
            }
            // Left column
            else if (button == buttons[10] || button == buttons[20] || button == buttons[30] || button == buttons[40] ||
                     button == buttons[50] || button == buttons[60] || button == buttons[70] || button == buttons[80])
            {
                if (aboveTile.isMine == true) { MinesAround.Add(aboveTile); }
                if (rightTile.isMine == true) { MinesAround.Add(rightTile); }
                if (TopRightTile.isMine == true) { MinesAround.Add(TopRightTile); }
                if (belowTile.isMine == true) { MinesAround.Add(belowTile); }
            }
            // Right column
            else if (button == buttons[19] || button == buttons[29] || button == buttons[39] || button == buttons[49] ||
                     button == buttons[59] || button == buttons[69] || button == buttons[79] || button == buttons[89])
            {
                if (aboveTile.isMine == true) { MinesAround.Add(aboveTile); }
                if (belowTile.isMine == true) { MinesAround.Add(belowTile); }
                if (leftTile.isMine == true) { MinesAround.Add(leftTile); }
                if (BottomLeftTile.isMine == true) { MinesAround.Add(BottomLeftTile); }
            }
            else
            {
                if (leftTile.isMine == true) { MinesAround.Add(leftTile); }
                if (TopLeftTile.isMine == true) { MinesAround.Add(TopLeftTile); }
                if (BottomLeftTile.isMine == true) { MinesAround.Add(BottomLeftTile); }
                if (aboveTile.isMine == true) { MinesAround.Add(aboveTile); }
                if (belowTile.isMine == true) { MinesAround.Add(belowTile); }
                if (TopRightTile.isMine == true) { MinesAround.Add(TopRightTile); }
                if (rightTile.isMine == true) { MinesAround.Add(rightTile); }
                if (BottomRightTile.isMine == true) { MinesAround.Add(BottomRightTile); }
            }

            while (true)
            {
                if
                (
                    leftTile.isMine == false && TopLeftTile.isMine == false &&
                    BottomLeftTile.isMine == false && aboveTile.isMine == false &&
                    belowTile.isMine == false && TopRightTile.isMine == false &&
                    rightTile.isMine == false && BottomRightTile.isMine == false
                )
                {
                    left.Visible = false;
                    TopLeft.Visible = false;
                    BottomLeft.Visible = false;
                    above.Visible = false;
                    below.Visible = false;
                    TopRight.Visible = false;
                    right.Visible = false;
                    BottomRight.Visible = false;
                    BombCheckAndfloodfill(left);
                    BombCheckAndfloodfill(TopLeft);
                    BombCheckAndfloodfill(BottomLeft);
                    BombCheckAndfloodfill(above);
                    BombCheckAndfloodfill(below);
                    BombCheckAndfloodfill(TopRight);
                    BombCheckAndfloodfill(right);
                    BombCheckAndfloodfill(BottomRight);
                }
            }
        }
        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the button object.
            Button button = (Button)sender;

            Tile tile = default;

            // Find the KeyValuePair that corresponds to our button in tiles.
            foreach (KeyValuePair<Button, Tile> btn in tiles)
            {
                // If the KeyValuePair we're checking against has our button, then we found it.
                if (btn.Key.Equals(button))
                {
                    // Get the tile object that corresponds to our Button.
                    tile = btn.Value;
                }

                // Add the button to the form.
                Controls.Add(button);
            }

            // If we clicked mouse1.
            if (e.Button == MouseButtons.Left)
            {
                BombCheckAndfloodfill(button);

                // Game loss mechanics
                if (tile.isMine)
                {
                    button.Image = null;
                    button.BackColor = Color.Red;
                    SoundPlayer bombDetonate = new SoundPlayer("bombDetonate.wav");
                    // Play sound bombs detonated
                    bombDetonate.Play();
                    // Label Instead of messagebox to stop the system sounds?
                    // Tell the user that they lost.
                    MessageBox.Show("You lost.", "Minesweeper", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset the play area.
                    DisposeTiles();
                    SetupTiles();

                    // Reset the clock.
                    seconds = 0;
                    minutes = 0;
                }
                else
                {
                    tile.Click();

                    button.BackColor = Color.Green;
                }
            }
            else if (e.Button == MouseButtons.Right && !tile.HasBeenClicked)
            {
                tile.HasBeenFlagged = !tile.HasBeenFlagged;

                if (tile.HasBeenFlagged)
                {
                    button.Image = flagImage;
                    flags++;
                }
                else
                {
                    button.Image = null;
                    flags--;
                }

                // If your remaining flags is less than 10, then add a 0 as the first digit to format it like this: 01, 02, 03 etc...
                LabelFlags.Text = $"Flags: {(flagCap - flags < 10 ? "0" : "")}{flagCap - flags}";
            }
        }
    }
}
