using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceWP_AUDAPriority: IWP_AUDAPriorityRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceWP_AUDAPriority> logger;
		public ServiceWP_AUDAPriority (AppDbContext context, ILogger<ServiceWP_AUDAPriority> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public WP_AUDAPriority Add(WP_AUDAPriority rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.WP_AUDAPriority.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public WP_AUDAPriority Delete(string id)
		{
		    WP_AUDAPriority rec = context.WP_AUDAPriority.Find(id);
		    if (rec != null)
		    {
		        context.WP_AUDAPriority.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<WP_AUDAPriority> GetAllRecords()
		{
		    return context.WP_AUDAPriority;
		}
        public IEnumerable<WP_AUDAPriority> GetRecordsByMainRecordId (string recid)
        {
            var records = context.WP_AUDAPriority
                                .Where(s => s.WPMainRecord_id==recid)
                                .ToList();

            return records;
        }
		public IEnumerable<WP_AUDAPriority>  GetRecordsByProjectYearAndPeriod (int projectid, int year, int period)
        {
            var records = context.WP_AUDAPriority
                                .Where(s => s.Project_Id==projectid && s.FiscalYear_Id==year && s.Period_Id==period)
                                .ToList();

            return records;
        }
		public IEnumerable<WP_AUDAPriority>  GetRecordsByProjectYearPeriodAndMainRecId (int projectid, int year, int period, string mainrecid)
        {
            var records = context.WP_AUDAPriority
                                .Where(s => s.Project_Id==projectid && s.FiscalYear_Id==year && s.Period_Id==period && s.WPMainRecord_id==mainrecid)
                                .ToList();

            return records;
        }

		public WP_AUDAPriority  GetRecordsByProjectYearPeriodAndPriority (int projectid, int year, int period, int priority)
        {
            var rec = context.WP_AUDAPriority
						.Where(s => s.Project_Id == projectid && s.FiscalYear_Id==year && s.Period_Id==period && s.Priority_Id==priority)
						.FirstOrDefault();
            return rec;
        }

		public WP_AUDAPriority  GetRecordsByProjectYearPeriodPriorityMainRecId (int projectid, int year, int period, int priority, string mainrecid)
        {
            var rec = context.WP_AUDAPriority
						.Where(s => s.Project_Id == projectid && s.FiscalYear_Id==year && s.Period_Id==period && s.Priority_Id==priority && s.WPMainRecord_id==mainrecid)
						.FirstOrDefault();
            return rec;
        }
		public WP_AUDAPriority GetRecord(string Id)
		{
		    return context.WP_AUDAPriority.Find(Id);
		}


        public WP_AUDAPriority Update(WP_AUDAPriority recChanges)
		{
		    var satype = context.WP_AUDAPriority.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}