using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_kitbox
{
    public class Cupboard : Item
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
                compartments[index].DoorColor,
                this);
        }

        public int NumberCompartments   
        {
            get { return compartments.Count; }
        }

        public List<Compartment> GetAllCompartments()
        {
            List<Compartment> list =  new List<Compartment>();
            for (int i = 0; i < compartments.Count; i++)
            {
                list.Add(GetCompartment(i));
            }
            return list;
        }

        public List<Compartment> Compartments
        {
            get { return compartments; }
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

        public void RemoveLastCompartment()
        {
                compartments.RemoveAt(compartments.Count - 1);
        }

        public List<Product> ItemToProduct()
        {
            List<Product> productList = new List<Product>();

            //CUPBOARD HEIGHT -> TO FIND ANGLEBARS
            int height = 0;

            //ADD PRODUCTS FOR EACH COMPARTMENT
            foreach (Compartment comp in compartments)
            {
                height += comp.Height;

                foreach(Product product in comp.ItemToProduct())
                {
                    productList.Add(product);
                }
                
            }

            //ADD PRODUCTS RELATIVE TO THE CUPBOARD
            Piece piece = Catalog.FindAngleBar(height, "white");
            Product prod = new Product(4, piece);
            productList.Add(prod);

            return productList;
        }

        public override string ToString()
        {
            return "Cupboard " + length.ToString() + "x" +depth.ToString();
        }
    }
}