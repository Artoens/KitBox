namespace KitBoxMag
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.ConfirmC = new System.Windows.Forms.Button();
            this.ConfirmP = new System.Windows.Forms.Button();
            this.Order = new System.Windows.Forms.Button();
            this.Tab = new System.Windows.Forms.TabControl();
            this.Stock = new System.Windows.Forms.TabPage();
            this.Orders = new System.Windows.Forms.TabPage();
            this.Com = new System.Windows.Forms.TabPage();
            this.Tab.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConfirmC
            // 
            this.ConfirmC.Location = new System.Drawing.Point(12, 27);
            this.ConfirmC.Name = "ConfirmC";
            this.ConfirmC.Size = new System.Drawing.Size(75, 40);
            this.ConfirmC.TabIndex = 1;
            this.ConfirmC.Text = "Confirm client\'s order";
            this.ConfirmC.UseVisualStyleBackColor = true;
            this.ConfirmC.Click += new System.EventHandler(this.ConfirmC_Click);
            // 
            // ConfirmP
            // 
            this.ConfirmP.Location = new System.Drawing.Point(93, 27);
            this.ConfirmP.Name = "ConfirmP";
            this.ConfirmP.Size = new System.Drawing.Size(75, 40);
            this.ConfirmP.TabIndex = 2;
            this.ConfirmP.Text = "Confirm piece order";
            this.ConfirmP.UseVisualStyleBackColor = true;
            this.ConfirmP.Click += new System.EventHandler(this.ConfirmP_Click);
            // 
            // Order
            // 
            this.Order.Location = new System.Drawing.Point(174, 27);
            this.Order.Name = "Order";
            this.Order.Size = new System.Drawing.Size(75, 40);
            this.Order.TabIndex = 3;
            this.Order.Text = "Order";
            this.Order.UseVisualStyleBackColor = true;
            this.Order.Click += new System.EventHandler(this.Order_Click);
            // 
            // Tab
            // 
            this.Tab.Controls.Add(this.Stock);
            this.Tab.Controls.Add(this.Orders);
            this.Tab.Controls.Add(this.Com);
            this.Tab.Location = new System.Drawing.Point(12, 74);
            this.Tab.Name = "Tab";
            this.Tab.SelectedIndex = 0;
            this.Tab.Size = new System.Drawing.Size(776, 364);
            this.Tab.TabIndex = 4;
            // 
            // Stock
            // 
            this.Stock.Location = new System.Drawing.Point(4, 22);
            this.Stock.Name = "Stock";
            this.Stock.Size = new System.Drawing.Size(768, 338);
            this.Stock.TabIndex = 0;
            this.Stock.Text = "Stock";
            this.Stock.UseVisualStyleBackColor = true;
            // 
            // Orders
            // 
            this.Orders.Location = new System.Drawing.Point(4, 22);
            this.Orders.Name = "Orders";
            this.Orders.Size = new System.Drawing.Size(768, 338);
            this.Orders.TabIndex = 1;
            this.Orders.Text = "Client\'s Orders";
            this.Orders.UseVisualStyleBackColor = true;
            // 
            // Com
            // 
            this.Com.Location = new System.Drawing.Point(4, 22);
            this.Com.Name = "Com";
            this.Com.Size = new System.Drawing.Size(768, 338);
            this.Com.TabIndex = 2;
            this.Com.Text = "Ordered Pieces";
            this.Com.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Tab);
            this.Controls.Add(this.Order);
            this.Controls.Add(this.ConfirmP);
            this.Controls.Add(this.ConfirmC);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Tab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ConfirmC;
        private System.Windows.Forms.Button ConfirmP;
        private System.Windows.Forms.Button Order;
        private System.Windows.Forms.TabControl Tab;
        private System.Windows.Forms.TabPage Stock;
        private System.Windows.Forms.TabPage Orders;
        private System.Windows.Forms.TabPage Com;
    }
}

