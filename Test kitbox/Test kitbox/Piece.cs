using System;
using System.Collections.Generic;

namespace Test_kitbox
{
    public abstract class Piece
    {
        protected int price;

        public Piece(int price)
        {
            this.price = price;
        }

        public int Price
        {
            get { return price; }
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

        abstract public Piece Copy();

        abstract override public string ToString();
    }
}