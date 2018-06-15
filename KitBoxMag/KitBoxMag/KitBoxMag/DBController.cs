using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace KitBoxMag
{
    class DBController
    {
        List<Piece> GetAllPiecesOrdered()
        {
            using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=C:\Users\15171\Desktop\Kitbox.db;Version=3;"))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {

                }
            
            }

        }

        List<Piece> GetAllStock()
        {

        }

        List<ClientOrder> GetAllClientsOrder()
        {

        }

        void OrderPiece(string Piece_Code)
        {

        }

        void DeletePieceOrdered(string Piece_Code)
        {

        }

        void DeleteClientOrder(char ID_Order)
        {

        }

        List<Piece> GetAllPiecesToOrder()
        {

        }
    }
