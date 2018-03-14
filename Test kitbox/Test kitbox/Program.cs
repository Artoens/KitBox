using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_kitbox
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            /*Piece piece = new Cleat(8, 25);
            Catalog.AddPiece(piece);

            piece = new Cleat(4, 12);
            Catalog.AddPiece(piece);

            Cupboard cupboard = new Cupboard(60, 40);
            Dimension dimension = new Dimension(new int[] {20,40,60}, 3);

            MessageBox.Show(dimension.ToString());*/
            Catalog.GetPieces();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ParentForm());
        }
    }
}
