using Microsoft.EntityFrameworkCore;
using Restaurante.Data.Seed;
using Restaurante.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Restaurante.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }

        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ComandasSeed());
            modelBuilder.ApplyConfiguration(new EmpleadosSeed());
            modelBuilder.ApplyConfiguration(new MesasSeed());
            modelBuilder.ApplyConfiguration(new PedidosSeed());
            modelBuilder.ApplyConfiguration(new ProductosSeed());


        }

        //Nombre de las  tablas

        public virtual DbSet<Comandas> Comandas { get; set; }
        public virtual DbSet<Empleados> Empleados{ get; set; }
        public virtual DbSet<Mesas> Mesas { get; set; }
        public virtual DbSet<Pedidos> Pedidos{ get; set; }
        public virtual DbSet<Productos> Productos { get; set; }


    }
}