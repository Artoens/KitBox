using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Test_kitbox
{
    public static class Catalog
    {
        private static List<Piece> pieceList = new List<Piece>();  //liste avec les piece pour chaque élément, chaque piece a un type 


        /// <summary>
        /// This method imports pieces from the DB to add them to the catalog
        /// All the pieces will be created according to their type (Cleat, AngleBar, ...)
        /// </summary>
        public static void GetPieces()
        {
            List<String> pieces = new List<String>();
            using (SQLiteConnection connect = new SQLiteConnection("Data Source=..\\..\\..\\..\\Kitbox.db"))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT * FROM Piece 
                                        INNER JOIN Reference 
                                        ON Piece.ID_Piece = Reference.ID_Piece
                                        LEFT OUTER JOIN Color 
                                        ON Piece.ID_Color = Color.PK_Color ";
                    SQLiteDataReader q = fmd.ExecuteReader();

                    while (q.Read())
                    {
                        string reference = Convert.ToString(q["Reference"]);
                        int price = Convert.ToInt32(q["Price_Client"]);
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
                            string type = "TB";//Top Bottom panel 
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

                        else if (reference == "LR_Rail")
                        {
                            string type = "LR";
                            int length = Convert.ToInt16(q["Depth"]);
                            Piece Rail = new Rail(type, length, price, id);
                            pieceList.Add(Rail);
                        }

                        else if (reference == "Knob")
                        {
                            int diameter = Convert.ToInt16(q["Dimensions"]); //ATTENTION changer le diamètre dans la table par juste le chiffre
                            Piece Knob = new Knob(diameter, price, id);
                            pieceList.Add(Knob);
                        }
                    }
                }

            }

        }

        //makes a list of all the pieces
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

        //All the find function are meant to find a spécific type of item in our list of pieces

        /// <summary>
        /// Find an existing Cleat based on its inner caracteristics
        /// </summary>
        /// <param name="height"></param>
        /// <returns>The existing Cleat if existing, or null</returns>
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

        /// <summary>
        /// Find an existing AngleBar based on its inner caracteristics
        /// </summary>
        /// <param name="height"></param>
        /// <param name="color"></param>
        /// <returns>The existing AngleBar if existing, or null</returns>
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
                        // As the angle bars can be cut, we try to find the shortest angle bar that fits with the required height
                        if (shortestAngleBar == null || shortestAngleBar.Height > angleBar.Height)
                        {
                            // If a shorther angle bar matching the caracteristics exists, it replaces the longer one
                            shortestAngleBar = angleBar;
                        }
                    }
                }
            }

            return shortestAngleBar;
        }

        /// <summary>
        /// Find an existing Rail based on its inner caracteristics
        /// </summary>
        /// <param name="type"></param>
        /// <param name="length"></param>
        /// <returns>The existing Rail if existing, or null</returns>
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

        /// <summary>
        /// Find an existing Door based on its inner caracteristics
        /// </summary>
        /// <param name="length"></param>
        /// <param name="height"></param>
        /// <param name="color"></param>
        /// <returns>The existing Door if existing, or null</returns>
        public static Piece FindDoor(int length, int height, string color)
        {
            Door door;
            foreach (Piece piece in pieceList)
            {
                if (piece is Door)
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

        /// <summary>
        /// Find an existing Panel based on its inner caracteristics
        /// </summary>
        /// <param name="length"></param>
        /// <param name="height"></param>
        /// <param name="depth"></param>
        /// <param name="color"></param>
        /// <param name="type"></param>
        /// <returns>The existing Panel if existing, or null</returns>
        public static Piece FindPanel(int length, int height, int depth, string color, string type)
        {
            Panel panel;
            foreach (Piece piece in pieceList)
            {
                if (piece is Panel)
                {
                    panel = piece as Panel;

                    // There can be 3 different types of panels
                    // Each one has different caracteristics (Length, Depth, Height)
                    if(type == "TB")
                    {
                        if (panel.Type == type && panel.Length == length
                        && panel.Depth == depth && panel.Color == color)
                        {
                            return panel;
                        }
                    }
                    else if(type == "LR")
                    {
                        if (panel.Type == type && panel.Height == height
                        && panel.Depth == depth && panel.Color == color)
                        {
                            return panel;
                        }
                    }
                    else if(type == "B")
                    {
                        if (panel.Type == type && panel.Length == length && panel.Height == height
                        && panel.Color == color)
                        {
                            return panel;
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Find an existing Knob based on its inner caracteristics
        /// </summary>
        /// <param name="diameter"></param>
        /// <returns>The existing Knob if existing, or null</returns>
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
