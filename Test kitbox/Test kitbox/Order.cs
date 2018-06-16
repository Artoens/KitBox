using System;
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
            int quantity = product.Quantity;
            Piece piece = product.Piece;

            using (SQLiteConnection connect = new SQLiteConnection("Data Source=..\\..\\..\\..\\Kitbox.db"))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    // CREATE SQL READER
                    SQLiteDataReader q;

                    if (piece is AngleBar)
                    {
                        AngleBar angleBar = piece as AngleBar;

                        fmd.CommandText = @"SELECT *
                                            FROM Stock s
                                            INNER JOIN Object o
                                                ON o.Piece_Code = s.Piece_Code 
                                            INNER JOIN Color c
                                                ON c.ID_Color = o.ID_Color
                                            WHERE c.Color = '" + angleBar.Color + "' AND o.Height = " + angleBar.Height + " AND o.Price = " + angleBar.Price;
                    }

                    else if (piece is Panel)
                    {
                        Panel panel = piece as Panel;
                        fmd.CommandText = @"SELECT *
                                            FROM Stock s
                                            INNER JOIN Piece p
                                                ON p.Piece_Code = s.Piece_Code 
                                            INNER JOIN Color c
                                                ON c.PK_Color = p.ID_Color
                                            WHERE p.Length = " + panel.Length + " AND p.Height = " + panel.Height + " AND p.Depth = " + panel.Depth + " AND c.Color = '" + panel.Color + "' AND p.Price_Client = " + panel.Price; //manque le type
                    }

                    else if (piece is Door)
                    {
                        Door door = piece as Door;
                        fmd.CommandText = @"SELECT *
                                            FROM Stock s
                                            INNER JOIN Piece p
                                                ON p.Piece_Code = s.Piece_Code 
                                            INNER JOIN Color c
                                                ON c.PK_Color = p.ID_Color
                                            WHERE p.Length = " + door.Length + " AND p.Height = " + door.Height + " AND c.Color = '" + door.Color + "' AND p.Price_Client = " + door.Price;
                    }

                    else if (piece is Cleat)
                    {
                        Cleat cleat = piece as Cleat;

                        fmd.CommandText = @"SELECT *
                                            FROM Stock s
                                            INNER JOIN Piece p
                                            ON p.Piece_Code = s.Piece_Code 
                                            WHERE p.Height = " + cleat.Height + " AND p.Price_Client = " + cleat.Price;
                    }

        


                    else if (piece is Rail)
                    {
                        Rail rail = piece as Rail;

                        if(rail.Type == "B_Rail" || rail.Type == "F_Rail")
                        {
                            fmd.CommandText = @"SELECT *
                                                FROM Stock s
                                                INNER JOIN Piece p
                                                    ON p.Piece_Code = s.Piece_Code
                                                WHERE p.Length = " + rail.Length + " AND p.Price_Client = " + rail.Price; //Manque type en premier
                        }
                        else
                        {
                            fmd.CommandText = @"SELECT *
                                                FROM Stock s
                                                INNER JOIN Piece p
                                                    ON p.Piece_Code = s.Piece_Code
                                                WHERE p.Depth = " + rail.Length + " AND p.Price_Client = " + rail.Price;
                        }

                    }

                    else if (piece is Knob)
                    {
                        Knob knob = piece as Knob;

                        fmd.CommandText = @"SELECT *
                                            FROM Stock s
                                            INNER JOIN Piece p
                                                ON p.Piece_Code = s.Piece_Code
                                            WHERE p.Dimensions = " + knob.Diameter + " AND p.Price_Client = " + knob.Price;

                    }

                    // EXECUTE THE SQL REQUEST
                    q = fmd.ExecuteReader();

                    while(q.Read())
                    {
                        int dbQuantity = Convert.ToInt32(q["Quantity"]);
                        return dbQuantity;
                    }

                    return 0;
                    
                }
            }
        }
        ///END OF MODIFICATION

        public bool CheckStock(Product product)
        {
            if (product.Quantity <= InStock(product))
            {
                return true;
            }
            return false;
        }

        // Si on a déjà commandé : il ne se passe rien
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
                using (SQLiteConnection connect = new SQLiteConnection("Data Source=..\\..\\..\\..\\Kitbox.db"))
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
                using (SQLiteConnection connect = new SQLiteConnection("Data Source=..\\..\\..\\..\\Kitbox.db"))
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
                    using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=C:\\Users\\sambe\\Desktop\\ECAM\\projet info\\KitBox\\Kitbox.db;Version=3;"))
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
                    using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=C:\\Users\\sambe\\Desktop\\ECAM\\projet info\\KitBox\\Kitbox.db;Version=3;"))
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
        }

            /*
            public List<Product> ItemToProduct(Item item)
            {
                List<Product> productList = new List<Product>();

                //Generate products
                Piece piece = new Cleat(14, 400);
                Product product = new Product(8, piece);
                productList.Add(product);

                return productList;
            }
            */

           /* public List<Product> ItemToProduct()
            {
                List<Product> productList = new List<Product>();

                //Generate products
                Piece piece = new Cleat(14, 400);
                Product product = new Product(8, piece);
                productList.Add(product);

                return productList;
            }
            */

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