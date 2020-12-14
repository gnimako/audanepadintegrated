using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using NodaTime;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceWP_MobilityInternalTeam: IWP_MobilityInternalTeamRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceWP_MobilityInternalTeam> logger;
		public ServiceWP_MobilityInternalTeam(AppDbContext context, ILogger<ServiceWP_MobilityInternalTeam> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public WP_MobilityInternalTeam Add(WP_MobilityInternalTeam rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.WP_MobilityInternalTeam.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public WP_MobilityInternalTeam Delete(string id)
		{
		    WP_MobilityInternalTeam rec = context.WP_MobilityInternalTeam.Find(id);
		    if (rec != null)
		    {
		        context.WP_MobilityInternalTeam.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<WP_MobilityInternalTeam> GetAllRecords()
		{
		    return context.WP_MobilityInternalTeam;
		}
		public IEnumerable<WP_MobilityInternalTeam> GetRecordsByMobilityId (string id)
        {
            var records = context.WP_MobilityInternalTeam
                                .Where(s => s.WPMobility_id==id)
                                .ToList();

            return records;
        }
		public IEnumerable<WP_MobilityInternalTeam> GetRecordsByMainRecordIdAndEmployee (string recid, int empid)
        {
            var records = context.WP_MobilityInternalTeam
                                .Where(s => s.WPMainRecord_id==recid && s.Employee_Id==empid)
                                .ToList();

            return records;
        }

		public IEnumerable<WP_MobilityInternalTeam> GetRecordsByMainRecordId (string recid)
        {
            var records = context.WP_MobilityInternalTeam
                                .Where(s => s.WPMainRecord_id==recid)
                                .ToList();

            return records;
        }
		public IEnumerable<WP_MobilityInternalTeam>   GetRecordsByEmployeeYearPeriod (int empid, int yearid, int periodid)
        {
            var records = context.WP_MobilityInternalTeam
                                .Where(s => s.Employee_Id==empid && s.FiscalYear_Id==yearid && s.Period_Id==periodid )
                                .ToList();

            return records;
        }

		public IEnumerable<WP_MobilityInternalTeam>   GetRecordsByEmployeeYearPeriodStartEnd (int empid, int yearid, int periodid, LocalDate PeriodStartDate, LocalDate PeriodEndDate)
        {
            var records = context.WP_MobilityInternalTeam
                                .Where(s => s.Employee_Id==empid && s.FiscalYear_Id==yearid && s.Period_Id==periodid && s.PeriodStartDate==PeriodStartDate && s.PeriodEndDate==PeriodEndDate)
                                .ToList();

            return records;
        }

		public WP_MobilityInternalTeam GetRecord(string Id)
		{
		    return context.WP_MobilityInternalTeam.Find(Id);
		}

		public WP_MobilityInternalTeam Update(WP_MobilityInternalTeam recChanges)
		{
		    var satype = context.WP_MobilityInternalTeam.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}