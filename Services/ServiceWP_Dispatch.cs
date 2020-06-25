using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceWP_Dispatch: IWP_DispatchRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceWP_Dispatch> logger;
		public ServiceWP_Dispatch(AppDbContext context, ILogger<ServiceWP_Dispatch> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public WP_Dispatch Add(WP_Dispatch rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.WP_Dispatch.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public WP_Dispatch Delete(string id)
		{
		    WP_Dispatch rec = context.WP_Dispatch.Find(id);
		    if (rec != null)
		    {
		        context.WP_Dispatch.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<WP_Dispatch> GetAllRecords()
		{
		    return context.WP_Dispatch;
		}

        public IEnumerable<WP_Dispatch> GetAllCurrentAndInactiveWPDispatch()
        {
            var records = context.WP_Dispatch
                                .Where(s => s.Dispatch_Status.Value == true || s.Dispatch_Status==null)
                                .ToList();

            return records;
        }

		public IEnumerable<WP_Dispatch> GetAllCurrentWPDispatch()
        {
            var records = context.WP_Dispatch
                                .Where(s => s.Dispatch_Status.Value == true)
                                .ToList();

            return records;
        }

		public IEnumerable<WP_Dispatch> GetAllClosedWPDispatch()
        {
            var records = context.WP_Dispatch
                                .Where(s => s.Dispatch_Status.Value == false)
                                .ToList();

            return records;
        }
		public IEnumerable<WP_Dispatch> GetAllCurrentWPDispatchByYear(int year)
        {
            var records = context.WP_Dispatch
                                .Where(s => s.Dispatch_Status.Value == true && s.FiscalYear_Id==year)
                                .ToList();

            return records;
        }

		public WP_Dispatch GetRecord(string Id)
		{
		    return context.WP_Dispatch.Find(Id);
		}
		public WP_Dispatch GetRecordByYearAndPeriod (int year, int period)
        {
            var rec = context.WP_Dispatch
						.Where(s => s.FiscalYear_Id == year && s.Period_Id == period)
						.FirstOrDefault();
            return rec;
        }

		public WP_Dispatch Update(WP_Dispatch recChanges)
		{
		    var satype = context.WP_Dispatch.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}