using PrivateHospital.Contracts.DataContracts;
using PrivateHospital.Contracts.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PrivateHospital.DAL.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        internal PrivateHospitalContext db;
        internal DbSet<Service> dbSet;

        public ServiceRepository(PrivateHospitalContext db)
        {
            this.db = db;
            this.dbSet = db.Set<Service>();
        }

        public virtual IEnumerable<Service> GetAll()
        {
            var result = dbSet.AsNoTracking<Service>().ToList();
            return result;
        }

        public virtual Service GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Add(Service entity)
        {
            dbSet.Add(entity);
            db.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            Service entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
            db.SaveChanges();
        }

        public virtual void Delete(Service entityToDelete)
        {
            if (db.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            db.SaveChanges();
        }

        public virtual void Update(Service entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            db.Entry(entityToUpdate).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
