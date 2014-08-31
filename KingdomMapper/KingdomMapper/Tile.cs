using System;
using System.Collections.Generic;

namespace KingdomMapper
{
    public class Tile
    {
        public enum Terrain { 
            Plains,
            Forest,
            Hills,
            Mountains,
            Swamp,
            Water
        };

        public enum Road
        {
            None,
            Road,
            Highway
        };

        public string name { get; set; }
        public bool isExplored { get; set; }
        public bool isPacified { get; set; }
        public bool isFogged { get; set; }
        public Terrain terrainType { get; set; }
        public Road roadType { get; set; }
        public Settlement settlement { get; set; }
        public Ressource ressource { get; set; }
        public string notes { get; set; }

        public List<Improvement> improvements { get; set; }
    }
}
