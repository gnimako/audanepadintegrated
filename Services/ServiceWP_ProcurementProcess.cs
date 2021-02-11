using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceWP_ProcurementProcess:IWP_ProcurementProcessRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceWP_ProcurementProcess> logger;
		public ServiceWP_ProcurementProcess (AppDbContext context, ILogger<ServiceWP_ProcurementProcess> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public WP_ProcurementProcess Add(WP_ProcurementProcess rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.WP_ProcurementProcess.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public WP_ProcurementProcess Delete(string id)
		{
		    WP_ProcurementProcess rec = context.WP_ProcurementProcess.Find(id);
		    if (rec != null)
		    {
		        context.WP_ProcurementProcess.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<WP_ProcurementProcess> GetAllRecords()
		{
		    return context.WP_ProcurementProcess;
		}
		
        public IEnumerable<WP_ProcurementProcess> GetRecordsByMainRecordId (string recid)
        {
            var records = context.WP_ProcurementProcess
                                .Where(s => s.WPMainRecord_id==recid)
                                .ToList();

            return records;
        }
        public IEnumerable<WP_ProcurementProcess> GetRecordsByProcurementId (string recid)
        {
            var records = context.WP_ProcurementProcess
                                .Where(s => s.WPProcurement_Id==recid)
                                .ToList();

            return records;
        }

		

		public WP_ProcurementProcess GetRecord(string Id)
		{
		    return context.WP_ProcurementProcess.Find(Id);
		}


        public WP_ProcurementProcess Update(WP_ProcurementProcess recChanges)
		{
		    var satype = context.WP_ProcurementProcess.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}