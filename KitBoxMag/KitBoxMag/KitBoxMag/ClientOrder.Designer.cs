namespace KitBoxMag
{
    partial class ClientOrder
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
            this.orderid = new System.Windows.Forms.ComboBox();
            this.IDo = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.Label();
            this.PriceL = new System.Windows.Forms.Label();
            this.Confirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // orderid
            // 
            this.orderid.AllowDrop = true;
            this.orderid.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.orderid.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.orderid.FormattingEnabled = true;
            this.orderid.Location = new System.Drawing.Point(91, 12);
            this.orderid.Name = "orderid";
            this.orderid.Size = new System.Drawing.Size(166, 21);
            this.orderid.TabIndex = 0;
            this.orderid.Text = "Order\'s ID";
            this.orderid.SelectedIndexChanged += new System.EventHandler(this.orderid_SelectedIndexChanged);
            // 
            // IDo
            // 
            this.IDo.AutoSize = true;
            this.IDo.Location = new System.Drawing.Point(12, 15);
            this.IDo.Name = "IDo";
            this.IDo.Size = new System.Drawing.Size(54, 13);
            this.IDo.TabIndex = 1;
            this.IDo.Text = "Order\'s ID";
            // 
            // price
            // 
            this.price.AutoSize = true;
            this.price.Location = new System.Drawing.Point(221, 40);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(37, 13);
            this.price.TabIndex = 2;
            this.price.Text = "0.00 €";
            // 
            // PriceL
            // 
            this.PriceL.AutoSize = true;
            this.PriceL.Location = new System.Drawing.Point(12, 40);
            this.PriceL.Name = "PriceL";
            this.PriceL.Size = new System.Drawing.Size(31, 13);
            this.PriceL.TabIndex = 3;
            this.PriceL.Text = "Price";
            // 
            // Confirm
            // 
            this.Confirm.Location = new System.Drawing.Point(182, 76);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(75, 23);
            this.Confirm.TabIndex = 4;
            this.Confirm.Text = "Confirm";
            this.Confirm.UseVisualStyleBackColor = true;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // ClientOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 111);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.PriceL);
            this.Controls.Add(this.price);
            this.Controls.Add(this.IDo);
            this.Controls.Add(this.orderid);
            this.Name = "ClientOrder";
            this.Text = "ClientOrder";
            this.Load += new System.EventHandler(this.ClientOrder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox orderid;
        private System.Windows.Forms.Label IDo;
        private System.Windows.Forms.Label price;
        private System.Windows.Forms.Label PriceL;
        private System.Windows.Forms.Button Confirm;
    }
}