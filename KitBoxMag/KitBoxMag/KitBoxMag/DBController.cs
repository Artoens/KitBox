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
        public static List<Piece> pieceList = new List<Piece>();
        public static List<ClientsOrder> OrderList = new List<ClientsOrder>();

        private static String pathdb = @"Data Source=..\..\..\..\..\Kitbox.db";

        //First method OK
        public static List<Piece> GetAllPiecesOrdered()
        {
            using (SQLiteConnection connect = new SQLiteConnection(pathdb))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT p.*, r.Reference
                                        FROM Piece p
                                        INNER JOIN Reference r
                                        ON p.Piece_Code = s.Piece_Code
                                        WHERE p.Ordered = 1";
                    SQLiteDataReader q = fmd.ExecuteReader();

                    while (q.Read())
                    {
                        GetListPieces(q);
                    }

                }

                return pieceList;

            }

        }
        //Second method OK
        public static List<Piece> GetAllStock()
        {
            using (SQLiteConnection connect = new SQLiteConnection(pathdb))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT p.*, r.Reference, c.Color
                                    FROM Piece p
                                    INNER JOIN Stock s
                                    ON p.Piece_Code = s.Piece_Code
                                    INNER JOIN Reference r
                                    ON r.ID_Piece = p.ID_Piece
                                    OUTER JOIN Color c
                                    ON c.PK_Color = p.ID_Color
                                    WHERE s.Quantity > 0";
                    SQLiteDataReader q = fmd.ExecuteReader();

                    while (q.Read())
                    {
                        GetListPieces(q);
                    }
                }

            }

            return pieceList;

        }

        //Third method OK
        //Il faut faire un constructeur pour ClientOrder qui prend comme arguments id, price_order
        public static List<ClientsOrder> GetAllClientsOrder()
        {
            using (SQLiteConnection connect = new SQLiteConnection(pathdb))
            {
                connect.Open();

                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT *
                                        FROM Order";

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
        public static List<Piece> GetAllPiecesToOrder()
        {
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
                            GetListPieces(q);
                        }
                }
            }

                return pieceList;

        }

        //Method just to simplify the other ones
        static private List<Piece> GetListPieces(SQLiteDataReader q)
        {
            pieceList.Clear();

            string reference = Convert.ToString(q["Reference"]);
            int price = Convert.ToInt16(q["Price_Client"]);
            string id = Convert.ToString(q["Piece_Code"]);

            if (reference == "Angle bar")
            {
                int height = Convert.ToInt16(q["Height"]);
                string color = Convert.ToString(q["Color"]);
                Piece AngleBar = new AngleBar(height, color, price, id);
                pieceList.Add(AngleBar);
            }

            else if (reference == "B_Panel")
            {
                int length = Convert.ToInt16(q["Length"]);
                int height = Convert.ToInt16(q["Height"]);
                int depth = Convert.ToInt16(q["Depth"]);
                string color = Convert.ToString(q["Color"]);
                string type = "B";
                Piece Panel = new Panel(length, height, depth, color, type, price, id);
                pieceList.Add(Panel);
            }

            else if (reference == "TB_Panel")
            {
                int length = Convert.ToInt16(q["Length"]);
                int height = Convert.ToInt16(q["Height"]);
                int depth = Convert.ToInt16(q["Depth"]);
                string color = Convert.ToString(q["Color"]);
                string type = "TB"; 
                Piece Panel = new Panel(length, height, depth, color, type, price, id);
                pieceList.Add(Panel);
            }

            else if (reference == "LR_Panel")
            {
                int length = Convert.ToInt16(q["Length"]);
                int height = Convert.ToInt16(q["Height"]);
                int depth = Convert.ToInt16(q["Depth"]);
                string color = Convert.ToString(q["Color"]);
                string type = "LR";
                Piece Panel = new Panel(length, height, depth, color, type, price, id);
                pieceList.Add(Panel);
            }


            else if (reference == "TB_Panel")
            {
                int length = Convert.ToInt16(q["Length"]);
                int height = Convert.ToInt16(q["Height"]);
                int depth = Convert.ToInt16(q["Depth"]);
                string color = Convert.ToString(q["Color"]);
                string type = "TB";
                Piece Panel = new Panel(length, height, depth, color, type, price, id);
                pieceList.Add(Panel);
            }

            else if (reference == "Door")
            {
                int length = Convert.ToInt16(q["Length"]);
                int height = Convert.ToInt16(q["Height"]);
                string color = Convert.ToString(q["Color"]);
                Piece Door = new Door(length, height, color, price, id);
                pieceList.Add(Door);
            }

            else if (reference == "Cleat")
            {
                int height = Convert.ToInt16(q["Height"]);
                Piece Cleat = new Cleat(height, price, id);
                pieceList.Add(Cleat);
            }

            else if (reference == "B_Rail")
            {
                string type = "B";
                int length = Convert.ToInt16(q["Length"]);
                Piece Rail = new Rail(type, length, price, id);
                pieceList.Add(Rail);
            }

            else if (reference == "F_Rail")
            {
                string type = "F";
                int length = Convert.ToInt16(q["Length"]);
                Piece Rail = new Rail(type, length, price, id);
                pieceList.Add(Rail);
            }

            else if (reference == "Knob")
            {
                int diameter = Convert.ToInt16(q["Dimensions"]);
                Piece Knob = new Knob(diameter, price, id);
                pieceList.Add(Knob);
            }

            else if (reference == "LR_Rail")
            {
                string type = "LR";
                int length = Convert.ToInt16(q["Length"]);
                Piece Rail = new Rail(type, length, price, id);
                pieceList.Add(Rail);
            }


            else if (reference == "Knob")
            {
                int diameter = Convert.ToInt16(q["Dimensions"]);
                Piece Knob = new Knob(diameter, price, id);
                pieceList.Add(Knob);
            }

            return pieceList;
        }
    }
}