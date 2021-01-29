using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceWP_Outputs: IWP_OutputsRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceWP_Outputs> logger;
		public ServiceWP_Outputs (AppDbContext context, ILogger<ServiceWP_Outputs> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public WP_Outputs Add(WP_Outputs rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.WP_Outputs.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public WP_Outputs Delete(string id)
		{
		    WP_Outputs rec = context.WP_Outputs.Find(id);
		    if (rec != null)
		    {
		        context.WP_Outputs.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<WP_Outputs> GetAllRecords()
		{
		    return context.WP_Outputs;
		}
        public IEnumerable<WP_Outputs> GetRecordsByMainRecordId (string recid)
        {
            var records = context.WP_Outputs
                                .Where(s => s.WPMainRecord_id==recid)
                                .ToList();

            return records;
        }
        public IEnumerable<WP_Outputs> GetRecordsByProjectYearAndPeriod (int projectid, int year, int period)
        {
            var records = context.WP_Outputs
                                .Where(s => s.Project_Id==projectid && s.FiscalYear_Id==year && s.Period_Id==period)
                                .ToList();

            return records;
        }


		public WP_Outputs GetRecord(string Id)
		{
		    return context.WP_Outputs.Find(Id);
		}
		public WP_Outputs GetRecordByOutputStatement (string output)
        {
            var rec = context.WP_Outputs
						.Where(s => s.Output == output)
						.FirstOrDefault();
            return rec;
        }

		public WP_Outputs GetRecordByOutputStatementAndOutputLinkId (string output, int outputlinkid)
        {
            var rec = context.WP_Outputs
						.Where(s => s.Output == output && s.WPOutputLinkType_Id==outputlinkid)
						.FirstOrDefault();
            return rec;
        }

        public WP_Outputs Update(WP_Outputs recChanges)
		{
		    var satype = context.WP_Outputs.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}