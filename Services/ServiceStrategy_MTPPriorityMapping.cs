using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceStrategy_MTPPriorityMapping: IStrategy_MTPPriorityMappingRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceStrategy_MTPPriorityMapping> logger;
		public ServiceStrategy_MTPPriorityMapping(AppDbContext context, ILogger<ServiceStrategy_MTPPriorityMapping> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public Strategy_MTPPriorityMapping Add(Strategy_MTPPriorityMapping rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.Strategy_MTPPriorityMapping.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public Strategy_MTPPriorityMapping Delete(string id)
		{
		    Strategy_MTPPriorityMapping rec = context.Strategy_MTPPriorityMapping.Find(id);
		    if (rec != null)
		    {
		        context.Strategy_MTPPriorityMapping.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}


        public IEnumerable<Strategy_MTPPriorityMapping> GetAllRecords()
		{
		    return context.Strategy_MTPPriorityMapping;
		}
		public IEnumerable<Strategy_MTPPriorityMapping> GetAllRecordsByMTP (int id)
        {
            var records = context.Strategy_MTPPriorityMapping
                                .Where(s => s.MTP_Id == id)
                                .ToList();

            return records;
        }

		public Strategy_MTPPriorityMapping GetRecordsByMTPAndPriority (int mtpid, int priorityid)
        {
            var rec = context.Strategy_MTPPriorityMapping
                                  .Where(s => s.MTP_Id == mtpid && s.Priority_Id==priorityid)
                                  .FirstOrDefault();
            return rec;
        }


		public Strategy_MTPPriorityMapping GetRecord(string Id)
		{
		    return context.Strategy_MTPPriorityMapping.Find(Id);
		}

		public Strategy_MTPPriorityMapping Update(Strategy_MTPPriorityMapping recChanges)
		{
		    var satype = context.Strategy_MTPPriorityMapping.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}