using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Models;
using Repository;

namespace Logic
{
    public class SystemLogic
    {
        IRepository<Planet> planetRepo;
        IRepository<Star> starRepo;
        IRepository<Models.System> systemRepo;

        public SystemLogic(IRepository<Planet> planetRepo, IRepository<Star> starRepo, IRepository<Models.System> systemRepo)
        {
            this.planetRepo = planetRepo;
            this.starRepo = starRepo;
            this.systemRepo = systemRepo;
        }

        //crud methods

        public void AddSystem(Models.System item)
        {
            this.systemRepo.Add(item);
        }

        public void DeleteSystem(string ID)
        {
            this.systemRepo.Delete(ID);
        }

        public IQueryable<Models.System> GetAllSystem()
        {
            return systemRepo.Read();
        }

        public Models.System GetSystem(string ID)
        {
            return systemRepo.Read(ID);
        }

        public void UpdateSystem(string ID, Models.System newitem)
        {
            systemRepo.Update(ID, newitem);
        }

        //public void FillDbWithSamples()
        //{
        //    Planet p1 = new Planet() { Name = "Earth", Habitable = true, Population = 80000, PlanetType = PlanetType.Terran, PlanetID = Guid.NewGuid().ToString() };
        //    Planet p2 = new Planet() { Name = "Mars", Habitable = true, Population = 1, PlanetType = PlanetType.Subterran, PlanetID = Guid.NewGuid().ToString() };
        //    Planet p3 = new Planet() { Name = "Venus", Habitable = false, Population = 0, PlanetType = PlanetType.Miniterran, PlanetID = Guid.NewGuid().ToString() };
        //    Planet p4 = new Planet() { Name = "Merkur", Habitable = false, Population = 0, PlanetType = PlanetType.Jovian, PlanetID = Guid.NewGuid().ToString() };
        //    Planet p5 = new Planet() { Name = "Neptunus", Habitable = false, Population = 0, PlanetType = PlanetType.Neptunian, PlanetID = Guid.NewGuid().ToString() };

        //    Star s1 = new Star() { Name = "Our Sun", Age = 10, StarType = StarType.Orange_Dwarfs, StarID = Guid.NewGuid().ToString() };


        //}
    }
}
