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
        public OrderPiece()
        {
            InitializeComponent();
            dataGridView.DataSource = DBController.GetAllPiecesOrdered();
        }
    }
}
