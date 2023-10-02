
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
            this.btnLeftCategory.Location = new System.Drawing.Point(64, 112);
            this.btnLeftCategory.Name = "btnLeftCategory";
            this.btnLeftCategory.Size = new System.Drawing.Size(253, 140);
            this.btnLeftCategory.TabIndex = 1;
            this.btnLeftCategory.Text = "button1";
            this.btnLeftCategory.UseVisualStyleBackColor = true;
            // 
            // btnRightCategory
            // 
            this.btnRightCategory.Location = new System.Drawing.Point(405, 112);
            this.btnRightCategory.Name = "btnRightCategory";
            this.btnRightCategory.Size = new System.Drawing.Size(253, 140);
            this.btnRightCategory.TabIndex = 2;
            this.btnRightCategory.Text = "button2";
            this.btnRightCategory.UseVisualStyleBackColor = true;
            // 
            // Category
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(724, 313);
            this.Controls.Add(this.btnRightCategory);
            this.Controls.Add(this.btnLeftCategory);
            this.Controls.Add(this.lblCategory);
            this.Name = "Category";
            this.Text = "Category";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Button btnLeftCategory;
        private System.Windows.Forms.Button btnRightCategory;
    }
}