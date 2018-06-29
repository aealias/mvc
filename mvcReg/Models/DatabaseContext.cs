using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace mvcReg.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=aleetaDBContext")
        {


        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add<ManyToManyCascadeDeleteConvention>();
            // base.OnModelCreating(modelBuilder);
        }
        public DbSet<UserAccount> userAccounts { get; set; }
        public DbSet<Reg> reg { get; set; }

    }
}