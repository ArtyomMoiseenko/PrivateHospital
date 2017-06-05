using PrivateHospital.Contracts.DataContracts;
using PrivateHospital.Contracts.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PrivateHospital.DAL.Repositories
{
    public class ClientRepository : IClientRepository
    {
        internal PrivateHospitalContext db;
        internal DbSet<Client> dbSet;
        
        public ClientRepository(PrivateHospitalContext db)
        {
            this.db = db;
            this.dbSet = db.Set<Client>();
        }

        public virtual IEnumerable<Client> GetAll()
        {
            var result = dbSet.AsNoTracking<Client>().ToList();
            return result;
        }

        public virtual Client GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Add(Client entity)
        {
            dbSet.Add(entity);
            db.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            Client entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
            db.SaveChanges();
        }

        public virtual void Delete(Client entityToDelete)
        {
            if (db.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            db.SaveChanges();
        }

        public virtual void Update(Client entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            db.Entry(entityToUpdate).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
