using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceTrans_ProcurementType: ITrans_ProcurementTypeRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceTrans_ProcurementType> logger;
		public ServiceTrans_ProcurementType(AppDbContext context, ILogger<ServiceTrans_ProcurementType> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public Trans_ProcurementType Add(Trans_ProcurementType rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.Trans_ProcurementType.Add(rec);
		    context.SaveChanges();
		    return rec;
		}


        public Trans_ProcurementType GetRecordByMainRecord_Id (int Id)
        {
            var rec = context.Trans_ProcurementType
						.Where(s => s.Record_Id == Id)
						.FirstOrDefault();
            return rec;
        }

		public Trans_ProcurementType Delete(string id)
		{
		    Trans_ProcurementType rec = context.Trans_ProcurementType.Find(id);
		    if (rec != null)
		    {
		        context.Trans_ProcurementType.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<Trans_ProcurementType> GetAllRecords()
		{
		    return context.Trans_ProcurementType;
		}

		public Trans_ProcurementType GetRecord(string Id)
		{
		    return context.Trans_ProcurementType.Find(Id);
		}

		public Trans_ProcurementType Update(Trans_ProcurementType recChanges)
		{
		    var satype = context.Trans_ProcurementType.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}