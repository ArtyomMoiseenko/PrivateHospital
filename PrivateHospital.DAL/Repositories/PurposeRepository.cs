using PrivateHospital.Contracts.DataContracts;
using PrivateHospital.Contracts.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PrivateHospital.DAL.Repositories
{
    public class PurposeRepository : IPurposeRepository
    {
        internal PrivateHospitalContext db;
        internal DbSet<Purpose> dbSet;

        public PurposeRepository(PrivateHospitalContext db)
        {
            this.db = db;
            this.dbSet = db.Set<Purpose>();
        }

        public virtual IEnumerable<Purpose> GetAll()
        {
            var result = dbSet.AsNoTracking<Purpose>().ToList();
            return result;
        }

        public virtual Purpose GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Add(Purpose entity)
        {
            dbSet.Add(entity);
            db.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            Purpose entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
            db.SaveChanges();
        }

        public virtual void Delete(Purpose entityToDelete)
        {
            if (db.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            db.SaveChanges();
        }

        public virtual void Update(Purpose entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            db.Entry(entityToUpdate).State = EntityState.Modified;
            db.SaveChanges();
        }

        public virtual Receipt GetReceipt(int id)
        {
            System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@IdPurpose", id);
            var result = db.Database.SqlQuery<Receipt>("SELECT * FROM dbo.ReceiptService (@IdPurpose)", param).FirstOrDefault();
            return result;
        }
    }
}
