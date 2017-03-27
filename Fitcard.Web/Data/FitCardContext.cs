using Fitcard.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Fitcard.Web.Data
{
    public class FitCardContext : DbContext
    {
        public FitCardContext()
            : base("ConnFitCard")
        {

        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //base.OnModelCreating(modelBuilder);
        }

        public DbSet<Estabelecimento> Estabelecimento { get; set; }
        public DbSet<Categoria> Categoria { get; set; }

    }
}