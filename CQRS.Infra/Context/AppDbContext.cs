using CQRS.Domain.Entities;
using CQRS.Infra.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Infra.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Member> Members { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MemberConfiguration());
        }
    }
}