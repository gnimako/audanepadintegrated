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
        public DbSet<LkUp_CommsChannel> LkUp_CommsChannel { get; set; } 
        public DbSet<LkUp_Country> LkUp_Country { get; set; } 
        public DbSet<LkUp_ExtParticipantType> LkUp_ExtParticipantType { get; set; }
        public DbSet<LkUp_FiscalYear> LkUp_FiscalYear { get; set; }
        public DbSet<LkUp_ImplementationType> LkUp_ImplementationType { get; set; }
        public DbSet<LkUp_LeadershipStatus> LkUp_LeadershipStatus { get; set; }
        public DbSet<LkUp_ParticipantType> LkUp_ParticipantType { get; set; }
        public DbSet<LkUp_ProcurementType> LkUp_ProcurementType { get; set; }
        public DbSet<LkUp_RiskCategory> LkUp_RiskCategory { get; set; }
        public DbSet<LkUp_RiskImpact> LkUp_RiskImpact { get; set; }
        public DbSet<LkUp_RiskProbability> LkUp_RiskProbability { get; set; }
        public DbSet<LkUp_RiskRTimeframe> LkUp_RiskRTimeframe { get; set; }


        public DbSet<Trans_ActivityType> Trans_ActivityType { get; set; }
        public DbSet<Trans_DSAType> Trans_DSAType { get; set; }
        public DbSet<Trans_CostCatelogue> Trans_CostCatelogue { get; set; }
        public DbSet<Trans_CommsChannel> Trans_CommsChannel { get; set; }
        public DbSet<Trans_Country> Trans_Country { get; set; }
        public DbSet<Trans_ExtParticipantType> Trans_ExtParticipantType { get; set; }
        public DbSet<Trans_FiscalYear> Trans_FiscalYear { get; set; }
        public DbSet<Trans_ImplementationType> Trans_ImplementationType { get; set; }
        public DbSet<Trans_LeadershipStatus> Trans_LeadershipStatus { get; set; }
        public DbSet<Trans_ParticipantType> Trans_ParticipantType { get; set; }
        public DbSet<Trans_ProcurementType> Trans_ProcurementType { get; set; }
        public DbSet<Trans_RiskCategory> Trans_RiskCategory { get; set; }
        public DbSet<Trans_RiskImpact> Trans_RiskImpact { get; set; }
        public DbSet<Trans_RiskProbability> Trans_RiskProbability { get; set; }
        public DbSet<Trans_RiskRTimeframe> Trans_RiskRTimeframe { get; set; }


        

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

            modelBuilder.Entity<LkUp_CommsChannel>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<LkUp_Country>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<LkUp_ExtParticipantType>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<LkUp_FiscalYear>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<LkUp_ImplementationType>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<LkUp_LeadershipStatus>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<LkUp_ParticipantType>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<LkUp_ProcurementType>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<LkUp_RiskCategory>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<LkUp_RiskImpact>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<LkUp_RiskProbability>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<LkUp_RiskRTimeframe>()
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

            modelBuilder.Entity<Trans_CommsChannel>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<Trans_Country>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<Trans_ExtParticipantType>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

			modelBuilder.Entity<Trans_FiscalYear>()
			.Property(e => e.TransactionDate)
			.HasConversion(localDateConverter);

            modelBuilder.Entity<Trans_ImplementationType>()
			.Property(e => e.TransactionDate)
			.HasConversion(localDateConverter);

            modelBuilder.Entity<Trans_LeadershipStatus>()
			.Property(e => e.TransactionDate)
			.HasConversion(localDateConverter);

            modelBuilder.Entity<Trans_ParticipantType>()
			.Property(e => e.TransactionDate)
			.HasConversion(localDateConverter);

            modelBuilder.Entity<Trans_ProcurementType>()
			.Property(e => e.TransactionDate)
			.HasConversion(localDateConverter);

            modelBuilder.Entity<Trans_RiskCategory>()
			.Property(e => e.TransactionDate)
			.HasConversion(localDateConverter);

            modelBuilder.Entity<Trans_RiskImpact>()
			.Property(e => e.TransactionDate)
			.HasConversion(localDateConverter);

            modelBuilder.Entity<Trans_RiskProbability>()
			.Property(e => e.TransactionDate)
			.HasConversion(localDateConverter);

            modelBuilder.Entity<Trans_RiskRTimeframe>()
			.Property(e => e.TransactionDate)
			.HasConversion(localDateConverter);






        }
        
    }
}