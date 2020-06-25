using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceTrans_StrategyPriority: ITrans_StrategyPriorityRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceTrans_StrategyPriority> logger;

        private readonly ITrans_StrategyKeyPerformanceAreaRepository _transStrategyKeyPerformanceAreaRepository ;
		public ServiceTrans_StrategyPriority(AppDbContext context, ILogger<ServiceTrans_StrategyPriority> logger,
                                                ITrans_StrategyKeyPerformanceAreaRepository transStrategyKeyPerformanceAreaRepository)
		{
		    this.context = context;
		    this.logger = logger;
            _transStrategyKeyPerformanceAreaRepository=transStrategyKeyPerformanceAreaRepository;
		}
		public Trans_StrategyPriority Add(Trans_StrategyPriority rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.Trans_StrategyPriority.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public Trans_StrategyPriority Delete(string id)
		{
            var dependent_recs=_transStrategyKeyPerformanceAreaRepository.GetAllRecordsByStrategicPriority(id).ToList();
            foreach (var record in dependent_recs)
            {
                if (record != null)
                {
                    context.Trans_StrategyKeyPerformanceArea.Remove(record);
                    context.SaveChanges();
                }
            }
		    Trans_StrategyPriority rec = context.Trans_StrategyPriority.Find(id);
		    if (rec != null)
		    {
		        context.Trans_StrategyPriority.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<Trans_StrategyPriority> GetAllRecords()
		{
		    return context.Trans_StrategyPriority;
		}

		public Trans_StrategyPriority GetRecord(string Id)
		{
		    return context.Trans_StrategyPriority.Find(Id);
		}

        public Trans_StrategyPriority GetRecordByMasterStrategyPriorityId(int Id)
        {
                        var rec = context.Trans_StrategyPriority
                                  .Where(s => s.Record_Id == Id)
                                  .FirstOrDefault();
                        return rec;
        }

        public Trans_StrategyPriority Update(Trans_StrategyPriority recChanges)
		{
		    var satype = context.Trans_StrategyPriority.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}