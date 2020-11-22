using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using NodaTime;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceWP_MobilityLimit: IWP_MobilityLimitRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceWP_MobilityLimit> logger;

		public ServiceWP_MobilityLimit(AppDbContext context, ILogger<ServiceWP_MobilityLimit> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public WP_MobilityLimit Add(WP_MobilityLimit rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.WP_MobilityLimit.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public WP_MobilityLimit Delete(string id)
		{
		    WP_MobilityLimit rec = context.WP_MobilityLimit.Find(id);
		    if (rec != null)
		    {
		        context.WP_MobilityLimit.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<WP_MobilityLimit> GetAllRecords()
		{
		    return context.WP_MobilityLimit;
		}
        public IEnumerable<WP_MobilityLimit>  GetRecordsByWPCycle (string wpcycleid)
        {
            var records = context.WP_MobilityLimit
                                .Where(s => s.WPCycle_id==wpcycleid)
                                .ToList();

            return records;
        }
		public WP_MobilityLimit  GetRecordByEmployeeAndCycle (int empid, string cycleid)
        {
            var rec = context.WP_MobilityLimit
						.Where(s => s.Employee_Id == empid && s.WPCycle_id ==cycleid )
						.FirstOrDefault();
            return rec;
        }

		public WP_MobilityLimit  GetRecordByEmployeeYearPeriod (int empid, int yearid, int periodid)
        {
            var rec = context.WP_MobilityLimit
						.Where(s => s.Employee_Id == empid && s.FiscalYear_Id ==yearid && s.Period_Id==periodid)
						.FirstOrDefault();
            return rec;
        }

		public WP_MobilityLimit   GetRecordByEmployeeYearPeriodStartEnd (int empid, int yearid, int periodid, LocalDate PeriodStartDate, LocalDate PeriodEndDate)
        {
            var rec = context.WP_MobilityLimit
						.Where(s => s.Employee_Id == empid && s.FiscalYear_Id ==yearid && s.Period_Id==periodid && s.PeriodStartDate==PeriodStartDate && s.PeriodEndDate==PeriodEndDate)
						.FirstOrDefault();
            return rec;
        }

		public WP_MobilityLimit GetRecord(string Id)
		{
		    return context.WP_MobilityLimit.Find(Id);
		}

		public WP_MobilityLimit Update(WP_MobilityLimit recChanges)
		{
		    var satype = context.WP_MobilityLimit.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}