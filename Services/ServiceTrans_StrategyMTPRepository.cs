using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceTrans_StrategyMTPRepository: ITrans_StrategyMTPRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceTrans_StrategyMTPRepository> logger;


		public ServiceTrans_StrategyMTPRepository(AppDbContext context, ILogger<ServiceTrans_StrategyMTPRepository> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public Trans_StrategyMTP Add(Trans_StrategyMTP rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.Trans_StrategyMTP.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public Trans_StrategyMTP Delete(string id)
		{
        
		    Trans_StrategyMTP rec = context.Trans_StrategyMTP.Find(id);

		    if (rec != null)
		    {
		        context.Trans_StrategyMTP.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<Trans_StrategyMTP> GetAllRecords()
		{
		    return context.Trans_StrategyMTP;
		}

		public Trans_StrategyMTP GetRecord(string Id)
		{
		    return context.Trans_StrategyMTP.Find(Id);
		}

        public Trans_StrategyMTP Update(Trans_StrategyMTP recChanges)
		{
		    var satype = context.Trans_StrategyMTP.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}