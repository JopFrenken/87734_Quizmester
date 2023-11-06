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
        #region variables
        string connectionString = "Server=localhost;Database=quizmester;User=root;Password=;";

        string username;
        int count = 0;
        int score;
        int time;
        int questionTime = 10;
        int questionIndex = 0;
        bool random;
        bool skipped = false;
        bool usedRidOfTwo = false;
        bool isSpecial = false;
        string specialQuestion = "";
        int specialIndex = -1;
        bool isSpecialQuestion = false;

        List<Question> questions = new List<Question>();
        QuestionManager questionManager = null;
        LeaderboardManager leaderboardManager = null;
        LoginManager loginManager = null;

        private SoundPlayer soundPlayerSpecial;
        #endregion

        public Quiz(string username, string category, int score, int time, bool random, bool skipped, bool usedRidOfTwo, int questionIndex, bool isSpecial, int specialIndex)
        {
            #region constructor
            InitializeComponent();
            // constructor variables
            this.username = username;
            this.score = score;
            this.time = time;
            this.random = random;
            this.skipped = skipped;
            this.usedRidOfTwo = usedRidOfTwo;
            this.questionIndex = questionIndex;
            this.specialIndex = specialIndex;
            this.isSpecial = isSpecial;
            #endregion

            lblScore.Text = $"Score: {score.ToString()}";
            lblTime.Text = $"Time: {time.ToString()}";

            #region sound logic
            // class instances
            questionManager = new QuestionManager(connectionString, category);
            leaderboardManager = new LeaderboardManager(connectionString);

            // audio paths and soundplayers
            string audioFilePathCorrect = @"..\..\..\sound\ding.wav";
            string audioFilePathWrong = @"..\..\..\sound\wrong.wav";
            string audioFilePathSpecial = @"..\..\..\sound\special.wav";
            soundPlayerSpecial = new SoundPlayer(audioFilePathSpecial);
            #endregion

            // subscribe to closing event
            this.FormClosing += new FormClosingEventHandler(this.Quiz_Closing);
        }

        private void Quiz_Load(object sender, EventArgs e)
        {
            loginManager = new LoginManager(connectionString);

            #region special logic
            if (!isSpecial)
            {
                // gets either all questions or 5 questions for a specific category & special question logic
                if (random == true)
                {
                    questions = questionManager.GetRandomQuestions();
                    Shuffle(questions);

                    // sets one of the first 20 questions as special
                    Random random = new Random();
                    int specialQuestionIndex = random.Next(0, 20);

                    specialQuestion = questions[specialQuestionIndex].QuestionText;
                }
                else
                {
                    questions = questionManager.GetQuestionsByCategory();
                    Shuffle(questions);

                    if(specialIndex == -1)
                    {
                        Random random = new Random();
                        specialIndex = random.Next(0, 20);
                    }
                }
            } // special quiz logic
            else
            {
                questions = questionManager.GetRandomQuestions();
                Shuffle(questions);
                PrepareSpecialQuiz(questions);
            }
            #endregion

            LoadQuestion(count);
            tmrQuiz.Start();

            if(skipped == true)
            {
                btnSkip.Enabled = false;
                btnSkip.BackColor = Color.Gray;
                btnSkip.Text = "Skip Question (0)";
            }

            if(usedRidOfTwo == true)
            {
                btnRidOfTwo.Enabled = false;
                btnRidOfTwo.BackColor = Color.Gray;
                btnRidOfTwo.Text = "50/50 (0)";
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
            // Temporarily disable all buttons to prevent further clicks
            foreach (Control control in Controls)
            {
                if (control is Button button && button != btnSkip && button != btnRidOfTwo)
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

                // this only needs to be done in a normal and category quiz
                if(!isSpecial)
                {
                    questionTime = 10;
                    lblQuestionTime.Text = $"Time left on question: {questionTime}";
                    lblQuestionTime.ForeColor = Color.Black;
                }

                // if correct add score
                if (buttonText == currentQuestion.CorrectAnswer)
                {
                    score++;
                    pcxCorrectWrong.Image = Image.FromFile(@"..\..\..\images\right.png");


                    // get 2 extra points if question is special
                    if (isSpecialQuestion )
                    {
                        score = score + 2;
                    }

                    // if special quiz score is 10, end game
                    if(isSpecial && score == 10)
                    {
                        tmrQuiz.Stop();
                        storeLeaderboard(username, time);
                    }

                    lblScore.Text = $"Score: {score.ToString()}";

                } else // if wrong
                {
                    pcxCorrectWrong.Image = Image.FromFile(@"..\..\..\images\wrong.png");
                    // if playins special quiz, increase time by 5
                    if (isSpecial)
                    {
                        time = time + 5;
                        lblTime.Text = $"Time: {time}";
                    }
                }

                // after 5 questions, loads the category form up so players have to choose a new category
                if (count == 5)
                {
                    if (random == false)
                    {
                        // Prompt the user with a MessageBox
                        DialogResult result = MessageBox.Show("Select a new category?\nIf you press 'No', you will end the game and lose progress.", "New Category", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            // If user selects 'Yes', stop the timer, create a new CategoryForm, and show it
                            tmrQuiz.Stop();
                            CategoryForm categoryForm = new CategoryForm(time, score, username, skipped, usedRidOfTwo, questionIndex, specialIndex);
                            categoryForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            Application.Exit();
                        }

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
                        if (control is Button button && button != btnSkip && button != btnRidOfTwo)
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
            btnSkip.BackColor = Color.Gray;
            btnSkip.Text = "Skip Question (0)";
        }

        // counts down in normal and category quiz, counts up for special quiz
        private void tmrQuiz_Tick(object sender, EventArgs e)
        {
            if(!isSpecial)
            {
                // counts the time down 
                time--;
                lblTime.Text = $"Time: {time}";

                if (time == 0)
                {
                    tmrQuiz.Stop();
                    storeLeaderboard(username, score);

                    // resets the quiz's used boolean
                    questionManager.ResetQuiz();
                }
            } else
            {
                time++;
                lblTime.Text = $"Time: {time}";
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

        private void btnRidOfTwo_Click(object sender, EventArgs e)
        {
            if(usedRidOfTwo == false)
            {
                usedRidOfTwo = true;
                btnRidOfTwo.Enabled = false;
                btnRidOfTwo.BackColor = Color.Gray;
                btnRidOfTwo.Text = "50/50 (0)";

                // Get the current question
                Question currentQuestion = questions[count];

                // Create a list to store incorrect answer buttons
                List<Button> incorrectAnswerButtons = new List<Button>();

                // Find incorrect answer buttons and add them to the list
                foreach (Control control in Controls)
                {
                    if (control is Button button &&
                        button.Text != currentQuestion.CorrectAnswer &&
                        button != btnSkip &&
                        button != btnRidOfTwo)
                    {
                        incorrectAnswerButtons.Add(button);
                    }
                }

                // Randomly select and disable two incorrect answer buttons
                Random random = new Random();
                for (int i = 0; i < 2; i++)
                {
                    if (incorrectAnswerButtons.Count > 0)
                    {
                        int index = random.Next(0, incorrectAnswerButtons.Count);
                        Button buttonToDisable = incorrectAnswerButtons[index];
                        buttonToDisable.Enabled = false;
                        buttonToDisable.BackColor = Color.Gray; // Change color to indicate disabled state
                        incorrectAnswerButtons.RemoveAt(index);
                    }
                }
            }
        }

        // All methods
        // Loads the next question
        public void LoadQuestion(int index)
        {
            if (index >= 0 && index < questions.Count)
            { 
                // individual question timer, not in special quiz
                if(!isSpecial)
                {
                    tmrQuestion.Start();
                }

                questionIndex++;

                Console.WriteLine(questionIndex);
                Console.WriteLine(specialIndex);

                // Loads the question based on index
                Question currentQuestion = questions[index];
                lblQuestion.Text = currentQuestion.QuestionText;

                // sets special properties to form
                if(currentQuestion.QuestionText == specialQuestion || questionIndex == specialIndex)
                {
                    isSpecialQuestion = true;
                    this.BackColor = Color.Gold;
                    lblSpecial.Text = "SPECIAL";
                    soundPlayerSpecial.Play();
                    specialIndex = -1;
                } else
                {
                    this.BackColor = Color.White;
                    lblSpecial.Text = "";
                    soundPlayerSpecial.Stop();
                }

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

                // Re enable question buttons from the 50/50
                EnableButtons();
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
            if(isSpecial)
            {
                leaderboardManager.AddLeaderboardEntry(username, score, false, true);
            } else
            {
                if (random)
                {
                    leaderboardManager.AddLeaderboardEntry(username, score, false, false);
                }
                else
                {
                    leaderboardManager.AddLeaderboardEntry(username, score, true, false);
                }
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
                Leaderboard lb = new Leaderboard(has_categories, isSpecial, score);
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
    
        private void EnableButtons()
        {
            Timer enableButtonsTimer = new Timer();
            enableButtonsTimer.Interval = 750;
            enableButtonsTimer.Tick += (s, ev) =>
            {
                // Re-enable all buttons
                foreach (Control control in Controls)
                {
                    if (control is Button button && button != btnSkip && button != btnRidOfTwo)
                    {
                        button.Enabled = true;
                    }
                }

                // Stop the timer after enabling buttons
                enableButtonsTimer.Stop();
            };

            // Start the timer to enable buttons after 750 milliseconds
            enableButtonsTimer.Start();

            btnAnswerOne.BackColor = Color.Linen;
            btnAnswerTwo.BackColor = Color.Honeydew;
            btnAnswerThree.BackColor = Color.Lavender;
            btnAnswerFour.BackColor = Color.Pink;
        }

        private void PrepareSpecialQuiz(List<Question> questions)
        {
            // prepares special quiz
            questions = questionManager.GetRandomQuestions();
            Shuffle(questions);

            lblQuestionTime.Text = "";
            tmrQuestion.Stop();
            time = 0;
        }
    }
}