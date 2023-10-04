
namespace _87734_Quizmester
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.txtRegUsername = new System.Windows.Forms.TextBox();
            this.txtRegPassword = new System.Windows.Forms.TextBox();
            this.lblRegUsername = new System.Windows.Forms.Label();
            this.lblRegPassword = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnLoginInstead = new System.Windows.Forms.Button();
            this.lblEntryScreen = new System.Windows.Forms.Label();
            this.TEST = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.textToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmMenuBar = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiRules = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiCredits = new System.Windows.Forms.ToolStripMenuItem();
            this.TEST.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.Black;
            this.lblWelcome.Location = new System.Drawing.Point(26, 28);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(531, 37);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome to the Video Game Quiz";
            this.lblWelcome.Click += new System.EventHandler(this.lblWelcome_Click);
            // 
            // txtRegUsername
            // 
            this.txtRegUsername.Location = new System.Drawing.Point(175, 192);
            this.txtRegUsername.Name = "txtRegUsername";
            this.txtRegUsername.Size = new System.Drawing.Size(188, 20);
            this.txtRegUsername.TabIndex = 1;
            // 
            // txtRegPassword
            // 
            this.txtRegPassword.Location = new System.Drawing.Point(175, 265);
            this.txtRegPassword.Name = "txtRegPassword";
            this.txtRegPassword.Size = new System.Drawing.Size(188, 20);
            this.txtRegPassword.TabIndex = 2;
            // 
            // lblRegUsername
            // 
            this.lblRegUsername.AutoSize = true;
            this.lblRegUsername.Location = new System.Drawing.Point(172, 165);
            this.lblRegUsername.Name = "lblRegUsername";
            this.lblRegUsername.Size = new System.Drawing.Size(55, 13);
            this.lblRegUsername.TabIndex = 3;
            this.lblRegUsername.Text = "Username";
            // 
            // lblRegPassword
            // 
            this.lblRegPassword.AutoSize = true;
            this.lblRegPassword.Location = new System.Drawing.Point(172, 237);
            this.lblRegPassword.Name = "lblRegPassword";
            this.lblRegPassword.Size = new System.Drawing.Size(53, 13);
            this.lblRegPassword.TabIndex = 4;
            this.lblRegPassword.Text = "Password";
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(175, 323);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(188, 29);
            this.btnRegister.TabIndex = 5;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnLoginInstead
            // 
            this.btnLoginInstead.BackColor = System.Drawing.Color.White;
            this.btnLoginInstead.Location = new System.Drawing.Point(175, 397);
            this.btnLoginInstead.Name = "btnLoginInstead";
            this.btnLoginInstead.Size = new System.Drawing.Size(188, 29);
            this.btnLoginInstead.TabIndex = 6;
            this.btnLoginInstead.Text = "Login instead";
            this.btnLoginInstead.UseVisualStyleBackColor = false;
            this.btnLoginInstead.Click += new System.EventHandler(this.btnLoginInstead_Click);
            // 
            // lblEntryScreen
            // 
            this.lblEntryScreen.AutoSize = true;
            this.lblEntryScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntryScreen.ForeColor = System.Drawing.Color.Black;
            this.lblEntryScreen.Location = new System.Drawing.Point(193, 93);
            this.lblEntryScreen.Name = "lblEntryScreen";
            this.lblEntryScreen.Size = new System.Drawing.Size(157, 26);
            this.lblEntryScreen.TabIndex = 7;
            this.lblEntryScreen.Text = "Please register";
            // 
            // TEST
            // 
            this.TEST.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textToolStripMenuItem});
            this.TEST.Name = "TEST";
            this.TEST.Size = new System.Drawing.Size(95, 26);
            // 
            // textToolStripMenuItem
            // 
            this.textToolStripMenuItem.Name = "textToolStripMenuItem";
            this.textToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.textToolStripMenuItem.Text = "text";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmMenuBar});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmMenuBar
            // 
            this.tsmMenuBar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiRules,
            this.tmiCredits});
            this.tsmMenuBar.Name = "tsmMenuBar";
            this.tsmMenuBar.Size = new System.Drawing.Size(71, 20);
            this.tsmMenuBar.Text = "More Info";
            // 
            // tmiRules
            // 
            this.tmiRules.Name = "tmiRules";
            this.tmiRules.Size = new System.Drawing.Size(180, 22);
            this.tmiRules.Text = "Game Rules";
            this.tmiRules.Click += new System.EventHandler(this.tmiRules_Click);
            // 
            // tmiCredits
            // 
            this.tmiCredits.Name = "tmiCredits";
            this.tmiCredits.Size = new System.Drawing.Size(180, 22);
            this.tmiCredits.Text = "Credits";
            this.tmiCredits.Click += new System.EventHandler(this.tmiCredits_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(584, 450);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lblEntryScreen);
            this.Controls.Add(this.btnLoginInstead);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.lblRegPassword);
            this.Controls.Add(this.lblRegUsername);
            this.Controls.Add(this.txtRegPassword);
            this.Controls.Add(this.txtRegUsername);
            this.Controls.Add(this.lblWelcome);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.TEST.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.TextBox txtRegUsername;
        private System.Windows.Forms.TextBox txtRegPassword;
        private System.Windows.Forms.Label lblRegUsername;
        private System.Windows.Forms.Label lblRegPassword;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnLoginInstead;
        private System.Windows.Forms.Label lblEntryScreen;
        private System.Windows.Forms.ContextMenuStrip TEST;
        private System.Windows.Forms.ToolStripMenuItem textToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmMenuBar;
        private System.Windows.Forms.ToolStripMenuItem tmiRules;
        private System.Windows.Forms.ToolStripMenuItem tmiCredits;
    }
}

