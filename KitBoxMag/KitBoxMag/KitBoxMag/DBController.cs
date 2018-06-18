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

        //Gets all ordered pieces from the DB
        //Returns a list of ViewModel PieceStock
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
        //Gets all stock from the DB (Quantity of the piece > 0)
        //Returns a list of ViewModel PieceStock
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

        //Gets all Client's order (ID and price)
        //Returns a list of ViewModel ClientsOrder
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
                        int price_order = Convert.ToInt32(q["Price"]);
                        ClientsOrder newOrder = new ClientsOrder(ID, price_order);
                        OrderList.Add(newOrder);
                    }
                }
                
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    Guid a = Guid.NewGuid();
                    fmd.CommandText = @"INSERT INTO Orders (ID_Order, Price) VALUES('" + a + "', 333333)";
                    fmd.ExecuteNonQuery();
                }
                

                return OrderList;

            }
        }

        //Updates a piece in the DB
        //In the db : Removes the piece from the to order list
        //            Sets the piece in the ordered list
        //            Sets the quantity ordered
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
                    fmd.CommandText = @"UPDATE Stock SET Ordered_Extra =" + quantity + ", To_Order = 0 WHERE Piece_Code =\"" + P_Code + "\"";
                    SQLiteDataReader q = fmd.ExecuteReader();
                    q.Read();
                    Console.WriteLine("add quantity");
                }
            }
        }

        //Updates a piece in the DB
        //In the db : Removes the piece from the ordered list
        //            Sets the quantity in stock = quantity ordered
        //            Sets the quantity ordered to 0
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

        //Deletes an Order from de DB
        //Once the Order is confirm, we don't need it anymore
        public static void DeleteClientOrder(string ID_Order)
        {
            using (SQLiteConnection connect = new SQLiteConnection(pathdb))
            {
                connect.Open();

                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"DELETE FROM Orders WHERE ID_Order = '" + ID_Order + "'";
                    SQLiteDataReader q = fmd.ExecuteReader();
                    q.Read();
                }
            }
            GetAllClientsOrder();
        }

        //Gets all pieces to order from the DB
        //Returns a list of ViewModel PieceStock
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

        //Creates the View Model and add it for the others methods
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

        //Updates the price of the View Model to the lowest 
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

        //Gets all the supplier from the DB
        public static List<Supplier> GetAllSupplier()
        {
            List<Supplier> suppliers = new List<Supplier>();
            using (SQLiteConnection connect = new SQLiteConnection(pathdb))
            {
                connect.Open();

                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT ID_Sup, Name
                                        FROM Supplier";

                    SQLiteDataReader q = fmd.ExecuteReader();

                    while (q.Read())
                    {
                        string ID = Convert.ToString(q["ID_Sup"]);
                        string name = Convert.ToString(q["Name"]);
                        Supplier supplier = new Supplier(ID, name);
                        suppliers.Add(supplier);
                    }
                }
            }

            return suppliers;
        }

        //Gets all the pieces proposed by a supplier
        public static List<string> GetAllCatalog(Supplier sup)
        {
            List<string> pieceList = new List<string>();
            using (SQLiteConnection connect = new SQLiteConnection(pathdb))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT Piece_Code
                                        FROM Link_Piece_Supp
                                        WHERE ID_Sup = '" + sup.ID +"'";
                    SQLiteDataReader q = fmd.ExecuteReader();

                    while (q.Read())
                    {
                        pieceList.Add(Convert.ToString(q["Piece_Code"]));
                    }
                }
            }
            return pieceList;
        }

        //Updates a piece in the DB
        //In the db : Update a price of a piece from a supplier
        public static void UpdatePrice(Supplier sup, string ID_P, int price)
        {
            using (SQLiteConnection connect = new SQLiteConnection(pathdb))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"UPDATE Link_Piece_Supp SET Price ="+ price +" WHERE Piece_Code =" + "\"" + ID_P + "\"AND ID_Sup = '" + sup.ID + "'";
                    SQLiteDataReader q = fmd.ExecuteReader();
                    q.Read();
                }
            }
        }
    }
}
