﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_kitbox
{
    public class Output
    {
        private static DateTime now = DateTime.Now;

        public string id = now.ToString("yyyyMMddHHmmss");
        public string InterfaceOuput(Order order)
        {
            string linesString = "";
            foreach (string line in MakeBill(order))
            {
                linesString += line + '\n';
            }
            return linesString;
        }

        //calculates the total price of the cupboard
        public int TotalPrice(Order order)
        {
            int totalPrice = 0;
            foreach (Product product in order.GenerateOrder())
            {
                totalPrice += product.Price;
            }
            return totalPrice;
        }

        //makes the files to print the clients bill
        public void MakeFiles(Order order)
        {
            List<string> lines = MakeBill(order);
            lines.ToArray();
            string path = (@"../../../Bill of" + id + ".txt");
            MakeBill(order).ToArray();
            System.IO.File.WriteAllLines(path, lines);
        }

        //makes a bill for the client 
        public List<string> MakeBill(Order order)
        {
            string line = null;
            int totalPrice = 0;
            int compartmentPrices = 0;
            Cupboard cupboard;
            foreach (Product product in order.GenerateOrder())
            {
                totalPrice += product.Price;
            }
            foreach (Item item in order.ItemList)
            {
                if (item is Cupboard)
                {
                    cupboard = item as Cupboard;
                    foreach (Compartment compartment in cupboard.GetAllCompartments())
                    {
                        foreach (Product product in compartment.ItemToProduct())
                        {
                            compartmentPrices += product.Price;
                        }
                    }
                }
            }

            List<string> lines = new List<string>
                {
                    "Bill made on the " + now + " for the client",
                    id,
                    "Item bought/price/availability",
                    "cupboard/" + ((totalPrice-compartmentPrices)/10000.0).ToString() + ""//pour ici
                };

            int i = 1;
            
            foreach (Item item in order.ItemList)
             {
                if(item is Cupboard)
                {
                    cupboard = item as Cupboard;

                    foreach (Compartment compartment in cupboard.GetAllCompartments())
                    {
                        //SET compartment AS available
                        string availability = "Available";

                        int price = 0;

                        foreach (Product product in compartment.ItemToProduct())
                        {
                            price += product.Price;

                            //To be deleted
                            lines.Add(product.ToString() + " Available : " + order.CheckStock(product).ToString());

                            //IF one piece is missing => SET AS not in stock
                            if (!order.CheckStock(product))
                            {
                                availability = "Not in stock";
                                
                            }
                        }
                        line = "compartment n°" + i.ToString() + "/" + (price/10000.0).ToString() + "/" + availability;
                        i += 1;
                        lines.Add(line);
                    }
                }
            }
            string totalPriceString = "Total price: " + (totalPrice/10000.0).ToString();
            lines.Add(totalPriceString);
            double vat = totalPrice * 1.21;
            string vatPrice = "Total price with VAT: " + (vat/10000.0).ToString();
            lines.Add(vatPrice);
            return lines;
        }

        //makes list of items to prepare for the vendor
        public void MakeList(Order order)
        {
            string line = null;
            string path = (@"../../../List of" + now + ".txt");
            List<string> lines = new List<string>
                {
                    "List of the" + now + "for" + "client",
                    " ",
                    "n° / item / availibility"
                };


            foreach (Product item in ProductSorter.RemoveDoubles(order.GenerateOrder()))
            {
                int n = 1;
                line = n.ToString() + "/" + item.ToString() + "/";
                if (order.CheckStock(item))
                {
                    line += "Available";
                }
                else
                {
                    line += "Not in Stock";
                }

                lines.Add(line);
                n += 1;
            }
            
            lines.ToArray();
            System.IO.File.WriteAllLines(path, lines);
        }
    }
}
