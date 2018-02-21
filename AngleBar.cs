using System;

namespace KitBoxApp
{
    public class AngleBar : Piece
    {
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
        public AngleBar(int height, string color)
        {
            this.height = height;
            this.color = color;
        }

        public AngleBar Copy()
        {
            return new AngleBar(this.height, this.color);
        }
    }
}
