
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Minesweeper
{
    public class GameOptions
    {
        // Static class because we will never need more than once instance of it.

        // TODO: Write difficulty to a file and remember for next time

        public enum Difficulty
        {
            EASY = 1,
            MEDIUM,
            HARD
        }

        /*
         * Properties are always written in PascalCase.
         * Any class can get the value from the variable, but
         * the value can only be set in this class.
         */
        public static Difficulty _Difficulty { get; private set; }
        public static int Columns { get; private set; }
        public static int Rows { get; private set; }
        public static int BombCount { get; set; }
        public static int BombLimit { get; set; }

        public static int nonBombCount { get; set; }

        public static int numberOfClicks { get; set; }
        public static string username { get; set; }

        /// <summary>
        /// Set the difficulty of the next game, and write it to a file.
        /// </summary>
        /// <param name="difficulty">Your desired difficulty.</param>
        public static void SetDifficulty(Difficulty difficulty)
        {
            switch (difficulty)
            {
                case Difficulty.EASY:
                    _Difficulty = difficulty;
                    Columns = 10;
                    Rows = 10;
                    BombLimit = 40;
                    break;
                case Difficulty.MEDIUM:
                    _Difficulty = difficulty;
                    Columns = 15;
                    Rows = 15;
                    BombLimit = 30;
                    break;
                case Difficulty.HARD:
                    _Difficulty = difficulty;
                    Columns = 20;
                    Rows = 20;
                    BombLimit = 50;
                    break;
                // Unrecognised difficulty, default to easy mode.
                default:
                    _Difficulty = Difficulty.EASY;
                    Columns = 10;
                    Rows = 10;
                    BombLimit = 40;
                    break;
            }

            SaveDifficulty();
        }

        /// <summary>
        /// Write the current difficulty to a file.
        /// </summary>
        private static void SaveDifficulty()
        {
            string path = "difficulty.txt";
            string content = "" + _Difficulty;
            File.WriteAllText(path, content);
        }
    }
}