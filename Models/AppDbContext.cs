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
        public DbSet<Strategy_MTP> Strategy_MTP { get; set; }
        public DbSet<Strategy_MTPPriorityMapping> Strategy_MTPPriorityMapping { get; set; }
        public DbSet<Strategy_OutputIndicators> Strategy_OutputIndicators { get; set; }
        public DbSet<Strategy_OutputIndicatorsPriorityMapping> Strategy_OutputIndicatorsPriorityMapping { get; set; }

        public DbSet<Strategy_KeyPerformanceArea> Strategy_KeyPerformanceArea { get; set; }
        public DbSet<Struc_Directorate> Struc_Directorate { get; set; }
        public DbSet<Struc_Division> Struc_Division { get; set; }
        public DbSet<LkUp_Programme> LkUp_Programme { get; set; }
        public DbSet<LkUp_Project> LkUp_Project { get; set; }
        public DbSet<LkUp_Period> LkUp_Period { get; set; }
        public DbSet<LkUp_IndicatorType> LkUp_IndicatorType { get; set; }
        public DbSet<LkUp_MobilityLimits> LkUp_MobilityLimits { get; set; }

        
        
        


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
        public DbSet<Trans_StrategyMTP> Trans_StrategyMTP { get; set; }
        public DbSet<Trans_StrategyOutputIndicators> Trans_StrategyOutputIndicators { get; set; }
        public DbSet<Trans_StrategyKeyPerformanceArea> Trans_StrategyKeyPerformanceArea { get; set; }
        public DbSet<Trans_StrucDirectorate> Trans_StrucDirectorate { get; set; }
        public DbSet<Trans_StrucDivision> Trans_StrucDivision { get; set; }
        public DbSet<Trans_MobilityLimits> Trans_MobilityLimits { get; set; }

        public DbSet<Struc_DirStaffMapping> Struc_DirStaffMapping { get; set; }
        public DbSet<Struc_DivStaffMapping> Struc_DivStaffMapping { get; set; }
        public DbSet<Struc_Director> Struc_Director { get; set; }
        public DbSet<Struc_DirectorOIC> Struc_DirectorOIC { get; set; }
        public DbSet<Struc_DivHead> Struc_DivHead { get; set; }
        public DbSet<Struc_DivHeadOIC> Struc_DivHeadOIC { get; set; }
        public DbSet<Struc_DirDivIndicators> Struc_DirDivIndicators { get; set; }
        public DbSet<Trans_Programme> Trans_Programme { get; set; }
        public DbSet<Trans_Project> Trans_Project { get; set; }
        public DbSet<Trans_Period> Trans_Period { get; set; }
        public DbSet<Trans_IndicatorType> Trans_IndicatorType { get; set; }
        public DbSet<Trans_StrucDirDivIndicators> Trans_StrucDirDivIndicators { get; set; }

        public DbSet<System_Audit> System_Audit { get; set; }
        
        
        //Workplans
        public DbSet<WP_DispatchCycle> WP_DispatchCycle { get; set; }
        public DbSet<WP_MainRecord> WP_MainRecord { get; set; }
        public DbSet<WP_Outcomes> WP_Outcomes { get; set; }
        public DbSet<WP_MTP> WP_MTP { get; set; }
        public DbSet<WP_AUDAPriority> WP_AUDAPriority { get; set; }
        public DbSet<WP_ApprovalStatus> WP_ApprovalStatus { get; set; }

        public DbSet<WP_RegionScope> WP_RegionScope { get; set; }
        public DbSet<WP_CountryScope> WP_CountryScope { get; set; }
        public DbSet<WP_Outputs> WP_Outputs { get; set; }
        public DbSet<WP_OutputIndicators> WP_OutputIndicators { get; set; }
        public DbSet<WP_OutputActivities> WP_OutputActivities { get; set; }
        public DbSet<WP_SAPLink> WP_SAPLink { get; set; }
        public DbSet<WP_OutputBudget> WP_OutputBudget { get; set; }
        public DbSet<WP_OutputActivityCountries> WP_OutputActivityCountries { get; set; }
        public DbSet<WP_Mobility> WP_Mobility { get; set; }
        public DbSet<WP_MobilityInternalTeam> WP_MobilityInternalTeam { get; set; }
        public DbSet<WP_MobilityExternalTeam> WP_MobilityExternalTeam { get; set; }
        public DbSet<WP_MobilityLimit> WP_MobilityLimit { get; set; }


        

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

            modelBuilder.Entity<LkUp_MobilityLimits>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<Strategy_Priority>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<Strategy_MTP>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<Strategy_MTPPriorityMapping>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<Strategy_OutputIndicators>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<Strategy_OutputIndicatorsPriorityMapping>()
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

            modelBuilder.Entity<LkUp_Programme>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<LkUp_Project>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<LkUp_Period>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

   

            modelBuilder.Entity<LkUp_IndicatorType>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);


            modelBuilder.Entity<Trans_StrucDirDivIndicators>()
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

            modelBuilder.Entity<Trans_StrategyMTP>()
			.Property(e => e.TransactionDate)
			.HasConversion(localDateConverter);

            modelBuilder.Entity<Trans_StrategyOutputIndicators>()
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

            modelBuilder.Entity<Trans_MobilityLimits>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);


            modelBuilder.Entity<Struc_DirStaffMapping>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<Struc_DivStaffMapping>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);


            modelBuilder.Entity<Struc_Director>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<Struc_Director>()
            .Property(e => e.StartDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<Struc_Director>()
            .Property(e => e.EndDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<Struc_DivHead>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<Struc_DivHead>()
            .Property(e => e.StartDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<Struc_DivHead>()
            .Property(e => e.EndDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<Struc_DirectorOIC>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<Struc_DirectorOIC>()
            .Property(e => e.StartDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<Struc_DirectorOIC>()
            .Property(e => e.EndDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<Struc_DivHeadOIC>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<Struc_DivHeadOIC>()
            .Property(e => e.StartDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<Struc_DivHeadOIC>()
            .Property(e => e.EndDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<Struc_DirDivIndicators>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<Trans_Programme>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<Trans_Project>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<Trans_Period>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<Trans_IndicatorType>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);






            modelBuilder.Entity<System_Audit>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);


            //Workplans
            modelBuilder.Entity<WP_DispatchCycle>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<WP_DispatchCycle>()
            .Property(e => e.PeriodStartDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<WP_DispatchCycle>()
            .Property(e => e.PeriodEndDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<WP_MainRecord>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<WP_MainRecord>()
            .Property(e => e.PeriodStartDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<WP_MainRecord>()
            .Property(e => e.PeriodEndDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<WP_Outcomes>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<WP_MTP>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<WP_AUDAPriority>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<WP_ApprovalStatus>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<WP_RegionScope>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<WP_CountryScope>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<WP_Outputs>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<WP_OutputIndicators>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<WP_OutputActivities>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<WP_OutputActivities>()
            .Property(e => e.ActivityStartDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<WP_OutputActivities>()
            .Property(e => e.ActivityEndDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<WP_SAPLink>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<WP_OutputBudget>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<WP_OutputActivityCountries>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<WP_Mobility>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<WP_Mobility>()
            .Property(e => e.MobilityStartDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<WP_Mobility>()
            .Property(e => e.MobilityEndDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<WP_MobilityInternalTeam>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<WP_MobilityInternalTeam>()
            .Property(e => e.PeriodStartDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<WP_MobilityInternalTeam>()
            .Property(e => e.PeriodEndDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<WP_MobilityExternalTeam>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<WP_MobilityExternalTeam>()
            .Property(e => e.PeriodStartDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<WP_MobilityExternalTeam>()
            .Property(e => e.PeriodEndDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<WP_MobilityLimit>()
            .Property(e => e.TransactionDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<WP_MobilityLimit>()
            .Property(e => e.PeriodStartDate)
            .HasConversion(localDateConverter);

            modelBuilder.Entity<WP_MobilityLimit>()
            .Property(e => e.PeriodEndDate)
            .HasConversion(localDateConverter);
        }
        
    }
}