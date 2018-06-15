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

            //IMPORT PANEL MANUALLY TO GET DIMENSIONS
            Piece panelTB = new Panel(60, 0, 40, "blue", "TB", 54);
            Catalog.AddPiece(panelTB);
            panelTB = new Panel(60, 0, 30, "blue", "TB", 47);
            Catalog.AddPiece(panelTB);
            panelTB = new Panel(50, 0, 20, "red", "TB", 34);
            Catalog.AddPiece(panelTB);

            Piece panel = new Panel(161, 41, 0, "blue", "B", 52);
            Catalog.AddPiece(panel);
            panel = new Panel(0, 41, 61, "blue", "LR", 52);
            Catalog.AddPiece(panel);
            panel = new Panel(80, 42, 0, "red", "B", 52);
            Catalog.AddPiece(panel);
            panel = new Panel(0, 42, 62, "red", "LR", 52);
            Catalog.AddPiece(panel);
            Piece door = new Door(60, 42, "blue", 25);
            Catalog.AddPiece(door);
            door = new Door(60, 41, "red", 25);
            Catalog.AddPiece(door);


            Order order = new Order();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ParentForm());
        }
    }
}
