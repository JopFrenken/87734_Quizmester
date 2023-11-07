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
        bool is_special;
        int score;

        public Leaderboard(bool has_categories, bool is_special, int score)
        {
            InitializeComponent();
            this.has_categories = has_categories;
            this.is_special = is_special;
            this.score = score;
        }

        private void Leaderboard_Load(object sender, EventArgs e)
        {
            lblTitle.Text = has_categories ? "Category Leaderboard" : (is_special ? "Special Leaderboard" : "Normal Leaderboard");

            leaderBoardManager = new LeaderboardManager(connectionString);
            entries = leaderBoardManager.GetAllLeaderboardEntries(has_categories, is_special);
            
            if(!is_special)  entries = entries.OrderByDescending(entry => entry.Score).ToList();
            else
            {
                entries = entries.OrderBy(entry => entry.Score).ToList();

                // change name of column to time
                DataGridViewTextBoxColumn specialColumn = new DataGridViewTextBoxColumn();
                specialColumn.HeaderText = "Time";
                specialColumn.DataPropertyName = "Score";
                leaderboardView.Columns.Add(specialColumn);
            }

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

        private void btnViewLeaderboard_Click(object sender, EventArgs e)
        {
            LeaderboardSelection leaderboardSelection = new LeaderboardSelection(null);
            leaderboardSelection.ShowDialog();
            this.Hide();
        }
    }

}
