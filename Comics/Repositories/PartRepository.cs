using Comics.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Comics.Repositories
{

    public class PartRepository : IRepository<Part>
    {
        private ApplicationDbContext db;
        public PartRepository(ApplicationDbContext context)
        {
            this.db = context;
        }

        public void Create(Part part)
        {
            db.Parts.Add(part);
        }

        public void CreateList(List<Part> parts,PageTemplate pageTemplate)
        {
            foreach (var part in parts)
            {
                part.PageTemplate = pageTemplate;
                db.Parts.Add(part);
            }         
        }

        public IEnumerable<Part> GetAll()
        {
            return db.Parts;
        }

        public void Update(Part part)
        {
            db.Entry(part).State = EntityState.Modified;
        }

        public Part Get(int id)
        {
            return db.Parts.Find(id);
        }
        public List<Part> GetAllForPage(int id)
        {
            return db.Parts.Where(u=>u.IdPageTemplate == id).ToList();
        }

        public void Delete(int id)
        {
            Part part = db.Parts.Find(id);
            if (part != null)
                db.Parts.Remove(part);
        }
    }
}