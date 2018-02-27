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
            this.LevelN = new System.Windows.Forms.Button();
            this.OtherLevel = new System.Windows.Forms.Label();
            this.LevelY = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LevelN
            // 
            this.LevelN.Location = new System.Drawing.Point(124, 115);
            this.LevelN.Name = "LevelN";
            this.LevelN.Size = new System.Drawing.Size(75, 23);
            this.LevelN.TabIndex = 7;
            this.LevelN.Text = "No";
            this.LevelN.UseVisualStyleBackColor = true;
            this.LevelN.Click += new System.EventHandler(this.LevelN_Click);
            // 
            // OtherLevel
            // 
            this.OtherLevel.AutoSize = true;
            this.OtherLevel.Location = new System.Drawing.Point(65, 48);
            this.OtherLevel.Name = "OtherLevel";
            this.OtherLevel.Size = new System.Drawing.Size(78, 13);
            this.OtherLevel.TabIndex = 6;
            this.OtherLevel.Text = "An other level?";
            // 
            // LevelY
            // 
            this.LevelY.Location = new System.Drawing.Point(12, 115);
            this.LevelY.Name = "LevelY";
            this.LevelY.Size = new System.Drawing.Size(75, 23);
            this.LevelY.TabIndex = 5;
            this.LevelY.Text = "Yes";
            this.LevelY.UseVisualStyleBackColor = true;
            this.LevelY.Click += new System.EventHandler(this.LevelY_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(211, 239);
            this.ControlBox = false;
            this.Controls.Add(this.LevelN);
            this.Controls.Add(this.OtherLevel);
            this.Controls.Add(this.LevelY);
            this.Name = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LevelN;
        private System.Windows.Forms.Label OtherLevel;
        private System.Windows.Forms.Button LevelY;
    }
}