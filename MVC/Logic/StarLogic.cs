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

        public void AddVideo(Star item)
        {
            this.starRepo.Add(item);
        }

        public void DeleteVideo(string ID)
        {
            this.starRepo.Delete(ID);
        }

        public IQueryable<Star> GetAllVideo()
        {
            return starRepo.Read();
        }

        public Star GetVideo(string ID)
        {
            return starRepo.Read(ID);
        }

        public void UpdateVideo(string uid, Star newitem)
        {
            starRepo.Update(uid, newitem);
        }
    }
}
