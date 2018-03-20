using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_kitbox
{
    public class Output
    {
        public Output()
        {


        }

        public void PrettyOrder(Order order)
        {
            foreach (Product product in order.GenerateOrder())
            {
                //Display the list onto the interface
            }
        }
        //il manque 
        public void MakeBill(Order order)
        {
            DateTime now = DateTime.Now;
            string line = null;
            string path = (@"../../../Bill of" + now + ".txt");
            int totalPrice = 0;
            int cupboardPrices = 0; //ça
            foreach (Product product in order.GenerateOrder())
            {
                totalPrice += product.Piece.Price;
            }


            List<string> lines = new List<string>
                {
                    "Bill made on the" + now + "for the client",
                    " ",
                    "Item bought/price/availibility",
                    "cupboard/" + ((totalPrice-cupboardPrices)/100).ToString() + ""//pour ici
                };
            foreach (Product product in order.GenerateOrder())
            {
                //ici aussi il manque un truc
                lines.Add(line);
            }
            string totalPriceString = "Total price: " + (totalPrice/100).ToString();
            lines.Add(totalPriceString);
            double vat = totalPrice * 1.21 / 100;
            string vatPrice = "Total price with VAT: " + vat.ToString();
            lines.Add(vatPrice);
            lines.ToArray();
            System.IO.File.WriteAllLines(path, lines);
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
            foreach (Product item in order.ItemToProduct())
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
