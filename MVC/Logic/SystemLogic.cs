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

        public void AddVideo(Models.System item)
        {
            this.systemRepo.Add(item);
        }

        public void DeleteVideo(string ID)
        {
            this.systemRepo.Delete(ID);
        }

        public IQueryable<Models.System> GetAllVideo()
        {
            return systemRepo.Read();
        }

        public Models.System GetVideo(string ID)
        {
            return systemRepo.Read(ID);
        }

        public void UpdateVideo(string uid, Models.System newitem)
        {
            systemRepo.Update(uid, newitem);
        }
    }
}
