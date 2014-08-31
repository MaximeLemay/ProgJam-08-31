using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingdomMapper;

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

        private Improvement testImprovement(string n, string desc = "") {
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
        public void addImprovement() 
        {
            Tile t = testTile();
            t.improvements.Add(testImprovement("Watch tower"));
            t.improvements.Add(testImprovement("Farm"));

            string[] txtList = new string[2]{ "Watch tower", "Farm" };

            foreach (Improvement i in t.improvements) {
                Assert.IsNotNull(i);
                bool valid = false;
                for (int j = 0; j < txtList.Length; j++)
                    valid = txtList[j] == i.name ? true : false;

                Assert.IsTrue(valid);
            }
        }
    }
}
