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
        int questionTime = 10;
        bool random;
        bool skipped = false;

        List<Question> questions = new List<Question>();
        QuestionManager questionManager = null;
        LeaderboardManager leaderboardManager = null;
        LoginManager loginManager = null;

        private SoundPlayer soundPlayerCorrect;
        private SoundPlayer soundPlayerWrong;

        public Quiz(string username, string category, int score, int time, bool random, bool skipped)
        {
            InitializeComponent();
            // constructor variables
            this.username = username;
            this.score = score;
            this.time = time;
            this.random = random;
            this.skipped = skipped;

            lblScore.Text = $"Score: {score.ToString()}";
            lblTime.Text = $"Time left: {time.ToString()}";

            // class instances
            questionManager = new QuestionManager(connectionString, category);
            leaderboardManager = new LeaderboardManager(connectionString);

            // audio paths and soundplayers
            string audioFilePathCorrect = @"..\..\..\sound\ding.wav";
            string audioFilePathWrong = @"..\..\..\sound\wrong.wav";
            soundPlayerCorrect = new SoundPlayer(audioFilePathCorrect);
            soundPlayerWrong = new SoundPlayer(audioFilePathWrong);

            // subscribe to closing event
            this.FormClosing += new FormClosingEventHandler(this.Quiz_Closing);
        }

        private void Quiz_Load(object sender, EventArgs e)
        {
            loginManager = new LoginManager(connectionString);
            // gets either all questions or 5 questions for a specific category
            if(random == true)
            {
                questions = questionManager.GetRandomQuestions();
                Shuffle(questions);
            } else
            {
                questions = questionManager.GetQuestionsByCategory();
                Shuffle(questions);
            }
            
            LoadQuestion(count);
            tmrQuiz.Start();

            if(skipped == true)
            {
                btnSkip.Enabled = false;
                btnSkip.BackColor = Color.Violet;
                btnSkip.Text = "Skip Question (0)";
                btnSkip.ForeColor = Color.Black;
            }
        }

        // resets used in database when closing
        private void Quiz_Closing(object sender, FormClosingEventArgs e)
        {
            questionManager.ResetQuiz();
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
                // checks which button has been clicked
                string buttonText = clickedButton.Text;
                Question currentQuestion = questions[count];
                count++;

                questionTime = 10;
                lblQuestionTime.Text = $"Time left on question: {questionTime}";
                lblQuestionTime.ForeColor = Color.Black;

                // if correct add score
                if (buttonText == currentQuestion.CorrectAnswer)
                {
                    score++;
                    lblScore.Text = $"Score: {score.ToString()}";
                    soundPlayerCorrect.Play();

                } else
                {
                    soundPlayerWrong.Play();
                }

                // after 5 questions, loads the category form up so players have to choose a new category
                if (count == 5)
                {
                    if (random == false)
                    {
                        tmrQuiz.Stop();
                        CategoryForm categoryForm = new CategoryForm(time, score, username, skipped);
                        categoryForm.Show();
                        this.Hide();

                        return;
                    }
                }


                // Wait a bit and then re-enable the buttons
                Timer enableButtonsTimer = new Timer();
                enableButtonsTimer.Interval = 750;
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

        // skips question, but can only be used once
        private void btnSkip_Click(object sender, EventArgs e)
        {
            questionTime = 10;
            lblQuestionTime.Text = $"Time left on question: {questionTime}";
            count++;
            skipped = true;
            LoadQuestion(count);
            btnSkip.Enabled = false;
            btnSkip.BackColor = Color.Violet;
            btnSkip.Text = "Skip Question (0)";
            btnSkip.ForeColor = Color.Black;
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

                // resets the quiz's used boolean
                questionManager.ResetQuiz();
            }
        }

        // timer limit per question
        private void tmrQuestion_Tick(object sender, EventArgs e)
        {
            questionTime--;
            lblQuestionTime.Text = $"Time left on question: {questionTime}";

            if (questionTime == 3) lblQuestionTime.ForeColor = Color.Red;

            if (questionTime == 0)
            {
                tmrQuestion.Stop();
                count++;
                questionTime = 10;
                lblQuestionTime.Text = $"Time left on question: {questionTime}";
                lblQuestionTime.ForeColor = Color.Black;
                LoadQuestion(count);
            }
        }

        // All methods
        // Loads the next question
        public void LoadQuestion(int index)
        {
            if (index >= 0 && index < questions.Count)
            {
                tmrQuestion.Start();
                // loads the question based on index
                Question currentQuestion = questions[index];
                lblQuestion.Text = currentQuestion.QuestionText;

                // Create a list to store answer choices
                List<string> answerChoices = new List<string>
                {
                    currentQuestion.Answer1,
                    currentQuestion.Answer2,
                    currentQuestion.Answer3,
                    currentQuestion.Answer4
                };

                // Shuffle the answer choices
                Shuffle(answerChoices);

                // Assign shuffled answer choices to buttons
                btnAnswerOne.Text = answerChoices[0];
                btnAnswerTwo.Text = answerChoices[1];
                btnAnswerThree.Text = answerChoices[2];
                btnAnswerFour.Text = answerChoices[3];
            }
            else if (questions.Count == 0)
            {
                // There are no more questions
                MessageBox.Show("Congratulations! You have completed all the questions.", "Quiz Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                storeLeaderboard(username, score);
            }
        }

        // stores the user and score in database
        public void storeLeaderboard(string username, int score)
        {
            // stores score after the game ended and shows a custom messagebox
            // 2 seperate leaderboards, 1 for random, 1 for categories
            if(random == true)
            {
                leaderboardManager.AddLeaderboardEntry(username, score, false);
            } else
            {
                leaderboardManager.AddLeaderboardEntry(username, score, true);
            }

            string message = "Game ended. Click 'OK' to view the leaderboard.";
            string caption = "Game Over";

            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result;

            // Display MessageBox with OKCancel buttons
            result = MessageBox.Show(message, caption, buttons);

            // If user clicks ok, show the leaderboard;
            if (result == DialogResult.OK)
            {
                // Shows leaderboard depending on whether they had categories or not
                bool has_categories = random == true ? false : true;
                Leaderboard lb = new Leaderboard(has_categories, score);
                lb.Show();
                lb.BringToFront();
                this.Hide();
            } else
            {
                Application.Exit();
            }
        }
        
        // Fisher-Yates shuffle algorithm
        private void Shuffle<T>(List<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        private void adminPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isAdmin = loginManager.CheckIfAdmin(username);

            if (isAdmin)
            {
                AdminForm adminform = new AdminForm(username);
                this.Hide();
                tmrQuestion.Stop();
                tmrQuiz.Stop();
                adminform.ShowDialog();
                tmrQuestion.Start();
                tmrQuiz.Start();
            }
            else
            {
                MessageBox.Show("Forbidden. User not Admin");
            }
        }
    }
}