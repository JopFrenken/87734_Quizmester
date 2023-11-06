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
    public partial class Gamemode : Form
    {
        string username;
        public Gamemode(string username)
        {
            InitializeComponent();
            this.ControlBox = false;
            this.username = username;
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            Quiz quizform = new Quiz(username, "none", 0, 50, true, false, false, 0, false, -1);
            quizform.Show();
            this.Hide();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            CategoryForm categoryForm = new CategoryForm(50, 0, username, false, false, 0, -1);
            categoryForm.Show();
            this.Hide();
        }

        private void btnSpecial_Click(object sender, EventArgs e)
        {
            Quiz quizform = new Quiz(username, "none", 0, 0, true, false, false, 0, true, -1);
            quizform.Show();
            this.Hide();
        }
    }
}
