using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceTrans_IndicatorType: ITrans_IndicatorTypeRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceTrans_IndicatorType> logger;
		public ServiceTrans_IndicatorType(AppDbContext context, ILogger<ServiceTrans_IndicatorType> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public Trans_IndicatorType Add(Trans_IndicatorType rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.Trans_IndicatorType.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public Trans_IndicatorType Delete(string id)
		{
		    Trans_IndicatorType rec = context.Trans_IndicatorType.Find(id);
		    if (rec != null)
		    {
		        context.Trans_IndicatorType.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<Trans_IndicatorType> GetAllRecords()
		{
		    return context.Trans_IndicatorType;
		}

		public Trans_IndicatorType GetRecord(string Id)
		{
		    return context.Trans_IndicatorType.Find(Id);
		}

		public Trans_IndicatorType Update(Trans_IndicatorType recChanges)
		{
		    var satype = context.Trans_IndicatorType.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}