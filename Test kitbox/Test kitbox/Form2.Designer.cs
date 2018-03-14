namespace Test_kitbox
{
    partial class Form2
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
            this.labelH = new System.Windows.Forms.Label();
            this.labelC = new System.Windows.Forms.Label();
            this.labelD = new System.Windows.Forms.Label();
            this.labelCD = new System.Windows.Forms.Label();
            this.comboBoxH = new System.Windows.Forms.ComboBox();
            this.comboBoxC = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.DoorY = new System.Windows.Forms.RadioButton();
            this.DoorN = new System.Windows.Forms.RadioButton();
            this.Done = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelH
            // 
            this.labelH.AutoSize = true;
            this.labelH.Location = new System.Drawing.Point(12, 24);
            this.labelH.Name = "labelH";
            this.labelH.Size = new System.Drawing.Size(38, 13);
            this.labelH.TabIndex = 0;
            this.labelH.Text = "Height";
            // 
            // labelC
            // 
            this.labelC.AutoSize = true;
            this.labelC.Location = new System.Drawing.Point(12, 48);
            this.labelC.Name = "labelC";
            this.labelC.Size = new System.Drawing.Size(31, 13);
            this.labelC.TabIndex = 1;
            this.labelC.Text = "Color";
            // 
            // labelD
            // 
            this.labelD.AutoSize = true;
            this.labelD.Location = new System.Drawing.Point(12, 70);
            this.labelD.Name = "labelD";
            this.labelD.Size = new System.Drawing.Size(30, 13);
            this.labelD.TabIndex = 2;
            this.labelD.Text = "Door";
            // 
            // labelCD
            // 
            this.labelCD.AutoSize = true;
            this.labelCD.Location = new System.Drawing.Point(19, 92);
            this.labelCD.Name = "labelCD";
            this.labelCD.Size = new System.Drawing.Size(31, 13);
            this.labelCD.TabIndex = 3;
            this.labelCD.Text = "Color";
            // 
            // comboBoxH
            // 
            this.comboBoxH.FormattingEnabled = true;
            this.comboBoxH.Location = new System.Drawing.Point(78, 21);
            this.comboBoxH.Name = "comboBoxH";
            this.comboBoxH.Size = new System.Drawing.Size(121, 21);
            this.comboBoxH.TabIndex = 4;
            this.comboBoxH.SelectedIndexChanged += new System.EventHandler(this.comboBoxH_SelectedIndexChanged);
            // 
            // comboBoxC
            // 
            this.comboBoxC.FormattingEnabled = true;
            this.comboBoxC.Location = new System.Drawing.Point(78, 45);
            this.comboBoxC.Name = "comboBoxC";
            this.comboBoxC.Size = new System.Drawing.Size(121, 21);
            this.comboBoxC.TabIndex = 5;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(78, 89);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 6;
            // 
            // DoorY
            // 
            this.DoorY.AutoSize = true;
            this.DoorY.Location = new System.Drawing.Point(78, 70);
            this.DoorY.Name = "DoorY";
            this.DoorY.Size = new System.Drawing.Size(43, 17);
            this.DoorY.TabIndex = 7;
            this.DoorY.TabStop = true;
            this.DoorY.Text = "Yes";
            this.DoorY.UseVisualStyleBackColor = true;
            this.DoorY.CheckedChanged += new System.EventHandler(this.DoorY_CheckedChanged);
            // 
            // DoorN
            // 
            this.DoorN.AutoSize = true;
            this.DoorN.Location = new System.Drawing.Point(128, 70);
            this.DoorN.Name = "DoorN";
            this.DoorN.Size = new System.Drawing.Size(39, 17);
            this.DoorN.TabIndex = 8;
            this.DoorN.TabStop = true;
            this.DoorN.Text = "No";
            this.DoorN.UseVisualStyleBackColor = true;
            this.DoorN.CheckedChanged += new System.EventHandler(this.DoorN_CheckedChanged);
            // 
            // Done
            // 
            this.Done.Location = new System.Drawing.Point(124, 204);
            this.Done.Name = "Done";
            this.Done.Size = new System.Drawing.Size(75, 23);
            this.Done.TabIndex = 9;
            this.Done.Text = "Done";
            this.Done.UseVisualStyleBackColor = true;
            this.Done.Click += new System.EventHandler(this.Done_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(13, 203);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 10;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(211, 239);
            this.ControlBox = false;
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Done);
            this.Controls.Add(this.DoorN);
            this.Controls.Add(this.DoorY);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBoxC);
            this.Controls.Add(this.comboBoxH);
            this.Controls.Add(this.labelCD);
            this.Controls.Add(this.labelD);
            this.Controls.Add(this.labelC);
            this.Controls.Add(this.labelH);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelH;
        private System.Windows.Forms.Label labelC;
        private System.Windows.Forms.Label labelD;
        private System.Windows.Forms.Label labelCD;
        private System.Windows.Forms.ComboBox comboBoxH;
        private System.Windows.Forms.ComboBox comboBoxC;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.RadioButton DoorY;
        private System.Windows.Forms.RadioButton DoorN;
        private System.Windows.Forms.Button Done;
        private System.Windows.Forms.Button Cancel;
    }
}