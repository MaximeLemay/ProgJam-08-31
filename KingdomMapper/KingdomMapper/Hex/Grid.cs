using System;
using System.Collections.Generic;
using System.Collections;
using KingdomMapper.Tiling;

namespace KingdomMapper.Hex
{
    /// <summary>
    /// Hexagonal grid. Pointy topped hexes.
    /// Uses a hashtable to store the grid data, as Coordinates, Tile
    /// The coordinate system is with an odd r offset.
    /// </summary>
    public class Grid
    {
        /// <summary>
        /// Grid constructor. Makes a width x height hexagonal grid.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Grid(int width, int height) {
            data = new Hashtable();
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    data.Add(new Coordinates{q = i, r=j}, new Tile());
                }
            }
        }

        public Hashtable data { get; set; }

        /// <summary>
        /// Locates a hex's neighbors. List format of type coordinates.
        /// </summary>
        /// <param name="center"> Central hex. Typed as Coordinates</param>
        /// <returns>List of Coordinates, representing the parameter's 6 neighbors</returns>
        public static List<Coordinates> GetNeighbors(Coordinates center) {
            List<Coordinates> list = new List<Coordinates>();
            Point p = Coordinates.ConvertOddROffsetToCube(center);

            // TODO : Messy, clean it up.
            list.Add(Coordinates.ConvertCubeToOddROffset(new Point { x = p.x + 1, y = p.y - 1, z = p.z }));
            list.Add(Coordinates.ConvertCubeToOddROffset(new Point { x = p.x + 1, y = p.y, z = p.z - 1 }));
            list.Add(Coordinates.ConvertCubeToOddROffset(new Point { x = p.x, y = p.y + 1, z = p.z - 1 }));
            list.Add(Coordinates.ConvertCubeToOddROffset(new Point { x = p.x - 1, y = p.y + 1, z = p.z }));
            list.Add(Coordinates.ConvertCubeToOddROffset(new Point { x = p.x - 1, y = p.y, z = p.z + 1 }));
            list.Add(Coordinates.ConvertCubeToOddROffset(new Point { x = p.x, y = p.y - 1, z = p.z + 1 }));
            return list;
        }

        /// <summary>
        /// Calculates the distance between two hexes in a straight line. 
        /// Algorithm uses cubic coordinates, with converted odd-r offset coordinates.
        /// </summary>
        /// <param name="cA">First hex. Typed as Coordinates</param>
        /// <param name="cB">Second hex. Typed as Coordinates</param>
        /// <returns>Number of hexes as distance.</returns>
        public static int GetDistance(Coordinates cA, Coordinates cB) {
            Point p1 = Coordinates.ConvertOddROffsetToCube(cA);
            Point p2 = Coordinates.ConvertOddROffsetToCube(cB);
            return (Math.Abs(p1.x - p2.x) + Math.Abs(p1.y - p2.y) + Math.Abs(p1.z - p2.z)) / 2;
        }
    }
}
