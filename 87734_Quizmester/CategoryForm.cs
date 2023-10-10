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
    public partial class CategoryForm : Form
    {
        string connectionString = "Server=localhost;Database=quizmester;User=root;Password=;";
        List<Category> categories = new List<Category>();
        CategoryManager categoryManager = null;

        int time = 0;
        int score = 0;
        string username = "";
        bool skipped;

        public CategoryForm(int time, int score, string username, bool skipped)
        {
            InitializeComponent();
            this.time = time;
            this.score = score;
            this.username = username;
            this.skipped = skipped;
            categoryManager = new CategoryManager(connectionString);
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            // gets two random categories
            categories = categoryManager.GetTwoCategories();

            if (categories.Count >= 2) // Ensure there are at least two categories
            {
                btnLeftCategory.Text = categories[0].CategoryName;
                btnRightCategory.Text = categories[1].CategoryName;
            }

            lblScore.Text = "Score: " + score.ToString();
            lblTimeLeft.Text = "Time Left: " + time.ToString();
        }

        private void allButtons_Click(object sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                Quiz quiz = new Quiz(username, clickedButton.Text, score, time, false, skipped);
                quiz.Show();
                this.Hide();
            }
        }
    }
}
