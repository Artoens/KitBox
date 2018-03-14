using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Test_kitbox
{
    static class Catalog
    {
        private static List<Piece> pieceList = new List<Piece>();

        //INUTILE
        public static List<String> TestGetPieces()
        {
            List<String> pieces = new List<String>();
            using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=C:\Users\15171\Desktop\Kitbox.db;Version=3;"))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT DISTINCT Piece_Code FROM Link_Piece_Sup";
                    SQLiteDataReader r = fmd.ExecuteReader();
                    
                    while (r.Read())
                    {
                        pieces.Add(Convert.ToString(r["Piece_Code"]));
                    }
                }

                //met tous les ID_link dans une liste
                // Dans une boucle : checker quel type de piece c'est (cleat,...)
                //En fonction du type, ajouter un piece :
                //Piece piece = new Cleat(50, 20);
                //Ajouter le piece à la List<Piece>
            }
            return pieces;
        }

        //UTILE
        public static List<String> GetPieces()
        {
            List<String> pieces = new List<String>();
            using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=C:\Users\15171\Desktop\Kitbox.db;Version=3;"))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    //demande tous les objects avec leur nom de référence
                    fmd.CommandText = @"SELECT * FROM Piece INNER JOIN Reference ON Piece.ID_Piece = Reference.ID_Piece";
                    SQLiteDataReader q = fmd.ExecuteReader();

                    while (q.Read())
                    {
                        string reference = Convert.ToString(q["Reference"]);

                        if (reference == "Angle bar")
                        {
                            int height = Convert.ToInt16(q["Height"]);
                            string color = Convert.ToString(q["Color"]);
                            int price = Convert.ToInt16(q["Price"]); //Attention, le prix est un float non ?
                            Piece AngleBar = new AngleBar(height, color, price);
                            pieceList.Add(AngleBar);
                        }

                        if (reference == "Panel")
                        {
                            int length = Convert.ToInt16(q["Length"]);
                            int height = Convert.ToInt16(q["height"]);
                            int depth = Convert.ToInt16(q["Depth"]);
                            string color = Convert.ToString(q["Color"]);
                            string type; //C'est quoi type?
                            int price = Convert.ToInt16(q["Price"]);
                            Piece Panel = new Panel(length, height, depth, color, type, price);
                            pieceList.Add(Panel);
                        }

                        if (reference == "Door")
                        {
                            int length = Convert.ToInt16(q["Length"]);
                            int height = Convert.ToInt16(q["height"]);
                            string color = Convert.ToString(q["Color"]);
                            int price = Convert.ToInt16(q["Price"]);
                            Piece Door = new Door(length, height, color, price);
                            pieceList.Add(Door);
                        }

                        if (reference == "Cleat")
                        {
                            int height = Convert.ToInt16(q["height"]);
                            int price = Convert.ToInt16(q["Price"]);
                            Piece Cleat = new Cleat(height, price);
                            pieceList.Add(Cleat);
                        }

                        if (reference == "Rail")
                        {
                            string type; //C'est quoi type?
                            int length = Convert.ToInt16(q["Length"]);
                            int price = Convert.ToInt16(q["Price"]);
                            Piece Rail = new Rail(type, length, price);
                            pieceList.Add(Rail);
                        }

                        if (reference == "Knob")
                        {
                            int diameter = Convert.ToInt16(q["Dimensions"]); //ATTENTION changer le diamètre dans la table par juste le chiffre
                            int price = Convert.ToInt16(q["Price"]);
                            Piece Knob = new Knob(diameter, price);
                            pieceList.Add(Knob);
                        }
                    }
                }

        }



                    fmd.CommandText = @"SELECT "
                }

                //met tous les ID_link dans une liste
                // Dans une boucle : checker quel type de piece c'est (cleat,...)
                //En fonction du type, ajouter un piece :
                //Piece piece = new Cleat(50, 20);
                //Ajouter le piece à la List<Piece>
            }
            return pieces;
        }































        public static List<Piece> PieceList
        {
            get
            {
                List<Piece> newList = new List<Piece>();

                foreach (Piece i in pieceList)
                {
                    newList.Add(i);
                }

                return newList;
            }
        }

        public static void AddPiece(Piece piece)
        {
            pieceList.Add(piece);
        }

        //UpdateFromDB

        public static Piece FindCleat(int height)
        {
            Cleat cleat;
            foreach (Piece piece in pieceList)
            {
                if (piece is Cleat)
                {
                    cleat = piece as Cleat;
                    if (cleat.Height == height)
                    {
                        return cleat;
                    }
                }
            }

            return null;
        }

        public static Piece FindAngleBar(int height, string color)
        {
            AngleBar angleBar, shortestAngleBar = null;

            foreach (Piece piece in pieceList)
            {
                if (piece is AngleBar)
                {
                    angleBar = piece as AngleBar;
                    if (angleBar.Height >= height && angleBar.Color == color)
                    {
                        if(shortestAngleBar.Height > angleBar.Height)
                        {
                            shortestAngleBar = angleBar;
                        }
                    }
                }
            }

            return shortestAngleBar;
        }

        public static Piece FindRail(string type, int length)
        {
            Rail rail;
            foreach (Piece piece in pieceList)
            {
                if (piece is Rail)
                {
                    rail = piece as Rail;
                    if (rail.Type == type && rail.Length == length)
                    {
                        return rail;
                    }
                }
            }

            return null;
        }

        public static Piece FindDoor(int length, int height, string color)
        {
            Door door;
            foreach (Piece piece in pieceList)
            {
                if (piece is Rail)
                {
                    door = piece as Door;
                    if (door.Length == length && door.Height == height && door.Color == color)
                    {
                        return door;
                    }
                }
            }

            return null;
        }

        public static Piece FindPanel(int length, int height, int depth, string color, string type)
        {
            Panel panel;
            foreach (Piece piece in pieceList)
            {
                if (piece is Rail)
                {
                    panel = piece as Panel;
                    if (panel.Type == type && panel.Length == length && panel.Height == height 
                        && panel.Depth == depth && panel.Color == color)
                    {
                        return panel;
                    }
                }
            }

            return null;
        }

        public static Piece FindKnob(int diameter)
        {
            Knob knob;
            foreach (Piece piece in pieceList)
            {
                if (piece is Knob)
                {
                    knob = piece as Knob;
                    if (knob.Diameter == diameter)
                    {
                        return knob;
                    }
                }
            }

            return null;
        }

    }
}
