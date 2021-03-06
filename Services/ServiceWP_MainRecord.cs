using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using NodaTime;



namespace AUDANEPAD_Integrated.Services
{
    public class ServiceWP_MainRecord: IWP_MainRecordRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceWP_MainRecord> logger;
		public ServiceWP_MainRecord(AppDbContext context, ILogger<ServiceWP_MainRecord> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public WP_MainRecord Add(WP_MainRecord rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.WP_MainRecord.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public WP_MainRecord Delete(string id)
		{
		    WP_MainRecord rec = context.WP_MainRecord.Find(id);
		    if (rec != null)
		    {
		        context.WP_MainRecord.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<WP_MainRecord> GetAllRecords()
		{
		    return context.WP_MainRecord;
		}


		public WP_MainRecord GetRecord(string Id)
		{
		    return context.WP_MainRecord.Find(Id);
		}
		public IEnumerable<WP_MainRecord>  GetRecordsByYearAndPeriod (int year, int period)
        {
            var rec = context.WP_MainRecord
						.Where(s => s.FiscalYear_Id == year && s.Period_Id == period)
						.ToList();
            return rec;
        }
		public IEnumerable<WP_MainRecord>  GetRecordsByDivisionYearAndPeriod (int div, int year, int period)
        {
            var rec = context.WP_MainRecord
						.Where(s => s.Division_Id==div && s.FiscalYear_Id == year && s.Period_Id == period)
						.ToList();
            return rec;
        }

		public IEnumerable<WP_MainRecord>  GetRecordsByDirectorateYearAndPeriod (int dir, int year, int period)
        {
            var rec = context.WP_MainRecord
						.Where(s => s.Directorate_Id==dir && s.FiscalYear_Id == year && s.Period_Id == period)
						.ToList();
            return rec;
        }

		public IEnumerable<WP_MainRecord> GetRecordsByDivisionYearAndPeriodStartEnd (int div, int year, int period, LocalDate PeriodStartDate, LocalDate PeriodEndDate)
        {
            var rec = context.WP_MainRecord
						.Where(s => s.Division_Id==div && s.FiscalYear_Id == year && s.Period_Id == period && s.PeriodStartDate==PeriodStartDate && s.PeriodEndDate==PeriodEndDate)
						.ToList();
            return rec;
        }

		public IEnumerable<WP_MainRecord> GetRecordsByDirectorateYearAndPeriodStartEnd (int dir, int year, int period, LocalDate PeriodStartDate, LocalDate PeriodEndDate)
        {
            var rec = context.WP_MainRecord
						.Where(s => s.Directorate_Id==dir && s.FiscalYear_Id == year && s.Period_Id == period && s.PeriodStartDate==PeriodStartDate && s.PeriodEndDate==PeriodEndDate)
						.ToList();
            return rec;
        }
		public IEnumerable<WP_MainRecord>  GetRecordsByProjectYearAndPeriodRecs (int projectid, int year, int period)
        {
            var rec = context.WP_MainRecord
						.Where(s => s.FiscalYear_Id == year && s.Period_Id == period && s.Project_Id==projectid)
						.ToList();
            return rec;
        }

		public IEnumerable<WP_MainRecord> GetDraftRecordsByDivRecs (int div)
        {
            var rec = context.WP_MainRecord
						.Where(s =>  s.Division_Id==div && s.WP_Status=="Drafting Mode")
						.ToList();
            return rec;
        }

		public IEnumerable<WP_MainRecord> GetRecordsByDivRecs (int div)
        {
            var rec = context.WP_MainRecord
						.Where(s =>  s.Division_Id==div)
						.ToList();
            return rec;
        }

		public IEnumerable<WP_MainRecord> GetRecordsByDirRecs (int dir)
        {
            var rec = context.WP_MainRecord
						.Where(s =>  s.Directorate_Id==dir)
						.ToList();
            return rec;
        }
        public WP_MainRecord GetRecordByProjectYearAndPeriod (int projectid, int year, int period)
        {
            var rec = context.WP_MainRecord
						.Where(s => s.FiscalYear_Id == year && s.Period_Id == period && s.Project_Id==projectid)
						.FirstOrDefault();
            return rec;
        }



        public WP_MainRecord Update(WP_MainRecord recChanges)
		{
		    var satype = context.WP_MainRecord.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}

 
    }
}