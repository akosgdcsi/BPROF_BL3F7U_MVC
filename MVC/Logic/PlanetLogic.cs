using System;
using System.Linq;
using Models;
using Repository;

namespace Logic
{
    public class PlanetLogic
    {
        IRepository<Planet> planetRepo;
        IRepository<Star> starRepo;
        IRepository<Models.System> systemRepo;

        public PlanetLogic(IRepository<Planet> planetRepo, IRepository<Star> starRepo, IRepository<Models.System> systemRepo)
        {
            this.planetRepo = planetRepo;
            this.starRepo = starRepo;
            this.systemRepo = systemRepo;
        }

        //crud methods

        public void AddPlanet(Planet item)
        {
            this.planetRepo.Add(item);
        }

        public void DeletePlanet(string ID)
        {
            this.planetRepo.Delete(ID);
        }

        public IQueryable<Planet> GetAllPlanet()
        {
            return planetRepo.Read();
        }

        public Planet GetPlanet(string ID)
        {
            return planetRepo.Read(ID);
        }

        public void UpdatePlanet(string ID, Planet newitem)
        {
            planetRepo.Update(ID, newitem);
        }

        public IQueryable<Planet> PlanetToStar(string id)
        {

            var q = planetRepo.Read().Select(x => x).Where(x => x.StarID == id);

            return q.AsQueryable();

        }
        
    }
}
