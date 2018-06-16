using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_kitbox
{
    public class Output
    {
        DateTime now = DateTime.Now;
        public string InterfaceOuput(Order order)
        {
            string linesString = "";
            foreach (string line in MakeBill(order))
            {
                linesString += line + '\n';
            }
            return linesString;
        }

        public void MakeFiles(Order order)
        {
            List<string> lines = MakeBill(order);
            lines.ToArray();
            string path = (@"../../../Bill of" + now + ".txt");
            MakeBill(order).ToArray();
            System.IO.File.WriteAllLines(path, lines);
        }
         
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
                    "Bill made on the" + now + "for the client",
                    " ",
                    "Item bought/price/availability",
                    "cupboard/" + ((totalPrice-compartmentPrices)/1000.0).ToString() + ""//pour ici
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
                        line = "compartment n°" + i.ToString() + "/" + (price/1000.0).ToString() + "/" + availability;
                        i += 1;
                        lines.Add(line);
                    }
                }
            }
            string totalPriceString = "Total price: " + (totalPrice/1000.0).ToString();
            lines.Add(totalPriceString);
            double vat = totalPrice * 1.21;
            string vatPrice = "Total price with VAT: " + (vat/1000.0).ToString();
            lines.Add(vatPrice);
            return lines;
        }


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
