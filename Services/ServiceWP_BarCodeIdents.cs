using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;



namespace AUDANEPAD_Integrated.Services
{
    public class ServiceWP_BarCodeIdents: IWP_BarCodeIdentsRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceWP_BarCodeIdents> logger;
		public ServiceWP_BarCodeIdents(AppDbContext context, ILogger<ServiceWP_BarCodeIdents> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public WP_BarCodeIdents Add(WP_BarCodeIdents rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.WP_BarCodeIdents.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public WP_BarCodeIdents Delete(string id)
		{
		    WP_BarCodeIdents rec = context.WP_BarCodeIdents.Find(id);
		    if (rec != null)
		    {
		        context.WP_BarCodeIdents.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<WP_BarCodeIdents> GetAllRecords()
		{
		    return context.WP_BarCodeIdents;
		}


		public WP_BarCodeIdents GetRecord(string Id)
		{
		    return context.WP_BarCodeIdents.Find(Id);
		}
		public  WP_BarCodeIdents GetRecordByDispatchCycle (string cycleid)
        {
            var rec = context.WP_BarCodeIdents
						.Where(s => s.DispatchCycle_Id==cycleid)
						.FirstOrDefault();
            return rec;
        }

		public WP_BarCodeIdents Update(WP_BarCodeIdents recChanges)
		{
		    var satype = context.WP_BarCodeIdents.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}