using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;


namespace AUDANEPAD_Integrated.Models
{
    public class Struc_DivHeadOIC
    {
        [Key]
        public string Transaction_Id { get; set; }
        public string ParentTransaction_Id { get; set; }
        public  int EmployeePK { get; set; }
        public string Staff_Number { get; set; }
        public int Directorate_Id { get; set; }
        public int Division_Id { get; set; }

        public string OIC_Status { get; set; }
        public LocalDate StartDate { get; set; }
        public LocalDate EndDate { get; set; }
        
        public LocalDate TransactionDate { get; set; }
        
    }
}