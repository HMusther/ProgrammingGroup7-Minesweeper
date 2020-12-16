using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    class Tile
    {
        public Tile(Button button)
        {
            this.button = button;

            // If the bomb count is lower than or equal to the bomb limit, 
            // carry on creating bombs until limit reached.
            if (GameOptions.BombCount <= GameOptions.BombLimit)
            {
                /*
                    * If the randomly generated number = 1 then return true,
                    * otherwise return false.
                    * 
                    * 30% chance to be true.
                    * 
                    * (int)DateTime.Now.Ticks guarantees that we have a random seed.
                */
                isMine = new Random((int)DateTime.Now.Ticks).Next(0, 3) == 1;
                // When mine has been successfully created, increment the amount of bombs in grid
                if (isMine)
                {
                    GameOptions.BombCount++;
                }
                else
                {
                    GameOptions.nonBombCount++;
                }
            }
        }

        public void Click()
        {
            if (!HasBeenClicked)
            {
                GameOptions.numberOfClicks++;
            }

            HasBeenClicked = true;
        }

        /// <summary>
        /// The button on the Form which this Tile represents.
        /// </summary>
        public readonly Button button;

        public bool HasBeenClicked { get; private set; }

        public bool HasBeenFlagged { get; set; }

        /// <summary>
        /// The Tile's location on the Form.
        /// </summary>
        public Point Position => button.Location;

        public readonly bool isMine;
    }
}
