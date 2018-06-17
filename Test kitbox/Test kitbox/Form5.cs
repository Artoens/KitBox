using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_kitbox
{
    public partial class Form5 : Form
    {
        ParentForm parent;
        public Form5(ParentForm parent)
        {
            this.parent = parent;
            InitializeComponent();
            anglebarcolor.DataSource = DimensionCatalog.GetAngleBarColors(parent.Cup.Height);
        }

        private void fin_Click(object sender, EventArgs e)
        {
            if (anglebarcolor.SelectedItem.ToString() != "")
            {

                parent.Cup.AngleBarColor = anglebarcolor.SelectedItem.ToString();
                Order order = new Order();
                order.AddItem(parent.Cup);
                Form4 form4 = new Form4(order);
                parent.Hide();
                form4.Show();
            }
            else
            {
                MessageBox.Show("NUL");
            }
        }
    }

}
