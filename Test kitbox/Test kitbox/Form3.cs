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
    public partial class Form3 : Form
    {
        ParentForm parent;

        public Form3(ParentForm parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void LevelY_Click(object sender, EventArgs e)
        {
            parent.Back();
        }

        private void LevelN_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            order.AddItem(parent.Cup);
            foreach (Compartment comp in parent.Cup.GetAllCompartments())
            {
                order.AddItem(comp);
            }
            parent.Close();
            Form4 form4 = new Form4(order);
        }
    }
}
