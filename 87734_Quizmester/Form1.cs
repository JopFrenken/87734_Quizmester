﻿using System;
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
            /*btnLogin.Click += new EventHandler(btnLoginInstead_Click);*/
            btnRegInstead.Click += new EventHandler(btnRegInstead_Click);
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
    }
}
