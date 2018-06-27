using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CyberWeb.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CyberWeb.DAL
{
      public class CyberDbContext : DbContext
    {
        public CyberDbContext() : base("DefaultConnection")
        {
            Database.SetInitializer<CyberDbContext>(new CreateDatabaseIfNotExists<CyberDbContext>());

            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseIfModelChanges<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseAlways<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new SchoolDBInitializer());
        }

        public DbSet<Build> Builds { get; set; }
        public DbSet<Evaluate> Evaluates { get; set; }
        public DbSet<Use> Uses { get; set; }
        public DbSet<Data> Datas { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Billing>()
            //.HasRequired(m => m.Company)
            //.WithMany(m => m.Billings)
            //.HasForeignKey(m => m.CompanyID)
            //.WillCascadeOnDelete(false);

           
        }


    }
}