using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceWP_Mobility: IWP_MobilityRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceWP_Mobility> logger;
		public ServiceWP_Mobility(AppDbContext context, ILogger<ServiceWP_Mobility> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public WP_Mobility Add(WP_Mobility rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.WP_Mobility.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public WP_Mobility Delete(string id)
		{
		    WP_Mobility rec = context.WP_Mobility.Find(id);
		    if (rec != null)
		    {
		        context.WP_Mobility.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<WP_Mobility> GetAllRecords()
		{
		    return context.WP_Mobility;
		}
		public IEnumerable<WP_Mobility> GetRecordsByOutputId (string outputid)
        {
            var records = context.WP_Mobility
                                .Where(s => s.WPOutput_Id==outputid)
                                .ToList();

            return records;
        }

		public WP_Mobility GetRecord(string Id)
		{
		    return context.WP_Mobility.Find(Id);
		}

		public WP_Mobility Update(WP_Mobility recChanges)
		{
		    var satype = context.WP_Mobility.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}