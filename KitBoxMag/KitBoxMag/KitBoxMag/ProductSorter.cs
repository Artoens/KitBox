using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitBoxMag
{
    //USE THIS CLASS TO SORT PRODUCT LISTS -> REMOVE DOUBLES -> EASY STOCK CHECK
    public static class ProductSorter
    {
        public static List<Product> RemoveDoubles(List<Product> productList)
        {
            List<Product> newList = new List<Product>();

            Piece currentPiece;
            int countPiece;

            foreach(Product currentProduct in productList)
            {
                currentPiece = currentProduct.Piece;
                countPiece = 0;

                foreach(Product product in productList)
                {
                    //PIECES ARE FOUND IN THE CATALOG
                    if(currentPiece.Equals(product.Piece))
                    {
                        countPiece += currentProduct.Quantity;
                        productList.Remove(currentProduct);
                    }
                }

                newList.Add(new Product(countPiece, currentPiece));
            }

            return newList;
        }
    }
}
