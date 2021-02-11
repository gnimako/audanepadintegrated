using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceTrans_ProcurementPaymentType: ITrans_ProcurementPaymentTypeRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceTrans_ProcurementPaymentType> logger;
		public ServiceTrans_ProcurementPaymentType(AppDbContext context, ILogger<ServiceTrans_ProcurementPaymentType> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public Trans_ProcurementPaymentType Add(Trans_ProcurementPaymentType rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.Trans_ProcurementPaymentType.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public Trans_ProcurementPaymentType Delete(string id)
		{
		    Trans_ProcurementPaymentType rec = context.Trans_ProcurementPaymentType.Find(id);
		    if (rec != null)
		    {
		        context.Trans_ProcurementPaymentType.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<Trans_ProcurementPaymentType> GetAllRecords()
		{
		    return context.Trans_ProcurementPaymentType;
		}

		public Trans_ProcurementPaymentType GetRecord(string Id)
		{
		    return context.Trans_ProcurementPaymentType.Find(Id);
		}

		public Trans_ProcurementPaymentType Update(Trans_ProcurementPaymentType recChanges)
		{
		    var satype = context.Trans_ProcurementPaymentType.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}