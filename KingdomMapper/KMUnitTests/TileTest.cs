using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingdomMapper.Tiling;

namespace KMUnitTests
{
    [TestClass]
    public class TileTest
    {

        private Tile testTile() {
            Tile cTile = new Tile
            {
                name = "Stuffs",
                isExplored = false,
                isFogged = true,
                isPacified = false,
                notes = "",
                ressource = new Ressource { name = "Iron", notes = "Bees in the cave" },
                roadType = Tile.Road.None,
                terrainType = Tile.Terrain.Hills
            };
            return cTile;
        }

        private Improvement testImprovement(string n, string desc) {
            Improvement imp = new Improvement
            {
                name = n,
                description = desc
            };
            return imp;
        }

        [TestMethod]
        public void TileCreate()
        {
            Tile t = testTile();
            Assert.IsNotNull(t);
            Assert.IsTrue(t.isFogged);
            Assert.AreEqual("Iron", t.ressource.name);
        }

        [TestMethod]
        public void defaultTile()
        {
            Tile t = new Tile();

            Assert.IsTrue(t.isFogged);
            Assert.IsFalse(t.isExplored);
        }

        [TestMethod]
        public void addImprovement() 
        {
            Tile t = testTile();
            t.improvements.Add(testImprovement("Watch tower", "test1"));
            t.improvements.Add(testImprovement("Farm", "test2"));

            string[] txtList = new string[2]{ "Watch tower", "Farm" };

            foreach (Improvement i in t.improvements) {
                Assert.IsNotNull(i);
                bool valid = false;
                for (int j = 0; j < txtList.Length && !valid; j++)
                    valid = txtList[j] == i.name ? true : false;

                Assert.IsTrue(valid);
            }
        }

        [TestMethod]
        public void addSettlement() 
        {
            Tile t = testTile();
            t.settlement = new Settlement
            {
                name = "Shack",
                isAffiliated = false,
                size = Settlement.Size.Thorp
            };

            Assert.AreEqual("Shack", t.settlement.name);
            Assert.AreEqual(false, t.settlement.isAffiliated);
            Assert.IsTrue(t.settlement.populationEstimate > 0);
        }
    }
}
