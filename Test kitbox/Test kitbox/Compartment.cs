using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_kitbox
{
    public class Compartment : Item
    {
        private int height;
        private string mainColor;
        private bool door;
        private string doorColor;
        private Cupboard cupboard;

        public Compartment(int height, string mainColor, bool door, string doorColor, Cupboard cupboard)
        {
            this.height = height;
            this.mainColor = mainColor;
            this.door = door;
            this.doorColor = doorColor;
            this.cupboard = cupboard;
        }

        public int Height 
        {
            get { return height; }
            set { this.height = value; }
        }

        public string MainColor
        {
            get { return mainColor; }
            set { this.mainColor = value; }
        }
        
        public bool DoorPresence
        {
            get { return door; }
            set { this.door = value; }
        }

        public string DoorColor
        {
            get { return doorColor; }
            set { this.doorColor = value; }
        }

        public override string ToString()
        {
            string result = mainColor + " Compartment " + height.ToString();
            if (door)
            {
                result += " " + doorColor + " D";
            }
            return result;
        }

        /// <summary>
        /// This list converts the item into a list of all the products needed to put it together
        /// These products are existing pieces from the database associated with a quantity
        /// </summary>
        /// <returns>Returns a list of all the products the item is made up of</returns>
        public List<Product> ItemToProduct()
        {
            // INIT WITH AN EMPTY LIST
            List<Product> productList = new List<Product>();
            Piece piece;
            Product product;

            //CLEAT
            piece = Catalog.FindCleat(this.Height);
            product = new Product(4, piece); 

            productList.Add(product);

            //RAIL FRONT
            piece = Catalog.FindRail("F", this.cupboard.Length);
            product = new Product(2, piece);
            productList.Add(product);

            //RAIL BACK
            piece = Catalog.FindRail("B", this.cupboard.Length);
            product = new Product(2, piece);
            productList.Add(product);

            //RAIL LEFT:RIGHT
            piece = Catalog.FindRail("LR", this.cupboard.Depth);
            product = new Product(4, piece);
            productList.Add(product);

            //PANEL TOP:BOTTOM
            piece = Catalog.FindPanel(this.cupboard.Length, this.Height, this.cupboard.Depth, this.MainColor, "TB");
            product = new Product(2, piece);
            productList.Add(product);

            //PANEL LEFT:RIGHT
            piece = Catalog.FindPanel(this.cupboard.Length, this.Height, this.cupboard.Depth, this.MainColor, "LR");
            product = new Product(2, piece);
            productList.Add(product);

            //PANEL BACK
            piece = Catalog.FindPanel(this.cupboard.Length, this.Height, this.cupboard.Depth, this.MainColor, "B");
            product = new Product(1, piece);
            productList.Add(product);

            //IF THERE ARE DOORS
            if(this.DoorPresence)
            {
                //DOOR
                piece = Catalog.FindDoor(this.cupboard.Length, this.Height, this.doorColor);
                product = new Product(2, piece);
                productList.Add(product);

                //IF THE DOORS ARE NOT IN GLASS
                if(this.DoorColor != "Verre")
                {
                    //KNOB
                    piece = Catalog.FindKnob(6);
                    product = new Product(4, piece);
                    productList.Add(product);
                }
                
            }
            return productList;
        }
    }
}
