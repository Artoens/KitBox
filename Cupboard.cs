using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_kitbox
{
    class Cupboard : Item
    {
        private int length;
        private int depth;
        private List<Compartment> compartments;

        public Cupboard(int length, int depth)
        {
            this.length = length;
            this.depth = depth;
            this.compartments = new List<Compartment>();
        }

        public int Length
        {
            get { return length; }

            //Not checked yet
            set { this.length = value; }
        }

        public int Depth
        {
            get { return depth; }

            //Not checked yet
            set { this.depth = value; }
        }

        //If you want to target the 3rd element, that is the compartment n°2
        //then index = 2
        public Compartment GetCompartment(int index)
        {
            return new Compartment(
                compartments[index].Height,
                compartments[index].MainColor,
                compartments[index].DoorPresence,
                compartments[index].DoorColor);
        }

        public int NumberCompartments
        {
            get { return compartments.Count; }
        }

        public void AddCompartment(Compartment newCompartment)
        {
            if(compartments.Count < 7)
            {
                compartments.Add(newCompartment);
            } 
        }

        //If you want to target the 3rd element, that is the compartment n°2
        //then index = 2
        public void RemoveCompartment(int index)
        {
            if(index >= 0 && index <= compartments.Count)
            compartments.RemoveAt(index);
        }

        public List<Product> ItemToProduct()
        {
            List<Product> productList = new List<Product>();

            foreach(Compartment comp in compartments)
            {
                //To be completed according to the catalog and the DB
                //Exemple :
                
                /*Piece piece = null;

                piece = Catalog.FindCleat(comp.Height - 2);
                if(piece != null)
                {
                    productList.Add(new Product(4, piece));
                }*/
                
            }

            return productList;
        }
    }
}