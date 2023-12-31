﻿using System;
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
    public partial class Form1 : Form
    {
        // db variables
        string connectionString = "Server=localhost;Database=quizmester;User=root;Password=;";
        RegisterManager registerManager = null;
        LoginManager loginManager = null;

        // user variables
        string username = "";
        string password = "";

        private SoundPlayer soundPlayer;

        public Form1()
        {
            InitializeComponent();


            // relative path to your audio file
            string audioFilePath = @"..\..\..\sound\welcome.wav";

            soundPlayer = new SoundPlayer(audioFilePath);
        }
        
        // creates the new items once the form loads
        private void Form1_Load(object sender, EventArgs e)
        {
            // class instances
            registerManager = new RegisterManager(connectionString);
            loginManager = new LoginManager(connectionString);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if(txtRegUsername.Text == "" || txtRegPassword.Text == "")
            {
                MessageBox.Show("Please fill in all your info.");
                return;
            }

            if (txtRegUsername.Text.Length > 12 || txtRegPassword.Text.Length > 12)
            {
                MessageBox.Show("Username and password must be 12 characters or less.");
                return;
            }

            username = txtRegUsername.Text;
            password = txtRegPassword.Text;

            // Registers user in class
            bool registrationResult = registerManager.RegisterUser(username, password);

            if (registrationResult) MessageBox.Show("Registration successful!");
            else MessageBox.Show("Registration failed. Username may already exist.");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtRegUsername.Text == "" || txtRegPassword.Text == "")
            {
                MessageBox.Show("Please fill in all your info.");
                return;
            }

            username = txtRegUsername.Text;
            password = txtRegPassword.Text;

            // Logins user in the class

            bool loginResult = loginManager.Login(username, password);

            if (loginResult)
            {
                if (loginResult)
                {
                    Gamemode gamemodeForm = new Gamemode(username);
                    gamemodeForm.Show();
                    this.Hide();
                }
            }
            else MessageBox.Show("Incorrect credentials");
        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {
            // Play the audio file
            soundPlayer.Play();
        }

        private void tmiRules_Click(object sender, EventArgs e)
        {
            string rules = "1. You have to create an account to play. \n2. You can play with categories. \n3. Each category has 5 questions before you can choose another category. \n4. The user can play the special version of the quiz, in which time goes up and there's no time limit. A wrong answer means +5 seconds added \n5. Play with sound if possible! \n6. Have fun!";
            MessageBox.Show(rules);
        }

        private void tmiCredits_Click(object sender, EventArgs e)
        {
            string credits = "This game was made by Jop Frenken.\nMy GitHub page: https://github.com/JopFrenken";
            MessageBox.Show(credits);
        }

        // pulls up leaderboard without having to log in
        private void btnViewLb_Click(object sender, EventArgs e)
        {
            LeaderboardSelection leaderboardSelection = new LeaderboardSelection(this);
            leaderboardSelection.ShowDialog();
        }
    }
}
