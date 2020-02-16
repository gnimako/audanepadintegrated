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
        public DbSet<LkUp_ProcurementLTime> LkUp_ProcurementLTime { get; set; }
        public DbSet<LkUp_ProjectScope> LkUp_ProjectScope { get; set; }
        public DbSet<LkUp_RegionScope> LkUp_RegionScope { get; set; }
        public DbSet<LkUp_PeopleType> LkUp_PeopleType { get; set; }
        public DbSet<Strategy_Priority> Strategy_Priority { get; set; }
        public DbSet<Strategy_KeyPerformanceArea> Strategy_KeyPerformanceArea { get; set; }
        public DbSet<Struc_Directorate> Struc_Directorate { get; set; }
        public DbSet<Struc_Division> Struc_Division { get; set; }
        
        


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
        public DbSet<Trans_PeopleType> Trans_PeopleType { get; set; }
        public DbSet<Trans_ProcurementLTime> Trans_ProcurementLTime { get; set; }
        public DbSet<Trans_ProjectScope> Trans_ProjectScope { get; set; }
        public DbSet<Trans_RegionScope> Trans_RegionScope { get; set; }
        public DbSet<Trans_StrategyPriority> Trans_StrategyPriority { get; set; }
        public DbSet<Trans_StrategyKeyPerformanceArea> Trans_StrategyKeyPerformanceArea { get; set; }
        public DbSet<Trans_StrucDirectorate> Trans_StrucDirectorate { get; set; }
        public DbSet<Trans_StrucDivision> Trans_StrucDivision { get; set; }


        

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

            modelBuilder.Entity<LkUp_ProcurementLTime>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<LkUp_ProjectScope>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<LkUp_RegionScope>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<LkUp_PeopleType>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<Strategy_Priority>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<Strategy_KeyPerformanceArea>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<Struc_Directorate>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<Struc_Division>()
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

            modelBuilder.Entity<Trans_PeopleType>()
			.Property(e => e.TransactionDate)
			.HasConversion(localDateConverter);

            modelBuilder.Entity<Trans_ProcurementLTime>()
			.Property(e => e.TransactionDate)
			.HasConversion(localDateConverter);

            modelBuilder.Entity<Trans_ProjectScope>()
			.Property(e => e.TransactionDate)
			.HasConversion(localDateConverter);

            modelBuilder.Entity<Trans_RegionScope>()
			.Property(e => e.TransactionDate)
			.HasConversion(localDateConverter);

            modelBuilder.Entity<Trans_StrategyPriority>()
			.Property(e => e.TransactionDate)
			.HasConversion(localDateConverter);

            modelBuilder.Entity<Trans_StrategyKeyPerformanceArea>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<Trans_StrucDirectorate>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<Trans_StrucDivision>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);






        }
        
    }
}