using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;



namespace AUDANEPAD_Integrated.Services
{
    public class ServiceWP_Procurement: IWP_ProcurementRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceWP_Procurement> logger;
		public ServiceWP_Procurement(AppDbContext context, ILogger<ServiceWP_Procurement> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public WP_Procurement Add(WP_Procurement rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.WP_Procurement.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public WP_Procurement Delete(string id)
		{
		    WP_Procurement rec = context.WP_Procurement.Find(id);
		    if (rec != null)
		    {
		        context.WP_Procurement.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<WP_Procurement> GetAllRecords()
		{
		    return context.WP_Procurement;
		}
		public IEnumerable<WP_Procurement> GetRecordsByOutputId (string outputid)
        {
            var records = context.WP_Procurement
                                .Where(s => s.WPOutput_Id==outputid)
                                .ToList();

            return records;
        }

		public WP_Procurement GetRecord(string Id)
		{
		    return context.WP_Procurement.Find(Id);
		}

		public WP_Procurement Update(WP_Procurement recChanges)
		{
		    var satype = context.WP_Procurement.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}