using Microsoft.EntityFrameworkCore;
using smarthintAPI.Models;

namespace smarthintAPI.Data
{
    public class SmarthintDBContext : DbContext
    {
        public SmarthintDBContext(DbContextOptions<SmarthintDBContext> context) : base(context) { }

        public DbSet<Cliente> Clientes { get; set; }

    }
}
