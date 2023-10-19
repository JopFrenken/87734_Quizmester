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
    public partial class EditQuestionForm : Form
    {
        string questionText;
        string answer1;
        string answer2;
        string answer3;
        string answer4;
        string correctAnswer;

        string connectionString = "Server=localhost;Database=quizmester;User=root;Password=;";
        AdminManager adminManager = null;
        public EditQuestionForm(string questionText, string answer1, string answer2, string answer3, string answer4, string correctAnswer)
        {
            InitializeComponent();

            this.questionText = questionText;
            this.answer1 = answer1;
            this.answer2 = answer2;
            this.answer3 = answer3;
            this.answer4 = answer4;
            this.correctAnswer = correctAnswer;
        }

        private void EditQuestionForm_Load(object sender, EventArgs e)
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

            // bind categories to the combobox and chosen question text and answers to the textboxes
            cmbCategory.DataSource = categories;
            txtQuestion.Text = questionText;
            txtAnswer1.Text = answer1;
            txtAnswer2.Text = answer2;
            txtAnswer3.Text = answer3;
            txtAnswer4.Text = answer4;
            txtCorrect.Text = correctAnswer;
        }

        private void btnEditQuestion_Click(object sender, EventArgs e)
        {
            // guard clause
            if (txtQuestion.Text == "" || txtAnswer1.Text == "" || txtAnswer2.Text == "" ||
                txtAnswer3.Text == "" || txtAnswer4.Text == "" || txtCorrect.Text == "" ||
                cmbCategory.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all inputs.");
                return;
            }

            bool editedQuestion = adminManager.EditQuestion(questionText, txtQuestion.Text, txtAnswer1.Text, txtAnswer2.Text, txtAnswer3.Text, txtAnswer4.Text, txtCorrect.Text, cmbCategory.SelectedItem.ToString());

            if (editedQuestion)
            {
                MessageBox.Show("Question edited successfully.");
                this.Hide();
            }
            else MessageBox.Show("Question edit failed");
        }
    }
}
