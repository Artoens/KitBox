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
    //MAIN FORM
    public partial class Form1 : Form
    {
        //Fills the tabs with views
        public Form1()
        {
            InitializeComponent();
            DataTab s = new Stock();
            DataTab c = new Client_s_Order();
            DataTab o = new OrderPiece();
            Tab.TabPages[0].Controls.Add(s.pnl);
            Tab.TabPages[1].Controls.Add(c.pnl);
            Tab.TabPages[2].Controls.Add(o.pnl);
            this.Activated += Form1_Activated;
        }

        //Updates the views when this form become the main window
        private void Form1_Activated(object sender, EventArgs e)
        {
            DataTab sa = new Stock();
            DataTab ca = new Client_s_Order();
            DataTab oa = new OrderPiece();
            Tab.TabPages[0].Controls.Clear();
            Tab.TabPages[0].Controls.Add(sa.pnl);
            Tab.TabPages[1].Controls.Clear();
            Tab.TabPages[1].Controls.Add(ca.pnl);
            Tab.TabPages[2].Controls.Clear();
            Tab.TabPages[2].Controls.Add(oa.pnl);
        }

        //ON CLICK : create a new ClientOrderForm and display it
        private void ConfirmC_Click(object sender, EventArgs e)
        {
            ClientOrder co = new ClientOrder();
            co.Show();
        }

        //ON CLICK : create a new ConfirmRecieve and display it
        private void ConfirmP_Click(object sender, EventArgs e)
        {
            ConfirmRecieve cr = new ConfirmRecieve();
            cr.Show();
        }

        //ON CLICK : create a new PieceOrder and display it
        private void Order_Click(object sender, EventArgs e)
        {
            PieceOrder p = new PieceOrder();
            p.Show();
        }

        //ON CLICK : create a new Update and display it
        private void update_Click(object sender, EventArgs e)
        {
            Update u = new Update();
            u.Show();
        }
    }
}
