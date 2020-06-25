using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;

namespace AUDANEPAD_Integrated.Models
{
    public class Trans_StrategyKeyPerformanceArea
    {
        [Key]
		public string Transaction_Id { get; set; }

        public string TransStrategicPriority_Id { get; set; } //for delete purposes

        public int StrategicKeyPerformanceArea_Id { get; set; } //this mapps to Strategiy_KeyPerformanceArea Entity
		public LocalDate TransactionDate { get; set; }
        
    }
}