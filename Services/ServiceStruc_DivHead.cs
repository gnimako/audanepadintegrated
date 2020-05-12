using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceStruc_DivHead: IStruc_DivHeadRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceStruc_DivHead> logger;
		public ServiceStruc_DivHead(AppDbContext context, ILogger<ServiceStruc_DivHead> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public Struc_DivHead Add(Struc_DivHead rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.Struc_DivHead.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public Struc_DivHead Delete(string id)
		{
		    Struc_DivHead rec = context.Struc_DivHead.Find(id);
		    if (rec != null)
		    {
		        context.Struc_DivHead.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<Struc_DivHead> GetAllRecords()
		{
		    return context.Struc_DivHead;
		}
		public IEnumerable<Struc_DivHead> GetAllRecordsByDivision(int Division_Id)
        {
            var records = context.Struc_DivHead
                                .Where(s => s.Division_Id == Division_Id)
                                .ToList();

            return records;
        }
		public Struc_DivHead GetRecordByEmployeeAndDivision (int Employee_Id, int Division_Id)
        {
            var rec = context.Struc_DivHead
                                  .Where(s => s.EmployeePK == Employee_Id && s.Division_Id==Division_Id)
                                  .FirstOrDefault();
            return rec;
        }

		public Struc_DivHead GetRecord(string Id)
		{
		    return context.Struc_DivHead.Find(Id);
		}

		public Struc_DivHead Update(Struc_DivHead recChanges)
		{
		    var satype = context.Struc_DivHead.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}