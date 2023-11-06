
namespace _87734_Quizmester
{
    partial class Gamemode
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
            this.btnNormal = new System.Windows.Forms.Button();
            this.lblGamemode = new System.Windows.Forms.Label();
            this.btnCategories = new System.Windows.Forms.Button();
            this.btnSpecial = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNormal
            // 
            this.btnNormal.BackColor = System.Drawing.Color.Khaki;
            this.btnNormal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNormal.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNormal.Location = new System.Drawing.Point(76, 84);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(263, 64);
            this.btnNormal.TabIndex = 0;
            this.btnNormal.Text = "Normal";
            this.btnNormal.UseVisualStyleBackColor = false;
            this.btnNormal.Click += new System.EventHandler(this.btnNormal_Click);
            // 
            // lblGamemode
            // 
            this.lblGamemode.AutoSize = true;
            this.lblGamemode.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGamemode.Location = new System.Drawing.Point(71, 20);
            this.lblGamemode.Name = "lblGamemode";
            this.lblGamemode.Size = new System.Drawing.Size(278, 29);
            this.lblGamemode.TabIndex = 1;
            this.lblGamemode.Text = "Choose your gamemode";
            // 
            // btnCategories
            // 
            this.btnCategories.BackColor = System.Drawing.Color.Coral;
            this.btnCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategories.Location = new System.Drawing.Point(76, 165);
            this.btnCategories.Name = "btnCategories";
            this.btnCategories.Size = new System.Drawing.Size(263, 64);
            this.btnCategories.TabIndex = 2;
            this.btnCategories.Text = "Categories";
            this.btnCategories.UseVisualStyleBackColor = false;
            this.btnCategories.Click += new System.EventHandler(this.btnCategories_Click);
            // 
            // btnSpecial
            // 
            this.btnSpecial.BackColor = System.Drawing.Color.Plum;
            this.btnSpecial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSpecial.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpecial.Location = new System.Drawing.Point(76, 248);
            this.btnSpecial.Name = "btnSpecial";
            this.btnSpecial.Size = new System.Drawing.Size(263, 64);
            this.btnSpecial.TabIndex = 3;
            this.btnSpecial.Text = "Special Quiz";
            this.btnSpecial.UseVisualStyleBackColor = false;
            this.btnSpecial.Click += new System.EventHandler(this.btnSpecial_Click);
            // 
            // Gamemode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 324);
            this.Controls.Add(this.btnSpecial);
            this.Controls.Add(this.btnCategories);
            this.Controls.Add(this.lblGamemode);
            this.Controls.Add(this.btnNormal);
            this.Name = "Gamemode";
            this.Text = "Gamemode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNormal;
        private System.Windows.Forms.Label lblGamemode;
        private System.Windows.Forms.Button btnCategories;
        private System.Windows.Forms.Button btnSpecial;
    }
}