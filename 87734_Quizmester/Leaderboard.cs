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
        bool has_categories;
        int score;

        public Leaderboard(bool has_categories, int score)
        {
            InitializeComponent();
            this.has_categories = has_categories;
            this.score = score;
        }

        private void Leaderboard_Load(object sender, EventArgs e)
        {
            lblTitle.Text = has_categories ? "Category Leaderboard" : "Normal Leaderboard";

            leaderBoardManager = new LeaderboardManager(connectionString);
            entries = leaderBoardManager.GetAllLeaderboardEntries(has_categories);
            entries = entries.OrderByDescending(entry => entry.Score).ToList();

            // first 10
            entries = entries.Take(10).ToList();

            // add to leaderboard
            leaderboardView.DataSource = entries;

            // says your score on the form
            lblYourScore.Text = $"Your Score: {score.ToString()}";
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
