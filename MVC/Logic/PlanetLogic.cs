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

        public void AddVideo(Planet item)
        {
            this.planetRepo.Add(item);
        }

        public void DeleteVideo(string ID)
        {
            this.planetRepo.Delete(ID);
        }

        public IQueryable<Planet> GetAllVideo()
        {
            return planetRepo.Read();
        }

        public Planet GetVideo(string ID)
        {
            return planetRepo.Read(ID);
        }

        public void UpdateVideo(string uid, Planet newitem)
        {
            planetRepo.Update(uid, newitem);
        }
    }
}
