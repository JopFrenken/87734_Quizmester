
namespace _87734_Quizmester
{
    partial class LeaderboardSelection
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
            this.btnSpecial = new System.Windows.Forms.Button();
            this.btnCategories = new System.Windows.Forms.Button();
            this.lblLb = new System.Windows.Forms.Label();
            this.btnNormal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSpecial
            // 
            this.btnSpecial.BackColor = System.Drawing.Color.Plum;
            this.btnSpecial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSpecial.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpecial.Location = new System.Drawing.Point(55, 267);
            this.btnSpecial.Name = "btnSpecial";
            this.btnSpecial.Size = new System.Drawing.Size(263, 64);
            this.btnSpecial.TabIndex = 7;
            this.btnSpecial.Text = "Special Quiz";
            this.btnSpecial.UseVisualStyleBackColor = false;
            this.btnSpecial.Click += new System.EventHandler(this.btnSpecial_Click);
            // 
            // btnCategories
            // 
            this.btnCategories.BackColor = System.Drawing.Color.Coral;
            this.btnCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategories.Location = new System.Drawing.Point(55, 184);
            this.btnCategories.Name = "btnCategories";
            this.btnCategories.Size = new System.Drawing.Size(263, 64);
            this.btnCategories.TabIndex = 6;
            this.btnCategories.Text = "Categories";
            this.btnCategories.UseVisualStyleBackColor = false;
            this.btnCategories.Click += new System.EventHandler(this.btnCategories_Click);
            // 
            // lblLb
            // 
            this.lblLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLb.Location = new System.Drawing.Point(50, 22);
            this.lblLb.Name = "lblLb";
            this.lblLb.Size = new System.Drawing.Size(277, 66);
            this.lblLb.TabIndex = 5;
            this.lblLb.Text = "What Leaderboard do you want to view?";
            // 
            // btnNormal
            // 
            this.btnNormal.BackColor = System.Drawing.Color.Khaki;
            this.btnNormal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNormal.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNormal.Location = new System.Drawing.Point(55, 103);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(263, 64);
            this.btnNormal.TabIndex = 4;
            this.btnNormal.Text = "Normal";
            this.btnNormal.UseVisualStyleBackColor = false;
            this.btnNormal.Click += new System.EventHandler(this.btnNormal_Click);
            // 
            // LeaderboardSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 354);
            this.Controls.Add(this.btnSpecial);
            this.Controls.Add(this.btnCategories);
            this.Controls.Add(this.lblLb);
            this.Controls.Add(this.btnNormal);
            this.Name = "LeaderboardSelection";
            this.Text = "LeaderboardSelection";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSpecial;
        private System.Windows.Forms.Button btnCategories;
        private System.Windows.Forms.Label lblLb;
        private System.Windows.Forms.Button btnNormal;
    }
}