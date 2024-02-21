using Biblio.Infrastrusture.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Biblio.Infrastrusture.Data.Context
{
    public class ApplicationContext : IdentityDbContext<User, Role, Guid>
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BiblioBook> BiblioBooks { get; set; }
        public DbSet<BiblioLendingInfo> BiblioLendingInfos { get; set; }
        public DbSet<BiblioFine> BiblioFines { get; set; }
        public DbSet<BiblioReader> BiblioReaders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BiblioFine>()
                .HasOne(fine => fine.LendingInfo)
                .WithOne(lendingInfo => lendingInfo.Fine)
                .HasForeignKey<BiblioFine>(fine => fine.LendingInfoId);
        }
    }
}
