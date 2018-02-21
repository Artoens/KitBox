using System;

namespace KitBoxApp
{
    public class Panel : Piece
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

        private int depth;
        public int Depth
        {
            get { return depth; }
        }

        private string color;
        public string Color
        {
            get { return color; }
        }

        private string type;
        public string Type
        {
            get { return type; }
        }

        public Panel(int length, int height,int depth, string color, string type)
        {
            this.length = length;
            this.height = height;
            this.depth = depth;
            this.color = color;
            this.type = type;
        }

        public Panel Copy()
        {
            return new Panel(this.length, this.height, this.depth, this.color, this.type);
        }
    }
}
