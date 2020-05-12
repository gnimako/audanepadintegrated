using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceStruc_Division:IStruc_DivisionRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<ServiceStruc_Division> logger;    

        public ServiceStruc_Division(AppDbContext context, ILogger<ServiceStruc_Division> logger)
        {
            this.context = context;
            this.logger = logger;
        }


        public Struc_Division Add(Struc_Division rec)
        {
            rec.Record_Id = GetAllRecords().Count() + 1;
            context.Struc_Division.Add(rec);
            context.SaveChanges();
            return rec;
        }

        public Struc_Division Delete(int id)
        {
            Struc_Division rec = context.Struc_Division.Find(id);
            if (rec != null)
            {
                context.Struc_Division.Remove(rec);
                context.SaveChanges();
            }
            return rec;
        }

        public IEnumerable<Struc_Division> GetAllRecords()
        {
            return context.Struc_Division;
        }

        public IEnumerable<Struc_Division> GetAllRecordsByDirectorate(int Directorate_Id)
        {
            var records = context.Struc_Division
                                .Where(s => s.Directorate_Id == Directorate_Id)
                                .ToList();

            return records;
        }

        public Struc_Division GetRecord(int Id)
        {
            return context.Struc_Division.Find(Id);
        }



        public Struc_Division GetRecordByName(string name)
        {
            var rec = context.Struc_Division
                                  .Where(s => s.Record_Name == name)
                                  .FirstOrDefault();
            return rec;
        }


        public  Struc_Division GetRecordByNameAndDirectorate(string name, int Directorate_Id)
        {
            var rec = context.Struc_Division
                                  .Where(s => s.Record_Name == name && s.Directorate_Id==Directorate_Id)
                                  .FirstOrDefault();
            return rec;
        }

        

        public Struc_Division Update(Struc_Division recChanges)
        {
            var rec = context.Struc_Division.Attach(recChanges);
            rec.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return recChanges;
        }
        
    }
}