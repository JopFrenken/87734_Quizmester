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
    public partial class Form1 : Form
    {
        // db variables
        string connectionString = "Server=localhost;Database=quizmester;User=root;Password=;";
        RegisterManager registerManager = null;
        LoginManager loginManager = null;

        // user variables
        string username = "";
        string password = "";

        // create new buttons dynamically
        Button btnLogin = null;
        Button btnRegInstead = null;

        public Form1()
        {
            InitializeComponent();
        }

        // creates the new items once the form loads
        private void Form1_Load(object sender, EventArgs e)
        {
            btnLogin = new Button();
            btnRegInstead = new Button();
            btnLogin.Text = "Login";
            btnRegInstead.Text = "Register instead";

            // Add the new buttons to the form
            this.Controls.Add(btnLogin);
            this.Controls.Add(btnRegInstead);

            // hidden for now
            btnLogin.Visible = false;
            btnRegInstead.Visible = false;

            // Attach the event handlers to the buttons
            btnLogin.Click += new EventHandler(btnLogin_Click);
            btnRegInstead.Click += new EventHandler(btnRegInstead_Click);

            // class instances
            registerManager = new RegisterManager(connectionString);
            loginManager = new LoginManager(connectionString);
        }

        private void btnLoginInstead_Click(object sender, EventArgs e)
        {
            // set the location and size of the new buttons to match the existing buttons
            btnLogin.Location = btnRegister.Location;
            btnRegInstead.Location = btnLoginInstead.Location;
            btnLogin.Size = btnRegister.Size;
            btnRegInstead.Size = btnLoginInstead.Size;

            // Hide the existing buttons
            btnRegister.Visible = false;
            btnLoginInstead.Visible = false;

            // show the other buttons
            btnLogin.Visible = true;
            btnRegInstead.Visible = true;

            // Change label text
            lblEntryScreen.Text = "Please login";
        }

        private void btnRegInstead_Click(object sender, EventArgs e)
        {
            // Hide the existing buttons
            btnLogin.Visible = false;
            btnRegInstead.Visible = false;

            // Adds back the other buttons
            btnRegister.Visible = true;
            btnLoginInstead.Visible = true; 

            // Change label text
            lblEntryScreen.Text = "Please register";
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if(txtRegUsername.Text == "" || txtRegPassword.Text == "")
            {
                MessageBox.Show("Please fill in all your info.");
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
                // Create and open the Quiz form if login is successful
                Quiz quizForm = new Quiz(username);
                quizForm.Show(); 
                this.Hide(); // Hide the current form
            }
            else
            {
                MessageBox.Show("Incorrect credentials");
            }
        }
    }
}
