
using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;



namespace AUDANEPAD_Integrated.Services
{
    public class ServiceWP_RiskProfileCountries: IWP_RiskProfileCountriesRepository
    {

        private readonly AppDbContext context;
		private readonly ILogger<ServiceWP_RiskProfileCountries> logger;
		public ServiceWP_RiskProfileCountries(AppDbContext context, ILogger<ServiceWP_RiskProfileCountries> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public WP_RiskProfileCountries Add(WP_RiskProfileCountries rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.WP_RiskProfileCountries.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public WP_RiskProfileCountries Delete(string id)
		{
		    WP_RiskProfileCountries rec = context.WP_RiskProfileCountries.Find(id);
		    if (rec != null)
		    {
		        context.WP_RiskProfileCountries.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<WP_RiskProfileCountries> GetAllRecords()
		{
		    return context.WP_RiskProfileCountries;
		}
		public IEnumerable<WP_RiskProfileCountries> GetRecordsByOutputId (string outputid)
        {
            var records = context.WP_RiskProfileCountries
                                .Where(s => s.WPOutput_Id==outputid)
                                .ToList();

            return records;
        }

		public IEnumerable<WP_RiskProfileCountries> GetRecordsByRiskId (string riskid)
        {
            var records = context.WP_RiskProfileCountries
                                .Where(s => s.WPRisk_id==riskid)
                                .ToList();

            return records;
        }
        public IEnumerable<WP_RiskProfileCountries> GetRecordsByOutputIdAndRiskId (string outputid, string riskid)
        {
            var records = context.WP_RiskProfileCountries
                                .Where(s => s.WPOutput_Id==outputid && s.WPRisk_id==riskid)
                                .ToList();

            return records;
        }

		public WP_RiskProfileCountries GetRecord(string Id)
		{
		    return context.WP_RiskProfileCountries.Find(Id);
		}

		public WP_RiskProfileCountries Update(WP_RiskProfileCountries recChanges)
		{
		    var satype = context.WP_RiskProfileCountries.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}