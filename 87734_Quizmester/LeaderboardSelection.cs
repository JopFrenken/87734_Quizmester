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
    public partial class LeaderboardSelection : Form
    {
        Form1 form1 = null;
        public LeaderboardSelection(Form1 form1)
        {
            InitializeComponent();

            // start form, needed for closing
            this.form1 = form1;
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            // User wants to see the normal leaderboard
            Leaderboard leaderboard = new Leaderboard(false, false, 0);
            leaderboard.Show();
            this.Hide();
            
            if(form1 != null) form1.Hide();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            // User wants to see the categories leaderboard
            Leaderboard leaderboard = new Leaderboard(true, false, 0);
            leaderboard.Show();
            this.Hide();
            if (form1 != null) form1.Hide();
        }

        private void btnSpecial_Click(object sender, EventArgs e)
        {
            // User wants to see the categories leaderboard
            Leaderboard leaderboard = new Leaderboard(false, true, 0);
            leaderboard.Show();
            this.Hide();
            if (form1 != null) form1.Hide();
        }
    }
}
