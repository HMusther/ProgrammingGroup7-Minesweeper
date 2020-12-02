using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class GameOptions
    {
        // Attributes
        // 1 = easy, 2 = medium, 3 = hard
        private int difficulty;
        private int columns;
        private int rows;
        private int bombCount;

        // Constructor defaults to easy mode
        public GameOptions()
        {
            difficulty = 1;
            columns = 10;
            rows = 10;
            bombCount = 10;
        }
        // Functions
        public void setDifficulty(int difficulty)
        {
            switch (difficulty)
            {
                // Easy
                case 1:
                    this.difficulty = difficulty;
                    columns = 10;
                    rows = 10;
                    bombCount = 10;
                    break;
                // Medium
                case 2:
                    this.difficulty = difficulty;
                    columns = 15;
                    rows = 15;
                    bombCount = 30;
                    break;
                // Hard
                case 3:
                    this.difficulty = difficulty;
                    columns = 20;
                    rows = 20;
                    bombCount = 50;
                    break;
                default:
                    break;
            }
        }
        public int getDifficulty()
        {
            return difficulty;
        }

        public int getColumns()
        {
            return columns;
        }

        public int getRows()
        {
            return rows;
        }

        public int getBombCount()
        {
            return bombCount;
        }
    }
}
