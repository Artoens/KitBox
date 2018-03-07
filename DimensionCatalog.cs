using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_kitbox
{
    static class DimensionCatalog
    {
        static public List<Dimension>GetDimensions()
        {
            List<Dimension> dimensionList = new List<Dimension>();

            Panel panel;

            foreach(Piece piece in Catalog.PieceList)
            {
                if (piece is Panel)
                {
                    panel = piece as Panel;

                    if (panel.Type == "TB")//Top-Bottom panel
                    {
                        
                    }
                }
            }

            return dimensionList;
        }
        

        static public List<string> GetDoorColors()
        {
            List<string> colorList = new List<string>();

            Door door;

            foreach (Piece piece in Catalog.PieceList)
            {
                if (piece is Door)
                {
                    door = piece as Door;
                    if(colorList.Contains(door.Color))
                    {
                        colorList.Add(door.Color);
                    }
                }
            }
            return colorList;
        }

        static public List<string> GetCompartmentColors()
        {
            List<string> colorList = new List<string>();

            Panel panel;

            foreach (Piece piece in Catalog.PieceList)
            {
                if (piece is Panel)
                {
                    panel = piece as Panel;
                    if (colorList.Contains(panel.Color))
                    {
                        colorList.Add(panel.Color);
                    }
                }
            }
            return colorList;
        }
    }
}
