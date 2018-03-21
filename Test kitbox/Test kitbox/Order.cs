using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Test_kitbox
{
    class Order
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

            foreach (Item i in itemList)
            {
                foreach (Product p in this.ItemToProduct(i))
                {
                    newList.Add(p);
                }
            }

            return newList;
        }

        //IMPLEMENTED WITH DATABASE

        public int InStock(Product product)
        {
            int quantity = product.Quantity;
            Piece piece = product.Piece;

            using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=C:\Users\15171\Desktop\Kitbox.db;Version=3;"))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    if (piece is AngleBar)
                    {
                        fmd.CommandText = @"SELECT *
                                            FROM Stock s
                                            INNER JOIN Object o
                                                ON o.Piece_Code = s.Piece_Code 
                                            INNER JOIN Color c
                                                ON c.ID_Color = o.ID_Color
                                            WHERE c.Color = piece[1] AND o.Height = piece[0] AND o.Price = piece[2]";
                        SQLiteDataReader q = fmd.ExecuteReader();
                        int dbQuantity = 0;

                        while (q.Read())
                        {
                            dbQuantity++;
                        }
                        if (dbQuantity == quantity)
                        {
                            return quantity;
                        }
                        return 0;
                    }

                    else if (piece is Panel)
                    {
                        fmd.CommandText = @"SELECT *
                                            FROM Stock s
                                            INNER JOIN Piece p
                                                ON p.Piece_Code = s.Piece_Code 
                                            INNER JOIN Color c
                                                ON c.ID_Color = p.ID_Color
                                            WHERE p.Length = piece[0] AND p.Height = piece[1] AND p.Depth = piece[2] AND c.Color = piece[3] AND p.Price_Client = piece[5]"; //manque le type

                        SQLiteDataReader q = fmd.ExecuteReader();
                        int dbQuantity = 0;

                        while (q.Read())
                        {
                            dbQuantity++;
                        }

                        if (dbQuantity == quantity)
                        {
                            return quantity;
                        }
                        return 0;
                    }

                    else if (piece is Door)
                    {
                        fmd.CommandText = @"SELECT *
                                            FROM Stock s
                                            INNER JOIN Piece p
                                                ON p.Piece_Code = s.Piece_Code 
                                            INNER JOIN Color c
                                                ON c.ID_Color = p.ID_Color
                                            WHERE p.Length = piece[0] AND p.Height = piece[1] AND c.Color = piece[2] AND p.Price_Client = piece[3]";

                        SQLiteDataReader q = fmd.ExecuteReader();
                        int dbQuantity = 0;

                        while (q.Read())
                        {
                            dbQuantity++;
                        }

                        if (dbQuantity == quantity)
                        {
                            return quantity;
                        }
                        return 0;
                    }

                    else if (piece is Cleat)
                    {
                        fmd.CommandText = @"SELECT *
                                            FROM Stock s
                                            INNER JOIN Piece p
                                                ON p.Piece_Code = s.Piece_Code 
                                            WHERE p.Height = piece[0] AND p.Price_Client = piece[1]";

                        SQLiteDataReader q = fmd.ExecuteReader();
                        int dbQuantity = 0;

                        while (q.Read())
                        {
                            dbQuantity++;
                        }
                        if (dbQuantity == quantity)
                        {
                            return quantity;
                        }
                        return 0;
                    }

                    else if (piece is Rail)
                    {
                        fmd.CommandText = @"SELECT *
                                            FROM Stock s
                                            INNER JOIN Piece p
                                                ON p.Piece_Code = s.Piece_Code
                                            WHERE p.Length = piece[1] AND p.Price_Client = piece[2]"; //Manque type en premier

                        SQLiteDataReader q = fmd.ExecuteReader();
                        int dbQuantity = 0;

                        while (q.Read())
                        {
                            dbQuantity++;
                        }
                        if (dbQuantity == quantity)
                        {
                            return quantity;
                        }
                        return 0;
                    }

                    else if (piece is Knob)
                    {
                        fmd.CommandText = @"SELECT *
                                            FROM Stock s
                                            INNER JOIN Piece p
                                                ON p.Piece_Code = s.Piece_Code 
                                            WHERE p.Dimensions = piece[0] AND p.Price_Client = piece[1]";

                        SQLiteDataReader q = fmd.ExecuteReader();
                        int dbQuantity = 0;

                        while (q.Read())
                        {
                            dbQuantity++;
                        }
                        if (dbQuantity == quantity)
                        {
                            return quantity;
                        }

                    }
                }
            }
            return 0;
        }

        public bool CheckStock(Product product)
        {
            if (product.Quantity == InStock(product))
            {
                return true;
            }
            return false;
        }

        // Si on a déjà commandé : il se passe rien
        public void UpdateDatabase(Product product)
        {
            Piece piece = product.Piece;
            string id = piece.Id;
            int quantity = product.Quantity;
            int stockQuantity = InStock(product);
            int wantedQuantity = stockQuantity - quantity;
            int orderedExtra = 0;
            int toOrder = 0;

            //If everything is in stock : decrease stock of the quatity
            if (CheckStock(product))
            {
                using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=C:\Users\15171\Desktop\Kitbox.db;Version=3;"))
                {
                    connect.Open();
                    using (SQLiteCommand fmd = connect.CreateCommand())
                    {
                        fmd.CommandText = @"UPDATE Stock s
                                               SET s.Quantity = wantedQuantity
                                               WHERE s.Piece_ID = id";
                    }
                }
            }

            //Si pas tout en stock
            else
            {
                //Si partie en stock
                int notStock = wantedQuantity - stockQuantity; //Doffice positif

                //Update quantity à 0
                using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=C:\Users\15171\Desktop\Kitbox.db;Version=3;"))
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
                    //Update OrderedExtra to (OrderedExtra - notStock
                    using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=C:\Users\15171\Desktop\Kitbox.db;Version=3;"))
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
                    using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=C:\Users\15171\Desktop\Kitbox.db;Version=3;"))
                    {
                        connect.Open();
                        using (SQLiteCommand fmd = connect.CreateCommand())
                        {
                            fmd.CommandText = @"UPDATE Stock s
                                                SET s.OrderedExtra = 0 AND s.ToOrder = rest
                                                WHERE s.Piece_ID = id";
                        }
                    }
                }
            }

            public List<Product> ItemToProduct(Item item)
            {
                List<Product> productList = new List<Product>();

                //Generate products
                Piece piece = new Cleat(14, 400);
                Product product = new Product(8, piece);
                productList.Add(product);

                return productList;
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
        }
    }
}