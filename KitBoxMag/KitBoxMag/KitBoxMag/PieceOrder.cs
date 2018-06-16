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
    public partial class PieceOrder : Form
    {
        public PieceOrder()
        {
            InitializeComponent();
            Piece.DataSource = DBController.GetAllPiecesToOrder();
            Number.Text = "1";
        }

        private void Piece_SelectedIndexChanged(object sender, EventArgs e)
        {
            Changeprice();
        }

        private void Number_TextChanged(object sender, EventArgs e)
        {
            Changeprice();
        }

        private void Changeprice()
        {
            try
            {
                int n = Int32.Parse(Number.Text);
                intPrice.Text = ((double)(((PieceStock)Piece.SelectedItem).Price * n) / 100).ToString("0.##€");
            }
            catch
            {

            }
        }

        private void intPrice_Click(object sender, EventArgs e)
        {

        }

        private void command_Click(object sender, EventArgs e)
        {
            try
            {
                int n = Int32.Parse(Number.Text);
                DBController.OrderPiece(((PieceStock)Piece.SelectedItem).Id, n);
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
