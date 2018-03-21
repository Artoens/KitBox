using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_kitbox
{ 
    public class Product
    {
        private int quantity;
        private Piece piece;

        public Product(int quantity, Piece piece)
        {
            this.quantity = quantity;
            this.piece = piece;
        }

        public int Quantity
        {
            get { return quantity; }
        }

        public int Price
        {
            get { return quantity * piece.Price; }
        }

        public Piece Piece
        {
            //Should return a copy
            get { return piece.Copy(); }
        }

        //Not done yet
        override public string ToString()
        {
            return quantity.ToString() + " x " + piece.ToString();
        }
    }
}