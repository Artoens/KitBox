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
        //Bind the combobox with de Model View
        public PieceOrder()
        {
            InitializeComponent();
            Piece.DataSource = DBController.GetAllPiecesToOrder();
            Number.Text = "1";
        }
        //ON COMBOBOX CHANGED : Updates the price
        private void Piece_SelectedIndexChanged(object sender, EventArgs e)
        {
            Changeprice();
        }

        //ON TEXT CHANGED : Updates the price
        private void Number_TextChanged(object sender, EventArgs e)
        {
            Changeprice();
        }

        //Updates the price depend on the piece and the quantity to order
        private void Changeprice()
        {
            try
            {
                int n = Int32.Parse(Number.Text);
                intPrice.Text = ((double)(((PieceStock)Piece.SelectedItem).Price * n) / 10000).ToString("0.##€");
            }
            catch
            {

            }
        }

        private void intPrice_Click(object sender, EventArgs e)
        {

        }

        //ON CLICK : Update the piece from de database (see DBController.OrderPiece method ) and close this form 
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
