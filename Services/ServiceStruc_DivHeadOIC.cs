using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;



namespace AUDANEPAD_Integrated.Services
{
    public class ServiceStruc_DivHeadOIC: IStruc_DivHeadOICRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceStruc_DivHeadOIC> logger;
		public ServiceStruc_DivHeadOIC(AppDbContext context, ILogger<ServiceStruc_DivHeadOIC> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public Struc_DivHeadOIC Add(Struc_DivHeadOIC rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.Struc_DivHeadOIC.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public Struc_DivHeadOIC Delete(string id)
		{
		    Struc_DivHeadOIC rec = context.Struc_DivHeadOIC.Find(id);
		    if (rec != null)
		    {
		        context.Struc_DivHeadOIC.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<Struc_DivHeadOIC> GetAllRecords()
		{
		    return context.Struc_DivHeadOIC;
		}
		public IEnumerable<Struc_DivHeadOIC> GetAllRecordsByDivision(int Division_Id)
        {
            var records = context.Struc_DivHeadOIC
                                .Where(s => s.Division_Id == Division_Id)
                                .ToList();

            return records;
        }
		public Struc_DivHeadOIC GetRecordByEmployeeAndDivision (int Employee_Id, int Division_Id)
        {
            var rec = context.Struc_DivHeadOIC
                                  .Where(s => s.EmployeePK == Employee_Id && s.Division_Id==Division_Id)
                                  .FirstOrDefault();
            return rec;
        }

		public Struc_DivHeadOIC GetRecord(string Id)
		{
		    return context.Struc_DivHeadOIC.Find(Id);
		}

		public Struc_DivHeadOIC Update(Struc_DivHeadOIC recChanges)
		{
		    var satype = context.Struc_DivHeadOIC.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}