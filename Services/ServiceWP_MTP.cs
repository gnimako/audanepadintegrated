using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceWP_MTP:IWP_MTPRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceWP_MTP> logger;
		public ServiceWP_MTP (AppDbContext context, ILogger<ServiceWP_MTP> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public WP_MTP Add(WP_MTP rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.WP_MTP.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public WP_MTP Delete(string id)
		{
		    WP_MTP rec = context.WP_MTP.Find(id);
		    if (rec != null)
		    {
		        context.WP_MTP.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<WP_MTP> GetAllRecords()
		{
		    return context.WP_MTP;
		}
		public IEnumerable<WP_MTP> GetRecordsByProjectYearAndPeriod (int projectid, int year, int period)
        {
            var records = context.WP_MTP
                                .Where(s => s.Project_Id==projectid && s.FiscalYear_Id==year && s.Period_Id==period)
                                .ToList();

            return records;
        }
        public IEnumerable<WP_MTP> GetRecordsByMainRecordId (string recid)
        {
            var records = context.WP_MTP
                                .Where(s => s.WPMainRecord_id==recid)
                                .ToList();

            return records;
        }

		public WP_MTP  GetRecordsByProjectYearPeriodAndMTP (int projectid, int year, int period, int mtp)
        {
            var rec = context.WP_MTP
						.Where(s => s.Project_Id == projectid && s.FiscalYear_Id==year && s.Period_Id==period && s.MTP_Id==mtp)
						.FirstOrDefault();
            return rec;
        }

		public WP_MTP GetRecord(string Id)
		{
		    return context.WP_MTP.Find(Id);
		}


        public WP_MTP Update(WP_MTP recChanges)
		{
		    var satype = context.WP_MTP.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}