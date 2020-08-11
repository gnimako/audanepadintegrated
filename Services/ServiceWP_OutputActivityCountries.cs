using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceWP_OutputActivityCountries: IWP_OutputActivityCountriesRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceWP_OutputActivityCountries> logger;
		public ServiceWP_OutputActivityCountries (AppDbContext context, ILogger<ServiceWP_OutputActivityCountries> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public WP_OutputActivityCountries Add(WP_OutputActivityCountries rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.WP_OutputActivityCountries.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public WP_OutputActivityCountries Delete(string id)
		{
		    WP_OutputActivityCountries rec = context.WP_OutputActivityCountries.Find(id);
		    if (rec != null)
		    {
		        context.WP_OutputActivityCountries.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<WP_OutputActivityCountries> GetAllRecords()
		{
		    return context.WP_OutputActivityCountries;
		}
        public IEnumerable<WP_OutputActivityCountries> GetRecordsByMainRecordId (string recid)
        {
            var records = context.WP_OutputActivityCountries
                                .Where(s => s.WPMainRecord_id==recid)
                                .ToList();

            return records;
        }
        public IEnumerable<WP_OutputActivityCountries> GetRecordsByMainRecordOutputId (string wpmainrecid, string outputid)
        {
            var records = context.WP_OutputActivityCountries
                                .Where(s => s.WPMainRecord_id==wpmainrecid && s.WPOutput_Id==outputid)
                                .ToList();

            return records;
        }
		public IEnumerable<WP_OutputActivityCountries> GetRecordsByOutputId (string outputid)
        {
            var records = context.WP_OutputActivityCountries
                                .Where(s => s.WPOutput_Id==outputid)
                                .ToList();

            return records;
        }
        public IEnumerable<WP_OutputActivityCountries> GetRecordsByProjectYearAndPeriod (int projectid, int year, int period)
        {
            var records = context.WP_OutputActivityCountries
                                .Where(s => s.Project_Id==projectid && s.FiscalYear_Id==year && s.Period_Id==period)
                                .ToList();

            return records;
        }

        public IEnumerable<WP_OutputActivityCountries>  GetRecordsByProjectYearPeriodOutputIdAndActivityId (int projectid, int year, int period, string outputid, string activityid)
        {
            var records = context.WP_OutputActivityCountries
                                .Where(s => s.Project_Id==projectid && s.FiscalYear_Id==year && s.Period_Id==period && s.WPOutput_Id==outputid && s.WPOutputActivity_Id==activityid)
                                .ToList();

            return records;
        }






		public WP_OutputActivityCountries GetRecord(string Id)
		{
		    return context.WP_OutputActivityCountries.Find(Id);
		}


        public WP_OutputActivityCountries Update(WP_OutputActivityCountries recChanges)
		{
		    var satype = context.WP_OutputActivityCountries.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}