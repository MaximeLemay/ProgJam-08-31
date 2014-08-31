using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingdomMapper.Hex;
using KingdomMapper.Tiling;
using System.Collections.Generic;

namespace KMUnitTests
{
    [TestClass]
    public class CoordinatesTest
    {
        [TestMethod]
        public void checkConvertAxtoCb()
        {
            Coordinates c = new Coordinates { q = 1, r = 1 };
            Point p = new Point { x = 1, z = 1, y = -2 };
            Point test = Coordinates.ConvertAxialToCubic(c);
            Assert.AreEqual(p.x, test.x);
            Assert.AreEqual(p.z, test.z);
            Assert.AreEqual(p.y, test.y);
        }

        [TestMethod]
        public void checkGridCount() {
            Grid test = new Grid(6, 6);

            Assert.IsNotNull(test);
            Assert.AreEqual(36,test.data.Count);
        }

        [TestMethod]
        public void checkGridTableElement() {
            Grid test = new Grid(6, 6);

            Tile t = (Tile)test.data[new Coordinates { q= 2, r = 3}];

            Assert.AreEqual(Tile.Terrain.Plains, t.terrainType);
            Assert.IsTrue(t.isFogged);
        }

        [TestMethod]
        public void checkGridDistance() {   
            Coordinates c1 = new Coordinates {q = 2, r=2};
            Coordinates c2 = new Coordinates {q = 4, r = 5};
            int dist = Grid.GetDistance(c2, c1);
            Assert.AreEqual(4, dist);
        }

        [TestMethod]
        public void checkNeighbors() {
            Coordinates c = new Coordinates { q= 3, r = 3};
            List<Coordinates> tList = Grid.GetNeighbors(c);
            Coordinates t = tList[2];
            Assert.AreEqual(new Coordinates { q = 4, r = 3 }, tList[0]);
            Assert.AreEqual(new Coordinates { q = 4, r = 2 }, tList[1]);
            Assert.AreEqual(new Coordinates { q = 3, r = 2}, tList[2]);
            Assert.AreEqual(new Coordinates { q = 2, r = 3 }, tList[3]);
            Assert.AreEqual(new Coordinates { q = 3, r = 4 }, tList[4]);
            Assert.AreEqual(new Coordinates { q = 4, r = 4 }, tList[5]);
        }
    }
}
