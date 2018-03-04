using System;

namespace Test_kitbox
{
    public class Knob : Piece
    {
        private int diameter;
        public int Diameter
        {
            get { return diameter; }
        }

        public Knob(int diameter, int price) : base (price)
        {
            this.diameter = diameter;
        }

        override public Piece Copy()
        {
            return new Knob(this.diameter, this.price);
        }

        public override string ToString()
        {
            return "Knob";
        }
    }
}