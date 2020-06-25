using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceTrans_StrategyKeyPerformanceArea: ITrans_StrategyKeyPerformanceAreaRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceTrans_StrategyKeyPerformanceArea> logger;
        
		public ServiceTrans_StrategyKeyPerformanceArea(AppDbContext context, ILogger<ServiceTrans_StrategyKeyPerformanceArea> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public Trans_StrategyKeyPerformanceArea Add(Trans_StrategyKeyPerformanceArea rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.Trans_StrategyKeyPerformanceArea.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public Trans_StrategyKeyPerformanceArea Delete(string id)
		{
        
		    Trans_StrategyKeyPerformanceArea rec = context.Trans_StrategyKeyPerformanceArea.Find(id);

		    if (rec != null)
		    {
		        context.Trans_StrategyKeyPerformanceArea.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<Trans_StrategyKeyPerformanceArea> GetAllRecords()
		{
		    return context.Trans_StrategyKeyPerformanceArea;
		}

        public IEnumerable<Trans_StrategyKeyPerformanceArea> GetAllRecordsByStrategicPriority(string TransStrategicPriority_Id)
        {
            var records = context.Trans_StrategyKeyPerformanceArea
                                .Where(s => s.TransStrategicPriority_Id == TransStrategicPriority_Id)
                                .ToList();

            return records;
        }

        public Trans_StrategyKeyPerformanceArea GetRecord(string Id)
		{
		    return context.Trans_StrategyKeyPerformanceArea.Find(Id);
		}

		public Trans_StrategyKeyPerformanceArea Update(Trans_StrategyKeyPerformanceArea recChanges)
		{
		    var satype = context.Trans_StrategyKeyPerformanceArea.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}