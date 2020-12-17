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
    public partial class Leaderboard : Form
    {

        private string path = "Leaderboard.txt";
        private List<KeyValuePair<string, string>> userTimes = new List<KeyValuePair<string, string>>();


        public Leaderboard()
        {
            InitializeComponent();
        }

        private void Leaderboard_Load(object sender, EventArgs e)
        {
            GetLeaderboard();
            FillLeaderboard();

        }

        // Insert the new user time into the userTimes list
        // Moves each value down the list
        public void InsertItem(int pos, KeyValuePair<string, string> userData)
        {
            int n = userTimes.Count - 1;
  
            for (int i = n; i > pos; i--)
                userTimes[i] = userTimes[i - 1];
            
            userTimes[pos] = userData;

            /*
            for (int i = pos; i <= userTimes.Count - 1; i++)
            {
                if (i == pos)
                {
                    itemBackup = userTimes[i];
                    userTimes[i] = userData;

                }
                else if (i == userTimes.Count - 1)
                {
                    userTimes[i] = userData;
                }
                else
                {
                    itemBackup2 = userTimes[i];
                    //userTimes[i] = itemBackup;

                }
            }
            */
            // Commits changes to the text file "Leaderboard.txt";
            WriteToLeaderboardFile();

        }

        public void WriteToLeaderboardFile()
        {
            // Creates a new string containing formatted leaderboard
            string newLeaderboard = "";
            foreach (KeyValuePair<string, string> userScore in userTimes)
            {
                newLeaderboard += $"{userScore.Key}/{userScore.Value}\n";
            }

            // Writes changes to the file.
            File.WriteAllText(path, newLeaderboard.TrimEnd());


        }

        public void FillLeaderboard()
        {
            // Fills the leaderboard
            TopOne.Text = $"1. {userTimes[0].Key} : {userTimes[0].Value}";
            TopTwo.Text = $"2. {userTimes[1].Key} : {userTimes[1].Value}";
            TopThree.Text = $"3. {userTimes[2].Key} : {userTimes[2].Value}";
            TopFour.Text = $"4. {userTimes[3].Key} : {userTimes[3].Value}";
            TopFive.Text = $"5. {userTimes[4].Key} : {userTimes[4].Value}";
            TopSix.Text = $"6. {userTimes[5].Key} : {userTimes[5].Value}";
            TopSeven.Text = $"7. {userTimes[6].Key} : {userTimes[6].Value}";
            TopEight.Text = $"8. {userTimes[7].Key} : {userTimes[7].Value}";
            TopNine.Text = $"9. {userTimes[8].Key} : {userTimes[8].Value}";
            TopTen.Text = $"10. {userTimes[9].Key} : {userTimes[9].Value}";
        }
        // Line format is Username/Time
        // userTimes are stored best to worst
        public void GetLeaderboard()
        {
            string[] lines = File.ReadAllLines(path);

            if (File.Exists(path))
            {
                foreach (var line in lines)
                {
                    string[] parts = line.Split('/');
                    userTimes.Add(new KeyValuePair<string, string>(parts[0], parts[1]));
                }
            }
        }

        public (bool, int) CheckIfQualifies(string newUsersTime)
        {
            // Loops through the existing leaderboard times and check whether
            // the new time is faster
            //(KeyValuePair<string,string> score in userTimes)
            for (int i = 0; i <= 10; i++)
            {
                if (userTimes.Count > i)
                {
                    KeyValuePair<string, string> score = userTimes[i];

                    // Gets the time of current item
                    string existingLeaderboardTime = score.Value;

                    // Converts MM:SS string format to separate ints
                    List<int> existingLeaderboardTimeInts = StringTimeToInts(existingLeaderboardTime);
                    List<int> newUsersTimeInts = StringTimeToInts(newUsersTime);

                    // Returns true if the new score is faster (less than)
                    // the current score in the leaderboard
                    //if (existingLeaderboardTime[0] == newUsersTimeInts[0])

                    // Checks if minutes are smaller
                    if (newUsersTimeInts[0] < existingLeaderboardTimeInts[0])
                        return (true, i);
                    
                    else if (newUsersTimeInts[0] == existingLeaderboardTimeInts[0])
                    {
                        // Check if the seconds are smaller
                        if (newUsersTimeInts[1] < existingLeaderboardTimeInts[1])
                            return (true, i);
                    }
                    else
                        continue;
                }
            }
            // Score does not qualify to be on the leaderboard
            return (false,-1);
        }

        // this function takes the time format mm:ss (string), and separates them into a list
        // containing minutes and seconds as integers
        public List<int> StringTimeToInts(string time)
        {
            // Split the string into a list
            string[] timeSplitString = time.Split(':');
            // Convert to ints
            List<int> timeSplitInt = new List<int>();

            int minutes = Convert.ToInt32(timeSplitString[0]);
            int seconds = Convert.ToInt32(timeSplitString[1]);

            timeSplitInt.Add(minutes);
            timeSplitInt.Add(seconds);

            return timeSplitInt;
        }
    }
}
