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
                    fmd.CommandText = @"SELECT p.*, r.Reference, s.Ordered_Extra
                                        FROM Piece p
                                        INNER JOIN Stock s
                                        ON p.Piece_Code = s.Piece_Code
                                        INNER JOIN Reference r
                                        ON r.ID_Piece = p.ID_Piece
                                        LEFT OUTER JOIN Color c
                                        ON c.PK_Color = p.ID_Color
                                        WHERE p.Ordered=1";
                    SQLiteDataReader q = fmd.ExecuteReader();

                    while (q.Read())
                    {
                        GetListPieces(q, pieceList);
                        Console.WriteLine(pieceList.Count);
                    }
                }
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT p.*, l.Price ,l.Delay, s.Name
                                    FROM Piece p
									INNER JOIN Link_Piece_Supp l
                                    ON p.Piece_Code = l.Piece_Code
									inner join Supplier s
									on l.ID_Sup = s.ID_Sup";
                    SQLiteDataReader q = fmd.ExecuteReader();
                    while (q.Read())
                    {
                        UpdatePiecesInfo(q, pieceList);
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
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT p.*, l.Price ,l.Delay, s.Name
                                    FROM Piece p
									INNER JOIN Link_Piece_Supp l
                                    ON p.Piece_Code = l.Piece_Code
									inner join Supplier s
									on l.ID_Sup = s.ID_Sup";
                    SQLiteDataReader q = fmd.ExecuteReader();
                    while (q.Read())
                    {
                        UpdatePiecesInfo(q, pieceList);
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
        public static void OrderPiece(string P_Code, int quantity)
        {
            using (SQLiteConnection connect = new SQLiteConnection(pathdb))
            {
                connect.Open();

                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"UPDATE Piece SET Ordered = 1 WHERE Piece_Code =" + "\"" + P_Code + "\"";
                    SQLiteDataReader q = fmd.ExecuteReader();
                    q.Read();
                    Console.WriteLine("ordered");
                }
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"UPDATE Stock SET Ordered_Extra ="+ quantity + ", To_Order = 0 WHERE Piece_Code =\"" + P_Code +"\"";
                    SQLiteDataReader q = fmd.ExecuteReader();
                    q.Read();
                    Console.WriteLine("add quantity");
                }
            }
        }

        //Fifth method - set ordered to null
        public static void DeletePieceOrdered(string Piece_Code, int quantity)
        {
            using (SQLiteConnection connect = new SQLiteConnection(pathdb))
            {
                connect.Open();

                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"UPDATE Piece SET Ordered = 0 WHERE Piece_Code =" + "\"" + Piece_Code + "\"";
                    SQLiteDataReader q = fmd.ExecuteReader();
                    q.Read();
                }
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"UPDATE Stock SET Ordered_Extra = 0, Quantity = Quantity + " + quantity + " WHERE Piece_Code =\"" + Piece_Code + "\"";
                    SQLiteDataReader q = fmd.ExecuteReader();
                    q.Read();
                }
            }
        }

        //Sixth method OK but see the variable thing
        public static void DeleteClientOrder(string ID_Order)
        {
            using (SQLiteConnection connect = new SQLiteConnection(pathdb))
            {
                connect.Open();

                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"DELETE FROM Orders WHERE ID_Order = " + ID_Order;
                    SQLiteDataReader q = fmd.ExecuteReader();
                    q.Read();
                }
            }
            GetAllClientsOrder();
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
                    fmd.CommandText = @"SELECT p.*, r.Reference, c.Color, s.Quantity
                                        FROM Piece p
                                        INNER JOIN Stock s
                                        ON s.Piece_Code = p.Piece_Code
                                        INNER JOIN Reference r
                                        ON r.ID_Piece=p.ID_Piece
                                        LEFT OUTER JOIN Color c
                                        ON c.PK_Color = p.ID_Color
                                        WHERE s.To_Order = 1";
                    SQLiteDataReader q = fmd.ExecuteReader();

                        while (q.Read())
                        {
                            GetListPieces(q, pieceList);
                        }
                }
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT p.*, l.Price ,l.Delay, s.Name
                                    FROM Piece p
									INNER JOIN Link_Piece_Supp l
                                    ON p.Piece_Code = l.Piece_Code
									inner join Supplier s
									on l.ID_Sup = s.ID_Sup";
                    SQLiteDataReader q = fmd.ExecuteReader();
                    while (q.Read())
                    {
                        UpdatePiecesInfo(q, pieceList);
                    }
                }
            }

                return pieceList;

        }

        //Method just to simplify the other ones
        static private List<PieceStock> GetListPieces(SQLiteDataReader q, List<PieceStock> pieceList)
        {
            int quantity = 0;
            string reference = Convert.ToString(q["Reference"]);
            int price = Convert.ToInt32(q["Price_Client"]);
            string id = Convert.ToString(q["Piece_Code"]);
            try
            {
                quantity = Convert.ToInt32(q["Quantity"]);
            }
            catch
            {
                quantity = Convert.ToInt32(q["Ordered_Extra"]); 
            }

            PieceStock temp = new PieceStock(reference, quantity, price, id);

            pieceList.Add(temp);

            return pieceList;
        }

        static private List<PieceStock> UpdatePiecesInfo(SQLiteDataReader q, List<PieceStock> pieceList)
        {
            //Console.WriteLine(Convert.ToString(q["Piece_Code"]));
            PieceStock piece = pieceList.Where(e => Convert.ToString(q["Piece_Code"]) == e.Id).FirstOrDefault();
            if (piece != null)
            {

                if (piece.Price > Convert.ToInt32(q["Price"]))
                {
                    piece.Price = Convert.ToInt32(q["Price"]);
                    piece.ShippingDelay = Convert.ToInt32(q["Delay"]);
                    piece.Supplier = Convert.ToString(q["Name"]);
                }
                else if (piece.Price == Convert.ToInt32(q["Price"]) && piece.ShippingDelay > Convert.ToInt32(q["Delay"]))
                {
                    piece.ShippingDelay = Convert.ToInt32(q["Delay"]);
                    piece.Supplier = Convert.ToString(q["Name"]);
                }
            }
            
            return pieceList;
        }
    }
}
