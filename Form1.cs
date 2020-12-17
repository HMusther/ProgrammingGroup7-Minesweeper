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

        private SoundPlayer bombDetonate = new SoundPlayer("bombDetonate.wav");

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

        private List<Tile> GetTileGrid(Tile tile)
        {
            List<Tile> grid = new List<Tile>();

            foreach (Tile t in tiles.Values)
            {
                // Move one tile to the right.
                int x = t.Position.X - buttonSize.Width;

                // Same Y position, so we don't find all tiles that are on the same X but not Y.
                int y = t.Position.Y;

                // If the X is one to the right, but the Y is the same.
                if (x == tile.Position.X && y == tile.Position.Y)
                {
                    //t.button.Text = "right";
                    grid.Add(t);
                }

                // Move one tile to the left.
                x = t.Position.X + buttonSize.Width;

                // If the X is one to the left, but the Y is the same.
                if (x == tile.Position.X && y == tile.Position.Y)
                {
                    //t.button.Text = "left";
                    grid.Add(t);
                }

                x = t.Position.X;

                // Move one tile up.
                y = t.Position.Y + buttonSize.Height;

                // If the X is the same, but the Y is one up.
                if (x == tile.Position.X && y == tile.Position.Y)
                {
                    //t.button.Text = "up";
                    grid.Add(t);
                }

                // Move one tile down.
                y = t.Position.Y - buttonSize.Height;

                // If the X is the same, but the Y is one up.
                if (x == tile.Position.X && y == tile.Position.Y)
                {
                    //t.button.Text = "down";
                    grid.Add(t);
                }

                // Move one tile to the left.
                x = t.Position.X + buttonSize.Width;

                // Move one tile up.
                y = t.Position.Y + buttonSize.Height;

                // If the X is one to the left, and the Y is one up.
                if (x == tile.Position.X && y == tile.Position.Y)
                {
                    //t.button.Text = "top left";
                    grid.Add(t);
                }

                // Move one tile to the right.
                x = t.Position.X - buttonSize.Width;

                // If the X is one to the right, and the Y is one up.
                if (x == tile.Position.X && y == tile.Position.Y)
                {
                    //t.button.Text = "top right";
                    grid.Add(t);
                }

                // Move one tile to the left.
                x = t.Position.X + buttonSize.Width;

                // Move one tile down.
                y = t.Position.Y - buttonSize.Height;

                // If the X is one to the left, and the Y is one down.
                if (x == tile.Position.X && y == tile.Position.Y)
                {
                    //t.button.Text = "bot left";
                    grid.Add(t);
                }

                // Move one tile to the right.
                x = t.Position.X - buttonSize.Width;

                // If the X is one to the right, and the Y is one down.
                if (x == tile.Position.X && y == tile.Position.Y)
                {
                    //t.button.Text = "bot right";
                    grid.Add(t);
                }
            }

            return grid;
        }

        private int GetTileNumber(Tile tile)
        {
            var tileGrid = GetTileGrid(tile);
            int mineCount = 0;

            foreach (Tile t in tileGrid)
                if (t.isMine)
                    mineCount++;

            return mineCount;
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
            LabelTimer.Text = $"{minutes}:{(seconds < 10 ? "0" : "")}{seconds}";
            LabelClicks.Text = $"{GameOptions.numberOfClicks}";
            LabelNonBombs.Text = $"{GameOptions.nonBombCount}";
        }

        private void SetupTiles()
        {
            // TODO: scale the amount of tiles and mines up depending on difficulty.
            // TODO: make a cap for mines depending on difficulty.

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
                /* If in debug mode then show all mines.*/
                if (tile.isMine)
                    button.BackColor = Color.Red;
#endif
                // Move the next button by the size of the buttons.
                previousPosition.X += buttonSize.Width;

                // If the next button.X position goes out of bounds then make a new line.
                if (previousPosition.X > GameOptions.Columns * (buttonSize.Width - 1))
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
            if(GameOptions._Difficulty == GameOptions.Difficulty.EASY)
            {
                ClientSize = new Size(400, 398 + 15);
            }
            else if(GameOptions._Difficulty == GameOptions.Difficulty.MEDIUM)
            {
                ClientSize = new Size(600, 600 + 15);
            }
            else if (GameOptions._Difficulty == GameOptions.Difficulty.HARD)
            {
                ClientSize = new Size(720, 720 + 15);
            }
        }

        private void DisposeTiles()
        {
            // Remove all buttons from the UI.
            foreach (Button btn in tiles.Keys)
                Controls.Remove(btn);

            // Reset our tile storage.
            tiles.Clear();
            GameOptions.nonBombCount = 0;
            GameOptions.numberOfClicks = 0;
            GameOptions.BombCount = 0;

            // TODO: automatically scale this, or have fixed values change depending on the difficulty.
            if (GameOptions._Difficulty == GameOptions.Difficulty.EASY)
            {
                ClientSize = new Size(400, 398 + 15);
            }
            else if (GameOptions._Difficulty == GameOptions.Difficulty.MEDIUM)
            {
                ClientSize = new Size(600, 600 + 15);
            }
            else if (GameOptions._Difficulty == GameOptions.Difficulty.HARD)
            {
                ClientSize = new Size(720, 720 + 15);
            }
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

            // If we clicked mouse1.
            if (e.Button == MouseButtons.Left)
            {
                if (tile.isMine)
                {
                    button.Image = null;
                    button.BackColor = Color.Red;


                    // Try play sound bombs detonated avoid error
                    try { bombDetonate.Play(); }
                    catch { throw; }
                    // Tell the user that they lost.
                    MessageBox.Show("You lost.", "Minesweeper", MessageBoxButtons.OK);

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

                    int mineCount = GetTileNumber(tile);

                    if (mineCount > 0)
                        tile.button.Text = mineCount.ToString();

                    button.BackColor = Color.Green;

                    if (GameOptions.numberOfClicks == GameOptions.nonBombCount)
                    {
                        Leaderboard leaderboard = new Leaderboard();
                        leaderboard.GetLeaderboard();

                        string time = LabelTimer.Text;

                        MessageBox.Show("You Won!", "Minesweeper", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        (bool, int) qualify = leaderboard.CheckIfQualifies(time);

                        KeyValuePair<string, string> userInformation = new KeyValuePair<string, string>(GameOptions.username, time);

                        if (qualify.Item1)
                        {
                            leaderboard.InsertItem(qualify.Item2, userInformation);
                        }

                        Close();
                    }
                }
            }
            else if (e.Button == MouseButtons.Right && !tile.HasBeenClicked && flags < flagCap)
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

        private void LabelTimer_Click(object sender, EventArgs e)
        {
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            DisposeTiles();
        }
    }
}
