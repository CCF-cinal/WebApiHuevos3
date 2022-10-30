using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using WebApiHuevos3.Entidades;

namespace WebApiHuevos3
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Encargado> Encargados { get; set; }
        public DbSet<Huevo> Huevos { get; set; }
    }
}
