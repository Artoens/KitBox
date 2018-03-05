using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_kitbox
{
    class Compartment
    {
        private int height;
        private string mainColor;
        private bool door;
        private string doorColor;

        public Compartment(int height, string mainColor, bool door, string doorColor)
        {
            this.height = height;
            this.mainColor = mainColor;
            this.door = door;
            this.doorColor = doorColor;
        }

        public int Height 
        {
            get { return height; }

            //Not checked yet
            set { this.height = value; }
        }

        public string MainColor
        {
            get { return mainColor; }

            //Not checked yet
            set { this.mainColor = value; }
        }
        
        public bool DoorPresence
        {
            get { return door; }

            //Not checked yet
            set { this.door = value; }
        }

        public string DoorColor
        {
            get { return doorColor; }

            //Not checked yet
            set { this.doorColor = value; }
        }
    }
}
