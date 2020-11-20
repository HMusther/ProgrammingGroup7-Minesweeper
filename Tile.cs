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
        public Tile(Point position, bool isMine, Button button)
        {
            this.position = position;
            this.isMine = isMine;
            this.button = button;
        }

        public readonly Button button;
        public readonly Point position;
        public readonly bool isMine;
    }
}
