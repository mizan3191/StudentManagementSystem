using StudentManagementSystem.Membership.Entities;
using Microsoft.EntityFrameworkCore;

namespace StudentManagementSystem.Membership.Contexts
{
    public class MembershipDbContext : DbContext, IMembershipDbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public MembershipDbContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(_connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ApplicationUser>()
            //    .ToTable("AspNetUsers", x => x.ExcludeFromMigrations())
            //    .HasMany<Student>()
            //    .WithOne(x => x.SuperAdmin);

            base.OnModelCreating(modelBuilder);
        }

        DbSet<Student> Students { get; set; }
    }
}
