using System;

namespace Test_kitbox
{
    public class Cleat : Piece
    {
        private int height;
        public int Height
        {
            get { return height; }
        }

        public Cleat(int height, int price, string id) : base(price, id)
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
