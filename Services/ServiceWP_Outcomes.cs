using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;



namespace AUDANEPAD_Integrated.Services
{
    public class ServiceWP_Outcomes: IWP_OutcomesRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceWP_Outcomes> logger;
		public ServiceWP_Outcomes (AppDbContext context, ILogger<ServiceWP_Outcomes> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public WP_Outcomes Add(WP_Outcomes rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.WP_Outcomes.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public WP_Outcomes Delete(string id)
		{
		    WP_Outcomes rec = context.WP_Outcomes.Find(id);
		    if (rec != null)
		    {
		        context.WP_Outcomes.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<WP_Outcomes> GetAllRecords()
		{
		    return context.WP_Outcomes;
		}
        public IEnumerable<WP_Outcomes> GetRecordsByMainRecordId (string recid)
        {
            var records = context.WP_Outcomes
                                .Where(s => s.WPMainRecord_id==recid)
                                .ToList();

            return records;
        }
        public IEnumerable<WP_Outcomes> GetRecordsByProjectYearAndPeriod (int projectid, int year, int period)
        {
            var records = context.WP_Outcomes
                                .Where(s => s.Project_Id==projectid && s.FiscalYear_Id==year && s.Period_Id==period)
                                .ToList();

            return records;
        }


		public WP_Outcomes GetRecord(string Id)
		{
		    return context.WP_Outcomes.Find(Id);
		}
		public WP_Outcomes GetRecordByOutcomeStatement (string outcome)
        {
            var rec = context.WP_Outcomes
						.Where(s => s.Outcome == outcome)
						.FirstOrDefault();
            return rec;
        }

        public WP_Outcomes Update(WP_Outcomes recChanges)
		{
		    var satype = context.WP_Outcomes.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}