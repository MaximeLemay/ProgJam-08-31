using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingdomMapper.Hex
{
    /// <summary>
    /// Axial coordinates for the hexagonal grid system.
    /// Convert methods only for the flat top hexagonals.
    /// q: the x axis
    /// r: the z axis
    /// </summary>
    public class Coordinates
    {
        public int q { get; set; }
        public int r { get; set; }

        public static Coordinates ConvertCubicToAxial(Point p) 
        {
            return new Coordinates
            {
                q = p.x,
                r = p.z,
            };
        }

        public static Point ConvertAxialToCubic(Coordinates c)
        {
            return new Point
            {
                x = c.q,
                z = c.r,
                y = -c.q - c.r
            };
        }

        // convert cube to even-q offset
        public static Coordinates ConvertCubeToEvenQOffset(Point p)
        {
            return new Coordinates
            {
                q = p.x,
                r = p.z + (p.x+(p.x&1)) / 2
            };
        }

        // convert even-q offset to cube
        public static Point ConvertEvenQOffsetToCube(Coordinates c) { 
            int _x = c.q;
            int _z = c.r - (c.q + (c.q&1))/2;
            int _y = -_x-_z;

            return new Point{
                x = _z,
                y = _y,
                z = _z
            };
        }

        //convert cube to odd-q offset
        public static Coordinates ConvertCubeToOddQOffset(Point p) {
            return new Coordinates
            {
                q = p.x,
                r = p.z + (p.x - (p.x&1))/2
            };
        }

        // convert odd-q offset to cube
        public static Point ConvertOddQOffsetToCube(Coordinates c) {
            int _x = c.q;
            int _z = c.r - (c.q - (c.q & 1)) / 2;
            int _y = -_x - _z;
            return new Point { 
                x = _x,
                y = _y,
                z = _z
            };
        }

        // convert cube to odd-r offset
        public static Coordinates ConvertCubeToOddROffset(Point p) { 
            return new Coordinates{
                q = p.x + (p.z - (p.z&1)) / 2,
                r = p.z
            };
        }

        // convert odd-r offset to cube
        public static Point ConvertOddROffsetToCube(Coordinates c) {
            int _x = c.q - (c.r - (c.r & 1)) / 2;
            int _z = c.r;
            int _y = -_x - _z;
            return new Point
            {
                x = _x,
                y = _y,
                z = _z
            };
        }

        public override int GetHashCode()
        {
            return q.GetHashCode() + r.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var o = obj as Coordinates;
            return q.Equals(o.q) && r.Equals(o.r);
        }
    }
}
