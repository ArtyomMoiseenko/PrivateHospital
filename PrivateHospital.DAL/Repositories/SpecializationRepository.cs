using PrivateHospital.Contracts.DataContracts;
using PrivateHospital.Contracts.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PrivateHospital.DAL.Repositories
{
    public class SpecializationRepository : ISpecializationRepository
    {
        internal PrivateHospitalContext db;
        internal DbSet<Specialization> dbSet;

        public SpecializationRepository(PrivateHospitalContext db)
        {
            this.db = db;
            this.dbSet = db.Set<Specialization>();
        }

        public virtual IEnumerable<Specialization> GetAll()
        {
            var result = dbSet.AsNoTracking<Specialization>().ToList();
            return result;
        }

        public virtual Specialization GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Add(Specialization entity)
        {
            dbSet.Add(entity);
            db.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            Specialization entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
            db.SaveChanges();
        }

        public virtual void Delete(Specialization entityToDelete)
        {
            if (db.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            db.SaveChanges();
        }

        public virtual void Update(Specialization entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            db.Entry(entityToUpdate).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
