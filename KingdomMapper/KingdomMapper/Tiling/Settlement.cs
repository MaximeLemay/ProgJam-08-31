using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingdomMapper.Tiling
{
    public class Settlement
    {
        public enum Size{
            Thorp,
            Hamlet,
            Village,
            SmallTown,
            LargeTown,
            SmallCity,
            LargeCity,
            Metropolis
        };

        public string name { get; set; }
        public bool isAffiliated { get; set; }
        public string kingdom { get; set; }
        public Size size { get; set; }
        public int populationEstimate {
            get {
                int val = 0;
                switch (size) {
                    case Size.Thorp: { val = 21;  break; }
                    case Size.Hamlet: { val = 60;  break; }
                    case Size.Village: { val = 200; break; }
                    case Size.SmallTown: { val = 2000; break; }
                    case Size.LargeTown: { val = 5000; break; }
                    case Size.SmallCity: { val = 10000; break; }
                    case Size.LargeCity: { val = 25000; break; }
                    case Size.Metropolis: { val = 50000; break; }
                }
                return val;
            }
        }
    }
}
