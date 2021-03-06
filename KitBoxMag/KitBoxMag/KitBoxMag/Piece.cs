using System;
using System.Data.SQLite;
using System.Collections.Generic;


namespace KitBoxMag
{
    //parent model of a piece
    public abstract class Piece
    {
        protected int price;
        protected string id;

        public Piece(int price, string id)
        {
            this.price = price;
            this.id = id;
        }
        public string Id
        {
            get { return id; }
        }


        //IMPLEMENTED WITH DATABASE
        //Je suppose que askedNumber est le Piece_ID

        public bool IsInStock(int askedNumber)
        {
            using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=C:\Users\15171\Desktop\Kitbox.db;Version=3;"))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT Amount FROM Stock where Piece_ID = askedNumber";
                    SQLiteDataReader q = fmd.ExecuteReader();
                    if (q.Read())
                    {
                        return true;
                    }
                    return false;
                }
            }
        }

        abstract public Piece Copy();
        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        //IMPLEMENTED WITH DATABASE
        /*public bool IsInStock(int askedNumber)
        {

        }*/

        /* public List<Supplier> GetSupplierList()
         {
                     List<Supplier> newList = new List<Supplier>();
                     return newList;
         }*/

        abstract override public string ToString();
    }
}