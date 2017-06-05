using PrivateHospital.Contracts.DataContracts;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PrivateHospital
{
    public class PrivateHospitalContext : DbContext
    {
        public PrivateHospitalContext()
            :base("PrivateHospitalContext")
        {
            Database.SetInitializer<PrivateHospitalContext>(new PrivateHospitalInitializer());
            Database.Initialize(true);
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<CustomerRecord> CustomerRecords { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Purpose> Purposes { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Specialization> Specializations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}
