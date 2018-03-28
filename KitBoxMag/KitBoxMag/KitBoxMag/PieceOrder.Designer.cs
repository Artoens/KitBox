﻿namespace KitBoxMag
{
    partial class PieceOrder
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
            this.Piece = new System.Windows.Forms.ComboBox();
            this.Supplier = new System.Windows.Forms.ComboBox();
            this.Number = new System.Windows.Forms.TextBox();
            this.Quantity = new System.Windows.Forms.Label();
            this.tag = new System.Windows.Forms.Label();
            this.intPrice = new System.Windows.Forms.Label();
            this.Price = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Piece
            // 
            this.Piece.FormattingEnabled = true;
            this.Piece.Location = new System.Drawing.Point(13, 13);
            this.Piece.Name = "Piece";
            this.Piece.Size = new System.Drawing.Size(125, 21);
            this.Piece.TabIndex = 0;
            // 
            // Supplier
            // 
            this.Supplier.FormattingEnabled = true;
            this.Supplier.Location = new System.Drawing.Point(13, 41);
            this.Supplier.Name = "Supplier";
            this.Supplier.Size = new System.Drawing.Size(125, 21);
            this.Supplier.TabIndex = 1;
            // 
            // Number
            // 
            this.Number.Location = new System.Drawing.Point(68, 69);
            this.Number.Name = "Number";
            this.Number.Size = new System.Drawing.Size(70, 20);
            this.Number.TabIndex = 2;
            // 
            // Quantity
            // 
            this.Quantity.AutoSize = true;
            this.Quantity.Location = new System.Drawing.Point(12, 72);
            this.Quantity.Name = "Quantity";
            this.Quantity.Size = new System.Drawing.Size(46, 13);
            this.Quantity.TabIndex = 3;
            this.Quantity.Text = "Quantity";
            // 
            // tag
            // 
            this.tag.AutoSize = true;
            this.tag.Location = new System.Drawing.Point(102, 96);
            this.tag.Name = "tag";
            this.tag.Size = new System.Drawing.Size(13, 13);
            this.tag.TabIndex = 4;
            this.tag.Text = "€";
            // 
            // intPrice
            // 
            this.intPrice.AutoSize = true;
            this.intPrice.Location = new System.Drawing.Point(68, 96);
            this.intPrice.Name = "intPrice";
            this.intPrice.Size = new System.Drawing.Size(28, 13);
            this.intPrice.TabIndex = 5;
            this.intPrice.Text = "0.00";
            // 
            // Price
            // 
            this.Price.AutoSize = true;
            this.Price.Location = new System.Drawing.Point(13, 96);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(31, 13);
            this.Price.TabIndex = 6;
            this.Price.Text = "Price";
            // 
            // PieceOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(150, 218);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.intPrice);
            this.Controls.Add(this.tag);
            this.Controls.Add(this.Quantity);
            this.Controls.Add(this.Number);
            this.Controls.Add(this.Supplier);
            this.Controls.Add(this.Piece);
            this.Name = "PieceOrder";
            this.Text = "PieceOrder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Piece;
        private System.Windows.Forms.ComboBox Supplier;
        private System.Windows.Forms.TextBox Number;
        private System.Windows.Forms.Label Quantity;
        private System.Windows.Forms.Label tag;
        private System.Windows.Forms.Label intPrice;
        private System.Windows.Forms.Label Price;
    }
}