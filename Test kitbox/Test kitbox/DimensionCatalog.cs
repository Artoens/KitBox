using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_kitbox
{
    public static class DimensionCatalog
    {
        /// <summary>
        /// This methods checks all the available dimensions from the list of panels in the catalog
        /// </summary>
        /// <returns>A list of all the available dimensions for a cupboard</returns>
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
                        Dimension dimension = new Dimension(new int[] { panel.Depth, panel.Length }, 2);
                        dimensionList.Add(dimension);
                    }
                }
            }
            return dimensionList;
        }

        /// <summary>
        /// This methods checks all the available dimensions from the list of panels in the catalog
        /// </summary>
        /// <returns>A list of all the available dimensions for compartment heights</returns>
        static public List<Dimension> GetCompartmentDimensions()
        {
            List<Dimension> dimensionList = new List<Dimension>();
            List<int> sidePanelDimList = new List<int>(), backPanelDimList = new List<int>(), doorDimList = new List<int>();

            Panel panel;
            Door door;

            foreach (Piece piece in Catalog.PieceList)
            {
                if (piece is Panel)
                {
                    panel = piece as Panel;

                    if (panel.Type == "LR")//Left-Right panel
                    {
                        sidePanelDimList.Add(panel.Height);
                    }

                    if (panel.Type == "B")//Back panel
                    {
                        backPanelDimList.Add(panel.Height);
                    }
                }

                if(piece is Door)
                {
                    door = piece as Door;

                    doorDimList.Add(door.Height);
                }
            }

            //Add the dimension to the available dimensions if all the pieces are available (panels, doors, rails ?)
            foreach(int height in sidePanelDimList)
            {
                if(sidePanelDimList.Contains(height) && backPanelDimList.Contains(height) && doorDimList.Contains(height))
                {
                    dimensionList.Add(new Dimension(new int[] { height }, 1));
                }
            }

            return dimensionList;
        }

        /// <summary>
        /// This methods checks all the available colors from the list of doors in the catalog
        /// </summary>
        /// <returns>A list of the available door colors</returns>
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

        /// <summary>
        /// This methods checks all the available colors from the list of panels in the catalog
        /// </summary>
        /// <returns>A list of the available compartment colors</returns>
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
