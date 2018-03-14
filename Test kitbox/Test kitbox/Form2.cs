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
    public partial class Form2 : Form
    {
        ParentForm parent;

        public Form2(ParentForm parent)
        {
            this.parent = parent;
            InitializeComponent();

            //GET DIMENSION LIST
            List<Dimension> dimensionList = DimensionCatalog.GetCompartmentDimensions();

            foreach (Dimension dimension in dimensionList)
            {
                comboBoxH.Items.Add(dimension.ToString());
            }
            //get colors
            List<string> colorlList = DimensionCatalog.GetCompartmentColors();

            foreach (string color in colorlList)
            {
                comboBoxC.Items.Add(color);
            }
        }

        private void Done_Click(object sender, EventArgs e)
        {
            parent.Next();
        }

        private void comboBoxH_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
