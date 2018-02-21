using System;
namespace KitBoxApp
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

        public Rail(string type, int length)
        {
            this.type = type;
            this.length = length;
        }

        public Rail Copy()
        {
            return new Rail(this.type, this.length);
        }
    }
}
