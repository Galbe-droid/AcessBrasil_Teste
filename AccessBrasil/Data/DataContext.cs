using AccessBrasil.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessBrasil.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Marca> DbMarca { get; set; }

        public DbSet<Carro> DbCarro { get; set; }
    }
}
