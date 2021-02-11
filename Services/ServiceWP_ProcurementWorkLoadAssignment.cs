using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceWP_ProcurementWorkLoadAssignment:IWP_ProcurementWorkLoadAssignmentRepository
    {

        private readonly AppDbContext context;
		private readonly ILogger<ServiceWP_ProcurementWorkLoadAssignment> logger;
		public ServiceWP_ProcurementWorkLoadAssignment (AppDbContext context, ILogger<ServiceWP_ProcurementWorkLoadAssignment> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public WP_ProcurementWorkLoadAssignment Add(WP_ProcurementWorkLoadAssignment rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.WP_ProcurementWorkLoadAssignment.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public WP_ProcurementWorkLoadAssignment Delete(string id)
		{
		    WP_ProcurementWorkLoadAssignment rec = context.WP_ProcurementWorkLoadAssignment.Find(id);
		    if (rec != null)
		    {
		        context.WP_ProcurementWorkLoadAssignment.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<WP_ProcurementWorkLoadAssignment> GetAllRecords()
		{
		    return context.WP_ProcurementWorkLoadAssignment;
		}
		
        public IEnumerable<WP_ProcurementWorkLoadAssignment> GetRecordsByMainRecordId (string recid)
        {
            var records = context.WP_ProcurementWorkLoadAssignment
                                .Where(s => s.WPMainRecord_id==recid)
                                .ToList();

            return records;
        }
        public IEnumerable<WP_ProcurementWorkLoadAssignment> GetRecordsByProcurementId (string recid)
        {
            var records = context.WP_ProcurementWorkLoadAssignment
                                .Where(s => s.WPProcurement_Id==recid)
                                .ToList();

            return records;
        }

		public IEnumerable<WP_ProcurementWorkLoadAssignment> GetRecordsByEmployeeIdAndStatus (int empid, string status)
        {
            var records = context.WP_ProcurementWorkLoadAssignment
                                .Where(s => s.Employee_Id==empid && s.WPProcurement_Status==status)
                                .ToList();

            return records;
        }


		public WP_ProcurementWorkLoadAssignment GetRecordByProcurementIdAndEmployeeId (string procid, int empid)
        {
            var rec = context.WP_ProcurementWorkLoadAssignment
						.Where(s => s.WPProcurement_Id == procid && s.Employee_Id==empid)
						.FirstOrDefault();
            return rec;
        }

		

		public WP_ProcurementWorkLoadAssignment GetRecord(string Id)
		{
		    return context.WP_ProcurementWorkLoadAssignment.Find(Id);
		}


        public WP_ProcurementWorkLoadAssignment Update(WP_ProcurementWorkLoadAssignment recChanges)
		{
		    var satype = context.WP_ProcurementWorkLoadAssignment.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}