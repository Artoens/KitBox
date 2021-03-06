﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_kitbox
{
    public class Cupboard : Item
    {
        private int height;
        private int length;
        private int depth;
        private string angleBarColor;
        private List<Compartment> compartments;

        public Cupboard(int length, int depth)
        {
            height = 0;
            this.length = length;
            this.depth = depth;
            this.angleBarColor = "White";
            this.compartments = new List<Compartment>();
        }

        public int Length
        {
            get { return length; }
            set { this.length = value; }
        }

        public int Height
        {
            get { return height; }
            set { this.height = value; }
        }

        public int Depth
        {
            get { return depth; }
            set { this.depth = value; }
        }

        public string AngleBarColor
        {
            get { return angleBarColor; }
            set { this.angleBarColor = value; }
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
                height += newCompartment.Height + 4;
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

        /// <summary>
        /// This list converts the item into a list of all the products needed to put it together
        /// These products are existing pieces from the database associated with a quantity
        /// </summary>
        /// <returns>Returns a list of all the products the item is made up of</returns>
        public List<Product> ItemToProduct()
        {
            List<Product> productList = new List<Product>();
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
            Piece piece = Catalog.FindAngleBar(height, AngleBarColor);
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