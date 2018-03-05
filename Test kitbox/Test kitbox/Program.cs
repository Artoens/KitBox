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

            Piece piece = new Cleat(8, 25);
            Catalog.pieceList.Add(piece);

            piece = new Cleat(4, 12);
            Catalog.pieceList.Add(piece);

            Cupboard cupboard = new Cupboard(60, 40);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ParentForm());
        }
    }
}
