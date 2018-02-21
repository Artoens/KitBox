using System;

namespace KitBoxApp
{
    public class Cleat : Piece
    {
        private int height;
        public int Height
        {
            get { return height; }
        }

        public Cleat(int height, int price) : base(price)
        {
            this.height = height;
        }

        override public Piece Copy()
        {
            return new Cleat(this.height, this.price);
        }

        public override string ToString()
        {
            return "Cleat - height : " + this.height + " price : " + this.price;
        }
    }
}