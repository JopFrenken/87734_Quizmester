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
    public partial class Quiz : Form
    {
        string connectionString = "Server=localhost;Database=quizmester;User=root;Password=;";
        string username;
        int count = 0;
        int score = 0;
        int time = 30;
        List<Question> questions = new List<Question>();
        QuestionManager questionManager = null;

        public Quiz(string username)
        {
            InitializeComponent();
            this.username = username;
            questionManager = new QuestionManager(connectionString);
        }

        private void Quiz_Load(object sender, EventArgs e)
        {
            questions = questionManager.GetAllQuestions();
            Random random = new Random();

            // randomize question order
            questions = questions.OrderBy(x => random.Next()).ToList();

            LoadQuestion(count);
            tmrQuiz.Start();
        }

        private void allButtons_Click(object sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                string buttonText = clickedButton.Text;
                Question currentQuestion = questions[count];
                count++;

                if (buttonText == currentQuestion.CorrectAnswer)
                {
                    score++;
                }

                LoadQuestion(count);
                lblScore.Text = $"Score: {score.ToString()}";
            }   
        }

        public void LoadQuestion(int index)
        {
            Question currentQuestion = questions[index];
            lblQuestion.Text = currentQuestion.QuestionText;
            btnAnswerOne.Text = currentQuestion.Answer1;
            btnAnswerTwo.Text = currentQuestion.Answer2;
            btnAnswerThree.Text = currentQuestion.Answer3;
            btnAnswerFour.Text = currentQuestion.Answer4;
        }

        private void tmrQuiz_Tick(object sender, EventArgs e)
        {
            time--;
            lblTime.Text = $"Time left: {time}";

            if(time == 0)
            {
                tmrQuiz.Stop();
            }
        }
    }
}
