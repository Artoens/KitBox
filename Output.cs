using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_kitbox
{
    class Output
    {
        public Output()
        {
            

        }

        public void PrettyOrder(Order order)
        {
            foreach(Product product in order.GenerateOrder())
            {
                //Display the list onto the interface
            }
        }
        public void MakeBill()
        {

        }
        public void MakeList()
        {

        }
    }
}
