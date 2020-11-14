using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Models;
using Repository;

namespace Logic
{
    public class StarLogic
    {
        IRepository<Planet> planetRepo;
        IRepository<Star> starRepo;
        IRepository<Models.System> systemRepo;

        public StarLogic(IRepository<Planet> planetRepo, IRepository<Star> starRepo, IRepository<Models.System> systemRepo)
        {
            this.planetRepo = planetRepo;
            this.starRepo = starRepo;
            this.systemRepo = systemRepo;
        }

        //crud methods

        public void AddStar(Star item)
        {
            this.starRepo.Add(item);
        }

        public void DeleteStar(string ID)
        {
            this.starRepo.Delete(ID);
        }

        public IQueryable<Star> GetAllStar()
        {
            return starRepo.Read();
        }

        public Star GetStar(string ID)
        {
            return starRepo.Read(ID);
        }

        public void UpdateStar(string ID, Star newitem)
        {
            starRepo.Update(ID, newitem);
        }
    }
}
