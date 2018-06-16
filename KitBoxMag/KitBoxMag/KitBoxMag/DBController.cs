using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace KitBoxMag
{
    public static class DBController
    {

        private static String pathdb = @"Data Source=..\..\..\..\..\Kitbox.db";

        //First method OK
        public static List<PieceStock> GetAllPiecesOrdered()
        {
            List<PieceStock> pieceList = new List<PieceStock>();
            using (SQLiteConnection connect = new SQLiteConnection(pathdb))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT p.*, r.Reference
                                        FROM Piece p
                                        INNER JOIN Reference r
                                        ON p.Piece_Code = r.ID_Piece
                                        WHERE p.Ordered = 1";
                    SQLiteDataReader q = fmd.ExecuteReader();

                    while (q.Read())
                    {
                        GetListPieces(q, pieceList);
                    }
                }

                return pieceList;

            }
        }
        //Second method OK
        public static List<PieceStock> GetAllStock()
        {
            List<PieceStock> pieceList = new List<PieceStock>();
            using (SQLiteConnection connect = new SQLiteConnection(pathdb))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT p.*, r.Reference, c.Color, s.Quantity
                                    FROM Piece p
                                    INNER JOIN Stock s
                                    ON p.Piece_Code = s.Piece_Code
                                    INNER JOIN Reference r
                                    ON r.ID_Piece = p.ID_Piece
                                    LEFT OUTER JOIN Color c
                                    ON c.PK_Color = p.ID_Color
                                    WHERE s.Quantity > 0";
                    SQLiteDataReader q = fmd.ExecuteReader();

                    while (q.Read())
                    {
                        GetListPieces(q, pieceList);
                    }
                }

            }

            return pieceList;

        }

        //Third method OK
        //Il faut faire un constructeur pour ClientOrder qui prend comme arguments id, price_order
        public static List<ClientsOrder> GetAllClientsOrder()
        {
            List<ClientsOrder> OrderList = new List<ClientsOrder>();
            using (SQLiteConnection connect = new SQLiteConnection(pathdb))
            {
                connect.Open();

                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT *
                                        FROM Orders";

                    SQLiteDataReader q = fmd.ExecuteReader();

                    while (q.Read())
                    {
                        string ID = Convert.ToString(q["ID_Order"]);
                        int price_order = Convert.ToInt16(q["Price"]);
                        ClientsOrder newOrder = new ClientsOrder(ID, price_order);
                        OrderList.Add(newOrder);
                    }
                }

                return OrderList;

            }
        }

        //Fourth method Done but must be verified with the variable thing
        public static void OrderPiece(string P_Code)
        {
            using (SQLiteConnection connect = new SQLiteConnection(pathdb))
            {
                connect.Open();

                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"UPDATE Piece SET Ordered = TRUE WHERE ID_Piece = " + P_Code + "";
                    SQLiteDataReader q = fmd.ExecuteReader();
                    q.Read();
                }
            }
        }

        //Fifth method - set ordered to null
        public static void DeletePieceOrdered(string Piece_Code)
        {
            using (SQLiteConnection connect = new SQLiteConnection(pathdb))
            {
                connect.Open();

                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"UPDATE Ordered FROM Piece SET Ordered = FALSE WHERE ID_Piece = " + Piece_Code + "";
                    SQLiteDataReader q = fmd.ExecuteReader();
                    q.Read();
                }
            }
        }

        //Sixth method OK but see the variable thing
        public static void DeleteClientOrder(char ID_Order)
        {
            using (SQLiteConnection connect = new SQLiteConnection(pathdb))
            {
                connect.Open();

                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"DELETE FROM Order WHERE ID_Order = " + ID_Order + "";
                    SQLiteDataReader q = fmd.ExecuteReader();
                    q.Read();
                }
            }
        }

        //Seventh method OK
        public static List<PieceStock> GetAllPiecesToOrder()
        {
            List<PieceStock> pieceList = new List<PieceStock>();
            using (SQLiteConnection connect = new SQLiteConnection(pathdb))
            {
                connect.Open();

                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT p.*, r.Reference, c.Color
                                        FROM Piece p
                                        INNER JOIN Stock s
                                        ON s.Piece_Code = p.Piece_Code
                                        INNER JOIN Reference r
                                        ON r.ID_Piece=p.ID_Piece
                                        OUTER JOIN Color c
                                        ON c.PK_Color = p.ID_Color
                                        WHERE s.To_Order = 1";
                    SQLiteDataReader q = fmd.ExecuteReader();

                        while (q.Read())
                        {
                            GetListPieces(q, pieceList);
                        }
                }
            }

                return pieceList;

        }

        //Method just to simplify the other ones
        static private List<PieceStock> GetListPieces(SQLiteDataReader q, List<PieceStock> pieceList)
        {
            string reference = Convert.ToString(q["Reference"]);
            int price = Convert.ToInt32(q["Price_Client"]);
            string id = Convert.ToString(q["Piece_Code"]);
            int quantity = Convert.ToInt32(q["Quantity"]);

            PieceStock temp = new PieceStock(reference, quantity, price, id);

            pieceList.Add(temp);

            return pieceList;
        }
    }
}
