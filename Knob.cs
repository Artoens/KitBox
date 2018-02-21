using System;

namespace KitBoxApp
{
    public class Knob : Piece
    {
        private int diameter;
        public int Diameter
        {
            get { return diameter; }
        }

        public Knob(int diameter)
        {
            this.diameter = diameter;
        }
    }
}