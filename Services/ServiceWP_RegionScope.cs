using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceWP_RegionScope: IWP_RegionScopeRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceWP_RegionScope> logger;
		public ServiceWP_RegionScope (AppDbContext context, ILogger<ServiceWP_RegionScope> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public WP_RegionScope Add(WP_RegionScope rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.WP_RegionScope.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public WP_RegionScope Delete(string id)
		{
		    WP_RegionScope rec = context.WP_RegionScope.Find(id);
		    if (rec != null)
		    {
		        context.WP_RegionScope.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<WP_RegionScope> GetAllRecords()
		{
		    return context.WP_RegionScope;
		}
		public IEnumerable<WP_RegionScope> GetRecordsByProjectYearAndPeriod (int projectid, int year, int period)
        {
            var records = context.WP_RegionScope
                                .Where(s => s.Project_Id==projectid && s.FiscalYear_Id==year && s.Period_Id==period)
                                .ToList();

            return records;
        }
		public IEnumerable<WP_RegionScope> GetRecordsByProjectYearPeriodAndMainRecId (int projectid, int year, int period, string mainrecid)
        {
            var records = context.WP_RegionScope
                                .Where(s => s.Project_Id==projectid && s.FiscalYear_Id==year && s.Period_Id==period && s.WPMainRecord_id==mainrecid)
                                .ToList();

            return records;
        }
        public IEnumerable<WP_RegionScope> GetRecordsByMainRecordId (string recid)
        {
            var records = context.WP_RegionScope
                                .Where(s => s.WPMainRecord_id==recid)
                                .ToList();

            return records;
        }

		public WP_RegionScope  GetRecordsByProjectYearPeriodAndRegion (int projectid, int year, int period, int region)
        {
            var rec = context.WP_RegionScope
						.Where(s => s.Project_Id == projectid && s.FiscalYear_Id==year && s.Period_Id==period && s.Region_Id==region)
						.FirstOrDefault();
            return rec;
        }

		public WP_RegionScope GetRecord(string Id)
		{
		    return context.WP_RegionScope.Find(Id);
		}


        public WP_RegionScope Update(WP_RegionScope recChanges)
		{
		    var satype = context.WP_RegionScope.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}