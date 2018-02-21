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

        public Cleat(int height)
        {
            this.height = height;
        }

        public Cleat Copy()
        {
            return new Cleat(this.height);
        }
    }
}
