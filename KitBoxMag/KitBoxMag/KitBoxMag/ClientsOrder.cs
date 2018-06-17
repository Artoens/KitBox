using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitBoxMag
{
    public class ClientsOrder
    {
        public string Id { get; set; }
        public int Price { get; set; }

        public ClientsOrder(string id, int price)
        {
            this.Id = id;
            this.Price = price;
        }

        public override string ToString()
        {
            return Id;
        }
    }

    
}