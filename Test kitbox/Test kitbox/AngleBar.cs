using System;

namespace Test_kitbox
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

        public AngleBar(int height, string color, int price, string id) : base (price, id)
        {
            this.height = height;
            this.color = color;
        }

       // AngleBar(int height, string color, int price, string id

        override public Piece Copy()
        {
            return new AngleBar(this.height, this.color, this.price, this.id); 
        }

        public override string ToString()
        {
            return "AngelBar";
        }
    }
}
