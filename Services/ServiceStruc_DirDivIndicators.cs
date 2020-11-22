using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceStruc_DirDivIndicators: IStruc_DirDivIndicatorsRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<Struc_DirDivIndicators> logger;    

        public ServiceStruc_DirDivIndicators(AppDbContext context, ILogger<Struc_DirDivIndicators> logger)
        {
            this.context = context;
            this.logger = logger;
        }


        public Struc_DirDivIndicators Add(Struc_DirDivIndicators rec)
        {
           // rec.Record_Id = GetAllRecords().Count() + 1;
            context.Struc_DirDivIndicators.Add(rec);
            context.SaveChanges();
            return rec;
        }

        public Struc_DirDivIndicators Delete(int id)
        {
            Struc_DirDivIndicators rec = context.Struc_DirDivIndicators.Find(id);
            if (rec != null)
            {
                context.Struc_DirDivIndicators.Remove(rec);
                context.SaveChanges();
            }
            return rec;
        }

        public IEnumerable<Struc_DirDivIndicators> GetAllRecords()
        {
            return context.Struc_DirDivIndicators;
        }

        public IEnumerable<Struc_DirDivIndicators> GetAllRecordsByDirectorate(int Directorate_Id)
        {
            var records = context.Struc_DirDivIndicators
                                .Where(s => s.Directorate_Id == Directorate_Id)
                                .ToList();

            return records;
        }

        public IEnumerable<Struc_DirDivIndicators> GetAllRecordsByDivision(int Division_Id)
        {
            var records = context.Struc_DirDivIndicators
                                .Where(s => s.Division_Id == Division_Id)
                                .ToList();

            return records;
        }

        public IEnumerable<Struc_DirDivIndicators> GetAllDeactivatedRecordsByDivision(int Division_Id)
        {
            var records = context.Struc_DirDivIndicators
                                .Where(s => s.Division_Id == Division_Id && s.Record_Status==false)
                                .ToList();

            return records;
        }

        public IEnumerable<Struc_DirDivIndicators> GetAllRecordsByDirectorateAndDivision(int Directorate_Id, int Division_Id)
        {
            var records = context.Struc_DirDivIndicators
                                .Where(s => s.Directorate_Id==Directorate_Id && s.Division_Id == Division_Id)
                                .ToList();

            return records;
        }

        public Struc_DirDivIndicators GetRecord(int Id)
        {
            return context.Struc_DirDivIndicators.Find(Id);
        }



        public Struc_DirDivIndicators GetRecordByName(string name)
        {
            var rec = context.Struc_DirDivIndicators
                                  .Where(s => s.Record_Name == name)
                                  .FirstOrDefault();
            return rec;
        }


        public  Struc_DirDivIndicators GetRecordByNameAndDirectorate(string name, int Directorate_Id)
        {
            var rec = context.Struc_DirDivIndicators
                                  .Where(s => s.Record_Name == name && s.Directorate_Id==Directorate_Id)
                                  .FirstOrDefault();
            return rec;
        }

        public  Struc_DirDivIndicators GetRecordByRecordNameDirectorateDivisionAndIndicatorType(string name, int Directorate_Id, int Division_Id, int Indicatory_Type_Id)
        {
            var rec = context.Struc_DirDivIndicators
                                  .Where(s => s.Record_Name == name && s.Directorate_Id==Directorate_Id && s.Division_Id==Division_Id && s.Indicator_Type_Id==Indicatory_Type_Id)
                                  .FirstOrDefault();
            return rec;
        }

        

        public Struc_DirDivIndicators Update(Struc_DirDivIndicators recChanges)
        {
            var rec = context.Struc_DirDivIndicators.Attach(recChanges);
            rec.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return recChanges;
        }
        
    }
}