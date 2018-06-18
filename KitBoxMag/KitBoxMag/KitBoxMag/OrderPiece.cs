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
    public partial class OrderPiece : DataTab
    {
        //order piece tab
        public OrderPiece()
        {
            InitializeComponent();
            //Bind it with the View Model
            dataGridView.DataSource = DBController.GetAllPiecesOrdered();
        }
    }
}
