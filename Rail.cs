using System;

namespace Test_kitbox
{
    public class Rail : Piece
    {
        private string type;

        public string Type
        {
            get{ return type; }
        }

        private int length;

        public int Length
        {
            get { return length; }
        }

        public Rail(string type, int length, int price) : base(price)
        {
            this.type = type;
            this.length = length;
        }

        override public Piece Copy()
        {
            return new Rail(this.type, this.length, this.price);
        }

        public override string ToString()
        {
            return "Rail";
        }
    }
}
