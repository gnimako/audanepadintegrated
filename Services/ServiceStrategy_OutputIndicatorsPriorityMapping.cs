using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceStrategy_OutputIndicatorsPriorityMapping: IStrategy_OutputIndicatorsPriorityMappingRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceStrategy_OutputIndicatorsPriorityMapping> logger;
		public ServiceStrategy_OutputIndicatorsPriorityMapping(AppDbContext context, ILogger<ServiceStrategy_OutputIndicatorsPriorityMapping> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public Strategy_OutputIndicatorsPriorityMapping Add(Strategy_OutputIndicatorsPriorityMapping rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.Strategy_OutputIndicatorsPriorityMapping.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public Strategy_OutputIndicatorsPriorityMapping Delete(string id)
		{
		    Strategy_OutputIndicatorsPriorityMapping rec = context.Strategy_OutputIndicatorsPriorityMapping.Find(id);
		    if (rec != null)
		    {
		        context.Strategy_OutputIndicatorsPriorityMapping.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}


        public IEnumerable<Strategy_OutputIndicatorsPriorityMapping> GetAllRecords()
		{
		    return context.Strategy_OutputIndicatorsPriorityMapping;
		}
		public IEnumerable<Strategy_OutputIndicatorsPriorityMapping> GetAllRecordsByIndicator (int id)
        {
            var records = context.Strategy_OutputIndicatorsPriorityMapping
                                .Where(s => s.OutputIndicator_Id == id)
                                .ToList();

            return records;
        }

        public IEnumerable<Strategy_OutputIndicatorsPriorityMapping> GetAllRecordsByKPA (int kpa)
        {
            var records = context.Strategy_OutputIndicatorsPriorityMapping
                                .Where(s => s.KeyPerformanceArea_Id == kpa)
                                .ToList();

            return records;
        }
		public IEnumerable<Strategy_OutputIndicatorsPriorityMapping> GetAllRecordsByPriority (int priority)
        {
            var records = context.Strategy_OutputIndicatorsPriorityMapping
                                .Where(s => s.Priority_Id == priority)
                                .ToList();

            return records;
        }

		public Strategy_OutputIndicatorsPriorityMapping GetRecordsByIndicatorPriorityAndKPA (int indicatorid, int priorityid, int kpa)
        {
            var rec = context.Strategy_OutputIndicatorsPriorityMapping
                                  .Where(s => s.OutputIndicator_Id == indicatorid && s.Priority_Id==priorityid && s.KeyPerformanceArea_Id==kpa)
                                  .FirstOrDefault();
            return rec;
        }


		public Strategy_OutputIndicatorsPriorityMapping GetRecord(string Id)
		{
		    return context.Strategy_OutputIndicatorsPriorityMapping.Find(Id);
		}

		public Strategy_OutputIndicatorsPriorityMapping Update(Strategy_OutputIndicatorsPriorityMapping recChanges)
		{
		    var satype = context.Strategy_OutputIndicatorsPriorityMapping.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}