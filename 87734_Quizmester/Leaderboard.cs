using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _87734_Quizmester
{
    public partial class Leaderboard : Form
    {
        LeaderboardManager leaderBoardManager = null;
        string connectionString = "Server=localhost;Database=quizmester;User=root;Password=;";
        List<LeaderboardEntry> entries = new List<LeaderboardEntry>();

        public Leaderboard()
        {
            InitializeComponent();
        }

        private void Leaderboard_Load(object sender, EventArgs e)
        {
            leaderBoardManager = new LeaderboardManager(connectionString);
            entries = leaderBoardManager.GetAllLeaderboardEntries();
            entries = entries.OrderByDescending(entry => entry.Score).ToList();

            // first 10
            entries = entries.Take(10).ToList();

            // add to leaderboard
            leaderboardView.DataSource = entries;
        }
    }
}
