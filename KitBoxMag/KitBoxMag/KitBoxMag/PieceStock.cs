using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitBoxMag
{
    public class PieceStock : Piece
    {
        public string Supplier { get; set; }
        public int ShippingDelay { get; set; }
        public string Name { get; }
        public int Quantity { get; }


        public PieceStock(string name, int quantity, int price, string id, int shippingdelay = Int32.MaxValue, string supplier = "") : base(price, id)
        {
            Supplier = supplier;
            this.ShippingDelay = shippingdelay;
            this.Name = name;
            this.Quantity = quantity;
        }

        override public Piece Copy()
        {
            return new PieceStock(this.Name, this.Quantity, this.price, this.id, ShippingDelay, Supplier);
        }

        public override string ToString()
        {
            return Name + " " + id + " " + Quantity.ToString();
        }
    }
}
