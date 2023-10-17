using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _87734_Quizmester.Custom_Input_Forms;

namespace _87734_Quizmester
{
    public partial class AdminForm : Form
    {
        string connectionString = "Server=localhost;Database=quizmester;User=root;Password=;";
        AdminManager adminManager = null;
        string loggedInUser;

        // users and questions
        List<User> users = new List<User>();
        List<Question> questions = new List<Question>();

        // datagrid variables
        string username;
        string password;
        string questionText;

        public AdminForm(string loggedInUser)
        {
            InitializeComponent();
            this.loggedInUser = loggedInUser;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            adminManager = new AdminManager(connectionString);

            users = adminManager.GetAllUsers();
            questions = adminManager.GetAllQuestions();

            accountsView.DataSource = users;

            questionsView.AutoGenerateColumns = false; // Disable automatic column generation

            // Add a column for QuestionText only
            DataGridViewTextBoxColumn questionTextColumn = new DataGridViewTextBoxColumn();
            questionTextColumn.DataPropertyName = "QuestionText";
            questionTextColumn.HeaderText = "Question Text";
            questionsView.Columns.Add(questionTextColumn);

            // Clear existing data bindings and re-bind the DataGridView
            questionsView.DataSource = null;
            questionsView.DataSource = questions;
        }

        private void datagridViews_SelectionChanged(object sender, EventArgs e)
        {
            // Retrieve data from the selected row
            if (sender is DataGridView selectedGridView)
            {
                if (selectedGridView.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = selectedGridView.SelectedRows[0];

                    if (selectedGridView == accountsView)
                    {
                        username = selectedRow.Cells["Username"].Value.ToString();
                        password = selectedRow.Cells["Password"].Value.ToString();                   
                    }

                    /*if (selectedGridView == questionsView) questionText = selectedRow.Cells["QuestionText"].Value.ToString();*/
                    if(selectedGridView == questionsView)
                    {
                        foreach (DataGridViewCell cell in selectedRow.Cells)
                        {
                            questionText = cell.Value.ToString();
                        }
                    }
                }
                else
                {
                    // No rows are selected, reset the variables
                    username = "";
                    password = "";
                    questionText = "";
                }
            }
        }

        #region account managing
        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            AddUserForm addUserForm = new AddUserForm();
            addUserForm.ShowDialog();

            // Refresh the DataGridView when the AddUserForm is closed
            users = adminManager.GetAllUsers();
            accountsView.DataSource = null;
            accountsView.DataSource = users;
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            // guard clause to check if user wants to delete their own account
            if(loggedInUser == username)
            {
                MessageBox.Show("You can't delete your currently logged-in account.");
                return;
            }

            // guard clause, so that users have to click a row to edit a user
            if (username == "" && password == "")
            {
                MessageBox.Show("Please select a row before editing an account.");
                return;
            }


            DialogResult result = MessageBox.Show("Are you sure you want to delete this account?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // succesfully deletes user
                bool userDeleted = adminManager.DeleteUser(username);

                if (userDeleted) MessageBox.Show("User deleted successfully.");
                else MessageBox.Show("User with the specified username does not exist.");


                // refresh datagridview
                users = adminManager.GetAllUsers();
                accountsView.DataSource = null;
                accountsView.DataSource = users;
            }
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            // guard clause, so that users have to click a row to edit a user
            if(username == "" && password == "")
            {
                MessageBox.Show("Please select a row before editing an account.");
                return;
            }

            EditUserForm editUserForm = new EditUserForm(username, password);
            editUserForm.ShowDialog();

            // Refresh the DataGridView when the AddUserForm is closed
            users = adminManager.GetAllUsers();
            accountsView.DataSource = null;
            accountsView.DataSource = users;
        }

        private void btnMakeAdmin_Click(object sender, EventArgs e)
        {
            // guard clause, so that users have to click a row to edit a user
            if (username == "" && password == "")
            {
                MessageBox.Show("Please select a row before editing an account.");
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to give admin to this account?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                bool makeAdmin = adminManager.makeAdmin(username);

                if (makeAdmin) MessageBox.Show("User made admin succesfully.");
                else MessageBox.Show("User is already admin");
            }
        }

        #endregion
    }
}
