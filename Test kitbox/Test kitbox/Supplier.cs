﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_kitbox
{
    public class Supplier
    {
        private string id;
        private string name;

        public Supplier (string id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public string ID
        {
            get { return ID; }
        }

        public string Name
        {
            get { return name; }
        }

        /// <summary>
        /// Pick up info from DB to build an existing supplier
        /// </summary>
        /// <returns>Supplier with info from DB</returns>
        public static Supplier SupplierFromDatabase()
        {
            return new Supplier("ID", "name");
        }
    }
}
