using System;

namespace Test_kitbox
{
    public class Door : Piece
    {
        private int length;

        public int Length
        {
            get { return length; }
        }

        private int height;
        public int Height
        {
            get { return height; }
        }

        private string color; 
        public string Color
        {
            get { return color; }
        }

        public Door(int length, int height, string color, int price) : base (price)
        {
            this.length = length;
            this.height = height;
            this.color = color;
        }

        override public Piece Copy()
        {
            return new Door(this.length, this.height, this.color, this.price);
        }

        public override string ToString()
        {
            return "Door";
        }
    }
}
