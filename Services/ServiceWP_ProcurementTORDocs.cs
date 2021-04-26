using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;




namespace AUDANEPAD_Integrated.Services
{
    public class ServiceWP_ProcurementTORDocs: IWP_ProcurementTORDocsRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceWP_ProcurementTORDocs> logger;
		public ServiceWP_ProcurementTORDocs (AppDbContext context, ILogger<ServiceWP_ProcurementTORDocs> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public WP_ProcurementTORDocs Add(WP_ProcurementTORDocs rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.WP_ProcurementTORDocs.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public WP_ProcurementTORDocs Delete(string id)
		{
		    WP_ProcurementTORDocs rec = context.WP_ProcurementTORDocs.Find(id);
		    if (rec != null)
		    {
		        context.WP_ProcurementTORDocs.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<WP_ProcurementTORDocs> GetAllRecords()
		{
		    return context.WP_ProcurementTORDocs;
		}
		
        public IEnumerable<WP_ProcurementTORDocs> GetRecordsByMainRecordId (string recid)
        {
            var records = context.WP_ProcurementTORDocs
                                .Where(s => s.WPMainRecord_id==recid)
                                .ToList();

            return records;
        }
        public IEnumerable<WP_ProcurementTORDocs> GetRecordsByProcurementId (string recid)
        {
            var records = context.WP_ProcurementTORDocs
                                .Where(s => s.WPProcurement_Id==recid)
                                .ToList();

            return records;
        }

		public WP_ProcurementTORDocs GetRecordByProcurementIdAndFilename (string recid, string filename)
        {
            var rec = context.WP_ProcurementTORDocs
						.Where(s => s.WPProcurement_Id == recid && s.WPDocPath==filename)
						.FirstOrDefault();
            return rec;
        }

		

		public WP_ProcurementTORDocs GetRecord(string Id)
		{
		    return context.WP_ProcurementTORDocs.Find(Id);
		}


        public WP_ProcurementTORDocs Update(WP_ProcurementTORDocs recChanges)
		{
		    var satype = context.WP_ProcurementTORDocs.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}

       

        
    }
}