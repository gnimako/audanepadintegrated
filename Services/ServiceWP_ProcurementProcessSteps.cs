using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;



namespace AUDANEPAD_Integrated.Services
{
    public class ServiceWP_ProcurementProcessSteps:IWP_ProcurementProcessStepsRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceWP_ProcurementProcessSteps> logger;
		public ServiceWP_ProcurementProcessSteps (AppDbContext context, ILogger<ServiceWP_ProcurementProcessSteps> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public WP_ProcurementProcessSteps Add(WP_ProcurementProcessSteps rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.WP_ProcurementProcessSteps.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public WP_ProcurementProcessSteps Delete(string id)
		{
		    WP_ProcurementProcessSteps rec = context.WP_ProcurementProcessSteps.Find(id);
		    if (rec != null)
		    {
		        context.WP_ProcurementProcessSteps.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<WP_ProcurementProcessSteps> GetAllRecords()
		{
		    return context.WP_ProcurementProcessSteps;
		}
		
        public IEnumerable<WP_ProcurementProcessSteps> GetRecordsByMainRecordId (string recid)
        {
            var records = context.WP_ProcurementProcessSteps
                                .Where(s => s.WPMainRecord_id==recid)
                                .ToList();

            return records;
        }
        public IEnumerable<WP_ProcurementProcessSteps> GetRecordsByProcurementId (string recid)
        {
            var records = context.WP_ProcurementProcessSteps
                                .Where(s => s.WPProcurement_Id==recid)
                                .ToList();

            return records;
        }

        public WP_ProcurementProcessSteps GetRecordByProcurementIdStepId1OrStepId2 (string recid, int stepid1, int stepid2)
        {
            var rec = context.WP_ProcurementProcessSteps
						.Where(s => s.WPProcurement_Id == recid && (s.WPStepType_Id==stepid1 || s.WPStepType_Id==stepid2 ))
						.FirstOrDefault();
            return rec;
        }

		public WP_ProcurementProcessSteps GetRecordByProcurementIdStepId (string recid, int stepid)
        {
            var rec = context.WP_ProcurementProcessSteps
						.Where(s => s.WPProcurement_Id == recid && s.WPStepType_Id==stepid )
						.FirstOrDefault();
            return rec;
        }

		public WP_ProcurementProcessSteps GetRecordByProcurementIdStepNumber (string recid, int stepnumber)
        {
            var rec = context.WP_ProcurementProcessSteps
						.Where(s => s.WPProcurement_Id == recid && s.WPStepNumber==stepnumber )
						.FirstOrDefault();
            return rec;
        }

		

		public WP_ProcurementProcessSteps GetRecord(string Id)
		{
		    return context.WP_ProcurementProcessSteps.Find(Id);
		}




        public WP_ProcurementProcessSteps Update(WP_ProcurementProcessSteps recChanges)
		{
		    var satype = context.WP_ProcurementProcessSteps.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}