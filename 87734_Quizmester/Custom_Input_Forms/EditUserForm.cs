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
    public partial class EditUserForm : Form
    {
        string username;
        string password;
        string oldUserName;

        string connectionString = "Server=localhost;Database=quizmester;User=root;Password=;";
        AdminManager adminManager = null;

        public EditUserForm(string username, string password)
        {
            InitializeComponent();
            this.username = username;
            oldUserName = username; 
            this.password = password;
        }

        private void EditUserForm_Load(object sender, EventArgs e)
        {
            txtUsername.Text = username;
            txtPassword.Text = password;
            adminManager = new AdminManager(connectionString);
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            // guard clause
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please fill in all inputs.");
                return;
            }

            bool editedUser = adminManager.EditUser(oldUserName, txtUsername.Text, txtPassword.Text);

            if (editedUser)
            {
                MessageBox.Show("User edited succesfully.");
                this.Hide();
            }
            else MessageBox.Show("User edited failed.");
        }
    }
}
