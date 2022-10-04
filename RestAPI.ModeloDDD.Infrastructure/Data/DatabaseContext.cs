using Microsoft.EntityFrameworkCore;
using RestAPI.ModeloDDD.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI.ModeloDDD.Infrastructure.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }


        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }


        public override int SaveChanges()
        {
            foreach (var item in ChangeTracker.Entries().Where(item => item.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (item.State == EntityState.Added)
                {
                    item.Property("DataCadastro").CurrentValue = DateTime.Now;
                }
                if (item.State == EntityState.Modified)
                {
                    item.Property("DataCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}
