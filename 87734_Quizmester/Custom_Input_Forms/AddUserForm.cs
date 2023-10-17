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
    public partial class AddUserForm : Form
    {
        string connectionString = "Server=localhost;Database=quizmester;User=root;Password=;";
        AdminManager adminManager = null;

        public AddUserForm()
        {
            InitializeComponent();
        }

        private void AddUserForm_Load(object sender, EventArgs e)
        {
            adminManager = new AdminManager(connectionString);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            // guard clause
            if(txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please fill in all inputs.");
                return;
            }

            bool userAdded = adminManager.AddUser(txtUsername.Text, txtPassword.Text);

            if(userAdded)
            {
                MessageBox.Show("User added succesfully");
                this.Close();

            } 
            else MessageBox.Show("User with the same username already exists.");
        }
    }
}
