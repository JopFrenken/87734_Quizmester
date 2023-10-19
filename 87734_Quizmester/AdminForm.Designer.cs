
namespace _87734_Quizmester
{
    partial class AdminForm
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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.gbxAccount = new System.Windows.Forms.GroupBox();
            this.btnMakeAdmin = new System.Windows.Forms.Button();
            this.btnEditAccount = new System.Windows.Forms.Button();
            this.btnCreateAccount = new System.Windows.Forms.Button();
            this.btnDeleteAccount = new System.Windows.Forms.Button();
            this.accountsView = new System.Windows.Forms.DataGridView();
            this.gbxQuestion = new System.Windows.Forms.GroupBox();
            this.btnDeleteQuestion = new System.Windows.Forms.Button();
            this.btnEditQuestion = new System.Windows.Forms.Button();
            this.btnCreateQuestion = new System.Windows.Forms.Button();
            this.questionsView = new System.Windows.Forms.DataGridView();
            this.gbxAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accountsView)).BeginInit();
            this.gbxQuestion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.questionsView)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(371, 33);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(209, 31);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome Admin";
            // 
            // gbxAccount
            // 
            this.gbxAccount.Controls.Add(this.btnMakeAdmin);
            this.gbxAccount.Controls.Add(this.btnEditAccount);
            this.gbxAccount.Controls.Add(this.btnCreateAccount);
            this.gbxAccount.Controls.Add(this.btnDeleteAccount);
            this.gbxAccount.Controls.Add(this.accountsView);
            this.gbxAccount.Location = new System.Drawing.Point(12, 96);
            this.gbxAccount.Name = "gbxAccount";
            this.gbxAccount.Size = new System.Drawing.Size(359, 487);
            this.gbxAccount.TabIndex = 1;
            this.gbxAccount.TabStop = false;
            this.gbxAccount.Text = "Account Managing";
            // 
            // btnMakeAdmin
            // 
            this.btnMakeAdmin.BackColor = System.Drawing.Color.LightBlue;
            this.btnMakeAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMakeAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMakeAdmin.Location = new System.Drawing.Point(180, 418);
            this.btnMakeAdmin.Name = "btnMakeAdmin";
            this.btnMakeAdmin.Size = new System.Drawing.Size(147, 54);
            this.btnMakeAdmin.TabIndex = 4;
            this.btnMakeAdmin.Text = "Make admin";
            this.btnMakeAdmin.UseVisualStyleBackColor = false;
            this.btnMakeAdmin.Click += new System.EventHandler(this.btnMakeAdmin_Click);
            // 
            // btnEditAccount
            // 
            this.btnEditAccount.BackColor = System.Drawing.Color.Khaki;
            this.btnEditAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditAccount.Location = new System.Drawing.Point(24, 418);
            this.btnEditAccount.Name = "btnEditAccount";
            this.btnEditAccount.Size = new System.Drawing.Size(147, 54);
            this.btnEditAccount.TabIndex = 3;
            this.btnEditAccount.Text = "Edit account";
            this.btnEditAccount.UseVisualStyleBackColor = false;
            this.btnEditAccount.Click += new System.EventHandler(this.btnEditAccount_Click);
            // 
            // btnCreateAccount
            // 
            this.btnCreateAccount.BackColor = System.Drawing.Color.PaleGreen;
            this.btnCreateAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateAccount.Location = new System.Drawing.Point(24, 345);
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.Size = new System.Drawing.Size(147, 54);
            this.btnCreateAccount.TabIndex = 2;
            this.btnCreateAccount.Text = "Create account";
            this.btnCreateAccount.UseVisualStyleBackColor = false;
            this.btnCreateAccount.Click += new System.EventHandler(this.btnCreateAccount_Click);
            // 
            // btnDeleteAccount
            // 
            this.btnDeleteAccount.BackColor = System.Drawing.Color.Tomato;
            this.btnDeleteAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteAccount.Location = new System.Drawing.Point(180, 345);
            this.btnDeleteAccount.Name = "btnDeleteAccount";
            this.btnDeleteAccount.Size = new System.Drawing.Size(147, 54);
            this.btnDeleteAccount.TabIndex = 1;
            this.btnDeleteAccount.Text = "Delete account";
            this.btnDeleteAccount.UseVisualStyleBackColor = false;
            this.btnDeleteAccount.Click += new System.EventHandler(this.btnDeleteAccount_Click);
            // 
            // accountsView
            // 
            this.accountsView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.accountsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.accountsView.Location = new System.Drawing.Point(24, 30);
            this.accountsView.Name = "accountsView";
            this.accountsView.Size = new System.Drawing.Size(303, 297);
            this.accountsView.TabIndex = 0;
            this.accountsView.SelectionChanged += new System.EventHandler(this.datagridViews_SelectionChanged);
            // 
            // gbxQuestion
            // 
            this.gbxQuestion.Controls.Add(this.btnDeleteQuestion);
            this.gbxQuestion.Controls.Add(this.btnEditQuestion);
            this.gbxQuestion.Controls.Add(this.btnCreateQuestion);
            this.gbxQuestion.Controls.Add(this.questionsView);
            this.gbxQuestion.Location = new System.Drawing.Point(388, 96);
            this.gbxQuestion.Name = "gbxQuestion";
            this.gbxQuestion.Size = new System.Drawing.Size(548, 487);
            this.gbxQuestion.TabIndex = 2;
            this.gbxQuestion.TabStop = false;
            this.gbxQuestion.Text = "Question Managing";
            // 
            // btnDeleteQuestion
            // 
            this.btnDeleteQuestion.BackColor = System.Drawing.Color.Tomato;
            this.btnDeleteQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteQuestion.Location = new System.Drawing.Point(203, 418);
            this.btnDeleteQuestion.Name = "btnDeleteQuestion";
            this.btnDeleteQuestion.Size = new System.Drawing.Size(147, 54);
            this.btnDeleteQuestion.TabIndex = 7;
            this.btnDeleteQuestion.Text = "Delete question";
            this.btnDeleteQuestion.UseVisualStyleBackColor = false;
            this.btnDeleteQuestion.Click += new System.EventHandler(this.btnDeleteQuestion_Click);
            // 
            // btnEditQuestion
            // 
            this.btnEditQuestion.BackColor = System.Drawing.Color.Khaki;
            this.btnEditQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditQuestion.Location = new System.Drawing.Point(374, 418);
            this.btnEditQuestion.Name = "btnEditQuestion";
            this.btnEditQuestion.Size = new System.Drawing.Size(147, 54);
            this.btnEditQuestion.TabIndex = 6;
            this.btnEditQuestion.Text = "Edit question";
            this.btnEditQuestion.UseVisualStyleBackColor = false;
            this.btnEditQuestion.Click += new System.EventHandler(this.btnEditQuestion_Click);
            // 
            // btnCreateQuestion
            // 
            this.btnCreateQuestion.BackColor = System.Drawing.Color.PaleGreen;
            this.btnCreateQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateQuestion.Location = new System.Drawing.Point(30, 418);
            this.btnCreateQuestion.Name = "btnCreateQuestion";
            this.btnCreateQuestion.Size = new System.Drawing.Size(147, 54);
            this.btnCreateQuestion.TabIndex = 5;
            this.btnCreateQuestion.Text = "Create question";
            this.btnCreateQuestion.UseVisualStyleBackColor = false;
            this.btnCreateQuestion.Click += new System.EventHandler(this.btnCreateQuestion_Click);
            // 
            // questionsView
            // 
            this.questionsView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.questionsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.questionsView.Location = new System.Drawing.Point(30, 30);
            this.questionsView.Name = "questionsView";
            this.questionsView.Size = new System.Drawing.Size(491, 348);
            this.questionsView.TabIndex = 1;
            this.questionsView.SelectionChanged += new System.EventHandler(this.datagridViews_SelectionChanged);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 595);
            this.Controls.Add(this.gbxQuestion);
            this.Controls.Add(this.gbxAccount);
            this.Controls.Add(this.lblWelcome);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.gbxAccount.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.accountsView)).EndInit();
            this.gbxQuestion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.questionsView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.GroupBox gbxAccount;
        private System.Windows.Forms.DataGridView accountsView;
        private System.Windows.Forms.GroupBox gbxQuestion;
        private System.Windows.Forms.DataGridView questionsView;
        private System.Windows.Forms.Button btnMakeAdmin;
        private System.Windows.Forms.Button btnEditAccount;
        private System.Windows.Forms.Button btnCreateAccount;
        private System.Windows.Forms.Button btnDeleteAccount;
        private System.Windows.Forms.Button btnDeleteQuestion;
        private System.Windows.Forms.Button btnEditQuestion;
        private System.Windows.Forms.Button btnCreateQuestion;
    }
}