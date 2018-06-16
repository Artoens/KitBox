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
        Output outp = new Output();
        public Form4(Order order)
        {
            InitializeComponent();
            Bill.Text = outp.InterfaceOuput(order);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection connect = new SQLiteConnection("Data Source=..\\..\\..\\..\\Kitbox.db"))
            {

                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"INSERT INTO Orders (ID_Order, Price)
                                            VALUES ("+ outp.id +", " + outp.Totalprice(order) +")";
                }
            }
            return 0;


        }
    }
}
