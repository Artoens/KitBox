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
        static public List<Dimension> GetDimensions()
        {
            List<Dimension> dimensionList = new List<Dimension>();

            bool alreadyIn;
            Panel panel;

            foreach (Piece piece in Catalog.PieceList)
            {
                if (piece is Panel)
                {
                    panel = piece as Panel;

                    if (panel.Type == "TB")//Top-Bottom panel
                    {
                        Dimension dimension = new Dimension(new int[] { panel.Depth, panel.Length }, 2);

                        alreadyIn = false;
                        foreach (Dimension dim in dimensionList)
                        {
                            if (dim.ToString() == dimension.ToString())
                            {
                                alreadyIn = true;
                                break;
                            }
                        }

                        if (!alreadyIn)
                        {
                            dimensionList.Add(dimension);
                        }
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

            bool alreadyIn;
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

                if (piece is Door)
                {
                    door = piece as Door;

                    doorDimList.Add(door.Height);
                }

            }

            //Add the dimension to the available dimensions if all the pieces are available (panels, doors, rails ?)
            foreach (int height in sidePanelDimList)
            {
                if (sidePanelDimList.Contains(height) && backPanelDimList.Contains(height) && doorDimList.Contains(height))
                {
                    Dimension dimension = new Dimension(new int[] { height }, 1);

                    alreadyIn = false;
                    foreach (Dimension dim in dimensionList)
                    {
                        if (dim.ToString() == dimension.ToString())
                        {
                            alreadyIn = true;
                            break;
                        }
                    }

                    if (!alreadyIn)
                    {
                        dimensionList.Add(dimension);
                    }
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
                    if (!colorList.Contains(door.Color))
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
                    if (!colorList.Contains(panel.Color))
                    {
                        colorList.Add(panel.Color);
                    }
                }
            }
            return colorList;
        }

        /// <summary>
        /// This methods checks all the available colors from the list of doors in the catalog
        /// It lists available colors according to the selecter height
        /// </summary>
        /// <returns>A list of the available door colors</returns>
        static public List<string> GetDoorColors(int height)
        {
            List<string> colorList = new List<string>();

            Door door;

            foreach (Piece piece in Catalog.PieceList)
            {
                if (piece is Door)
                {
                    door = piece as Door;
                    if (door.Height == height && !colorList.Contains(door.Color))
                    {
                        colorList.Add(door.Color);
                    }
                }
            }
            return colorList;
        }

        /// <summary>
        /// This methods checks all the available colors from the list of angle bars in the catalog
        /// It lists available colors according to the selecter height
        /// </summary>
        /// <returns>A list of the available door colors</returns>
        static public List<string> GetAngleBarColors(int height)
        {
            List<string> colorList = new List<string>();

            AngleBar angleBar;

            foreach (Piece piece in Catalog.PieceList)
            {
                if (piece is AngleBar)
                {
                    angleBar = piece as AngleBar;
                    if (angleBar.Height >= height && !colorList.Contains(angleBar.Color))
                    {
                        colorList.Add(angleBar.Color);
                    }
                }
            }
            return colorList;
        }

        /// <summary>
        /// This methods checks all the available colors from the list of panels in the catalog
        /// It lists available colors according to the selecter height
        /// </summary>
        /// <returns>A list of the available compartment colors</returns>
        static public List<string> GetCompartmentColors(int height)
        {
            List<string> colorList = new List<string>();
            List<string> sidePanelColorList = new List<string>(), backPanelColorList = new List<string>();

            Panel panel;

            foreach (Piece piece in Catalog.PieceList)
            {
                if (piece is Panel)
                {
                    panel = piece as Panel;

                    if (panel.Type == "LR")//Left-Right panel
                    {
                        sidePanelColorList.Add(panel.Color);
                    }

                    if (panel.Type == "B")//Back panel
                    {
                        backPanelColorList.Add(panel.Color);
                    }
                }
            }

            //Add the color to the available colors if all the pieces are available (panels B, panels LR)
            foreach (string color in sidePanelColorList)
            {
                //If the color is already in the list : do not add it
                //Check if the color is available for the back & side panels
                if (sidePanelColorList.Contains(color) && backPanelColorList.Contains(color) && !colorList.Contains(color))
                {
                    colorList.Add(color);
                }
            }

            return colorList;
        }
    }
}