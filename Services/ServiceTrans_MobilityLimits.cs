using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;



namespace AUDANEPAD_Integrated.Services
{
    public class ServiceTrans_MobilityLimits: ITrans_MobilityLimitsRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceTrans_MobilityLimits> logger;
		public ServiceTrans_MobilityLimits(AppDbContext context, ILogger<ServiceTrans_MobilityLimits> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public Trans_MobilityLimits Add(Trans_MobilityLimits rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.Trans_MobilityLimits.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public Trans_MobilityLimits Delete(string id)
		{
		    Trans_MobilityLimits rec = context.Trans_MobilityLimits.Find(id);
		    if (rec != null)
		    {
		        context.Trans_MobilityLimits.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<Trans_MobilityLimits> GetAllRecords()
		{
		    return context.Trans_MobilityLimits;
		}

		public Trans_MobilityLimits GetRecord(string Id)
		{
		    return context.Trans_MobilityLimits.Find(Id);
		}

		public  Trans_MobilityLimits GetFirstOrDefaultRecordSet ()
		{
			var rec = context.Trans_MobilityLimits
							.FirstOrDefault();
            return rec;
		}

		public Trans_MobilityLimits Update(Trans_MobilityLimits recChanges)
		{
		    var satype = context.Trans_MobilityLimits.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}