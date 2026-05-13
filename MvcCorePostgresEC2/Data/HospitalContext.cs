using Microsoft.EntityFrameworkCore;
using MvcCorePostgresEC2.Models;

namespace MvcCorePostgresEC2.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> context)
            : base(context) { }
        public DbSet<Departamento> Departamentos { get; set; }
    }
}
