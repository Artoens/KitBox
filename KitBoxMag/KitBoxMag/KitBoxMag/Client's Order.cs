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
    public partial class Client_s_Order : DataTab
    {
        public Client_s_Order()
        {
            InitializeComponent();
            //MessageBox.Show("Bite");
            dataGridView.Rows.Clear();
            dataGridView.DataSource = DBController.GetAllClientsOrder();
        }
    }
}
