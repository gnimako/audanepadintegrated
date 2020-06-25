using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceWP_ApprovalStatus: IWP_ApprovalStatusRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceWP_ApprovalStatus> logger;
		public ServiceWP_ApprovalStatus (AppDbContext context, ILogger<ServiceWP_ApprovalStatus> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public WP_ApprovalStatus Add(WP_ApprovalStatus rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.WP_ApprovalStatus.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public WP_ApprovalStatus Delete(string id)
		{
		    WP_ApprovalStatus rec = context.WP_ApprovalStatus.Find(id);
		    if (rec != null)
		    {
		        context.WP_ApprovalStatus.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<WP_ApprovalStatus> GetAllRecords()
		{
		    return context.WP_ApprovalStatus;
		}
		public IEnumerable<WP_ApprovalStatus> GetRecordsByProjectYearAndPeriod (int projectid, int year, int period)
        {
            var records = context.WP_ApprovalStatus
                                .Where(s => s.Project_Id==projectid && s.FiscalYear_Id==year && s.Period_Id==period)
                                .ToList();

            return records;
        }
        public IEnumerable<WP_ApprovalStatus> GetRecordsByMainRecordId (string recid)
        {
            var records = context.WP_ApprovalStatus
                                .Where(s => s.WPMainRecord_id==recid)
                                .ToList();

            return records;
        }

		public WP_ApprovalStatus GetRecord(string Id)
		{
		    return context.WP_ApprovalStatus.Find(Id);
		}


        public WP_ApprovalStatus Update(WP_ApprovalStatus recChanges)
		{
		    var satype = context.WP_ApprovalStatus.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}