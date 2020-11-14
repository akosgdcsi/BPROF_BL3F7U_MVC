using System;
using Models;
using Data;
using System.Linq;

namespace Repository
{
    public class PlanetRepository : IRepository<Planet>

    {
        SolarContext context = new SolarContext();
        public void Add(Planet item)
        {
            context.Planets.Add(item);
            context.SaveChanges();
        }

        public void Delete(Planet item)
        {
            context.Planets.Remove(item);
            context.SaveChanges();
        }

        public void Delete(string ID)
        {
            Delete(Read(ID));
        }

        public Planet Read(string ID)
        {
            return context.Planets.FirstOrDefault(t => t.PlanetID == ID);
        }

        public IQueryable<Planet> Read()
        {
            return context.Planets.AsQueryable();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(string oldid, Planet newitem)
        {
            var olditem = Read(oldid);
            olditem.Name = newitem.Name;
            olditem.PlanetType = newitem.PlanetType;
            olditem.Habitable = newitem.Habitable;
            olditem.Population = newitem.Population;

            context.SaveChanges();
        }
    }
}
