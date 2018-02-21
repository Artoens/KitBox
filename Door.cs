using System;

namespace KitBoxApp
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

        public Door(int length, int height, string color)
        {
            this.length = length;
            this.height = height;
            this.color = color;
        }

        public Door Copy()
        {
            return new Door(this.length, this.height, this.color);
        }
    }
}
