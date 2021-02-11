using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AUDANEPAD_Integrated.Migrations
{
    public partial class LookUp69 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LkUp_ProcurementApprovalAuthority",
                columns: table => new
                {
                    Record_Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Record_Name = table.Column<string>(maxLength: 255, nullable: false),
                    Record_Status = table.Column<bool>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LkUp_ProcurementApprovalAuthority", x => x.Record_Id);
                });

            migrationBuilder.CreateTable(
                name: "LkUp_ProcurementPaymentType",
                columns: table => new
                {
                    Record_Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Record_Name = table.Column<string>(maxLength: 255, nullable: false),
                    Record_Status = table.Column<bool>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LkUp_ProcurementPaymentType", x => x.Record_Id);
                });

            migrationBuilder.CreateTable(
                name: "LkUp_ProcurementSelectionMethod",
                columns: table => new
                {
                    Record_Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Record_Name = table.Column<string>(maxLength: 255, nullable: false),
                    Record_Status = table.Column<bool>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LkUp_ProcurementSelectionMethod", x => x.Record_Id);
                });

            migrationBuilder.CreateTable(
                name: "Trans_ProcurementApprovalAuthority",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    Record_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trans_ProcurementApprovalAuthority", x => x.Transaction_Id);
                });

            migrationBuilder.CreateTable(
                name: "Trans_ProcurementPaymentType",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    Record_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trans_ProcurementPaymentType", x => x.Transaction_Id);
                });

            migrationBuilder.CreateTable(
                name: "Trans_ProcurementSelectionMethod",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    Record_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trans_ProcurementSelectionMethod", x => x.Transaction_Id);
                });

            migrationBuilder.CreateTable(
                name: "WP_ProcurementProcess",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    WPProcurement_Id = table.Column<string>(nullable: true),
                    ProcurementEmployee_Id = table.Column<int>(nullable: false),
                    ProgrammeEmployee_Id = table.Column<int>(nullable: false),
                    ProcurementApprovalAuthority_Id = table.Column<int>(nullable: false),
                    ProcurementSelectionMethod_Id = table.Column<int>(nullable: false),
                    ProcurementPaymentType_Id = table.Column<int>(nullable: false),
                    WPDocTORSubmissionDate_Plan = table.Column<DateTime>(nullable: false),
                    WPDocTORSubmissionDate_Actual = table.Column<DateTime>(nullable: false),
                    WPDocTORApprovalDate_Plan = table.Column<DateTime>(nullable: false),
                    WPDocTORApprovalDate_Actual = table.Column<DateTime>(nullable: false),
                    WPAdvertiseREOIDate_Plan = table.Column<DateTime>(nullable: false),
                    WPAdvertiseREOIDate_Actual = table.Column<DateTime>(nullable: false),
                    WPLeadTimeBeforeShortlist_IdPlan = table.Column<int>(nullable: false),
                    WPLeadTimeBeforeShortlist_IdActual = table.Column<int>(nullable: false),
                    WPShortlistSubmissionDate_Plan = table.Column<DateTime>(nullable: false),
                    WPShortlistSubmissionDate_Actual = table.Column<DateTime>(nullable: false),
                    WPNoObjectionShortlistDate_Plan = table.Column<DateTime>(nullable: false),
                    WPNoObjectionShortlistDate_Actual = table.Column<DateTime>(nullable: false),
                    WPInvitationRFPQDate_Plan = table.Column<DateTime>(nullable: false),
                    WPInvitationRFPQDate_Actual = table.Column<DateTime>(nullable: false),
                    WPSubmissionOpeningDate_Plan = table.Column<DateTime>(nullable: false),
                    WPSubmissionOpeningDate_Actual = table.Column<DateTime>(nullable: false),
                    WPSubmissionEvaluationDate_Plan = table.Column<DateTime>(nullable: false),
                    WPSubmissionEvaluationDate_Actual = table.Column<DateTime>(nullable: false),
                    WPNoObjectionSubmissionEvaluationDate_Plan = table.Column<DateTime>(nullable: false),
                    WPNoObjectionSubmissionEvaluationDate_Actual = table.Column<DateTime>(nullable: false),
                    WPOpeningFinancialProposalsDate_Plan = table.Column<DateTime>(nullable: false),
                    WPOpeningFinancialProposalsDate_Actual = table.Column<DateTime>(nullable: false),
                    WPPreparationApprovalIPCDate_Plan = table.Column<DateTime>(nullable: false),
                    WPPreparationApprovalIPCDate_Actual = table.Column<DateTime>(nullable: false),
                    WPNegotiationDate_Plan = table.Column<DateTime>(nullable: false),
                    WPNegotiationDate_Actual = table.Column<DateTime>(nullable: false),
                    WPDraftContractVettingSubmissionDate_Plan = table.Column<DateTime>(nullable: false),
                    WPDraftContractVettingSubmissionDate_Actual = table.Column<DateTime>(nullable: false),
                    WPDraftContractVettingNoObjectionDate_Plan = table.Column<DateTime>(nullable: false),
                    WPDraftContractVettingNoObjectionDate_Actual = table.Column<DateTime>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WP_ProcurementProcess", x => x.Transaction_Id);
                });

            migrationBuilder.CreateTable(
                name: "WP_ProcurementWorkLoadAssignment",
                columns: table => new
                {
                    Transaction_Id = table.Column<string>(nullable: false),
                    WPProcurement_Id = table.Column<string>(nullable: true),
                    Employee_Id = table.Column<int>(nullable: false),
                    ProcurementApprovalAuthority_Id = table.Column<int>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WP_ProcurementWorkLoadAssignment", x => x.Transaction_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LkUp_ProcurementApprovalAuthority");

            migrationBuilder.DropTable(
                name: "LkUp_ProcurementPaymentType");

            migrationBuilder.DropTable(
                name: "LkUp_ProcurementSelectionMethod");

            migrationBuilder.DropTable(
                name: "Trans_ProcurementApprovalAuthority");

            migrationBuilder.DropTable(
                name: "Trans_ProcurementPaymentType");

            migrationBuilder.DropTable(
                name: "Trans_ProcurementSelectionMethod");

            migrationBuilder.DropTable(
                name: "WP_ProcurementProcess");

            migrationBuilder.DropTable(
                name: "WP_ProcurementWorkLoadAssignment");
        }
    }
}
