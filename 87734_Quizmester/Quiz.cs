using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Media;
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
        int score;
        int time;

        List<Question> questions = new List<Question>();
        QuestionManager questionManager = null;
        LeaderboardManager leaderboardManager = null;

        private SoundPlayer soundPlayerCorrect;
        private SoundPlayer soundPlayerWrong;

        public Quiz(string username, string category, int score, int time)
        {
            InitializeComponent();
            this.username = username;
            this.score = score;
            this.time = 5;

            lblScore.Text = $"Score: {score.ToString()}";
            lblTime.Text = $"Time left: {time.ToString()}";

            questionManager = new QuestionManager(connectionString, category);
            leaderboardManager = new LeaderboardManager(connectionString);

            string audioFilePathCorrect = @"..\..\..\sound\ding.wav";
            string audioFilePathWrong = @"..\..\..\sound\wrong.wav";

            soundPlayerCorrect = new SoundPlayer(audioFilePathCorrect);
            soundPlayerWrong = new SoundPlayer(audioFilePathWrong);
        }

        private void Quiz_Load(object sender, EventArgs e)
        {
            questions = questionManager.GetRandomQuestions();
            Random random = new Random();

            // randomize question order
            questions = questions.OrderBy(x => random.Next()).ToList();

            LoadQuestion(count);
            tmrQuiz.Start();
        }

        // event for all buttons
        private void allButtons_Click(object sender, EventArgs e)
        {
            // Disable all buttons to prevent further clicks
            foreach (Control control in Controls)
            {
                if (control is Button button)
                {
                    button.Enabled = false;
                }
            }

            if (sender is Button clickedButton)
            {
                string buttonText = clickedButton.Text;
                Question currentQuestion = questions[count];
                count++;

                if (buttonText == currentQuestion.CorrectAnswer)
                {
                    score++;
                    lblScore.Text = $"Score: {score.ToString()}";
                    soundPlayerCorrect.Play();
                } else
                {
                    soundPlayerWrong.Play();
                }

                if (count == 5)
                {
                    tmrQuiz.Stop();
                    CategoryForm categoryForm = new CategoryForm(time, score, username);
                    categoryForm.Show();
                    this.Hide();

                    return;
                }


                // Wait for 1 second and then re-enable the buttons
                Timer enableButtonsTimer = new Timer();
                enableButtonsTimer.Interval = 1000; // 1 second
                enableButtonsTimer.Tick += (s, ev) =>
                {
                    // Re-enable all buttons
                    foreach (Control control in Controls)
                    {
                        if (control is Button button)
                        {
                            button.Enabled = true;
                        }
                    }

                    // Stop the timer after enabling buttons
                    enableButtonsTimer.Stop();
                };

                enableButtonsTimer.Start();

                LoadQuestion(count);        
            }   
        }

        private void tmrQuiz_Tick(object sender, EventArgs e)
        {
            // counts the time down 
            time--;
            lblTime.Text = $"Time left: {time}";

            if(time == 0)
            {
                tmrQuiz.Stop();
                storeLeaderboard(username, score);
            }
        }

        // All methods
        public void LoadQuestion(int index)
        {
            // loads the question based on index
            Question currentQuestion = questions[index];
            lblQuestion.Text = currentQuestion.QuestionText;
            btnAnswerOne.Text = currentQuestion.Answer1;
            btnAnswerTwo.Text = currentQuestion.Answer2;
            btnAnswerThree.Text = currentQuestion.Answer3;
            btnAnswerFour.Text = currentQuestion.Answer4;
        }

        public void storeLeaderboard(string username, int score)
        {
            // stores score after the game ended and shows a custom messagebox
            leaderboardManager.AddLeaderboardEntry(username, score);

            string message = "Game ended. Click 'OK' to view the leaderboard.";
            string caption = "Game Over";

            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result;

            // Display MessageBox with OKCancel buttons
            result = MessageBox.Show(message, caption, buttons);

            // If user clicks 'OK', show the leaderboard;
            if (result == DialogResult.OK)
            {
                Leaderboard lb = new Leaderboard();
                lb.Show();
                lb.BringToFront();
                this.Hide();
            } else
            {
                Application.Exit();
            }
        }
    }
}