using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceWP_OutputIndicators: IWP_OutputIndicatorsRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceWP_OutputIndicators> logger;
		public ServiceWP_OutputIndicators (AppDbContext context, ILogger<ServiceWP_OutputIndicators> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public WP_OutputIndicators Add(WP_OutputIndicators rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.WP_OutputIndicators.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public WP_OutputIndicators Delete(string id)
		{
		    WP_OutputIndicators rec = context.WP_OutputIndicators.Find(id);
		    if (rec != null)
		    {
		        context.WP_OutputIndicators.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<WP_OutputIndicators> GetAllRecords()
		{
		    return context.WP_OutputIndicators;
		}
        public IEnumerable<WP_OutputIndicators> GetRecordsByMainRecordId (string recid)
        {
            var records = context.WP_OutputIndicators
                                .Where(s => s.WPMainRecord_id==recid)
                                .ToList();

            return records;
        }
        public IEnumerable<WP_OutputIndicators> GetRecordsByMainRecordOutputId (string wpmainrecid, string outputid)
        {
            var records = context.WP_OutputIndicators
                                .Where(s => s.WPMainRecord_id==wpmainrecid && s.WPOutput_Id==outputid)
                                .ToList();

            return records;
        }
		public IEnumerable<WP_OutputIndicators> GetRecordsByOutputId (string outputid)
        {
            var records = context.WP_OutputIndicators
                                .Where(s => s.WPOutput_Id==outputid)
                                .ToList();

            return records;
        }
        public IEnumerable<WP_OutputIndicators> GetRecordsByProjectYearAndPeriod (int projectid, int year, int period)
        {
            var records = context.WP_OutputIndicators
                                .Where(s => s.Project_Id==projectid && s.FiscalYear_Id==year && s.Period_Id==period)
                                .ToList();

            return records;
        }

        public IEnumerable<WP_OutputIndicators>  GetRecordsByProjectYearPeriodAndOutputId (int projectid, int year, int period, string outputid)
        {
            var records = context.WP_OutputIndicators
                                .Where(s => s.Project_Id==projectid && s.FiscalYear_Id==year && s.Period_Id==period && s.WPOutput_Id==outputid)
                                .ToList();

            return records;
        }

		public  WP_OutputIndicators GetRecordByProjectYearAndPeriodOutputIdIndicatorId (int projectid, int year, int period, string outputid, int indicatorid)
        {
            var rec = context.WP_OutputIndicators
						.Where(s => s.FiscalYear_Id == year && s.Period_Id == period && s.Project_Id==projectid && s.OutputIndicator_Id==indicatorid && s.WPOutput_Id==outputid)
						.FirstOrDefault();
            return rec;
        }




		public WP_OutputIndicators GetRecord(string Id)
		{
		    return context.WP_OutputIndicators.Find(Id);
		}


        public WP_OutputIndicators Update(WP_OutputIndicators recChanges)
		{
		    var satype = context.WP_OutputIndicators.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}