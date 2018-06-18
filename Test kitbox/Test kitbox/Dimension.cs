using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_kitbox
{
    /// <summary>
    /// This class aims at providing an easy way to deal with the different dimensions of the pieces
    /// It only contains an array of dimensions (int) + the size of this array
    /// </summary>
    public class Dimension
    {
        private int[] dimensions;
        private int numberOfDim;

        public Dimension (int[] dimensions, int N)
        {
            int i;

            this.numberOfDim = N;
            this.dimensions = new int[N];

            for(i = 0; i < N; i++)
            {
                this.dimensions[i] = dimensions[i];
            }
        }

        public int Number
        {
            get { return numberOfDim; }
        }

        public int GetDimension(int i)
        {
            if (i < numberOfDim)
            {
                return dimensions[i];
            }

            return -1;
        }

        public override string ToString()
        {
            if (dimensions == null)
            {
                return "";
            }

            int i;
            string s = dimensions[0].ToString();

            


            for(i = 1; i < numberOfDim; i++)
            {
                s += "x" + dimensions[i];
            }

            return s;
        }
    }
}
