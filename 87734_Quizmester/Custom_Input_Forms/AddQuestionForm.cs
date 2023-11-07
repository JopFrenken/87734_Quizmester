using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _87734_Quizmester.Custom_Input_Forms
{
    public partial class AddQuestionForm : Form
    {
        string connectionString = "Server=localhost;Database=quizmester;User=root;Password=;";
        AdminManager adminManager = null;

        public AddQuestionForm()
        {
            InitializeComponent();
        }

        // events

        private void AddQuestionForm_Load(object sender, EventArgs e)
        {
            adminManager = new AdminManager(connectionString);

            List<string> categories = new List<string>
            {
                "Nintendo",
                "Xbox",
                "Playstation",
                "History",
                "Popular Titles",
                "Game Mechanics",
                "Game Terminology",
                "Game Characters"
            };

            // bind categories to the combobox
            cmbCategory.DataSource = categories;
        }

        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            // Check if all answer options are valid and unique
            if (AreAnswerOptionsValid())
            {
                // Check if the correct answer is valid
                if (IsCorrectAnswerValid())
                {
                    string selectedCategory = cmbCategory.SelectedItem.ToString();

                    if(selectedCategory == "")
                    {
                        MessageBox.Show("Please add a category.");
                        return;
                    }

                    bool addQuestion = adminManager.AddQuestion(txtQuestion.Text, txtAnswer1.Text, txtAnswer2.Text, txtAnswer3.Text, txtAnswer4.Text, txtCorrect.Text, selectedCategory);
                    if(addQuestion)
                    {
                        MessageBox.Show("Question added succesfully");
                        this.Close();
                    }
                }
                else MessageBox.Show("The correct answer must match one of the answer options.");
            }
            else MessageBox.Show("All answer options must be non-empty and unique.");
        }

        // methods
        // checks if the correct answers matches one of the textboxes.
        private bool IsCorrectAnswerValid()
        {
            string correctAnswer = txtCorrect.Text.Trim();
            string answer1 = txtAnswer1.Text.Trim();
            string answer2 = txtAnswer2.Text.Trim();
            string answer3 = txtAnswer3.Text.Trim();
            string answer4 = txtAnswer4.Text.Trim();

            // Check if the correct answer matches one of the answer options
            return correctAnswer.Equals(answer1, StringComparison.OrdinalIgnoreCase) ||
                   correctAnswer.Equals(answer2, StringComparison.OrdinalIgnoreCase) ||
                   correctAnswer.Equals(answer3, StringComparison.OrdinalIgnoreCase) ||
                   correctAnswer.Equals(answer4, StringComparison.OrdinalIgnoreCase);
        }

        // checks if answers are unique.
        private bool AreAnswerOptionsValid()
        {
            string answer1 = txtAnswer1.Text.Trim().ToLower();
            string answer2 = txtAnswer2.Text.Trim().ToLower();
            string answer3 = txtAnswer3.Text.Trim().ToLower();
            string answer4 = txtAnswer4.Text.Trim().ToLower();

            // Check if all answer options are non-empty and unique
            return !string.IsNullOrWhiteSpace(answer1) &&
                   !string.IsNullOrWhiteSpace(answer2) &&
                   !string.IsNullOrWhiteSpace(answer3) &&
                   !string.IsNullOrWhiteSpace(answer4) &&
                   answer1 != answer2 &&
                   answer1 != answer3 &&
                   answer1 != answer4 &&
                   answer2 != answer3 &&
                   answer2 != answer4 &&
                   answer3 != answer4;
        }
    }
}
