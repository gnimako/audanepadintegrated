using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceWP_OutputBudget: IWP_OutputBudgetRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceWP_OutputBudget> logger;
		public ServiceWP_OutputBudget (AppDbContext context, ILogger<ServiceWP_OutputBudget> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public WP_OutputBudget Add(WP_OutputBudget rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.WP_OutputBudget.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public WP_OutputBudget Delete(string id)
		{
		    WP_OutputBudget rec = context.WP_OutputBudget.Find(id);
		    if (rec != null)
		    {
		        context.WP_OutputBudget.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<WP_OutputBudget> GetAllRecords()
		{
		    return context.WP_OutputBudget;
		}
        public IEnumerable<WP_OutputBudget> GetRecordsByMainRecordId (string recid)
        {
            var records = context.WP_OutputBudget
                                .Where(s => s.WPMainRecord_id==recid)
                                .ToList();

            return records;
        }
        public IEnumerable<WP_OutputBudget> GetRecordsByMainRecordOutputId (string wpmainrecid, string outputid)
        {
            var records = context.WP_OutputBudget
                                .Where(s => s.WPMainRecord_id==wpmainrecid && s.WPOutput_Id==outputid)
                                .ToList();

            return records;
        }
		public IEnumerable<WP_OutputBudget> GetRecordsByOutputId (string outputid)
        {
            var records = context.WP_OutputBudget
                                .Where(s => s.WPOutput_Id==outputid)
                                .ToList();

            return records;
        }
        public IEnumerable<WP_OutputBudget> GetRecordsByProjectYearAndPeriod (int projectid, int year, int period)
        {
            var records = context.WP_OutputBudget
                                .Where(s => s.Project_Id==projectid && s.FiscalYear_Id==year && s.Period_Id==period)
                                .ToList();

            return records;
        }

        public WP_OutputBudget  GetRecordsByProjectYearPeriodAndOutputId (int projectid, int year, int period, string outputid)
        {
            var record = context.WP_OutputBudget
                                .Where(s => s.Project_Id==projectid && s.FiscalYear_Id==year && s.Period_Id==period && s.WPOutput_Id==outputid)
                               .FirstOrDefault();

            return record;
        }
        public WP_OutputBudget  GetRecordByOutputId (string outputid)
        {
            var record = context.WP_OutputBudget
                                .Where(s => s.WPOutput_Id==outputid)
                               .FirstOrDefault();

            return record;
        }
        public IEnumerable<WP_OutputBudget>  GetRecordsBySAPLinkId (string saplinkid)
        {
            var records = context.WP_OutputBudget
                                .Where(s => s.WPSAPLink_Id==saplinkid)
                                .ToList();

            return records;
        }

		public  WP_OutputBudget GetRecordByProjectYearAndPeriodOutputSAPLinkId (int projectid, int year, int period, string outputid, string saplinkid)
        {
            var rec = context.WP_OutputBudget
						.Where(s => s.FiscalYear_Id == year && s.Period_Id == period && s.Project_Id==projectid && s.WPSAPLink_Id==saplinkid && s.WPOutput_Id==outputid)
						.FirstOrDefault();
            return rec;
        }




		public WP_OutputBudget GetRecord(string Id)
		{
		    return context.WP_OutputBudget.Find(Id);
		}


        public WP_OutputBudget Update(WP_OutputBudget recChanges)
		{
		    var satype = context.WP_OutputBudget.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}