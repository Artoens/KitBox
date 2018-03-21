using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_kitbox
{
    public class Output
    {
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
            DateTime now = DateTime.Now;
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
                    "cupboard/" + ((totalPrice-compartmentPrices)/100).ToString() + ""//pour ici
                };

            int i = 1;
            string availability = "Available";
            foreach (Item item in order.ItemList)
             {
                if(item is Cupboard)
                {
                    cupboard = item as Cupboard;
                    foreach (Compartment compartment in cupboard.GetAllCompartments())
                    {
                        int price = 0;
                        foreach (Product product in compartment.ItemToProduct())
                        {
                            price += product.Price;

                            if (!order.CheckStock(product))
                            {
                                availability = "Not in stock";
                            }
                        }
                        line = "compartment n°" + i.ToString() + "/" + price.ToString() + "/" + availability;
                        i += 1;
                        lines.Add(line);
                    }
                }
            }
            string totalPriceString = "Total price: " + (totalPrice/100).ToString();
            lines.Add(totalPriceString);
            double vat = totalPrice * 1.21 / 100;
            string vatPrice = "Total price with VAT: " + vat.ToString();
            lines.Add(vatPrice);
            return lines;
        }


        public void MakeList(Order order)
        {
            DateTime now = DateTime.Now;
            string line = null;
            string path = (@"../../../List of" + now + ".txt");
            List<string> lines = new List<string>
                {
                    "List of the" + now + "for" + "client",
                    " ",
                    "n° / item / availibility"
                };
            foreach (Product item in ProductSorter.RemoveDoubles(order.ItemToProduct()))
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
