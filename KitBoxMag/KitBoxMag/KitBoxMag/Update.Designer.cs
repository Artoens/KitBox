namespace KitBoxMag
{
    partial class Update
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
            this.comboBoxSupp = new System.Windows.Forms.ComboBox();
            this.comboBoxPiece = new System.Windows.Forms.ComboBox();
            this.supp = new System.Windows.Forms.Label();
            this.piece = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.newprice = new System.Windows.Forms.TextBox();
            this.updt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxSupp
            // 
            this.comboBoxSupp.FormattingEnabled = true;
            this.comboBoxSupp.Location = new System.Drawing.Point(115, 12);
            this.comboBoxSupp.Name = "comboBoxSupp";
            this.comboBoxSupp.Size = new System.Drawing.Size(178, 21);
            this.comboBoxSupp.TabIndex = 0;
            this.comboBoxSupp.SelectedIndexChanged += new System.EventHandler(this.comboBoxSupp_SelectedIndexChanged);
            // 
            // comboBoxPiece
            // 
            this.comboBoxPiece.FormattingEnabled = true;
            this.comboBoxPiece.Location = new System.Drawing.Point(115, 39);
            this.comboBoxPiece.Name = "comboBoxPiece";
            this.comboBoxPiece.Size = new System.Drawing.Size(178, 21);
            this.comboBoxPiece.TabIndex = 1;
            // 
            // supp
            // 
            this.supp.AutoSize = true;
            this.supp.Location = new System.Drawing.Point(12, 15);
            this.supp.Name = "supp";
            this.supp.Size = new System.Drawing.Size(45, 13);
            this.supp.TabIndex = 2;
            this.supp.Text = "Supplier";
            // 
            // piece
            // 
            this.piece.AutoSize = true;
            this.piece.Location = new System.Drawing.Point(13, 42);
            this.piece.Name = "piece";
            this.piece.Size = new System.Drawing.Size(34, 13);
            this.piece.TabIndex = 3;
            this.piece.Text = "Piece";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "New price";
            // 
            // newprice
            // 
            this.newprice.Location = new System.Drawing.Point(193, 66);
            this.newprice.Name = "newprice";
            this.newprice.Size = new System.Drawing.Size(100, 20);
            this.newprice.TabIndex = 5;
            // 
            // updt
            // 
            this.updt.Location = new System.Drawing.Point(16, 92);
            this.updt.Name = "updt";
            this.updt.Size = new System.Drawing.Size(277, 36);
            this.updt.TabIndex = 6;
            this.updt.Text = "Update price";
            this.updt.UseVisualStyleBackColor = true;
            this.updt.Click += new System.EventHandler(this.updt_Click);
            // 
            // Update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 140);
            this.Controls.Add(this.updt);
            this.Controls.Add(this.newprice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.piece);
            this.Controls.Add(this.supp);
            this.Controls.Add(this.comboBoxPiece);
            this.Controls.Add(this.comboBoxSupp);
            this.Name = "Update";
            this.Text = "Update";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSupp;
        private System.Windows.Forms.ComboBox comboBoxPiece;
        private System.Windows.Forms.Label supp;
        private System.Windows.Forms.Label piece;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox newprice;
        private System.Windows.Forms.Button updt;
    }
}