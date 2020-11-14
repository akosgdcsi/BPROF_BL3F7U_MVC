using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Data;
using System.Linq;

namespace Repository
{
    public class StarRepository : IRepository<Star>
    {
        SolarContext context = new SolarContext();
        public void Add(Star item)
        {
            context.Stars.Add(item);
            context.SaveChanges();
        }

        public void Delete(Star item)
        {
            context.Stars.Remove(item);
            context.SaveChanges();
        }

        public void Delete(string ID)
        {
            Delete(Read(ID));
        }

        public Star Read(string ID)
        {
            return context.Stars.FirstOrDefault(t => t.StarID == ID);
        }

        public IQueryable<Star> Read()
        {
            return context.Stars.AsQueryable();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(string oldID, Star newitem)
        {
            var olditem = Read(oldID);
            olditem.Name = newitem.Name;
            olditem.StarType = newitem.StarType;
            olditem.Age = newitem.Age;

            olditem.Planets.Clear();
            foreach (var item in newitem.Planets)
            {
                olditem.Planets.Add(item);
            }

            context.SaveChanges();
        }
    }
}
