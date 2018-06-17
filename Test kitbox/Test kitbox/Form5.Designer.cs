namespace Test_kitbox
{
    partial class Form5
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
            this.anglebar = new System.Windows.Forms.Label();
            this.anglebarcolor = new System.Windows.Forms.ComboBox();
            this.fin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // anglebar
            // 
            this.anglebar.AutoSize = true;
            this.anglebar.Location = new System.Drawing.Point(12, 9);
            this.anglebar.Name = "anglebar";
            this.anglebar.Size = new System.Drawing.Size(82, 13);
            this.anglebar.TabIndex = 0;
            this.anglebar.Text = "Anglebar Color :";
            // 
            // anglebarcolor
            // 
            this.anglebarcolor.FormattingEnabled = true;
            this.anglebarcolor.Location = new System.Drawing.Point(49, 25);
            this.anglebarcolor.Name = "anglebarcolor";
            this.anglebarcolor.Size = new System.Drawing.Size(150, 21);
            this.anglebarcolor.TabIndex = 1;
            // 
            // fin
            // 
            this.fin.Location = new System.Drawing.Point(123, 204);
            this.fin.Name = "fin";
            this.fin.Size = new System.Drawing.Size(75, 23);
            this.fin.TabIndex = 2;
            this.fin.Text = "finish";
            this.fin.UseVisualStyleBackColor = true;
            this.fin.Click += new System.EventHandler(this.fin_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(211, 239);
            this.ControlBox = false;
            this.Controls.Add(this.fin);
            this.Controls.Add(this.anglebarcolor);
            this.Controls.Add(this.anglebar);
            this.Name = "Form5";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label anglebar;
        private System.Windows.Forms.ComboBox anglebarcolor;
        private System.Windows.Forms.Button fin;
    }
}