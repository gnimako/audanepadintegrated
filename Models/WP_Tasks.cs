using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;



namespace AUDANEPAD_Integrated.Models
{
    public class WP_Tasks
    {
        [Key]
        public string Transaction_Id { get; set; }
        public string WPCategoryMain { get; set; }
        public string WPReference_Id { get; set; }
        public string WPCategorySub1 { get; set; }
        public string WPCategorySub2 { get; set; }
        public string WPCategorySub3 { get; set; }
        public string WPCategorySub4 { get; set; }
        public string WPCategorySub5 { get; set; }

        public string WPTaskDescription { get; set; }
        public string WPTaskStatus { get; set; }

        public int  WPRequesterEmployee_Id { get; set; }
        public int  WPRepondentEmployee_Id { get; set; }

        public int  WPDirectorate_Id { get; set; }
        public int  WPDivision_Id { get; set; }

        public string  WPResponsibleDeptType { get; set; }
        public string  TaskNotes { get; set; }
        public LocalDate TransactionDate { get; set; }

        
    }
}