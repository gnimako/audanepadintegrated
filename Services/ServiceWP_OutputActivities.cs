using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceWP_OutputActivities: IWP_OutputActivitiesRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceWP_OutputActivities> logger;
		public ServiceWP_OutputActivities (AppDbContext context, ILogger<ServiceWP_OutputActivities> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public WP_OutputActivities Add(WP_OutputActivities rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.WP_OutputActivities.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public WP_OutputActivities Delete(string id)
		{
		    WP_OutputActivities rec = context.WP_OutputActivities.Find(id);
		    if (rec != null)
		    {
		        context.WP_OutputActivities.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<WP_OutputActivities> GetAllRecords()
		{
		    return context.WP_OutputActivities;
		}
        public IEnumerable<WP_OutputActivities> GetRecordsByMainRecordId (string recid)
        {
            var records = context.WP_OutputActivities
                                .Where(s => s.WPMainRecord_id==recid)
                                .ToList();

            return records;
        }
        public IEnumerable<WP_OutputActivities> GetRecordsByMainRecordIdMS (string recid)
        {
            var records = context.WP_OutputActivities
                                .Where(s => s.WPMainRecord_id==recid && s.PartnerFunding==true)
                                .ToList();

            return records;
        }
        public IEnumerable<WP_OutputActivities> GetRecordsByMainRecordOutputId (string wpmainrecid, string outputid)
        {
            var records = context.WP_OutputActivities
                                .Where(s => s.WPMainRecord_id==wpmainrecid && s.WPOutput_Id==outputid)
                                .ToList();

            return records;
        }
        public IEnumerable<WP_OutputActivities> GetRecordsByMainRecordImpType (string wpmainrecid, int implementationtypeid)
        {
            var records = context.WP_OutputActivities
                                .Where(s => s.WPMainRecord_id==wpmainrecid && s.ImplementationType_Id==implementationtypeid)
                                .ToList();

            return records;
        }
        public IEnumerable<WP_OutputActivities> GetRecordsByMainRecIDYearAndWithinMonth(string wpmainrecid, int year, int month)
        {
            var records = context.WP_OutputActivities
                                .Where(s => s.WPMainRecord_id==wpmainrecid)//&& s.WPOutput_Id==outputid)
                                .ToList();

            return records;
        }
        public bool WithinMonth(int year, int month, DateTime start, DateTime end)
        {
            DateTime monthstart=new DateTime(year, month, 1);
            DateTime monthend=new DateTime(year, month, DateTime.DaysInMonth(year, month));

            return start >= monthstart && end <= monthend;
        }

		public IEnumerable<WP_OutputActivities> GetRecordsByOutputId (string outputid)
        {
            var records = context.WP_OutputActivities
                                .Where(s => s.WPOutput_Id==outputid)
                                .ToList();

            return records;
        }

        public IEnumerable<WP_OutputActivities> GetRecordsByWPSAPLink_Id (string saplinkid)
        {
            var records = context.WP_OutputActivities
                                .Where(s => s.WPSAPLink_Id==saplinkid)
                                .ToList();

            return records;
        }
        public IEnumerable<WP_OutputActivities> GetRecordsByProjectYearAndPeriod (int projectid, int year, int period)
        {
            var records = context.WP_OutputActivities
                                .Where(s => s.Project_Id==projectid && s.FiscalYear_Id==year && s.Period_Id==period)
                                .ToList();

            return records;
        }

        public IEnumerable<WP_OutputActivities>  GetRecordsByProjectYearPeriodAndOutputId (int projectid, int year, int period, string outputid)
        {
            var records = context.WP_OutputActivities
                                .Where(s => s.Project_Id==projectid && s.FiscalYear_Id==year && s.Period_Id==period && s.WPOutput_Id==outputid)
                                .ToList();

            return records;
        }

        public WP_OutputActivities  GetRecordsByProjectYearPeriodOutputIdActivityTypeAndDescr (int projectid, int year, int period, string outputid, int activitytype, string activitydescr)
        {
            var record = context.WP_OutputActivities
                                .Where(s => s.Project_Id==projectid && s.FiscalYear_Id==year && s.Period_Id==period && s.WPOutput_Id==outputid && s.ActivityType_Id==activitytype && s.ActivityDescription==activitydescr)
                                .FirstOrDefault();

            return record;
        }





		public WP_OutputActivities GetRecord(string Id)
		{
		    return context.WP_OutputActivities.Find(Id);
		}


        public WP_OutputActivities Update(WP_OutputActivities recChanges)
		{
		    var satype = context.WP_OutputActivities.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}