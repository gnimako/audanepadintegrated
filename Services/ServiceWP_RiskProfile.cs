
using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceWP_RiskProfile: IWP_RiskProfileRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceWP_RiskProfile> logger;
		public ServiceWP_RiskProfile(AppDbContext context, ILogger<ServiceWP_RiskProfile> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public WP_RiskProfile Add(WP_RiskProfile rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.WP_RiskProfile.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public WP_RiskProfile Delete(string id)
		{
		    WP_RiskProfile rec = context.WP_RiskProfile.Find(id);
		    if (rec != null)
		    {
		        context.WP_RiskProfile.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<WP_RiskProfile> GetAllRecords()
		{
		    return context.WP_RiskProfile;
		}
        public IEnumerable<WP_RiskProfile> GetRecordsByMainRecordId (string recid)
        {
            var records = context.WP_RiskProfile
                                .Where(s => s.WPMainRecord_id==recid)
                                .ToList();

            return records;
        }
		public IEnumerable<WP_RiskProfile> GetRecordsByMainRecordOutputId (string wpmainrecid, string outputid)
        {
            var records = context.WP_RiskProfile
                                .Where(s => s.WPMainRecord_id==wpmainrecid && s.WPOutput_Id==outputid)
                                .ToList();

            return records;
        }
		public IEnumerable<WP_RiskProfile> GetRecordsByOutputId (string outputid)
        {
            var records = context.WP_RiskProfile
                                .Where(s => s.WPOutput_Id==outputid)
                                .ToList();

            return records;
        }

		public WP_RiskProfile GetRecord(string Id)
		{
		    return context.WP_RiskProfile.Find(Id);
		}

		public WP_RiskProfile Update(WP_RiskProfile recChanges)
		{
		    var satype = context.WP_RiskProfile.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}