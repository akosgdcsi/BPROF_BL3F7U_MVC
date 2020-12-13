using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Logic
{
    public class StatsLogic
    {
        IRepository<Planet> planetRepo;
        IRepository<Star> starRepo;
        IRepository<Models.System> systemRepo;

        public StatsLogic(IRepository<Planet> planetRepo, IRepository<Star> starRepo, IRepository<Models.System> systemRepo)
        {
            this.planetRepo = planetRepo;
            this.starRepo = starRepo;
            this.systemRepo = systemRepo;
        }
        public IEnumerable<Star> StarsWithLife()
        {
            var q1 = from star in starRepo.Read().ToList()
                     join planet in planetRepo.Read().ToList() on star.StarID equals planet.StarID
                     where planet.Habitable
                     select star;
            return q1;
        }
        public IEnumerable<PopulationInSec> PopulationInSectors()
        {
            var q2 = (from system in systemRepo.Read().ToList()
                      join star in starRepo.Read().ToList() on system.SystemID equals star.SystemID
                      join planet in planetRepo.Read().ToList() on star.StarID equals planet.StarID
                      group system by system.SectorName into g
                      select new PopulationInSec
                      {
                          SectorType = g.Key,
                          Population = g.SelectMany(sys => sys.Stars).SelectMany(s => s.Planets).Distinct().Sum(p => p.Population)
                      }).OrderByDescending(x => x.Population);
            return q2.AsQueryable();
        }
        public IEnumerable<PlanetTypeGrouped> PlanetTypeGrouped()
        {
            var q3 = from planet in planetRepo.Read().ToList()
                     join star in starRepo.Read().ToList() on planet.StarID equals star.StarID
                     where star.Age > 1000000
                     group planet by planet.PlanetType into g
                     select new PlanetTypeGrouped
                     {
                         Type = g.Key,
                         NumberOfStars = g.Select(x => x.StarID).Distinct().Count()
                     };
            return q3.AsQueryable();
        }
    }
}
