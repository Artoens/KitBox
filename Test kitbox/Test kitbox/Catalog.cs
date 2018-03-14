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

        public static List<String> GetPieces()
        {
            List<String> pieces = new List<String>();
            using(SQLiteConnection connect = new SQLiteConnection(@"Data Source=/Users/eliseraxhon/Desktop/3BAC/kitbox/BD/Final/Kitbox.db;Version=3;"))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    //Piece piece;
                    fmd.CommandText = @"SELECT DISTINCT ID_Piece FROM Link_Piece_Sup";
                    SQLiteDataReader r = fmd.ExecuteReader();
                    while (r.Read())
                    {
                        pieces.Add(Convert.ToString(r["ID_Piece"]));
                    }
                }
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
