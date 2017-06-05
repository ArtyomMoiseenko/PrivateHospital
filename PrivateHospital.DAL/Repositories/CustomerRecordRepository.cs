using PrivateHospital.Contracts.DataContracts;
using PrivateHospital.Contracts.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PrivateHospital.DAL.Repositories
{
    public class CustomerRecordRepository : ICustomerRecordRepository
    {
        internal PrivateHospitalContext db;
        internal DbSet<CustomerRecord> dbSet;

        public CustomerRecordRepository(PrivateHospitalContext db)
        {
            this.db = db;
            this.dbSet = db.Set<CustomerRecord>();
        }

        public virtual IEnumerable<CustomerRecord> GetAll()
        {
            var result = dbSet.AsNoTracking<CustomerRecord>().ToList();
            return result;
        }

        public virtual CustomerRecord GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Add(CustomerRecord entity)
        {
            dbSet.Add(entity);
            db.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            CustomerRecord entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
            db.SaveChanges();
        }

        public virtual void Delete(CustomerRecord entityToDelete)
        {
            if (db.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            db.SaveChanges();
        }

        public virtual void Update(CustomerRecord entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            db.Entry(entityToUpdate).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
