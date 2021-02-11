using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;

namespace AUDANEPAD_Integrated.Models
{
    public class WP_ProcurementProcess
    {
        [Key]
        public string Transaction_Id { get; set; }
        public string WPMainRecord_id { get; set; }
        public string WPProcurement_Id { get; set; }
        public int  ProcurementEmployee_Id { get; set; }
        public int  ProgrammeEmployee_Id { get; set; }
        public int  ProcurementApprovalAuthority_Id { get; set; }//Automatic
        public int  ProcurementSelectionMethod_Id { get; set; }
        public int  ProcurementPaymentType_Id { get; set; }


        //Process Attributes
        public LocalDate WPDocTORSubmissionDate_Plan { get; set; }//Automatic Retrieve
        public LocalDate WPDocTORSubmissionDate_Actual { get; set; }

        public LocalDate WPDocTORApprovalDate_Plan { get; set; }
        public LocalDate WPDocTORApprovalDate_Actual { get; set; }

        public LocalDate WPAdvertiseREOIDate_Plan { get; set; }
        public LocalDate WPAdvertiseREOIDate_Actual { get; set; }

        public int  WPLeadTimeBeforeShortlist_IdPlan { get; set; }
        public int  WPLeadTimeBeforeShortlist_IdActual { get; set; }

        public LocalDate WPShortlistSubmissionDate_Plan { get; set; }
        public LocalDate WPShortlistSubmissionDate_Actual { get; set; }

        public LocalDate WPNoObjectionShortlistDate_Plan { get; set; }
        public LocalDate WPNoObjectionShortlistDate_Actual { get; set; }

        public LocalDate WPInvitationRFPQDate_Plan { get; set; }
        public LocalDate WPInvitationRFPQDate_Actual { get; set; }

        public LocalDate WPSubmissionOpeningDate_Plan { get; set; }
        public LocalDate WPSubmissionOpeningDate_Actual { get; set; }

        public LocalDate WPSubmissionEvaluationDate_Plan { get; set; }
        public LocalDate WPSubmissionEvaluationDate_Actual { get; set; }

        public LocalDate WPNoObjectionSubmissionEvaluationDate_Plan { get; set; }
        public LocalDate WPNoObjectionSubmissionEvaluationDate_Actual { get; set; }

        public LocalDate WPOpeningFinancialProposalsDate_Plan { get; set; }
        public LocalDate WPOpeningFinancialProposalsDate_Actual { get; set; }

        public LocalDate WPPreparationApprovalIPCDate_Plan { get; set; }
        public LocalDate WPPreparationApprovalIPCDate_Actual { get; set; }

        public LocalDate WPNegotiationDate_Plan { get; set; }
        public LocalDate WPNegotiationDate_Actual { get; set; }

        public LocalDate WPDraftContractVettingSubmissionDate_Plan { get; set; }
        public LocalDate WPDraftContractVettingSubmissionDate_Actual { get; set; }

        public LocalDate WPDraftContractVettingNoObjectionDate_Plan { get; set; }
        public LocalDate WPDraftContractVettingNoObjectionDate_Actual { get; set; }


        public string WPProcurementProcess_Status { get; set; }


        public LocalDate TransactionDate { get; set; }
        
    }
}