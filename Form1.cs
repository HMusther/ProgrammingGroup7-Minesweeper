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
            List<Button> buttons = tiles.Keys.ToList();
            /*
                If a condition is true below and a surrounding tile is a mine,
                this list gets added to, when all tiles surrounding have been 
                calculated the list is counted for the surrounding bombs and 
                this will determine the number on the tile.
            */
            List<Tile> MinesAround = new List<Tile>();

            // Get the button object.
            //Button button = (Button)sender;
            //Tile tile = tiles[button];
            int index = buttons.IndexOf(button);

            // IMPORTANT mine surrounding logic
            // Here is logic for button anomalies below, these are positions that
            // must be treated differently becasuse they are on the edges of the grid
            // IMPORTANT difficulty scaling logic
            // In order for it to be compatible with different grid sizes, 
            // values will be multiplied by the neccessary value to reach the new grid size
            // eg: Easy is a 10 x 10 grid so 100, in medium it is 15 x 15 so 225 therefore all values must be times by 2.25 and rounded
            // Corners
            var Corners = new List<Button>();
            Button TopLeftCorner = buttons[0];
            Button TopRightCorner = buttons[10];
            Button BottomLeftCorner = buttons[90];
            Button BottomRightCorner = buttons[100];
            Corners.Add(TopLeftCorner);
            Corners.Add(TopRightCorner);
            Corners.Add(BottomLeftCorner);
            Corners.Add(BottomRightCorner);

            // Top row
            var TopRow = new List<Button>();
            Button TopRowOne = buttons[1];
            Button TopRowTwo = buttons[2];
            Button TopRowThree = buttons[3];
            Button TopRowFour = buttons[4];
            Button TopRowFive = buttons[5];
            Button TopRowSix = buttons[6];
            Button TopRowSeven = buttons[7];
            Button TopRowEight = buttons[8];
            Button TopRowNine = buttons[9];
            TopRow.Add(TopRowOne);
            TopRow.Add(TopRowTwo);
            TopRow.Add(TopRowThree);
            TopRow.Add(TopRowFour);
            TopRow.Add(TopRowFive);
            TopRow.Add(TopRowSix);
            TopRow.Add(TopRowSeven);
            TopRow.Add(TopRowEight);
            TopRow.Add(TopRowNine);
            // Bottom row
            var BottomRow = new List<Button>();
            Button BottomRowOne = buttons[91];
            Button BottomRowTwo = buttons[92];
            Button BottomRowThree = buttons[93];
            Button BottomRowFour = buttons[94];
            Button BottomRowFive = buttons[95];
            Button BottomRowSix = buttons[96];
            Button BottomRowSeven = buttons[97];
            Button BottomRowEight = buttons[98];
            Button BottomRowNine = buttons[99];
            BottomRow.Add(BottomRowOne);
            BottomRow.Add(BottomRowTwo);
            BottomRow.Add(BottomRowThree);
            BottomRow.Add(BottomRowFour);
            BottomRow.Add(BottomRowFive);
            BottomRow.Add(BottomRowSix);
            BottomRow.Add(BottomRowSeven);
            BottomRow.Add(BottomRowEight);
            BottomRow.Add(BottomRowNine);
            // Left column
            var LeftColumn = new List<Button>();
            Button LeftColOne = buttons[11];
            Button LeftColTwo = buttons[21];
            Button LeftColThree = buttons[31];
            Button LeftColFour = buttons[41];
            Button LeftColFive = buttons[51];
            Button LeftColSix = buttons[61];
            Button LeftColSeven = buttons[71];
            Button LeftColEight = buttons[81];
            LeftColumn.Add(LeftColOne);
            LeftColumn.Add(LeftColTwo);
            LeftColumn.Add(LeftColThree);
            LeftColumn.Add(LeftColFour);
            LeftColumn.Add(LeftColFive);
            LeftColumn.Add(LeftColSix);
            LeftColumn.Add(LeftColSix);
            LeftColumn.Add(LeftColSeven);
            LeftColumn.Add(LeftColEight);
            // Right column
            var RightColumn = new List<Button>();
            Button RightColOne = buttons[20];
            Button RightColTwo = buttons[30];
            Button RightColThree = buttons[40];
            Button RightColFour = buttons[50];
            Button RightColFive = buttons[60];
            Button RightColSix = buttons[70];
            Button RightColSeven = buttons[80];
            Button RightColEight = buttons[90];
            RightColumn.Add(RightColOne);
            RightColumn.Add(RightColTwo);
            RightColumn.Add(RightColThree);
            RightColumn.Add(RightColFour);
            RightColumn.Add(RightColFive);
            RightColumn.Add(RightColSix);
            RightColumn.Add(RightColSeven);
            RightColumn.Add(RightColEight);
            // Tiles in relation to buttons
            Button TopLeft = buttons[index - 11];
            Button BottomLeft = buttons[index + 9];
            Button left = buttons[index - 1];
            Button above = buttons[index - 10];
            Button below = buttons[index + 10];
            Button right = buttons[index + 1];
            Button TopRight = buttons[index - 9];
            Button BottomRight = buttons[index + 11];

            // Adjacent tiles
            Tile leftTile = tiles[left];
            Tile TopLeftTile = tiles[TopLeft];
            Tile BottomLeftTile = tiles[BottomLeft];
            Tile aboveTile = tiles[above];
            Tile belowTile = tiles[below];
            Tile TopRightTile = tiles[TopRight];
            Tile rightTile = tiles[right];
            Tile BottomRightTile = tiles[BottomRight];

            // Checks for mines and then adding if one is found
            if (leftTile.isMine == true) MinesAround.Add(leftTile);
            if (TopLeftTile.isMine == true) MinesAround.Add(TopLeftTile);
            if (BottomLeftTile.isMine == true) MinesAround.Add(BottomLeftTile);
            if (aboveTile.isMine == true) MinesAround.Add(aboveTile);
            if (belowTile.isMine == true) MinesAround.Add(belowTile);
            if (TopRightTile.isMine == true) MinesAround.Add(TopRightTile);
            if (rightTile.isMine == true) MinesAround.Add(rightTile);
            if (BottomRightTile.isMine == true) MinesAround.Add(BottomRightTile);

            // If we clicked mouse1.
            if (e.Button == MouseButtons.Left)
            {
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
