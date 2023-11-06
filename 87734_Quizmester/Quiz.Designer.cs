
namespace _87734_Quizmester
{
    partial class Quiz
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
            this.btnAnswerOne = new System.Windows.Forms.Button();
            this.btnAnswerTwo = new System.Windows.Forms.Button();
            this.btnAnswerFour = new System.Windows.Forms.Button();
            this.btnAnswerThree = new System.Windows.Forms.Button();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.tmrQuiz = new System.Windows.Forms.Timer(this.components);
            this.btnSkip = new System.Windows.Forms.Button();
            this.tmrQuestion = new System.Windows.Forms.Timer(this.components);
            this.lblQuizName = new System.Windows.Forms.Label();
            this.lblQuestionTime = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRidOfTwo = new System.Windows.Forms.Button();
            this.lblSpecial = new System.Windows.Forms.Label();
            this.pcxCorrectWrong = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcxCorrectWrong)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAnswerOne
            // 
            this.btnAnswerOne.BackColor = System.Drawing.Color.Linen;
            this.btnAnswerOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnswerOne.Location = new System.Drawing.Point(29, 256);
            this.btnAnswerOne.Name = "btnAnswerOne";
            this.btnAnswerOne.Size = new System.Drawing.Size(362, 108);
            this.btnAnswerOne.TabIndex = 0;
            this.btnAnswerOne.UseVisualStyleBackColor = false;
            this.btnAnswerOne.Click += new System.EventHandler(this.allButtons_Click);
            // 
            // btnAnswerTwo
            // 
            this.btnAnswerTwo.BackColor = System.Drawing.Color.Honeydew;
            this.btnAnswerTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnswerTwo.Location = new System.Drawing.Point(411, 256);
            this.btnAnswerTwo.Name = "btnAnswerTwo";
            this.btnAnswerTwo.Size = new System.Drawing.Size(362, 108);
            this.btnAnswerTwo.TabIndex = 1;
            this.btnAnswerTwo.UseVisualStyleBackColor = false;
            this.btnAnswerTwo.Click += new System.EventHandler(this.allButtons_Click);
            // 
            // btnAnswerFour
            // 
            this.btnAnswerFour.BackColor = System.Drawing.Color.Pink;
            this.btnAnswerFour.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnswerFour.Location = new System.Drawing.Point(411, 370);
            this.btnAnswerFour.Name = "btnAnswerFour";
            this.btnAnswerFour.Size = new System.Drawing.Size(362, 106);
            this.btnAnswerFour.TabIndex = 2;
            this.btnAnswerFour.UseVisualStyleBackColor = false;
            this.btnAnswerFour.Click += new System.EventHandler(this.allButtons_Click);
            // 
            // btnAnswerThree
            // 
            this.btnAnswerThree.BackColor = System.Drawing.Color.Lavender;
            this.btnAnswerThree.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnswerThree.Location = new System.Drawing.Point(29, 370);
            this.btnAnswerThree.Name = "btnAnswerThree";
            this.btnAnswerThree.Size = new System.Drawing.Size(362, 108);
            this.btnAnswerThree.TabIndex = 3;
            this.btnAnswerThree.UseVisualStyleBackColor = false;
            this.btnAnswerThree.Click += new System.EventHandler(this.allButtons_Click);
            // 
            // lblQuestion
            // 
            this.lblQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestion.Location = new System.Drawing.Point(29, 98);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(744, 150);
            this.lblQuestion.TabIndex = 4;
            this.lblQuestion.Text = "test";
            this.lblQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblScore
            // 
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(666, 25);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(100, 26);
            this.lblScore.TabIndex = 5;
            this.lblScore.Text = "Score: 0";
            // 
            // lblTime
            // 
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(30, 26);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(120, 28);
            this.lblTime.TabIndex = 6;
            this.lblTime.Text = "Time left: 30";
            // 
            // tmrQuiz
            // 
            this.tmrQuiz.Interval = 1000;
            this.tmrQuiz.Tick += new System.EventHandler(this.tmrQuiz_Tick);
            // 
            // btnSkip
            // 
            this.btnSkip.BackColor = System.Drawing.Color.DarkMagenta;
            this.btnSkip.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSkip.ForeColor = System.Drawing.Color.White;
            this.btnSkip.Location = new System.Drawing.Point(29, 484);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(362, 66);
            this.btnSkip.TabIndex = 7;
            this.btnSkip.Text = "Skip Question (1)";
            this.btnSkip.UseVisualStyleBackColor = false;
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // tmrQuestion
            // 
            this.tmrQuestion.Interval = 1000;
            this.tmrQuestion.Tick += new System.EventHandler(this.tmrQuestion_Tick);
            // 
            // lblQuizName
            // 
            this.lblQuizName.AutoSize = true;
            this.lblQuizName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuizName.Location = new System.Drawing.Point(312, 26);
            this.lblQuizName.Name = "lblQuizName";
            this.lblQuizName.Size = new System.Drawing.Size(185, 26);
            this.lblQuizName.TabIndex = 8;
            this.lblQuizName.Text = "Video Game Quiz";
            // 
            // lblQuestionTime
            // 
            this.lblQuestionTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestionTime.ForeColor = System.Drawing.Color.Black;
            this.lblQuestionTime.Location = new System.Drawing.Point(30, 62);
            this.lblQuestionTime.Name = "lblQuestionTime";
            this.lblQuestionTime.Size = new System.Drawing.Size(230, 28);
            this.lblQuestionTime.TabIndex = 9;
            this.lblQuestionTime.Text = "Time left on question: 10";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminPanelToolStripMenuItem});
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.adminToolStripMenuItem.Text = "Admin";
            // 
            // adminPanelToolStripMenuItem
            // 
            this.adminPanelToolStripMenuItem.Name = "adminPanelToolStripMenuItem";
            this.adminPanelToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.adminPanelToolStripMenuItem.Text = "Admin Panel";
            this.adminPanelToolStripMenuItem.Click += new System.EventHandler(this.adminPanelToolStripMenuItem_Click);
            // 
            // btnRidOfTwo
            // 
            this.btnRidOfTwo.BackColor = System.Drawing.Color.Cyan;
            this.btnRidOfTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRidOfTwo.Location = new System.Drawing.Point(411, 484);
            this.btnRidOfTwo.Name = "btnRidOfTwo";
            this.btnRidOfTwo.Size = new System.Drawing.Size(362, 66);
            this.btnRidOfTwo.TabIndex = 11;
            this.btnRidOfTwo.Text = "50/50 (1)";
            this.btnRidOfTwo.UseVisualStyleBackColor = false;
            this.btnRidOfTwo.Click += new System.EventHandler(this.btnRidOfTwo_Click);
            // 
            // lblSpecial
            // 
            this.lblSpecial.AutoSize = true;
            this.lblSpecial.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpecial.Location = new System.Drawing.Point(671, 55);
            this.lblSpecial.Name = "lblSpecial";
            this.lblSpecial.Size = new System.Drawing.Size(0, 25);
            this.lblSpecial.TabIndex = 12;
            // 
            // pcxCorrectWrong
            // 
            this.pcxCorrectWrong.Location = new System.Drawing.Point(376, 62);
            this.pcxCorrectWrong.Name = "pcxCorrectWrong";
            this.pcxCorrectWrong.Size = new System.Drawing.Size(60, 60);
            this.pcxCorrectWrong.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcxCorrectWrong.TabIndex = 13;
            this.pcxCorrectWrong.TabStop = false;
            // 
            // Quiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 558);
            this.Controls.Add(this.pcxCorrectWrong);
            this.Controls.Add(this.lblSpecial);
            this.Controls.Add(this.btnRidOfTwo);
            this.Controls.Add(this.lblQuestionTime);
            this.Controls.Add(this.lblQuizName);
            this.Controls.Add(this.btnSkip);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.btnAnswerThree);
            this.Controls.Add(this.btnAnswerFour);
            this.Controls.Add(this.btnAnswerTwo);
            this.Controls.Add(this.btnAnswerOne);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Quiz";
            this.Text = "Quiz";
            this.Load += new System.EventHandler(this.Quiz_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcxCorrectWrong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAnswerOne;
        private System.Windows.Forms.Button btnAnswerTwo;
        private System.Windows.Forms.Button btnAnswerFour;
        private System.Windows.Forms.Button btnAnswerThree;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer tmrQuiz;
        private System.Windows.Forms.Button btnSkip;
        private System.Windows.Forms.Timer tmrQuestion;
        private System.Windows.Forms.Label lblQuizName;
        private System.Windows.Forms.Label lblQuestionTime;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminPanelToolStripMenuItem;
        private System.Windows.Forms.Button btnRidOfTwo;
        private System.Windows.Forms.Label lblSpecial;
        private System.Windows.Forms.PictureBox pcxCorrectWrong;
    }
}