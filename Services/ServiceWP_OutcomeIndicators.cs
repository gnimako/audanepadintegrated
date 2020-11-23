using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceWP_OutcomeIndicators: IWP_OutcomeIndicatorsRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceWP_OutcomeIndicators> logger;
		public ServiceWP_OutcomeIndicators (AppDbContext context, ILogger<ServiceWP_OutcomeIndicators> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public WP_OutcomeIndicators Add(WP_OutcomeIndicators rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.WP_OutcomeIndicators.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public WP_OutcomeIndicators Delete(string id)
		{
		    WP_OutcomeIndicators rec = context.WP_OutcomeIndicators.Find(id);
		    if (rec != null)
		    {
		        context.WP_OutcomeIndicators.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<WP_OutcomeIndicators> GetAllRecords()
		{
		    return context.WP_OutcomeIndicators;
		}
        public IEnumerable<WP_OutcomeIndicators> GetRecordsByMainRecordId (string recid)
        {
            var records = context.WP_OutcomeIndicators
                                .Where(s => s.WPMainRecord_id==recid)
                                .ToList();

            return records;
        }
        public IEnumerable<WP_OutcomeIndicators> GetRecordsByMainRecordOutcomeId (string wpmainrecid, string outcomeid)
        {
            var records = context.WP_OutcomeIndicators
                                .Where(s => s.WPMainRecord_id==wpmainrecid && s.WPOutcome_Id==outcomeid)
                                .ToList();

            return records;
        }
		public IEnumerable<WP_OutcomeIndicators> GetRecordsByOutcomeId (string outcomeid)
        {
            var records = context.WP_OutcomeIndicators
                                .Where(s => s.WPOutcome_Id==outcomeid)
                                .ToList();

            return records;
        }
        public IEnumerable<WP_OutcomeIndicators> GetRecordsByProjectYearAndPeriod (int projectid, int year, int period)
        {
            var records = context.WP_OutcomeIndicators
                                .Where(s => s.Project_Id==projectid && s.FiscalYear_Id==year && s.Period_Id==period)
                                .ToList();

            return records;
        }

        public IEnumerable<WP_OutcomeIndicators>  GetRecordsByProjectYearPeriodAndOutcomeId (int projectid, int year, int period, string outcomeid)
        {
            var records = context.WP_OutcomeIndicators
                                .Where(s => s.Project_Id==projectid && s.FiscalYear_Id==year && s.Period_Id==period && s.WPOutcome_Id==outcomeid)
                                .ToList();

            return records;
        }

		public  WP_OutcomeIndicators GetRecordByProjectYearAndPeriodOutcomeIdIndicatorId (int projectid, int year, int period, string outcomeid, int indicatorid)
        {
            var rec = context.WP_OutcomeIndicators
						.Where(s => s.FiscalYear_Id == year && s.Period_Id == period && s.Project_Id==projectid && s.OutcomeIndicator_Id==indicatorid && s.WPOutcome_Id==outcomeid)
						.FirstOrDefault();
            return rec;
        }

		public  WP_OutcomeIndicators GetRecordByProjectYearAndPeriodOutcomeIdIndicatorId_Dir (int projectid, int year, int period, string outcomeid, int indicatorid)
        {
            var rec = context.WP_OutcomeIndicators
						.Where(s => s.FiscalYear_Id == year && s.Period_Id == period && s.Project_Id==projectid && s.OutcomeIndicator_Id==indicatorid && s.WPOutcome_Id==outcomeid && s.IndicatorCategory=="Directorate-Level")
						.FirstOrDefault();
            return rec;
        }



		public WP_OutcomeIndicators GetRecord(string Id)
		{
		    return context.WP_OutcomeIndicators.Find(Id);
		}


        public WP_OutcomeIndicators Update(WP_OutcomeIndicators recChanges)
		{
		    var satype = context.WP_OutcomeIndicators.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}

        
    }
}