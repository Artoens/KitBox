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
                foreach(Product p in this.ItemToProduct(i))
                {
                    newList.Add(p);
                }
            }

            return newList;
        }

        //IMPLEMENTED WITH DATABASE
        public bool CheckStock(Product product)
        {
            int quantity = product.Quantity;
            Piece piece = product.Piece;


            using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=C:\Users\15171\Desktop\Kitbox.db;Version=3;"))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    if(piece is AngleBar)
                    {
                        fmd.CommandText = @"SELECT *
                                            FROM Stock s
                                            INNER JOIN Object o
                                                ON o.Piece_Code = s.Piece_Code 
                                                WHERE o.Height = piece[0] AND o.Price = piece[2]
                                            INNER JOIN Color c
                                                ON c.ID_Color = o.ID_Color
                                            WHERE c.Color = piece[1]";
                        SQLiteDataReader q = fmd.ExecuteReader();
                        int dbQuantity = 0;
                            
                        while (q.Read())
                        {
                            dbQuantity ++;
                        }
                        if (dbQuantity == quantity)
                        {
                            return true;
                        }
                    }








                    }

                    //IMPLEMENTED WITH DATABASE
                    public bool UpdateDatabase()
                    {

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
