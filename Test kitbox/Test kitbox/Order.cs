﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Test_kitbox
{
    public class Order
    {
        private List<Item> itemList;
        private List<Product> productList;

        public Order()
        {
            this.itemList = new List<Item>();
            this.productList = new List<Product>();
        }

        public List<Product> GenerateOrder()
        {
            //Should check this line => aims at copying the list into a new one
            List<Product> newList = new List<Product>();

            foreach (Item item in itemList)
            {
                foreach (Product p in item.ItemToProduct())
                {
                    newList.Add(p);
                }
            }

            return newList;
        }

        //IMPLEMENTED WITH DATABASE

        public int InStock(Product product)
        {
            Piece piece = product.Piece;
            int dbQuantity = 0;

            if (piece != null)
            {
                using (SQLiteConnection connect = new SQLiteConnection("Data Source=..\\..\\..\\..\\Kitbox.db;Version=3;"))
                {
                    connect.Open();
                    using (SQLiteCommand fmd = connect.CreateCommand())
                    {
                        // CREATE SQL READER
                        SQLiteDataReader q;

                        fmd.CommandText = @"SELECT *
                                            FROM Stock s
                                            INNER JOIN Piece p
                                                ON p.Piece_Code = s.Piece_Code 
                                            WHERE p.Piece_Code = '" + piece.Id + "'";

                        // EXECUTE THE SQL REQUEST
                        q = fmd.ExecuteReader();

                        while (q.Read())
                        {
                            dbQuantity = Convert.ToInt32(q["Quantity"]);
                        }
                    }
                }
            }

            return dbQuantity;
        }

        public void RemoveFromStock(Product product)
        {
            Piece piece = product.Piece;

            if(piece != null)
            {
                using (SQLiteConnection connect = new SQLiteConnection("Data Source=..\\..\\..\\..\\Kitbox.db;Version=3;"))
                {
                    connect.Open();
                    using (SQLiteCommand fmd = connect.CreateCommand())
                    {
                        // CREATE SQL READER
                        SQLiteDataReader q;
                                        fmd.CommandText = @"UPDATE Stock
                                        SET Quantity = Quantity - " + product.Quantity +
                                        " WHERE PIECE_Code = '" + piece.Id + "'";

                        // EXECUTE THE SQL REQUEST
                        q = fmd.ExecuteReader();
                        q.Read();
                    }
                }
            }
        }



        public bool CheckStock(Product product)
        {
            if (product.Quantity <= InStock(product))
            {
                return true;
            }
            return false;
        }

        // if it's already ordered nothing will happen
        public void UpdateDatabase(Product product)
        {
            Piece piece = product.Piece;
            string id = piece.Id;
            int quantity = product.Quantity;
            int stockQuantity = InStock(product);
            int wantedQuantity = stockQuantity - quantity;
            int orderedExtra = 0;
            int toOrder = 0;
            //If everything is in stock : decrease stock of the quantity
            if (CheckStock(product))
            {
                RemoveFromStock(product);
            }
            //IF everything isn't in stock
            else
            {
                int notStock = wantedQuantity - stockQuantity; 

                //Update quantity à 0
                using (SQLiteConnection connect = new SQLiteConnection("Data Source=..\\..\\..\\..\\Kitbox.db;Version=3;"))
                {

                    connect.Open();
                    using (SQLiteCommand fmd = connect.CreateCommand())
                    {
                        fmd.CommandText = @"UPDATE Stock s
                                        SET s.Quantity = 0
                                        WHERE s.Piece_ID = id";
                    }

                    using (SQLiteCommand fmd = connect.CreateCommand())
                    {
                        fmd.CommandText = @"SELECT ToOrder, OrderedExtra
                                    FROM Stock
                                    WHERE s.Piece_ID = id";

                        SQLiteDataReader q = fmd.ExecuteReader();

                        while (q.Read())
                        {
                            orderedExtra = Convert.ToInt16(q["OrderedExtra"]);
                            toOrder = Convert.ToInt16(q["ToOrder"]);
                        }
                    }
                }

                //If everything in OrderedExtra
                if (orderedExtra >= notStock)
                {
                    using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=..\\..\\..\\..\\Kitbox.db;Version=3;"))
                    {
                        connect.Open();
                        using (SQLiteCommand fmd = connect.CreateCommand())
                        {
                            fmd.CommandText = @"UPDATE Stock s
                                            SET s.Quantity = 0
                                            WHERE s.Piece_ID = id";
                        }
                    }
                }

                else
                {
                    int rest = notStock - orderedExtra;
                    using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=..\\..\\..\\..\\Kitbox.db;Version=3;"))
                    {
                        connect.Open();
                        using (SQLiteCommand fmd = connect.CreateCommand())
                        {
                            fmd.CommandText = @"UPDATE Stock s
                                                SET s.OrderedExtra = 0 AND s.ToOrder = " + rest +
                                                "WHERE s.Piece_ID = id";
                        }
                    }
                }
            }
        }


        public void AddItem(Item newItem)
        {
            itemList.Add(newItem);
        }

        //If you want to target the 3rd element, that is the item n°2
        //then index = 2
        public void RemoveItem(int index)
        {
            if (index >= 0 && index <= itemList.Count)
                itemList.RemoveAt(index);
        }

        public List<Item> ItemList
        {
            get { return itemList; }
        }
    }
}