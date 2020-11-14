using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Data;
using System.Linq;

namespace Repository
{
    class SystemRepository : IRepository<Models.System>
    {
        SolarContext context = new SolarContext();
        public void Add(Models.System item)
        {
            context.Systems.Add(item);
            context.SaveChanges();
        }

        public void Delete(Models.System item)
        {
            context.Systems.Remove(item);
            context.SaveChanges();
        }

        public void Delete(string ID)
        {
            Delete(Read(ID));
        }

        public Models.System Read(string ID)
        {
            return context.Systems.FirstOrDefault(t => t.SystemID == ID);
        }

        public IQueryable<Models.System> Read()
        {
            return context.Systems.AsQueryable();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(string oldID, Models.System newitem)
        {
            var olditem = Read(oldID);
            olditem.Name = newitem.Name;
            olditem.SectorName = newitem.SectorName;
            

            olditem.Stars.Clear();
            foreach (var item in newitem.Stars)
            {
                olditem.Stars.Add(item);
            }

            context.SaveChanges();
        }
    }
}
