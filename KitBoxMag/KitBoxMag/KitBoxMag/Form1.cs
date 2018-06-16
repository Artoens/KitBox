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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DataTab s = new Stock();
            DataTab c = new Client_s_Order();
            DataTab o = new OrderPiece();
            Tab.TabPages[0].Controls.Add(s.pnl);
            Tab.TabPages[1].Controls.Add(c.pnl);
            Tab.TabPages[2].Controls.Add(o.pnl);

        }

        private void ConfirmC_Click(object sender, EventArgs e)
        {
            ClientOrder co = new ClientOrder();
            co.Show();
        }

        private void ConfirmP_Click(object sender, EventArgs e)
        {
            ConfirmRecieve cr = new ConfirmRecieve();
            cr.Show();
        }

        private void Order_Click(object sender, EventArgs e)
        {
            PieceOrder p = new PieceOrder();
            p.Show();
        }
    }
}
