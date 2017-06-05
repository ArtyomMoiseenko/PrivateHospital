using PrivateHospital.Contracts.DataContracts;
using PrivateHospital.Contracts.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PrivateHospital.DAL.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        internal PrivateHospitalContext db;
        internal DbSet<Doctor> dbSet;

        public DoctorRepository(PrivateHospitalContext db)
        {
            this.db = db;
            this.dbSet = db.Set<Doctor>();
        }

        public virtual IEnumerable<Doctor> GetAll()
        {
            var result = dbSet.AsNoTracking<Doctor>().ToList();
            return result;
        }

        public virtual Doctor GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Add(Doctor entity)
        {
            dbSet.Add(entity);
            db.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            Doctor entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
            db.SaveChanges();
        }

        public virtual void Delete(Doctor entityToDelete)
        {
            if (db.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            db.SaveChanges();
        }

        public virtual void Update(Doctor entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            db.Entry(entityToUpdate).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
