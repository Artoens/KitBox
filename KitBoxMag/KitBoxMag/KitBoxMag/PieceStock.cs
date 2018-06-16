using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitBoxMag
{
    public class PieceStock : Piece
    {
        public string Name { get; }
        public int Quantity { get; }

        public PieceStock(string name, int quantity, int price, string id) : base(price, id)
        {
            this.Name = name;
            this.Quantity = quantity;
        }

        override public Piece Copy()
        {
            return new PieceStock(this.Name, this.Quantity, this.price, this.id);
        }

        public override string ToString()
        {
            return Name + " " + id + " " + Quantity.ToString();
        }
    }
}
