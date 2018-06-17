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
    public partial class Update : Form
    {
        public Update()
        {
            InitializeComponent();
            comboBoxSupp.DataSource = DBController.GetAllSupplier();
        }

        private void comboBoxSupp_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxPiece.DataSource = DBController.GetAllCatalog((Supplier)comboBoxSupp.SelectedItem);
        }

        private void updt_Click(object sender, EventArgs e)
        {
            try
            {
                int n = Int32.Parse(newprice.Text);
                DBController.UpdatePrice((Supplier)comboBoxSupp.SelectedItem, (string)comboBoxPiece.SelectedItem, n);
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
