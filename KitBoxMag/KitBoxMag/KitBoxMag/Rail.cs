using System;
namespace KitBoxMag
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

        public Rail(string type, int length, int price, string id) : base(price, id)
        {
            this.type = type;
            this.length = length;
        }

        override public Piece Copy()
        {
            return new Rail(this.type, this.length, this.price, this.id);
        }

        public override string ToString()
        {
            return "Rail";
        }
    }
}
