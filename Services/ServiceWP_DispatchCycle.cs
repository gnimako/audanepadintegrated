using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using NodaTime;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceWP_DispatchCycle: IWP_DispatchCycleRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceWP_DispatchCycle> logger;
		public ServiceWP_DispatchCycle(AppDbContext context, ILogger<ServiceWP_DispatchCycle> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public WP_DispatchCycle Add(WP_DispatchCycle rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.WP_DispatchCycle.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public WP_DispatchCycle Delete(string id)
		{
		    WP_DispatchCycle rec = context.WP_DispatchCycle.Find(id);
		    if (rec != null)
		    {
		        context.WP_DispatchCycle.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<WP_DispatchCycle> GetAllRecords()
		{
		    return context.WP_DispatchCycle;
		}

        public IEnumerable<WP_DispatchCycle> GetAllCurrentAndInactiveWPDispatch()
        {
            var records = context.WP_DispatchCycle
                                .Where(s => s.Dispatch_Status.Value == true || s.Dispatch_Status==null)
                                .ToList();

            return records;
        }

		public IEnumerable<WP_DispatchCycle> GetAllCurrentWPDispatch()
        {
            var records = context.WP_DispatchCycle
                                .Where(s => s.Dispatch_Status.Value == true)
                                .ToList();

            return records;
        }

		public IEnumerable<WP_DispatchCycle> GetAllClosedWPDispatch()
        {
            var records = context.WP_DispatchCycle
                                .Where(s => s.Dispatch_Status.Value == false)
                                .ToList();

            return records;
        }
		public IEnumerable<WP_DispatchCycle> GetAllCurrentWPDispatchByYear(int year)
        {
            var records = context.WP_DispatchCycle
                                .Where(s => s.Dispatch_Status.Value == true && s.FiscalYear_Id==year)
                                .ToList();

            return records;
        }
		public IEnumerable<WP_DispatchCycle> GetRecordsByYearAndPeriodRecs (int year, int period)
        {
            var records = context.WP_DispatchCycle
                                .Where(s => s.Period_Id==period && s.FiscalYear_Id==year)
                                .ToList();

            return records;
        }

		public WP_DispatchCycle GetRecord(string Id)
		{
		    return context.WP_DispatchCycle.Find(Id);
		}
		public WP_DispatchCycle GetRecordByYearAndPeriod (int year, int period)
        {
            var rec = context.WP_DispatchCycle
						.Where(s => s.FiscalYear_Id == year && s.Period_Id == period)
						.FirstOrDefault();
            return rec;
        }

		public WP_DispatchCycle GetRecordByYearPStartPEnd (int year, LocalDate pstart, LocalDate pend)
        {
            var rec = context.WP_DispatchCycle
						.Where(s => s.FiscalYear_Id == year && s.PeriodStartDate == pstart && s.PeriodEndDate==pend)
						.FirstOrDefault();
            return rec;
        }

		public WP_DispatchCycle Update(WP_DispatchCycle recChanges)
		{
		    var satype = context.WP_DispatchCycle.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}


    }
}