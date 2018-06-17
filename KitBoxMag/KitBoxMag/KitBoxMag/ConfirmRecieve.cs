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
    public partial class ConfirmRecieve : Form
    {
        public ConfirmRecieve()
        {
            InitializeComponent();
            pieceref.DataSource = DBController.GetAllPiecesOrdered();
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            DBController.DeletePieceOrdered(((PieceStock)pieceref.SelectedItem).Id, ((PieceStock)pieceref.SelectedItem).Quantity);
            Close();
        }

        private void pieceref_SelectedIndexChanged(object sender, EventArgs e)
        {
            price.Text = ((double)(((PieceStock)pieceref.SelectedItem).Price * ((PieceStock)pieceref.SelectedItem).Quantity) / 1000).ToString("0.##€");
            Quantity.Text = ((PieceStock)pieceref.SelectedItem).Quantity.ToString();
        }
    }
}
