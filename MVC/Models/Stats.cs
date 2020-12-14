using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Models
{
    public class Stats
    {
        public IEnumerable<Star> StarsWithLife { get; set; }
        public IEnumerable<PopulationInSec> PopulationInSectors { get; set; }
        public IEnumerable<PlanetTypeGrouped> PlanetTypeGrouped { get; set; }
    }
}
