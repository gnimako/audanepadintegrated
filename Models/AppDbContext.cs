using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;


using NodaTime;

namespace AUDANEPAD_Integrated.Models
{
    public class AppDbContext: IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<LkUp_ActivityType> LkUp_ActivityType { get; set; }
        public DbSet<LkUp_DSAType> LkUp_DSAType { get; set; }   
        public DbSet<LkUp_CostCatelogue> LkUp_CostCatelogue { get; set; }   


        public DbSet<Trans_ActivityType> Trans_ActivityType { get; set; }
        public DbSet<Trans_DSAType> Trans_DSAType { get; set; }
        public DbSet<Trans_CostCatelogue> Trans_CostCatelogue { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           // modelBuilder.Seed();

            var localDateConverter =
            new ValueConverter<LocalDate, DateTime>(v =>
                v.ToDateTimeUnspecified(),
                v => LocalDate.FromDateTime(v));

            var localDateTimeConverter = new ValueConverter<LocalDateTime, DateTime>(v =>
                                                                                     v.ToDateTimeUnspecified(),
                                                                                     v => LocalDateTime.FromDateTime(v));

            
            modelBuilder.Entity<Employee>()
            .Property(e => e.DOB)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<Employee>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<ApplicationUser>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<LkUp_ActivityType>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<LkUp_DSAType>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<LkUp_CostCatelogue>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<Trans_ActivityType>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<Trans_DSAType>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);


            modelBuilder.Entity<Trans_CostCatelogue>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);


        }
        
    }
}