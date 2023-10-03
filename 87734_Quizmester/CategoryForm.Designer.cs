
namespace _87734_Quizmester
{
    partial class CategoryForm
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
            this.lblCategory = new System.Windows.Forms.Label();
            this.btnLeftCategory = new System.Windows.Forms.Button();
            this.btnRightCategory = new System.Windows.Forms.Button();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblTimeLeft = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategory.Location = new System.Drawing.Point(173, 19);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(357, 46);
            this.lblCategory.TabIndex = 0;
            this.lblCategory.Text = "Choose a category";
            // 
            // btnLeftCategory
            // 
            this.btnLeftCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeftCategory.Location = new System.Drawing.Point(57, 161);
            this.btnLeftCategory.Name = "btnLeftCategory";
            this.btnLeftCategory.Size = new System.Drawing.Size(253, 140);
            this.btnLeftCategory.TabIndex = 1;
            this.btnLeftCategory.Text = "button1";
            this.btnLeftCategory.UseVisualStyleBackColor = true;
            this.btnLeftCategory.Click += new System.EventHandler(this.allButtons_Click);
            // 
            // btnRightCategory
            // 
            this.btnRightCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRightCategory.Location = new System.Drawing.Point(410, 161);
            this.btnRightCategory.Name = "btnRightCategory";
            this.btnRightCategory.Size = new System.Drawing.Size(253, 140);
            this.btnRightCategory.TabIndex = 2;
            this.btnRightCategory.Text = "button2";
            this.btnRightCategory.UseVisualStyleBackColor = true;
            this.btnRightCategory.Click += new System.EventHandler(this.allButtons_Click);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(54, 109);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(59, 20);
            this.lblScore.TabIndex = 3;
            this.lblScore.Text = "Score: ";
            // 
            // lblTimeLeft
            // 
            this.lblTimeLeft.AutoSize = true;
            this.lblTimeLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeLeft.Location = new System.Drawing.Point(407, 109);
            this.lblTimeLeft.Name = "lblTimeLeft";
            this.lblTimeLeft.Size = new System.Drawing.Size(83, 20);
            this.lblTimeLeft.TabIndex = 4;
            this.lblTimeLeft.Text = "Time Left: ";
            // 
            // CategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(724, 313);
            this.Controls.Add(this.lblTimeLeft);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.btnRightCategory);
            this.Controls.Add(this.btnLeftCategory);
            this.Controls.Add(this.lblCategory);
            this.Name = "CategoryForm";
            this.Text = "Category";
            this.Load += new System.EventHandler(this.CategoryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Button btnLeftCategory;
        private System.Windows.Forms.Button btnRightCategory;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblTimeLeft;
    }
}