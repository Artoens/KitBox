namespace Test_kitbox
{
    partial class Form3
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.OtherLevel = new System.Windows.Forms.Label();
            this.LevelY = new System.Windows.Forms.Button();
            this.LevelN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(244, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(265, 449);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(11, 273);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(226, 188);
            this.treeView1.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LevelN);
            this.panel1.Controls.Add(this.OtherLevel);
            this.panel1.Controls.Add(this.LevelY);
            this.panel1.Location = new System.Drawing.Point(11, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(226, 258);
            this.panel1.TabIndex = 6;
            // 
            // OtherLevel
            // 
            this.OtherLevel.AutoSize = true;
            this.OtherLevel.Location = new System.Drawing.Point(68, 82);
            this.OtherLevel.Name = "OtherLevel";
            this.OtherLevel.Size = new System.Drawing.Size(78, 13);
            this.OtherLevel.TabIndex = 3;
            this.OtherLevel.Text = "An other level?";
            // 
            // LevelY
            // 
            this.LevelY.Location = new System.Drawing.Point(15, 150);
            this.LevelY.Name = "LevelY";
            this.LevelY.Size = new System.Drawing.Size(75, 23);
            this.LevelY.TabIndex = 2;
            this.LevelY.Text = "Yes";
            this.LevelY.UseVisualStyleBackColor = true;
            // 
            // LevelN
            // 
            this.LevelN.Location = new System.Drawing.Point(137, 149);
            this.LevelN.Name = "LevelN";
            this.LevelN.Size = new System.Drawing.Size(75, 23);
            this.LevelN.TabIndex = 4;
            this.LevelN.Text = "No";
            this.LevelN.UseVisualStyleBackColor = true;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 473);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.panel1);
            this.Name = "Form3";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label OtherLevel;
        private System.Windows.Forms.Button LevelY;
        private System.Windows.Forms.Button LevelN;
    }
}