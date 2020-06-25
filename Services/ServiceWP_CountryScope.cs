using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceWP_CountryScope: IWP_CountryScopeRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceWP_CountryScope> logger;
		public ServiceWP_CountryScope (AppDbContext context, ILogger<ServiceWP_CountryScope> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public WP_CountryScope Add(WP_CountryScope rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.WP_CountryScope.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public WP_CountryScope Delete(string id)
		{
		    WP_CountryScope rec = context.WP_CountryScope.Find(id);
		    if (rec != null)
		    {
		        context.WP_CountryScope.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<WP_CountryScope> GetAllRecords()
		{
		    return context.WP_CountryScope;
		}
		public IEnumerable<WP_CountryScope> GetRecordsByProjectYearAndPeriod (int projectid, int year, int period)
        {
            var records = context.WP_CountryScope
                                .Where(s => s.Project_Id==projectid && s.FiscalYear_Id==year && s.Period_Id==period)
                                .ToList();

            return records;
        }
        public IEnumerable<WP_CountryScope> GetRecordsByMainRecordId (string recid)
        {
            var records = context.WP_CountryScope
                                .Where(s => s.WPMainRecord_id==recid)
                                .ToList();

            return records;
        }

		public WP_CountryScope  GetRecordsByProjectYearPeriodAndCountry (int projectid, int year, int period, int country)
        {
            var rec = context.WP_CountryScope
						.Where(s => s.Project_Id == projectid && s.FiscalYear_Id==year && s.Period_Id==period && s.Country_Id==country)
						.FirstOrDefault();
            return rec;
        }

		public WP_CountryScope GetRecord(string Id)
		{
		    return context.WP_CountryScope.Find(Id);
		}


        public WP_CountryScope Update(WP_CountryScope recChanges)
		{
		    var satype = context.WP_CountryScope.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}