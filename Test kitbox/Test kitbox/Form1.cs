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
    public partial class Form1 : Form
    {
        ParentForm parent;

        public Form1(ParentForm parent)
        {
            this.parent = parent;
            InitializeComponent();

            //GET DIMENSION LIST
            List<Dimension> dimensionList = DimensionCatalog.GetDimensions();

            foreach (Dimension dimension in dimensionList)
            {
                comboBoxDim.Items.Add(dimension.ToString());
            }
            
            
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if (comboBoxDim.Text != "")
            {
            string[] dim = comboBoxDim.Text.Split('x');
            Cupboard Cupboard = new Cupboard(Int32.Parse(dim[0]), Int32.Parse(dim[1]));
            parent.Cup = Cupboard;
            parent.Next();
            }
            else
            {
                MessageBox.Show("Enter a valid dimention pls");
            }
        }

        private void comboBoxDim_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
