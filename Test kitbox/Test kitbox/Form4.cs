using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Test_kitbox
{
    public partial class Form4 : Form
    {
        Order order;
        Output outp = new Output();
        public Form4(Order order)
        {
            this.order = order;
            InitializeComponent();
            Bill.Text = outp.InterfaceOuput(order);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            using (SQLiteConnection connect = new SQLiteConnection("Data Source=..\\..\\..\\..\\Kitbox.db"))
            {
                /*
                connect.Open();
                SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO Orders (ID_Order, Price) VALUES(\"" + outp.id + "\"," + outp.TotalPrice(order).ToString() + ")", connect);

                try
                {
                    insertSQL.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                

                connect.Open();
                string sql = "insert into Orders (ID_Order, Price) values ('22222222', 6000)";
                SQLiteCommand command = new SQLiteCommand(sql, connect);
                // EXECUTE THE SQL REQUEST
                command.ExecuteNonQuery();
                //q.Read();
                */
                string InsertSql = @"INSERT INTO Orders (ID_Order, Price) VALUES($id, $price)";
                connect.Open();
                SQLiteCommand InsertCom = new SQLiteCommand(InsertSql, connect);
                InsertCom.Parameters.Add("$id", DbType.String).Value = outp.id;
                InsertCom.Parameters.Add("$price", DbType.Int32).Value = outp.TotalPrice(order);
                InsertCom.ExecuteNonQuery(); ;

            }

            //MessageBox.Show(fmd.CommandText);
            List<Product> products = order.GenerateOrder();
            foreach (Product product in products)
            {
                //REMOVE THE ORDERED PIECES FROM THE STOCK
                // & PLACE MISSING PIECES INTO DB (TO ORDER)
                order.UpdateDatabase(product);
                
            }

            //CLOSE THE FORM & THE APP
            //Application.Exit();
            this.Close();
            Form f = new ParentForm();
            f.Show();
        }
    }
}
