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
    public partial class Form4 : Form
    {
        public Form4(Order order)
        {
            InitializeComponent();
            Output outp = new Output();
            Bill.Text = outp.InterfaceOuput(order);
        }
    }
}
