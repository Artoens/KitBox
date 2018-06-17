namespace KitBoxMag
{
    partial class ConfirmRecieve
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
            this.Confirm = new System.Windows.Forms.Button();
            this.PriceL = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.Label();
            this.IDo = new System.Windows.Forms.Label();
            this.pieceref = new System.Windows.Forms.ComboBox();
            this.Quantity = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Confirm
            // 
            this.Confirm.Location = new System.Drawing.Point(182, 95);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(75, 23);
            this.Confirm.TabIndex = 9;
            this.Confirm.Text = "Confirm";
            this.Confirm.UseVisualStyleBackColor = true;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // PriceL
            // 
            this.PriceL.AutoSize = true;
            this.PriceL.Location = new System.Drawing.Point(12, 59);
            this.PriceL.Name = "PriceL";
            this.PriceL.Size = new System.Drawing.Size(31, 13);
            this.PriceL.TabIndex = 8;
            this.PriceL.Text = "Price";
            // 
            // price
            // 
            this.price.AutoSize = true;
            this.price.Location = new System.Drawing.Point(219, 59);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(37, 13);
            this.price.TabIndex = 7;
            this.price.Text = "0.00 €";
            // 
            // IDo
            // 
            this.IDo.AutoSize = true;
            this.IDo.Location = new System.Drawing.Point(11, 15);
            this.IDo.Name = "IDo";
            this.IDo.Size = new System.Drawing.Size(82, 13);
            this.IDo.TabIndex = 6;
            this.IDo.Text = "Piece reference";
            // 
            // pieceref
            // 
            this.pieceref.AllowDrop = true;
            this.pieceref.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.pieceref.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.pieceref.FormattingEnabled = true;
            this.pieceref.Location = new System.Drawing.Point(99, 12);
            this.pieceref.Name = "pieceref";
            this.pieceref.Size = new System.Drawing.Size(157, 21);
            this.pieceref.TabIndex = 5;
            this.pieceref.Text = "piece ref";
            this.pieceref.SelectedIndexChanged += new System.EventHandler(this.pieceref_SelectedIndexChanged);
            // 
            // Quantity
            // 
            this.Quantity.AutoSize = true;
            this.Quantity.Location = new System.Drawing.Point(219, 37);
            this.Quantity.Name = "Quantity";
            this.Quantity.Size = new System.Drawing.Size(13, 13);
            this.Quantity.TabIndex = 10;
            this.Quantity.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Quantity";
            // 
            // ConfirmRecieve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 130);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Quantity);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.PriceL);
            this.Controls.Add(this.price);
            this.Controls.Add(this.IDo);
            this.Controls.Add(this.pieceref);
            this.Name = "ConfirmRecieve";
            this.Text = "ConfirmRecieve";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Confirm;
        private System.Windows.Forms.Label PriceL;
        private System.Windows.Forms.Label price;
        private System.Windows.Forms.Label IDo;
        private System.Windows.Forms.ComboBox pieceref;
        private System.Windows.Forms.Label Quantity;
        private System.Windows.Forms.Label label2;
    }
}