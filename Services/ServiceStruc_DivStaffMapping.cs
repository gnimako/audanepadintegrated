using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceStruc_DivStaffMapping: IStruc_DivStaffMappingRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceStruc_DivStaffMapping> logger;
		public ServiceStruc_DivStaffMapping(AppDbContext context, ILogger<ServiceStruc_DivStaffMapping> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public Struc_DivStaffMapping Add(Struc_DivStaffMapping rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.Struc_DivStaffMapping.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public Struc_DivStaffMapping Delete(string id)
		{
		    Struc_DivStaffMapping rec = context.Struc_DivStaffMapping.Find(id);
		    if (rec != null)
		    {
		        context.Struc_DivStaffMapping.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<Struc_DivStaffMapping> GetAllRecords()
		{
		    return context.Struc_DivStaffMapping;
		}

		public IEnumerable<Struc_DivStaffMapping> GetAllRecordsByDivision(int Division_Id)
        {
            var records = context.Struc_DivStaffMapping
                                .Where(s => s.Division_Id == Division_Id)
                                .ToList();

            return records;
        }

		public IEnumerable<Struc_DivStaffMapping> GetAllRecordsByEmployeeAndDirectorate(int Employee_Id, int Directorate_Id)
        {
            var records = context.Struc_DivStaffMapping
                                .Where(s => s.EmployeePK == Employee_Id && s.Directorate_Id==Directorate_Id)
                                .ToList();

            return records;
        }

		public Struc_DivStaffMapping GetRecordByEmployeeAndDirectorsDiv (int Employee_Id, int Directorate_Id)
        {
            var rec = context.Struc_DivStaffMapping
                                .Where(s => s.EmployeePK == Employee_Id && s.Directorate_Id==Directorate_Id && s.PrimaryDivision==true)
                                .FirstOrDefault();

            return rec;
        }
		public Struc_DivStaffMapping GetRecordByEmployeeAndThisPrimaryDivision (int Employee_Id, int Division_Id)
        {
            var rec = context.Struc_DivStaffMapping
                                  .Where(s => s.EmployeePK == Employee_Id && s.Division_Id == Division_Id && s.PrimaryDivision==true)
                                  .FirstOrDefault();
            return rec;
        }
		public Struc_DivStaffMapping GetRecordByEmployeeAndPrimaryDivision (int Employee_Id)
        {
            var rec = context.Struc_DivStaffMapping
                                  .Where(s => s.EmployeePK == Employee_Id && s.PrimaryDivision==true)
                                  .FirstOrDefault();
            return rec;
        }
		public Struc_DivStaffMapping GetRecordByEmployeeAndDivision (int Employee_Id, int Division_Id)
        {
            var rec = context.Struc_DivStaffMapping
                                  .Where(s => s.EmployeePK == Employee_Id && s.Division_Id==Division_Id)
                                  .FirstOrDefault();
            return rec;
        }
		public Struc_DivStaffMapping GetRecord(string Id)
		{
		    return context.Struc_DivStaffMapping.Find(Id);
		}

		public Struc_DivStaffMapping Update(Struc_DivStaffMapping recChanges)
		{
		    var satype = context.Struc_DivStaffMapping.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}