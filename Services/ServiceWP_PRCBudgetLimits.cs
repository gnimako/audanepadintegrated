using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using NodaTime;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceWP_PRCBudgetLimits: IWP_PRCBudgetLimitsRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceWP_PRCBudgetLimits> logger;
		public ServiceWP_PRCBudgetLimits(AppDbContext context, ILogger<ServiceWP_PRCBudgetLimits> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public WP_PRCBudgetLimits Add(WP_PRCBudgetLimits rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.WP_PRCBudgetLimits.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public WP_PRCBudgetLimits Delete(string id)
		{
		    WP_PRCBudgetLimits rec = context.WP_PRCBudgetLimits.Find(id);
		    if (rec != null)
		    {
		        context.WP_PRCBudgetLimits.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<WP_PRCBudgetLimits> GetAllRecords()
		{
		    return context.WP_PRCBudgetLimits;
		}
		public IEnumerable<WP_PRCBudgetLimits>  GetRecordsByWPCycle (string wpcycleid)
        {
            var records = context.WP_PRCBudgetLimits
                                .Where(s => s.WPCycle_id==wpcycleid)
                                .ToList();

            return records;
        }
		public WP_PRCBudgetLimits  GetRecordByDirectorateAndCycle (int dirid, string cycleid)
        {
            var rec = context.WP_PRCBudgetLimits
						.Where(s => s.Directorate_Id == dirid && s.WPCycle_id ==cycleid )
						.FirstOrDefault();
            return rec;
        }

		public WP_PRCBudgetLimits  GetRecordByDirectorateearPeriod (int dirid, int yearid, int periodid)
        {
            var rec = context.WP_PRCBudgetLimits
						.Where(s => s.Directorate_Id == dirid && s.FiscalYear_Id ==yearid && s.Period_Id==periodid)
						.FirstOrDefault();
            return rec;
        }

		public WP_PRCBudgetLimits  GetRecordByDirectorateYearPeriodStartEnd (int dirid, int yearid, int periodid, LocalDate PeriodStartDate, LocalDate PeriodEndDate)
        {
            var rec = context.WP_PRCBudgetLimits
						.Where(s => s.Directorate_Id == dirid && s.FiscalYear_Id ==yearid && s.Period_Id==periodid && s.PeriodStartDate==PeriodStartDate && s.PeriodEndDate==PeriodEndDate)
						.FirstOrDefault();
            return rec;
        }


		public WP_PRCBudgetLimits GetRecord(string Id)
		{
		    return context.WP_PRCBudgetLimits.Find(Id);
		}

		public WP_PRCBudgetLimits Update(WP_PRCBudgetLimits recChanges)
		{
		    var satype = context.WP_PRCBudgetLimits.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}