using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_kitbox
{
    public class Client
    {
        private string name;
        private string tva;

        public Client(string name, string tva)
        {
            this.name = name;
            this.tva = tva;
        }

        public string Name
        {
            get { return name; }
            set { name = value;}
        }

        public string TVAnumber
        {
            get { return tva; }
            set { tva = value; }
        }
    }
}
