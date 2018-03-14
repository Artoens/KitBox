using System.Collections.Generic;

namespace Test_kitbox
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
            this.Dim = new System.Windows.Forms.Label();
            this.comboBoxDim = new System.Windows.Forms.ComboBox();
            this.Next = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Dim
            // 
            this.Dim.AutoSize = true;
            this.Dim.Location = new System.Drawing.Point(12, 36);
            this.Dim.Name = "Dim";
            this.Dim.Size = new System.Drawing.Size(61, 13);
            this.Dim.TabIndex = 0;
            this.Dim.Text = "Dimensions";
            // 
            // comboBoxDim
            // 
            this.comboBoxDim.FormattingEnabled = true;
            this.comboBoxDim.Location = new System.Drawing.Point(79, 33);
            this.comboBoxDim.Name = "comboBoxDim";
            this.comboBoxDim.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDim.TabIndex = 1;
            this.comboBoxDim.SelectedIndexChanged += new System.EventHandler(this.comboBoxDim_SelectedIndexChanged);
            // 
            // Next
            // 
            this.Next.Location = new System.Drawing.Point(124, 204);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(75, 23);
            this.Next.TabIndex = 2;
            this.Next.Text = "Next";
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(211, 239);
            this.ControlBox = false;
            this.Controls.Add(this.Next);
            this.Controls.Add(this.comboBoxDim);
            this.Controls.Add(this.Dim);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Dim;
        private System.Windows.Forms.ComboBox comboBoxDim;
        private System.Windows.Forms.Button Next;
    }
}

