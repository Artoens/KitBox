using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KitBoxMag
{
    public partial class ClientOrder : Form
    {
        public ClientOrder()
        {
            InitializeComponent();
        }

        //Bind the combobox with de Model View
        private void ClientOrder_Load(object sender, EventArgs e)
        {
            orderid.DataSource = DBController.GetAllClientsOrder();
        }

        //ON COMBOBOX CHANGED : Updates the price depend on the Client's order selected
        private void orderid_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClientsOrder order = (ClientsOrder)orderid.SelectedItem;
            price.Text = ((double)order.Price/10000).ToString("0.##€");
        }


        //ON CLICK : Deletes the order from de database and close this form 
        private void Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                DBController.DeleteClientOrder(((ClientsOrder)orderid.SelectedItem).Id);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Close();
            }
        }
    }
}
