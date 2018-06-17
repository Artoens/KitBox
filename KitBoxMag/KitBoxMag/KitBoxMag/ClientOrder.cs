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

        private void ClientOrder_Load(object sender, EventArgs e)
        {
            orderid.DataSource = DBController.GetAllClientsOrder();
        }

        private void orderid_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClientsOrder order = (ClientsOrder)orderid.SelectedItem;
            price.Text = ((double)order.Price/1000).ToString("0.##€");
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                DBController.DeleteClientOrder(((ClientsOrder)orderid.SelectedItem).Id);
            }
            catch
            {

            }
            finally
            {
                Close();
            }
        }
    }
}
