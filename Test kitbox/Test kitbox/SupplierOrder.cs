using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_kitbox
{
    public class SupplierOrder
    {
        private Supplier supplier;
        private Product product;

        public SupplierOrder ()
        {
            
        }

        public Product Product
        {
            get { return product; }
            set
            {
                if (value is Product)
                {
                    product = value;
                }
            }
        }

        public Supplier Supplier
        {
            get { return supplier; }
            set
            {
                if (value is Supplier)
                {
                    supplier = value;
                }
            }
        }
    }
}
