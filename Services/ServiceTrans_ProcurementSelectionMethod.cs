using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceTrans_ProcurementSelectionMethod: ITrans_ProcurementSelectionMethodRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceTrans_ProcurementSelectionMethod> logger;
		public ServiceTrans_ProcurementSelectionMethod(AppDbContext context, ILogger<ServiceTrans_ProcurementSelectionMethod> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public Trans_ProcurementSelectionMethod Add(Trans_ProcurementSelectionMethod rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.Trans_ProcurementSelectionMethod.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public Trans_ProcurementSelectionMethod Delete(string id)
		{
		    Trans_ProcurementSelectionMethod rec = context.Trans_ProcurementSelectionMethod.Find(id);
		    if (rec != null)
		    {
		        context.Trans_ProcurementSelectionMethod.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<Trans_ProcurementSelectionMethod> GetAllRecords()
		{
		    return context.Trans_ProcurementSelectionMethod;
		}

		public Trans_ProcurementSelectionMethod GetRecord(string Id)
		{
		    return context.Trans_ProcurementSelectionMethod.Find(Id);
		}

		public Trans_ProcurementSelectionMethod Update(Trans_ProcurementSelectionMethod recChanges)
		{
		    var satype = context.Trans_ProcurementSelectionMethod.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}