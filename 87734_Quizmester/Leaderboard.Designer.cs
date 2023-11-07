
namespace _87734_Quizmester
{
    partial class Leaderboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.leaderboardView = new System.Windows.Forms.DataGridView();
            this.btnRestart = new System.Windows.Forms.Button();
            this.lblYourScore = new System.Windows.Forms.Label();
            this.btnViewLeaderboard = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.leaderboardView)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(17, 29);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(109, 39);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "label1";
            // 
            // leaderboardView
            // 
            this.leaderboardView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.leaderboardView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.leaderboardView.Location = new System.Drawing.Point(24, 108);
            this.leaderboardView.Name = "leaderboardView";
            this.leaderboardView.ReadOnly = true;
            this.leaderboardView.Size = new System.Drawing.Size(647, 244);
            this.leaderboardView.TabIndex = 0;
            // 
            // btnRestart
            // 
            this.btnRestart.BackColor = System.Drawing.Color.MistyRose;
            this.btnRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestart.Location = new System.Drawing.Point(475, 372);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(196, 66);
            this.btnRestart.TabIndex = 2;
            this.btnRestart.Text = "Restart Game";
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // lblYourScore
            // 
            this.lblYourScore.AutoSize = true;
            this.lblYourScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYourScore.Location = new System.Drawing.Point(19, 393);
            this.lblYourScore.Name = "lblYourScore";
            this.lblYourScore.Size = new System.Drawing.Size(134, 26);
            this.lblYourScore.TabIndex = 3;
            this.lblYourScore.Text = "Your Score: ";
            // 
            // btnViewLeaderboard
            // 
            this.btnViewLeaderboard.BackColor = System.Drawing.Color.PowderBlue;
            this.btnViewLeaderboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewLeaderboard.Location = new System.Drawing.Point(264, 372);
            this.btnViewLeaderboard.Name = "btnViewLeaderboard";
            this.btnViewLeaderboard.Size = new System.Drawing.Size(196, 66);
            this.btnViewLeaderboard.TabIndex = 4;
            this.btnViewLeaderboard.Text = "View other Leaderboards";
            this.btnViewLeaderboard.UseVisualStyleBackColor = false;
            this.btnViewLeaderboard.Click += new System.EventHandler(this.btnViewLeaderboard_Click);
            // 
            // Leaderboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(699, 450);
            this.Controls.Add(this.btnViewLeaderboard);
            this.Controls.Add(this.lblYourScore);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.leaderboardView);
            this.Name = "Leaderboard";
            this.Text = "Leaderboard";
            this.Load += new System.EventHandler(this.Leaderboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.leaderboardView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView leaderboardView;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Label lblYourScore;
        private System.Windows.Forms.Button btnViewLeaderboard;
    }
}