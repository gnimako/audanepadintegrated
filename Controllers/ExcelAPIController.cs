using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Globalization;
using AUDANEPAD_Integrated.Interfaces;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.ViewModels;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NodaTime;
using System.Threading;


using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System.Drawing;



namespace AUDANEPAD_Integrated.Controllers
{
    public class ExcelAPIController: Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        
        private readonly UserManager<ApplicationUser> userManager;

      
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ILkUp_ActivityTypeRepository _lkupActivityTypeRepository;
        private readonly ILkUp_DSATypeRepository _lkupDSATypeRepository;
        private readonly ILkUp_CostCatelogueRepository _lkupCostCatelogueRepository ;
        private readonly ILkUp_CommsChannelRepository _lkupCommsChannelRepository ;
        private readonly ILkUp_CountryRepository _lkupCountryRepository ;
        private readonly ILkUp_ExtParticipantTypeRepository _lkupExtParticipantTypeRepository ;
        private readonly ILkUp_FiscalYearRepository _lkupFiscalYearRepository ;
        private readonly ILkUp_ImplementationTypeRepository _lkupImplementationTypeRepository  ;
        private readonly ILkUp_LeadershipStatusRepository _lkupLeadershipStatusRepository ;
        private readonly ILkUp_ParticipantTypeRepository _lkupParticipantTypeRepository ;
        private readonly ILkUp_ProcurementTypeRepository _lkupProcurementTypeRepository ;
        private readonly ILkUp_RiskCategoryRepository _lkupRiskCategoryRepository ;
        private readonly ILkUp_RiskImpactRepository _lkupRiskImpactRepository ;
        private readonly ILkUp_RiskProbabilityRepository _lkupRiskProbabilityRepository ;
        private readonly ILkUp_RiskRTimeframeRepository _lkupRiskRTimeframeRepository ;
        private readonly ILkUp_PeopleTypeRepository _lkupPeopleTypeRepository ;
        private readonly ILkUp_ProcurementLTimeRepository _lkupProcurementLTimeRepository ;
        private readonly ILkUp_ProjectScopeRepository _lkupProjectScopeRepository ;
        private readonly ILkUp_RegionScopeRepository _lkupRegionScopeRepository ;
        private readonly ILkUp_MobilityLimitsRepository _lkupMobilityLimitsRepository ;
        private readonly IStrategy_PriorityRepository _strategyPriorityRepository ;
        private readonly IStrategy_MTPRepository _strategyMTPRepository;
        private readonly IStrategy_MTPPriorityMappingRepository _strategyMTPPriorityMappingRepository ;
        private readonly IStrategy_KeyPerformanceAreaRepository _strategyKeyPerformanceAreaRepository;
        private readonly IStrategy_OutputIndicatorsRepository _strategyOutputIndicatorsRepository ;
        private readonly IStrategy_OutputIndicatorsPriorityMappingRepository _strategyOutputIndicatorsPriorityMappingRepository;
        private readonly IStruc_DirectorateRepository _strucDirectorateRepository ;
        private readonly IStruc_DivisionRepository _strucDivisionRepository;
        private readonly IStruc_DirDivIndicatorsRepository _strucDirDivIndicatorsRepository;
        private readonly ILkUp_ProgrammeRepository _lkupProgrammeRepository;
        private readonly ILkUp_ProjectRepository _lkupProjectRepository;
        private readonly ILkUp_PeriodRepository _lkupPeriodRepository;
        private readonly ILkUp_IndicatorTypeRepository _lkupIndicatorTypeRepository;


        private readonly ITrans_ActivityTypeRepository _transActivityTypeRepository;
        private readonly ITrans_DSATypeRepository _transDSATypeRepository;
        private readonly ITrans_CostCatelogueRepository _transCostCatelogueRepository;
        private readonly ITrans_CommsChannelRepository _transCommsChannelRepository;
        private readonly ITrans_CountryRepository _transCountryRepository;
        private readonly ITrans_ExtParticipantTypeRepository _transExtParticipantTypeRepository ;
        private readonly ITrans_FiscalYearRepository _transFiscalYearRepository ;
        private readonly ITrans_ImplementationTypeRepository _transImplementationTypeRepository  ;
        private readonly ITrans_LeadershipStatusRepository _transLeadershipStatusRepository ;
        private readonly ITrans_ParticipantTypeRepository _transParticipantTypeRepository ;
        private readonly ITrans_ProcurementTypeRepository _transProcurementTypeRepository ;
        private readonly ITrans_RiskCategoryRepository _transRiskCategoryRepository  ;
        private readonly ITrans_RiskImpactRepository _transRiskImpactRepository;
        private readonly ITrans_RiskProbabilityRepository _transRiskProbabilityRepository ;
        private readonly ITrans_RiskRTimeframeRepository _transRiskRTimeframeRepository ;
        private readonly ITrans_PeopleTypeRepository _transPeopleTypeRepository ;
        private readonly ITrans_ProcurementLTimeRepository _transProcurementLTimeRepository;
        private readonly ITrans_ProjectScopeRepository _transProjectScopeRepository ;
        private readonly ITrans_RegionScopeRepository _transRegionScopeRepository ;
        private readonly ITrans_MobilityLimitsRepository _transMobilityLimitsRepository ;
        private readonly ITrans_StrategyPriorityRepository _transStrategyPriorityRepository ;
        private readonly ITrans_StrategyMTPRepository _transStrategyMTPRepository ;
        private readonly ITrans_StrategyKeyPerformanceAreaRepository _transStrategyKeyPerformanceAreaRepository  ;
        private readonly ITrans_StrategyOutputIndicators _transStrategyOutputIndicators  ;
        private readonly ITrans_StrucDirectorateRepository _transStrucDirectorateRepository  ;
        private readonly ITrans_StrucDivisionRepository _transStrucDivisionRepository  ;
        private readonly ITrans_StrucDirDivIndicatorsRepository _transStrucDirDivIndicatorsRepository  ;
        private readonly ITrans_ProgrammeRepository _transProgrammeRepository ;
        private readonly ITrans_ProjectRepository _transProjectRepository  ;
        private readonly ITrans_PeriodRepository _transPeriodRepository ;
        private readonly ITrans_IndicatorTypeRepository _transIndicatorTypeRepository ;
        private readonly ISystem_AuditRepository _sysSystemAuditRepository;

        


        private readonly IStruc_DirStaffMappingRepository _strucDirStaffMappingRepository  ;
        private readonly IStruc_DivStaffMappingRepository _strucDivStaffMappingRepository  ;

        private readonly IStruc_DirectorRepository _strucDirectorRepository   ;
        private readonly IStruc_DirectorOICRepository _strucDirectorOICRepository   ;
        private readonly IStruc_DivHeadRepository _strucDivHeadRepository   ;
        private readonly IStruc_DivHeadOICRepository _strucDivHeadOICRepository  ;
        private readonly IEmailSender _emailSender  ;

        //Workplans
        private readonly IWP_DispatchCycleRepository _wpDispatchCycleRepository;
        private readonly IWP_MainRecordRepository _wpMainRecordRepository;
        private readonly IWP_OutcomesRepository _wpOutcomesRepository;
        private readonly IWP_MTPRepository _wpMTPRepository;
        private readonly IWP_AUDAPriorityRepository _wpAUDAPriorityRepository;
        private readonly IWP_ApprovalStatusRepository _wpApprovalStatusRepository;
        private readonly IWP_RegionScopeRepository _wpRegionScopeRepository;
        private readonly IWP_CountryScopeRepository _wpCountryScopeRepository ;
        private readonly IWP_OutputsRepository _wpOutputsRepository ;
        private readonly IWP_OutcomeIndicatorsRepository _wpOutcomeIndicatorsRepository ;
        private readonly IWP_OutputIndicatorsRepository _wpOutputIndicatorsRepository ;
        private readonly IWP_OutputActivitiesRepository _wpOutputActivitiesRepository ;
        private readonly IWP_SAPLinkRepository _wpSAPLinkRepository  ;
        private readonly IWP_OutputBudgetRepository _wpOutputBudgetRepository ;
        private readonly IWP_OutputActivityCountriesRepository _wpOutputActivityCountriesRepository;
        private readonly IWP_MobilityRepository _wpMobilityRepository;
        private readonly IWP_MobilityInternalTeamRepository _wpMobilityInternalTeamRepository;
        private readonly IWP_MobilityExternalTeamRepository _wpMobilityExternalTeamRepository;
        private readonly IWP_MobilityLimitRepository _wpMobilityLimitRepository;
        private readonly IWP_BarCodeIdentsRepository _wpBarCodeIdentsRepository;
        private readonly IWP_CommunicationRepository _wpCommunicationRepository;
        private readonly IWP_PRCBudgetLimitsRepository _wpPRCBudgetLimitsRepository;
        private readonly IWP_ProcurementRepository _wpProcurementRepository;
        private readonly IWP_RiskProfileRepository _wpRiskProfileRepository;
        private readonly IWP_RiskProfileCountriesRepository _wpRiskProfileCountriesRepository;

        //Procurement Automation
        private readonly ILkUp_ProcurementApprovalAuthorityRepository _lkupProcurementApprovalAuthorityRepository ;
        private readonly ILkUp_ProcurementSelectionMethodRepository _lkupProcurementSelectionMethodRepository ;
        private readonly ILkUp_ProcurementPaymentTypeRepository _lkupProcurementPaymentTypeRepository ;
        private readonly ITrans_ProcurementApprovalAuthorityRepository _transProcurementApprovalAuthorityRepository;
        private readonly ITrans_ProcurementSelectionMethodRepository _transProcurementSelectionMethodRepository;
        private readonly ITrans_ProcurementPaymentTypeRepository _transProcurementPaymentTypeRepository;
        private readonly IWP_ProcurementWorkLoadAssignmentRepository _wpProcurementWorkLoadAssignmentRepository;
        private readonly IWP_ProcurementProcessRepository _wpProcurementProcessRepository;
        private readonly IWP_TasksRepository _wpTasksRepository;
        private readonly ILkUp_ProcurementProcessStepsRepository _lkupProcurementProcessStepsRepository;
        private readonly ITrans_ProcurementProcessStepsRepository _transProcurementProcessStepsReposity;
        private readonly IWP_ProcurementProcessStepsRepository _wpProcurementProcessStepsRepository;
        private readonly IWP_ProcurementTORDocsRepository _wpProcurementTORDocsRepository;




        private readonly AppDbContext _context;

        private readonly IWebHostEnvironment hostingEnvironment;

        public ExcelAPIController(IEmployeeRepository employeeRepository,
                                UserManager<ApplicationUser> userManager,
                                RoleManager<IdentityRole> roleManager,
                                SignInManager<ApplicationUser> signInManager,
                                AppDbContext context,
                                IWebHostEnvironment hostingEnvironment,
                                ILkUp_ActivityTypeRepository lkupActivityTypeRepository,
                                ILkUp_DSATypeRepository lkupDSATypeRepository,
                                ILkUp_CostCatelogueRepository lkupCostCatelogueRepository,
                                ILkUp_CommsChannelRepository lkupCommsChannelRepository,
                                ILkUp_CountryRepository lkupCountryRepository,
                                ILkUp_ExtParticipantTypeRepository lkupExtParticipantTypeRepository,
                                ILkUp_FiscalYearRepository lkupFiscalYearRepository,
                                ILkUp_ImplementationTypeRepository lkupImplementationTypeRepository,
                                ILkUp_LeadershipStatusRepository lkupLeadershipStatusRepository,
                                ILkUp_ParticipantTypeRepository lkupParticipantTypeRepository,
                                ILkUp_ProcurementTypeRepository lkupProcurementTypeRepository, 
                                ILkUp_RiskCategoryRepository lkupRiskCategoryRepository, 
                                ILkUp_RiskImpactRepository lkupRiskImpactRepository, 
                                ILkUp_RiskProbabilityRepository lkupRiskProbabilityRepository,
                                ILkUp_RiskRTimeframeRepository lkupRiskRTimeframeRepository,
                                ILkUp_PeopleTypeRepository lkupPeopleTypeRepository ,
                                ILkUp_ProcurementLTimeRepository lkupProcurementLTimeRepository ,
                                ILkUp_ProjectScopeRepository lkupProjectScopeRepository,
                                ILkUp_RegionScopeRepository lkupRegionScopeRepository ,
                                ILkUp_MobilityLimitsRepository lkupMobilityLimitsRepository ,
                                IStrategy_PriorityRepository strategyPriorityRepository,
                                IStrategy_MTPRepository strategyMTPRepository,
                                IStrategy_MTPPriorityMappingRepository strategyMTPPriorityMappingRepository,
                                IStrategy_KeyPerformanceAreaRepository strategyKeyPerformanceAreaRepository,
                                IStrategy_OutputIndicatorsRepository strategyOutputIndicatorsRepository,
                                IStrategy_OutputIndicatorsPriorityMappingRepository strategyOutputIndicatorsPriorityMappingRepository,
                                IStruc_DirectorateRepository strucDirectorateRepository,
                                IStruc_DivisionRepository strucDivisionRepository,
                                IStruc_DirDivIndicatorsRepository strucDirDivIndicatorsRepository,
                                ILkUp_ProgrammeRepository lkupProgrammeRepository,
                                ILkUp_ProjectRepository lkupProjectRepository,
                                ILkUp_PeriodRepository lkupPeriodRepository,
                                ILkUp_IndicatorTypeRepository lkupIndicatorTypeRepository,

                                ITrans_ActivityTypeRepository transActivityTypeRepository,
                                ITrans_DSATypeRepository transDSATypeRepository,
                                ITrans_CostCatelogueRepository transCostCatelogueRepository,
                                ITrans_CommsChannelRepository transCommsChannelRepository,
                                ITrans_CountryRepository transCountryRepository,
                                ITrans_ExtParticipantTypeRepository transExtParticipantTypeRepository,
                                ITrans_FiscalYearRepository transFiscalYearRepository,
                                ITrans_ImplementationTypeRepository transImplementationTypeRepository,
                                ITrans_LeadershipStatusRepository transLeadershipStatusRepository,
                                ITrans_ParticipantTypeRepository transParticipantTypeRepository,
                                ITrans_ProcurementTypeRepository transProcurementTypeRepository,
                                ITrans_RiskCategoryRepository transRiskCategoryRepository,
                                ITrans_RiskImpactRepository transRiskImpactRepository,
                                ITrans_RiskProbabilityRepository transRiskProbabilityRepository,
                                ITrans_RiskRTimeframeRepository transRiskRTimeframeRepository,
                                ITrans_PeopleTypeRepository transPeopleTypeRepository ,
                                ITrans_ProcurementLTimeRepository transProcurementLTimeRepository,
                                ITrans_ProjectScopeRepository transProjectScopeRepository,
                                ITrans_RegionScopeRepository transRegionScopeRepository,
                                ITrans_MobilityLimitsRepository transMobilityLimitsRepository,
                                ITrans_StrategyPriorityRepository transStrategyPriorityRepository,
                                ITrans_StrategyMTPRepository transStrategyMTPRepository,
                                ITrans_StrategyKeyPerformanceAreaRepository transStrategyKeyPerformanceAreaRepository,
                                ITrans_StrategyOutputIndicators transStrategyOutputIndicators,
                                ITrans_StrucDirectorateRepository transStrucDirectorateRepository,
                                ITrans_StrucDivisionRepository transStrucDivisionRepository,   
                                ITrans_StrucDirDivIndicatorsRepository transStrucDirDivIndicatorsRepository ,
                                ITrans_ProgrammeRepository transProgrammeRepository, 
                                ITrans_ProjectRepository transProjectRepository, 
                                ITrans_PeriodRepository transPeriodRepository,
                                ITrans_IndicatorTypeRepository transIndicatorTypeRepository,
                                ISystem_AuditRepository sysSystemAuditRepository,
                                IStruc_DirStaffMappingRepository strucDirStaffMappingRepository,
                                IStruc_DivStaffMappingRepository strucDivStaffMappingRepository,
                                IStruc_DirectorRepository strucDirectorRepository,
                                IStruc_DirectorOICRepository strucDirectorOICRepository,
                                IStruc_DivHeadRepository strucDivHeadRepository,
                                IStruc_DivHeadOICRepository strucDivHeadOICRepository,
                                IEmailSender emailSender,
                                //workplans
                                IWP_DispatchCycleRepository wpDispatchCycleRepository,
                                IWP_MainRecordRepository wpMainRecordRepository,
                                IWP_OutcomesRepository wpOutcomesRepository,
                                IWP_MTPRepository wpMTPRepository,
                                IWP_AUDAPriorityRepository wpAUDAPriorityRepository,
                                IWP_ApprovalStatusRepository wpApprovalStatusRepository,
                                IWP_RegionScopeRepository wpRegionScopeRepository,
                                IWP_CountryScopeRepository wpCountryScopeRepository,
                                IWP_OutputsRepository wpOutputsRepository,
                                IWP_OutcomeIndicatorsRepository wpOutcomeIndicatorsRepository,
                                IWP_OutputIndicatorsRepository wpOutputIndicatorsRepository,
                                IWP_OutputActivitiesRepository wpOutputActivitiesRepository,
                                IWP_SAPLinkRepository wpSAPLinkRepository,
                                IWP_OutputBudgetRepository wpOutputBudgetRepository,
                                IWP_OutputActivityCountriesRepository wpOutputActivityCountriesRepository,
                                IWP_MobilityRepository wpMobilityRepository,
                                IWP_MobilityInternalTeamRepository wpMobilityInternalTeamRepository,
                                IWP_MobilityExternalTeamRepository wpMobilityExternalTeamRepository,
                                IWP_MobilityLimitRepository wpMobilityLimitRepository,
                                IWP_BarCodeIdentsRepository wpBarCodeIdentsRepository,
                                IWP_CommunicationRepository wpCommunicationRepository,
                                IWP_PRCBudgetLimitsRepository wpPRCBudgetLimitsRepository,
                                IWP_ProcurementRepository wpProcurementRepository,
                                IWP_RiskProfileRepository wpRiskProfileRepository,
                                IWP_RiskProfileCountriesRepository wpRiskProfileCountriesRepository,
                                
                                //Procurement Automation
                                ILkUp_ProcurementApprovalAuthorityRepository lkupProcurementApprovalAuthorityRepository,
                                ILkUp_ProcurementSelectionMethodRepository lkupProcurementSelectionMethodRepository,
                                ILkUp_ProcurementPaymentTypeRepository lkupProcurementPaymentTypeRepository,
                                ITrans_ProcurementApprovalAuthorityRepository transProcurementApprovalAuthorityRepository,
                                ITrans_ProcurementSelectionMethodRepository transProcurementSelectionMethodRepository,
                                ITrans_ProcurementPaymentTypeRepository transProcurementPaymentTypeRepository,
                                IWP_ProcurementWorkLoadAssignmentRepository wpProcurementWorkLoadAssignmentRepository,
                                IWP_ProcurementProcessRepository wpProcurementProcessRepository,
                                IWP_TasksRepository wpTasksRepository,
                                ILkUp_ProcurementProcessStepsRepository lkupProcurementProcessStepsRepository,
                                ITrans_ProcurementProcessStepsRepository transProcurementProcessStepsReposity,
                                IWP_ProcurementProcessStepsRepository wpProcurementProcessStepsRepository,
                                IWP_ProcurementTORDocsRepository wpProcurementTORDocsRepository)
        {
            this._employeeRepository = employeeRepository;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            this.hostingEnvironment = hostingEnvironment;

            _lkupActivityTypeRepository=lkupActivityTypeRepository;
            _lkupDSATypeRepository=lkupDSATypeRepository;
            _lkupCostCatelogueRepository=lkupCostCatelogueRepository;
            _lkupCommsChannelRepository=lkupCommsChannelRepository;
            _lkupCountryRepository=lkupCountryRepository;
            _lkupExtParticipantTypeRepository=lkupExtParticipantTypeRepository;
            _lkupFiscalYearRepository=lkupFiscalYearRepository;
            _lkupImplementationTypeRepository=lkupImplementationTypeRepository;
            _lkupLeadershipStatusRepository=lkupLeadershipStatusRepository;
            _lkupParticipantTypeRepository=lkupParticipantTypeRepository;
            _lkupProcurementTypeRepository=lkupProcurementTypeRepository; 
            _lkupRiskCategoryRepository=lkupRiskCategoryRepository; 
            _lkupRiskImpactRepository=lkupRiskImpactRepository;
            _lkupRiskProbabilityRepository=lkupRiskProbabilityRepository;
            _lkupRiskRTimeframeRepository=lkupRiskRTimeframeRepository;
            _lkupPeopleTypeRepository =lkupPeopleTypeRepository;
            _lkupProcurementLTimeRepository =lkupProcurementLTimeRepository;
            _lkupProjectScopeRepository = lkupProjectScopeRepository;
            _lkupRegionScopeRepository= lkupRegionScopeRepository;
            _lkupProgrammeRepository=lkupProgrammeRepository;
            _lkupProjectRepository=lkupProjectRepository;
            _lkupPeriodRepository=lkupPeriodRepository;
            _lkupIndicatorTypeRepository=lkupIndicatorTypeRepository;
            _lkupMobilityLimitsRepository=lkupMobilityLimitsRepository;
            _strategyPriorityRepository=strategyPriorityRepository;
            _strategyMTPRepository=strategyMTPRepository;
            _strategyMTPPriorityMappingRepository=strategyMTPPriorityMappingRepository;
            _strategyKeyPerformanceAreaRepository=strategyKeyPerformanceAreaRepository;
            _strategyOutputIndicatorsRepository=strategyOutputIndicatorsRepository;
            _strategyOutputIndicatorsPriorityMappingRepository=strategyOutputIndicatorsPriorityMappingRepository;
            _strucDirectorateRepository=strucDirectorateRepository;
            _strucDivisionRepository=strucDivisionRepository;
            _strucDirDivIndicatorsRepository=strucDirDivIndicatorsRepository;


            _transActivityTypeRepository=transActivityTypeRepository;
            _transDSATypeRepository=transDSATypeRepository;
            _transCostCatelogueRepository=transCostCatelogueRepository;
            _transCommsChannelRepository=transCommsChannelRepository;
            _transCountryRepository=transCountryRepository;
            _transExtParticipantTypeRepository=transExtParticipantTypeRepository;
            _transFiscalYearRepository=transFiscalYearRepository;
            _transImplementationTypeRepository=transImplementationTypeRepository;
            _transLeadershipStatusRepository=transLeadershipStatusRepository;
            _transParticipantTypeRepository=transParticipantTypeRepository;
            _transProcurementTypeRepository =transProcurementTypeRepository ;
            _transRiskCategoryRepository =transRiskCategoryRepository  ;
            _transRiskImpactRepository =transRiskImpactRepository;
            _transRiskProbabilityRepository =transRiskProbabilityRepository ;
            _transRiskRTimeframeRepository =transRiskRTimeframeRepository ;
            _transPeopleTypeRepository =transPeopleTypeRepository;
            _transProcurementLTimeRepository=transProcurementLTimeRepository;
            _transProjectScopeRepository =transProjectScopeRepository;
            _transRegionScopeRepository= transRegionScopeRepository;
            _transMobilityLimitsRepository= transMobilityLimitsRepository;
            _transStrategyPriorityRepository=transStrategyPriorityRepository;
            _transStrategyMTPRepository=transStrategyMTPRepository;
            _transStrategyKeyPerformanceAreaRepository=transStrategyKeyPerformanceAreaRepository;
            _transStrategyOutputIndicators=transStrategyOutputIndicators;
            _transStrucDirectorateRepository=transStrucDirectorateRepository;
            _transStrucDivisionRepository=transStrucDivisionRepository;
            _transStrucDirDivIndicatorsRepository=transStrucDirDivIndicatorsRepository;
            _transProgrammeRepository=transProgrammeRepository;
            _transProjectRepository=transProjectRepository;
            _transPeriodRepository=transPeriodRepository;
            _transIndicatorTypeRepository=transIndicatorTypeRepository;
            _sysSystemAuditRepository=sysSystemAuditRepository;
            _strucDirStaffMappingRepository=strucDirStaffMappingRepository;
            _strucDivStaffMappingRepository=strucDivStaffMappingRepository;
            _strucDirectorRepository=strucDirectorRepository;
            _strucDirectorOICRepository=strucDirectorOICRepository;
            _strucDivHeadRepository=strucDivHeadRepository;
            _strucDivHeadOICRepository=strucDivHeadOICRepository;
            _emailSender=emailSender;

            //workplans
            _wpDispatchCycleRepository=wpDispatchCycleRepository;
            _wpMainRecordRepository=wpMainRecordRepository;
            _wpOutcomesRepository=wpOutcomesRepository;
            _wpMTPRepository=wpMTPRepository;
            _wpAUDAPriorityRepository=wpAUDAPriorityRepository;
            _wpApprovalStatusRepository=wpApprovalStatusRepository;
            _wpRegionScopeRepository=wpRegionScopeRepository;
            _wpCountryScopeRepository=wpCountryScopeRepository;
            _wpOutputsRepository=wpOutputsRepository;
            _wpOutcomeIndicatorsRepository=wpOutcomeIndicatorsRepository;
            _wpOutputIndicatorsRepository=wpOutputIndicatorsRepository;
            _wpOutputActivitiesRepository=wpOutputActivitiesRepository;
            _wpSAPLinkRepository=wpSAPLinkRepository;
            _wpOutputBudgetRepository=wpOutputBudgetRepository;
            _wpOutputActivityCountriesRepository=wpOutputActivityCountriesRepository;
            _wpMobilityRepository=wpMobilityRepository;
            _wpMobilityInternalTeamRepository=wpMobilityInternalTeamRepository;
            _wpMobilityExternalTeamRepository=wpMobilityExternalTeamRepository;
            _wpMobilityLimitRepository=wpMobilityLimitRepository;
            _wpBarCodeIdentsRepository=wpBarCodeIdentsRepository;
            _wpCommunicationRepository=wpCommunicationRepository;
            _wpPRCBudgetLimitsRepository=wpPRCBudgetLimitsRepository;
            _wpProcurementRepository=wpProcurementRepository;
            _wpRiskProfileRepository=wpRiskProfileRepository;
            _wpRiskProfileCountriesRepository=wpRiskProfileCountriesRepository;

            //Procurement Automation
            _lkupProcurementApprovalAuthorityRepository =lkupProcurementApprovalAuthorityRepository;
            _lkupProcurementSelectionMethodRepository =lkupProcurementSelectionMethodRepository;
            _lkupProcurementPaymentTypeRepository =lkupProcurementPaymentTypeRepository;
            _transProcurementApprovalAuthorityRepository=transProcurementApprovalAuthorityRepository;
            _transProcurementSelectionMethodRepository=transProcurementSelectionMethodRepository;
            _transProcurementPaymentTypeRepository=transProcurementPaymentTypeRepository;
            _wpProcurementWorkLoadAssignmentRepository=wpProcurementWorkLoadAssignmentRepository;
            _wpProcurementProcessRepository=wpProcurementProcessRepository;
            _wpTasksRepository=wpTasksRepository;
            _lkupProcurementProcessStepsRepository=lkupProcurementProcessStepsRepository;
            _transProcurementProcessStepsReposity=transProcurementProcessStepsReposity;
            _wpProcurementProcessStepsRepository=wpProcurementProcessStepsRepository;
            _wpProcurementTORDocsRepository=wpProcurementTORDocsRepository;
        



            _context = context;
            
        }

        public FileResult InstitutionalProcurementPlanExcel(string id, string periodid)
        {
            IWorkbook workbook;
            string path=@"wwwroot/appdirectory/excelreports/institutional/procurement/Procurement_Plan_Template_V1.xlsx";


            WP_DispatchCycle cyclerec=_wpDispatchCycleRepository.GetRecord(id);
            string pathtofile_save="";

           
      
            string periodname="";
            if(periodid=="1")
                periodname="Q1";
            else if (periodid=="2")
                periodname="Q2";
            else if (periodid=="3")
                periodname="Q3";
            else if (periodid=="4")
                periodname="Q4"; 
            else if (periodid=="5")
                periodname="Semester_1"; 
            else if (periodid=="6")
                periodname="Semester_2";
            else if (periodid=="7")
                periodname="Annual";
            else
            {
                DateTime pstart=new DateTime(cyclerec.PeriodStartDate.Year, cyclerec.PeriodStartDate.Month, cyclerec.PeriodStartDate.Day);
                DateTime pend=new DateTime(cyclerec.PeriodEndDate.Year, cyclerec.PeriodEndDate.Month, cyclerec.PeriodEndDate.Day);
                periodname=pstart.Date.ToString("MMM d, yyyy") + " - "+ pend.Date.ToString("MMM d, yyyy"); 
                
            }

            pathtofile_save=@"wwwroot/appdirectory/excelreports/institutional/procurement/Institutional_Procurement_Plan_" +_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name +"_" +periodname+".xlsx";
           


            try
            {
                //OPENING TEMPLATE STARTS HERE....
                    FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                    // Try to read workbook as XLSX:
                    try
                    {
                        workbook = new XSSFWorkbook(fs);
                    }
                    catch
                    {
                        workbook = null;
                    }

                    // If reading fails, try to read workbook as XLS:
                    if (workbook == null)
                    {
                        workbook = new HSSFWorkbook(fs);
                    }
                //OPENING TEMPLATE ENDS HERE....


                //EDITING TEMPLATE STARTS HERE....


                // HSSFFont cellfont = (HSSFFont)workbook.CreateFont();
                // cellfont.FontHeightInPoints = 11;
                // cellfont.FontName = "Tahoma";

                // Defining a border
                // HSSFCellStyle borderedCellStylenormal = (HSSFCellStyle)workbook.CreateCellStyle();
                // borderedCellStylenormal.SetFont(cellfont);
                // borderedCellStylenormal.BorderLeft = BorderStyle.Thin;
                // borderedCellStylenormal.BorderTop = BorderStyle.Thin;
                // borderedCellStylenormal.BorderRight = BorderStyle.Thin;
                // borderedCellStylenormal.BorderBottom = BorderStyle.Thin;
                // borderedCellStylenormal.VerticalAlignment = VerticalAlignment.Top;
                // borderedCellStylenormal.Alignment =HorizontalAlignment.Left;
                // borderedCellStylenormal.WrapText=true;

                IFont fontnormal = workbook.CreateFont();
                fontnormal.IsBold = false;
                fontnormal.FontHeightInPoints = 11;
                fontnormal.FontName="Arial";

                ICellStyle cellStyleNormal = workbook.CreateCellStyle();
                cellStyleNormal.SetFont(fontnormal);
                cellStyleNormal.BorderLeft = BorderStyle.Thin;
                cellStyleNormal.BorderTop = BorderStyle.Thin;
                cellStyleNormal.BorderRight = BorderStyle.Thin;
                cellStyleNormal.BorderBottom = BorderStyle.Thin;
                cellStyleNormal.VerticalAlignment = VerticalAlignment.Top;
                cellStyleNormal.Alignment =HorizontalAlignment.Left;
                cellStyleNormal.WrapText=true;


                ISheet worksheet = workbook.GetSheetAt(0);
                IRow row = worksheet.CreateRow(5);

               // CreateCell(row, 0, "Recruit Junior Programming consultant to support in the finalisation of the integrated work plan application", borderedCellStylenormal);


                ICell Cell = row.CreateCell(0);
                Cell.SetCellValue("Recruit Junior Programming consultant to support in the finalisation of the integrated work plan application");
                Cell.CellStyle = cellStyleNormal;


                //EDITING T TEMPLATE ENDS HERE....








                //SAVING TEMPLATE STARTS HERE....

                using (FileStream stream = new FileStream(pathtofile_save, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(stream);
                } 


                //SAVING TEMPLATE ENDS HERE....





            }
            catch (Exception)
            {

            }
           
           
           
           
           
           
            

            



            //Save File Ends Here...


            






            string contentType =  "application/vnd.ms-excel";//"application/pdf"
           // string pathtofile=@"wwwroot/appdirectory/excelreports/institutional/Procurement_Plan_2021.xlsx";
            
            string pathtofile="/appdirectory/excelreports/institutional/procurement/Institutional_Procurement_Plan_" +_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name +"_" +periodname+".xlsx";
           
            




            return File(pathtofile, contentType, "Institutional_Procurement_Plan_" +_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name +"_" +periodname+".xlsx");

        }


        public FileResult InstitutionalOutputsFullExcel(string id, string periodid)
        {
            IWorkbook workbook;
            string path=@"wwwroot/appdirectory/excelreports/institutional/finance/SAP_Budget_Load_Template_Annual.xlsx";


            WP_DispatchCycle cyclerec=_wpDispatchCycleRepository.GetRecord(id);
            string pathtofile_save="";

           
      
            string periodname="";
            if(periodid=="1")
                periodname="Q1";
            else if (periodid=="2")
                periodname="Q2";
            else if (periodid=="3")
                periodname="Q3";
            else if (periodid=="4")
                periodname="Q4"; 
            else if (periodid=="5")
                periodname="Semester_1"; 
            else if (periodid=="6")
                periodname="Semester_2";
            else if (periodid=="7")
                periodname="Annual";
            else
            {
                DateTime pstart=new DateTime(cyclerec.PeriodStartDate.Year, cyclerec.PeriodStartDate.Month, cyclerec.PeriodStartDate.Day);
                DateTime pend=new DateTime(cyclerec.PeriodEndDate.Year, cyclerec.PeriodEndDate.Month, cyclerec.PeriodEndDate.Day);
                periodname=pstart.Date.ToString("MMM d, yyyy") + " - "+ pend.Date.ToString("MMM d, yyyy"); 
                
            }

            pathtofile_save=@"wwwroot/appdirectory/excelreports/institutional/finance/Institutional_Workplan_Budget_Lines_" +_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name +"_" +periodname+".xlsx";
           


            try
            {
                //OPENING TEMPLATE STARTS HERE....
                    FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                    // Try to read workbook as XLSX:
                    try
                    {
                        workbook = new XSSFWorkbook(fs);
                    }
                    catch
                    {
                        workbook = null;
                    }

                    // If reading fails, try to read workbook as XLS:
                    if (workbook == null)
                    {
                        workbook = new HSSFWorkbook(fs);
                    }
                //OPENING TEMPLATE ENDS HERE....


                //EDITING TEMPLATE STARTS HERE....
                List<WP_OutputsGridVM> collection_recs = new List<WP_OutputsGridVM>();
                List<WP_OutputsGridVM> collection_recs_details = new List<WP_OutputsGridVM>();

            

            

                if (id != null && periodid!=null)
                {
                    

                    var DB_Records = _transStrucDirectorateRepository.GetAllRecords().ToList();
                    int _countrecs =  DB_Records.Count();

                    if(_countrecs>0)
                    {
                        foreach (var rec_set in DB_Records)
                        {
                            var DirMainRecs=_wpMainRecordRepository.GetRecordsByDirRecs(rec_set.Record_Id).ToList();
                                    

                            //Fetch the Directorate Project Records that correspond the cycle 
                            if(cyclerec.Period_Id==8)
                            {
                                DirMainRecs=_wpMainRecordRepository.GetRecordsByDirectorateYearAndPeriodStartEnd(rec_set.Record_Id, cyclerec.FiscalYear_Id,cyclerec.Period_Id, cyclerec.PeriodStartDate, cyclerec.PeriodEndDate).ToList();
                            }
                            else
                            {
                                DirMainRecs=_wpMainRecordRepository.GetRecordsByDirectorateYearAndPeriod(rec_set.Record_Id, cyclerec.FiscalYear_Id,cyclerec.Period_Id).ToList();
                            }

                            if(DirMainRecs.Count()>0)
                            {


                                foreach (var mproject in DirMainRecs)
                                {
                                    //Get Periorities
                                    var DB_MainProjsPriorities=_wpAUDAPriorityRepository.GetRecordsByMainRecordId(mproject.Transaction_Id);
                                    string rtnstringPriorities = string.Empty;
                                    int prioritycount=0;
                                    foreach(var record in DB_MainProjsPriorities)
                                    {
                                        prioritycount=prioritycount+1;
                                        Strategy_Priority priority=_strategyPriorityRepository.GetRecord(record.Priority_Id);

                                        if(prioritycount==DB_MainProjsPriorities.Count())
                                        {
                                            rtnstringPriorities += "("+prioritycount.ToString()+") " + priority.Record_Name.TrimEnd();  

                                        }
                                        else
                                        {
                                            rtnstringPriorities += "("+prioritycount.ToString()+") " + priority.Record_Name.TrimEnd()+", ";  
                                        }

                                    }


                                    

                                    //Get WP_RiskProfiles

                                    var CategoryRecs=_wpOutputsRepository.GetRecordsByMainRecordId(mproject.Transaction_Id).ToList();

                                    
                                    foreach(var record in CategoryRecs)
                                    {
                                        int ms_count=0;
                                        int dp_count=0;
                                        string fundssource="";
                                        string outputlinktype="";

                                        WP_MainRecord mainrec=_wpMainRecordRepository.GetRecord(record.WPMainRecord_id);

                                        //Total Output Budget
                                        var DB_Activities_Recs=_wpOutputActivitiesRepository.GetRecordsByOutputId(record.Transaction_Id).ToList();
                                        double output_total_budget=0;
                                        foreach (var _innerrec in DB_Activities_Recs)
                                        {
                                            output_total_budget=output_total_budget+_innerrec.ActivityCost;

                                            if(_innerrec.PartnerFunding==true)
                                            {
                                                dp_count=dp_count+1;
                                            }
                                            else
                                            {
                                                ms_count=ms_count+1;
                                            }
                                        }

                                        //Q1 Computation
                                        double q1_output_budget=0;

                                        var DB_Mobilities_Recs=_wpMobilityRepository.GetRecordsByOutputIdStartEndRange(record.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 1, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 3, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 3))).ToList();
                                        var DB_Mobilities_Recs_All=_wpMobilityRepository.GetRecordsByOutputId(record.Transaction_Id).ToList(); 


                                        var DB_Procurement_Recs_All=_wpProcurementRepository.GetRecordsByOutputId(record.Transaction_Id).ToList();
                                        var DB_Procurement_Recs=_wpProcurementRepository.GetRecordsByOutputIdStartEndRange(record.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 1, 1),
                                                                                                                                                new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 3, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 3))).ToList();                                                                                                          
                                        
                                        var DB_Communication_Recs_All=_wpCommunicationRepository.GetRecordsByOutputId(record.Transaction_Id).ToList();
                                        var DB_Communication_Recs=_wpCommunicationRepository.GetRecordsByOutputIdStartEndRange(record.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 1, 1),
                                                                                                                                                new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 3, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 3))).ToList();

                                        //inner totals
                                        double output_dp_budget=0;
                                        double output_ms_budget=0;
                                        double output_budget_all=0;  

                                        //Sum as DP
                                        if(dp_count>ms_count)
                                        {
                                            foreach (var _innerrec in DB_Mobilities_Recs)
                                            {
                                                output_dp_budget=output_dp_budget+_innerrec.MobilityCost;
                                            }

                                            foreach (var _innerrec in DB_Procurement_Recs)
                                            {
                                                output_dp_budget=output_dp_budget+_innerrec.WPProcurementCost;
                                            }

                                            foreach (var _innerrec in DB_Communication_Recs)
                                            {
                                                output_dp_budget=output_dp_budget+_innerrec.WPCommsCost;
                                            }

                                            //Get the Overall Total for Mobility, Procurement and Communication 
                                            
                                            foreach (var _innerrec in DB_Mobilities_Recs_All)
                                            {
                                                output_budget_all=output_budget_all+_innerrec.MobilityCost;
                                            }

                                            foreach (var _innerrec in DB_Procurement_Recs_All)
                                            {
                                                output_budget_all=output_budget_all+_innerrec.WPProcurementCost;
                                            }

                                            foreach (var _innerrec in DB_Communication_Recs_All)
                                            {
                                                output_budget_all=output_budget_all+_innerrec.WPCommsCost;
                                            }

                                            double remainingfunds=output_total_budget-output_budget_all;

                                            //Add Adjust Cost to DP
                                            
                                            if(remainingfunds!=0)
                                                output_dp_budget=output_dp_budget+(remainingfunds/4.0);
                                           
                                            

                                            q1_output_budget=q1_output_budget+output_dp_budget;
                                                
                                        }
                                        else //Sum as MS
                                        {
                                            foreach (var _innerrec in DB_Mobilities_Recs)
                                            {
                                                output_ms_budget=output_ms_budget+_innerrec.MobilityCost;
                                            }

                                            foreach (var _innerrec in DB_Procurement_Recs)
                                            {
                                                output_ms_budget=output_ms_budget+_innerrec.WPProcurementCost;
                                            }

                                            foreach (var _innerrec in DB_Communication_Recs)
                                            {
                                                output_ms_budget=output_ms_budget+_innerrec.WPCommsCost;
                                            }

                                            //Get the Overall Total for Mobility, Procurement and Communication 
                                            
                                            foreach (var _innerrec in DB_Mobilities_Recs_All)
                                            {
                                                output_budget_all=output_budget_all+_innerrec.MobilityCost;
                                            }

                                            foreach (var _innerrec in DB_Procurement_Recs_All)
                                            {
                                                output_budget_all=output_budget_all+_innerrec.WPProcurementCost;
                                            }

                                            foreach (var _innerrec in DB_Communication_Recs_All)
                                            {
                                                output_budget_all=output_budget_all+_innerrec.WPCommsCost;
                                            }
                                            double remainingfunds=output_total_budget-output_budget_all;

                                            //Add Adjust Cost to DP
                                            
                                            if(remainingfunds!=0)
                                                output_ms_budget=output_ms_budget+(remainingfunds/4.0);
                                            
                                            

                                            q1_output_budget=q1_output_budget+output_ms_budget;

                                        } 


                                        //Q2 Computation
                                        double q2_output_budget=0;

                                        DB_Mobilities_Recs=_wpMobilityRepository.GetRecordsByOutputIdStartEndRange(record.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 4, 1),
                                                                                                                                                new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6))).ToList();
             

                   
                                        DB_Procurement_Recs=_wpProcurementRepository.GetRecordsByOutputIdStartEndRange(record.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 4, 1),
                                                                                                                                                new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6))).ToList();                                                                                                         
                                        
                               
                                        DB_Communication_Recs=_wpCommunicationRepository.GetRecordsByOutputIdStartEndRange(record.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 4, 1),
                                                                                                                                                new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6))).ToList();

                                        //inner totals
                                        output_dp_budget=0;
                                        output_ms_budget=0;
                                        output_budget_all=0; 


                                        //Sum as DP
                                        if(dp_count>ms_count)
                                        {
                                            foreach (var _innerrec in DB_Mobilities_Recs)
                                            {
                                                output_dp_budget=output_dp_budget+_innerrec.MobilityCost;
                                            }

                                            foreach (var _innerrec in DB_Procurement_Recs)
                                            {
                                                output_dp_budget=output_dp_budget+_innerrec.WPProcurementCost;
                                            }

                                            foreach (var _innerrec in DB_Communication_Recs)
                                            {
                                                output_dp_budget=output_dp_budget+_innerrec.WPCommsCost;
                                            }

                                            //Get the Overall Total for Mobility, Procurement and Communication 
                                            
                                            foreach (var _innerrec in DB_Mobilities_Recs_All)
                                            {
                                                output_budget_all=output_budget_all+_innerrec.MobilityCost;
                                            }

                                            foreach (var _innerrec in DB_Procurement_Recs_All)
                                            {
                                                output_budget_all=output_budget_all+_innerrec.WPProcurementCost;
                                            }

                                            foreach (var _innerrec in DB_Communication_Recs_All)
                                            {
                                                output_budget_all=output_budget_all+_innerrec.WPCommsCost;
                                            }

                                            double remainingfunds=output_total_budget-output_budget_all;

                                            //Add Adjust Cost to DP
                                           
                                            if(remainingfunds!=0)
                                                output_dp_budget=output_dp_budget+(remainingfunds/4.0);
                                           

                                            q2_output_budget=q2_output_budget+output_dp_budget;
                                                
                                        }
                                        else //Sum as MS
                                        {
                                            foreach (var _innerrec in DB_Mobilities_Recs)
                                            {
                                                output_ms_budget=output_ms_budget+_innerrec.MobilityCost;
                                            }

                                            foreach (var _innerrec in DB_Procurement_Recs)
                                            {
                                                output_ms_budget=output_ms_budget+_innerrec.WPProcurementCost;
                                            }

                                            foreach (var _innerrec in DB_Communication_Recs)
                                            {
                                                output_ms_budget=output_ms_budget+_innerrec.WPCommsCost;
                                            }

                                            //Get the Overall Total for Mobility, Procurement and Communication 
                                            
                                            foreach (var _innerrec in DB_Mobilities_Recs_All)
                                            {
                                                output_budget_all=output_budget_all+_innerrec.MobilityCost;
                                            }

                                            foreach (var _innerrec in DB_Procurement_Recs_All)
                                            {
                                                output_budget_all=output_budget_all+_innerrec.WPProcurementCost;
                                            }

                                            foreach (var _innerrec in DB_Communication_Recs_All)
                                            {
                                                output_budget_all=output_budget_all+_innerrec.WPCommsCost;
                                            }
                                            double remainingfunds=output_total_budget-output_budget_all;

                                            //Add Adjust Cost to DP
                                            
                                            if(remainingfunds!=0)
                                                output_ms_budget=output_ms_budget+(remainingfunds/4.0);
                                            

                                            q2_output_budget=q2_output_budget+output_ms_budget;

                                        }



                                        //Q3 Computation
                                        double q3_output_budget=0;

                                        DB_Mobilities_Recs=_wpMobilityRepository.GetRecordsByOutputIdStartEndRange(record.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 7, 1),
                                                                                                                                                new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 9, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 9))).ToList();
                                    

                   
                                        DB_Procurement_Recs=_wpProcurementRepository.GetRecordsByOutputIdStartEndRange(record.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 7, 1),
                                                                                                                                                new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 9, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 9))).ToList();
                                    
                               
                                        DB_Communication_Recs=_wpCommunicationRepository.GetRecordsByOutputIdStartEndRange(record.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 7, 1),
                                                                                                                                                new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 9, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 9))).ToList();
                                    
                                        //inner totals
                                        output_dp_budget=0;
                                        output_ms_budget=0;
                                        output_budget_all=0; 


                                        //Sum as DP
                                        if(dp_count>ms_count)
                                        {
                                            foreach (var _innerrec in DB_Mobilities_Recs)
                                            {
                                                output_dp_budget=output_dp_budget+_innerrec.MobilityCost;
                                            }

                                            foreach (var _innerrec in DB_Procurement_Recs)
                                            {
                                                output_dp_budget=output_dp_budget+_innerrec.WPProcurementCost;
                                            }

                                            foreach (var _innerrec in DB_Communication_Recs)
                                            {
                                                output_dp_budget=output_dp_budget+_innerrec.WPCommsCost;
                                            }

                                            //Get the Overall Total for Mobility, Procurement and Communication 
                                            
                                            foreach (var _innerrec in DB_Mobilities_Recs_All)
                                            {
                                                output_budget_all=output_budget_all+_innerrec.MobilityCost;
                                            }

                                            foreach (var _innerrec in DB_Procurement_Recs_All)
                                            {
                                                output_budget_all=output_budget_all+_innerrec.WPProcurementCost;
                                            }

                                            foreach (var _innerrec in DB_Communication_Recs_All)
                                            {
                                                output_budget_all=output_budget_all+_innerrec.WPCommsCost;
                                            }

                                            double remainingfunds=output_total_budget-output_budget_all;

                                            //Add Adjust Cost to DP
                                           
                                            if(remainingfunds!=0)
                                                output_dp_budget=output_dp_budget+(remainingfunds/4.0);
                                           

                                            q3_output_budget=q3_output_budget+output_dp_budget;
                                                
                                        }
                                        else //Sum as MS
                                        {
                                            foreach (var _innerrec in DB_Mobilities_Recs)
                                            {
                                                output_ms_budget=output_ms_budget+_innerrec.MobilityCost;
                                            }

                                            foreach (var _innerrec in DB_Procurement_Recs)
                                            {
                                                output_ms_budget=output_ms_budget+_innerrec.WPProcurementCost;
                                            }

                                            foreach (var _innerrec in DB_Communication_Recs)
                                            {
                                                output_ms_budget=output_ms_budget+_innerrec.WPCommsCost;
                                            }

                                            //Get the Overall Total for Mobility, Procurement and Communication 
                                            
                                            foreach (var _innerrec in DB_Mobilities_Recs_All)
                                            {
                                                output_budget_all=output_budget_all+_innerrec.MobilityCost;
                                            }

                                            foreach (var _innerrec in DB_Procurement_Recs_All)
                                            {
                                                output_budget_all=output_budget_all+_innerrec.WPProcurementCost;
                                            }

                                            foreach (var _innerrec in DB_Communication_Recs_All)
                                            {
                                                output_budget_all=output_budget_all+_innerrec.WPCommsCost;
                                            }
                                            double remainingfunds=output_total_budget-output_budget_all;

                                            //Add Adjust Cost to DP
                                            
                                            if(remainingfunds!=0)
                                                output_ms_budget=output_ms_budget+(remainingfunds/4.0);
                                            

                                            q3_output_budget=q3_output_budget+output_ms_budget;

                                        }

                                        //Q4 Computation
                                        double q4_output_budget=0;

                                        DB_Mobilities_Recs=_wpMobilityRepository.GetRecordsByOutputIdStartEndRange(record.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 10, 1),
                                                                                                                                                new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12))).ToList();
                                    

                   
                                        DB_Procurement_Recs=_wpProcurementRepository.GetRecordsByOutputIdStartEndRange(record.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 10, 1),
                                                                                                                                                new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12))).ToList();
                                    
                               
                                        DB_Communication_Recs=_wpCommunicationRepository.GetRecordsByOutputIdStartEndRange(record.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 10, 1),
                                                                                                                                                new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12))).ToList();
                                    
                                        //inner totals
                                        output_dp_budget=0;
                                        output_ms_budget=0;
                                        output_budget_all=0; 


                                        //Sum as DP
                                        if(dp_count>ms_count)
                                        {
                                            foreach (var _innerrec in DB_Mobilities_Recs)
                                            {
                                                output_dp_budget=output_dp_budget+_innerrec.MobilityCost;
                                            }

                                            foreach (var _innerrec in DB_Procurement_Recs)
                                            {
                                                output_dp_budget=output_dp_budget+_innerrec.WPProcurementCost;
                                            }

                                            foreach (var _innerrec in DB_Communication_Recs)
                                            {
                                                output_dp_budget=output_dp_budget+_innerrec.WPCommsCost;
                                            }

                                            //Get the Overall Total for Mobility, Procurement and Communication 
                                            
                                            foreach (var _innerrec in DB_Mobilities_Recs_All)
                                            {
                                                output_budget_all=output_budget_all+_innerrec.MobilityCost;
                                            }

                                            foreach (var _innerrec in DB_Procurement_Recs_All)
                                            {
                                                output_budget_all=output_budget_all+_innerrec.WPProcurementCost;
                                            }

                                            foreach (var _innerrec in DB_Communication_Recs_All)
                                            {
                                                output_budget_all=output_budget_all+_innerrec.WPCommsCost;
                                            }

                                            double remainingfunds=output_total_budget-output_budget_all;

                                            //Add Adjust Cost to DP
                                           
                                            if(remainingfunds!=0)
                                                output_dp_budget=output_dp_budget+(remainingfunds/4.0);
                                           

                                            q4_output_budget=q4_output_budget+output_dp_budget;
                                                
                                        }
                                        else //Sum as MS
                                        {
                                            foreach (var _innerrec in DB_Mobilities_Recs)
                                            {
                                                output_ms_budget=output_ms_budget+_innerrec.MobilityCost;
                                            }

                                            foreach (var _innerrec in DB_Procurement_Recs)
                                            {
                                                output_ms_budget=output_ms_budget+_innerrec.WPProcurementCost;
                                            }

                                            foreach (var _innerrec in DB_Communication_Recs)
                                            {
                                                output_ms_budget=output_ms_budget+_innerrec.WPCommsCost;
                                            }

                                            //Get the Overall Total for Mobility, Procurement and Communication 
                                            
                                            foreach (var _innerrec in DB_Mobilities_Recs_All)
                                            {
                                                output_budget_all=output_budget_all+_innerrec.MobilityCost;
                                            }

                                            foreach (var _innerrec in DB_Procurement_Recs_All)
                                            {
                                                output_budget_all=output_budget_all+_innerrec.WPProcurementCost;
                                            }

                                            foreach (var _innerrec in DB_Communication_Recs_All)
                                            {
                                                output_budget_all=output_budget_all+_innerrec.WPCommsCost;
                                            }
                                            double remainingfunds=output_total_budget-output_budget_all;

                                            //Add Adjust Cost to DP
                                            
                                            if(remainingfunds!=0)
                                                output_ms_budget=output_ms_budget+(remainingfunds/4.0);
                                            

                                            q4_output_budget=q4_output_budget+output_ms_budget;

                                        }                                                                                                     







                                        if(dp_count>ms_count)
                                        {
                                            WP_OutputActivities refactivity=_wpOutputActivitiesRepository.GetRecordsByMainRecordOutputIdDPStatusRecord(mainrec.Transaction_Id, record.Transaction_Id, true);
                                            if(refactivity.PartnerFunding==true && refactivity.PartnerFundingDescr!=null)
                                            {
                                                fundssource="DP ("+refactivity.PartnerFundingDescr+")";
                                            }
                                            else if (refactivity.PartnerFunding==true && refactivity.PartnerFundingDescr!=null)
                                            {
                                                fundssource="DP";
                                            }

                                        }
                                        else
                                        {
                                            fundssource="MS";
                                        }



                                        if(record.WPOutputLinkType_Id==1)
                                        {
                                            outputlinktype="Programme Costs";
                                        }
                                        else
                                        {
                                            outputlinktype="Staff Related Costs";
                                        }




                                        WP_OutputsGridVM srec = new WP_OutputsGridVM
                                        {
                                            Transaction_IdGVM = record.Transaction_Id,
                                            WPMainRecord_idGVM = record.WPMainRecord_id,
                                            Project_IdGVM  = record.Project_Id,
                                            Project_NameGVM=_lkupProjectRepository.GetRecord(record.Project_Id).Record_Name,
                                            FiscalYear_IdGVM  = record.FiscalYear_Id,
                                            FiscalYear_NameGVM=_lkupFiscalYearRepository.GetRecord(record.FiscalYear_Id).Record_Name,
                                            Period_IdGVM = record.Period_Id,
                                            OutputGVM = record.Output,
                                            WPOutputCostGVM=output_total_budget,
                                            WPOutputQ1CostGVM=q1_output_budget,
                                            WPOutputQ2CostGVM=q2_output_budget,
                                            WPOutputQ3CostGVM=q3_output_budget,
                                            WPOutputQ4CostGVM=q4_output_budget,
                                            WPFundingSourceGVM=fundssource,
                                            WPOutputLinkTypeGVM=outputlinktype,
                                            Strategic_PrioritiesGVM=rtnstringPriorities,
                                            Directorate_IdGVM = mainrec.Directorate_Id,
                                            Directorate_NameGVM = _strucDirectorateRepository.GetRecord(mainrec.Directorate_Id).AcronymName,
                                            Division_IdGVM =  mainrec.Division_Id,
                                            Division_NameGVM = _strucDivisionRepository.GetRecord(mainrec.Division_Id).Record_Name,
                                            Cycle_IdGVM = id,
                                            InstitutionalSelectdedPeriodIdentGVM = periodid

                                        };
                                        collection_recs.Add(srec);




                                        var DB_MainProjsPriorities_Det=_wpAUDAPriorityRepository.GetRecordsByMainRecordId(mainrec.Transaction_Id);
                                        double denominator=Convert.ToDouble(DB_MainProjsPriorities_Det.Count());

                                        double output_total_budget_det=0;
                                        double q1_output_budget_det=0;
                                        double q2_output_budget_det=0;
                                        double q3_output_budget_det=0;
                                        double q4_output_budget_det=0;
                                       
                                        foreach(var recordset in DB_MainProjsPriorities_Det)
                                        {
                                            if(denominator!=0)
                                            {
                                                output_total_budget_det=output_total_budget/denominator;
                                                q1_output_budget_det=q1_output_budget/denominator;
                                                q2_output_budget_det=q2_output_budget/denominator;
                                                q3_output_budget_det=q3_output_budget/denominator;
                                                q4_output_budget_det=q4_output_budget/denominator;
                                            }





                                            WP_OutputsGridVM srec_detail = new WP_OutputsGridVM
                                            {
                                                Transaction_IdGVM = record.Transaction_Id,
                                                WPMainRecord_idGVM = record.WPMainRecord_id,
                                                Project_IdGVM  = record.Project_Id,
                                                Project_NameGVM=_lkupProjectRepository.GetRecord(record.Project_Id).Record_Name,
                                                FiscalYear_IdGVM  = record.FiscalYear_Id,
                                                FiscalYear_NameGVM=_lkupFiscalYearRepository.GetRecord(record.FiscalYear_Id).Record_Name,
                                                Period_IdGVM = record.Period_Id,
                                                OutputGVM = record.Output,
                                                WPOutputCostGVM=output_total_budget_det,
                                                WPOutputQ1CostGVM=q1_output_budget_det,
                                                WPOutputQ2CostGVM=q2_output_budget_det,
                                                WPOutputQ3CostGVM=q3_output_budget_det,
                                                WPOutputQ4CostGVM=q4_output_budget_det,
                                                WPFundingSourceGVM=fundssource,
                                                WPOutputLinkTypeGVM=outputlinktype,
                                                Strategic_PriorityIdGVM=recordset.Priority_Id,
                                                Strategic_PrioritiesGVM=_strategyPriorityRepository.GetRecord(recordset.Priority_Id).Record_Name,
                                                Directorate_IdGVM = mainrec.Directorate_Id,
                                                Directorate_NameGVM = _strucDirectorateRepository.GetRecord(mainrec.Directorate_Id).AcronymName,
                                                Division_IdGVM =  mainrec.Division_Id,
                                                Division_NameGVM = _strucDivisionRepository.GetRecord(mainrec.Division_Id).Record_Name,
                                                Cycle_IdGVM = id,
                                                InstitutionalSelectdedPeriodIdentGVM = periodid

                                            };
                                            collection_recs_details.Add(srec_detail);

                                        }

                                    }

                                }

                            }


                        }

                    }

                    //Sorting Directorate_IdGVM
                    collection_recs=collection_recs.OrderBy(d => d.Directorate_IdGVM).ThenBy(d => d.Division_IdGVM).ThenBy(d => d.Project_NameGVM).ToList();
                    collection_recs_details=collection_recs_details.OrderBy(d => d.Strategic_PriorityIdGVM).ThenBy(d => d.Directorate_IdGVM).ThenBy(d => d.Division_IdGVM).ThenBy(d => d.Project_NameGVM).ToList();


                    
                }












                

                IFont fontnormal = workbook.CreateFont();
                fontnormal.IsBold = false;
                fontnormal.FontHeightInPoints = 11;
                fontnormal.FontName="Arial";

                IFont fontnormalbold = workbook.CreateFont();
                fontnormalbold.IsBold = true;
                fontnormalbold.FontHeightInPoints = 11;
                fontnormalbold.FontName="Arial";

                ICellStyle cellStyleNormal = workbook.CreateCellStyle();
                cellStyleNormal.SetFont(fontnormal);
                cellStyleNormal.BorderLeft = BorderStyle.Thin;
                cellStyleNormal.BorderTop = BorderStyle.Thin;
                cellStyleNormal.BorderRight = BorderStyle.Thin;
                cellStyleNormal.BorderBottom = BorderStyle.Thin;
                cellStyleNormal.VerticalAlignment = VerticalAlignment.Top;
                cellStyleNormal.Alignment =HorizontalAlignment.Left;
                cellStyleNormal.WrapText=true;
                cellStyleNormal.FillForegroundColor=26;
                cellStyleNormal.FillPattern=FillPattern.SolidForeground; 

                ICellStyle cellStyleNormalRight = workbook.CreateCellStyle();
                cellStyleNormalRight.SetFont(fontnormal);
                cellStyleNormalRight.BorderLeft = BorderStyle.Thin;
                cellStyleNormalRight.BorderTop = BorderStyle.Thin;
                cellStyleNormalRight.BorderRight = BorderStyle.Thin;
                cellStyleNormalRight.BorderBottom = BorderStyle.Thin;
                cellStyleNormalRight.VerticalAlignment = VerticalAlignment.Top;
                cellStyleNormalRight.Alignment =HorizontalAlignment.Right;
                cellStyleNormalRight.WrapText=true;
                cellStyleNormalRight.FillForegroundColor=26;
                cellStyleNormalRight.FillPattern=FillPattern.SolidForeground; 


                ICellStyle cellStyleNormalLIGHTGREEN = workbook.CreateCellStyle();
                cellStyleNormalLIGHTGREEN.SetFont(fontnormal);
                cellStyleNormalLIGHTGREEN.BorderLeft = BorderStyle.Thin;
                cellStyleNormalLIGHTGREEN.BorderTop = BorderStyle.Thin;
                cellStyleNormalLIGHTGREEN.BorderRight = BorderStyle.Thin;
                cellStyleNormalLIGHTGREEN.BorderBottom = BorderStyle.Thin;
                cellStyleNormalLIGHTGREEN.VerticalAlignment = VerticalAlignment.Top;
                cellStyleNormalLIGHTGREEN.Alignment =HorizontalAlignment.Left;
                cellStyleNormalLIGHTGREEN.WrapText=true;
                cellStyleNormalLIGHTGREEN.FillForegroundColor=42;
                cellStyleNormalLIGHTGREEN.FillPattern=FillPattern.SolidForeground; 

                ICellStyle cellStyleNormalRightLIGHTGREEN = workbook.CreateCellStyle();
                cellStyleNormalRightLIGHTGREEN.SetFont(fontnormal);
                cellStyleNormalRightLIGHTGREEN.BorderLeft = BorderStyle.Thin;
                cellStyleNormalRightLIGHTGREEN.BorderTop = BorderStyle.Thin;
                cellStyleNormalRightLIGHTGREEN.BorderRight = BorderStyle.Thin;
                cellStyleNormalRightLIGHTGREEN.BorderBottom = BorderStyle.Thin;
                cellStyleNormalRightLIGHTGREEN.VerticalAlignment = VerticalAlignment.Top;
                cellStyleNormalRightLIGHTGREEN.Alignment =HorizontalAlignment.Right;
                cellStyleNormalRightLIGHTGREEN.WrapText=true;
                cellStyleNormalRightLIGHTGREEN.FillForegroundColor=42;
                cellStyleNormalRightLIGHTGREEN.FillPattern=FillPattern.SolidForeground; 

                ICellStyle cellStyleYellowNormalSTART = workbook.CreateCellStyle();
                cellStyleYellowNormalSTART.SetFont(fontnormal);
                cellStyleYellowNormalSTART.BorderLeft = BorderStyle.Thin;
                cellStyleYellowNormalSTART.BorderTop = BorderStyle.Thin;
                cellStyleYellowNormalSTART.BorderRight = BorderStyle.None;
                cellStyleYellowNormalSTART.BorderBottom = BorderStyle.Thin;
                cellStyleYellowNormalSTART.VerticalAlignment = VerticalAlignment.Top;
                cellStyleYellowNormalSTART.Alignment =HorizontalAlignment.Left;
                cellStyleYellowNormalSTART.WrapText=true;
                cellStyleYellowNormalSTART.FillForegroundColor=13;
                cellStyleYellowNormalSTART.FillPattern=FillPattern.SolidForeground; 

                ICellStyle cellStyleYellowNormalEND = workbook.CreateCellStyle();
                cellStyleYellowNormalEND.SetFont(fontnormalbold);
                cellStyleYellowNormalEND.BorderLeft = BorderStyle.None;
                cellStyleYellowNormalEND.BorderTop = BorderStyle.Thin;
                cellStyleYellowNormalEND.BorderRight = BorderStyle.Thin;
                cellStyleYellowNormalEND.BorderBottom = BorderStyle.Thin;
                cellStyleYellowNormalEND.VerticalAlignment = VerticalAlignment.Top;
                cellStyleYellowNormalEND.Alignment =HorizontalAlignment.Right;
                cellStyleYellowNormalEND.WrapText=true;
                cellStyleYellowNormalEND.FillForegroundColor=13;
                cellStyleYellowNormalEND.FillPattern=FillPattern.SolidForeground; 

                ICellStyle cellStyleYellowNormal = workbook.CreateCellStyle();
                cellStyleYellowNormal.SetFont(fontnormalbold);
                cellStyleYellowNormal.BorderLeft = BorderStyle.Thin;
                cellStyleYellowNormal.BorderTop = BorderStyle.Thin;
                cellStyleYellowNormal.BorderRight = BorderStyle.Thin;
                cellStyleYellowNormal.BorderBottom = BorderStyle.Thin;
                cellStyleYellowNormal.VerticalAlignment = VerticalAlignment.Top;
                cellStyleYellowNormal.Alignment =HorizontalAlignment.Left;
                cellStyleYellowNormal.WrapText=true;
                cellStyleYellowNormal.FillForegroundColor=13;
                cellStyleYellowNormal.FillPattern=FillPattern.SolidForeground; 

                ICellStyle cellStyleNormalYellowRight = workbook.CreateCellStyle();
                cellStyleNormalYellowRight.SetFont(fontnormalbold);
                cellStyleNormalYellowRight.BorderLeft = BorderStyle.Thin;
                cellStyleNormalYellowRight.BorderTop = BorderStyle.Thin;
                cellStyleNormalYellowRight.BorderRight = BorderStyle.Thin;
                cellStyleNormalYellowRight.BorderBottom = BorderStyle.Thin;
                cellStyleNormalYellowRight.VerticalAlignment = VerticalAlignment.Top;
                cellStyleNormalYellowRight.Alignment =HorizontalAlignment.Right;
                cellStyleNormalYellowRight.WrapText=true;
                cellStyleNormalYellowRight.FillForegroundColor=13;
                cellStyleNormalYellowRight.FillPattern=FillPattern.SolidForeground; 





                ICellStyle cellStyleYellowNormalMiddle = workbook.CreateCellStyle();
                cellStyleYellowNormalMiddle.SetFont(fontnormalbold);
                cellStyleYellowNormalMiddle.BorderLeft = BorderStyle.None;
                cellStyleYellowNormalMiddle.BorderTop = BorderStyle.Thin;
                cellStyleYellowNormalMiddle.BorderRight = BorderStyle.None;
                cellStyleYellowNormalMiddle.BorderBottom = BorderStyle.Thin;
                cellStyleYellowNormalMiddle.VerticalAlignment = VerticalAlignment.Top;
                cellStyleYellowNormalMiddle.Alignment =HorizontalAlignment.Left;
                cellStyleYellowNormalMiddle.WrapText=true;
                cellStyleYellowNormalMiddle.FillForegroundColor=13;
                cellStyleYellowNormalMiddle.FillPattern=FillPattern.SolidForeground; 

                ICellStyle cellStyleNormalYellowRightMiddle = workbook.CreateCellStyle();
                cellStyleNormalYellowRightMiddle.SetFont(fontnormalbold);
                cellStyleNormalYellowRightMiddle.BorderLeft = BorderStyle.None;
                cellStyleNormalYellowRightMiddle.BorderTop = BorderStyle.Thin;
                cellStyleNormalYellowRightMiddle.BorderRight = BorderStyle.None;
                cellStyleNormalYellowRightMiddle.BorderBottom = BorderStyle.Thin;
                cellStyleNormalYellowRightMiddle.VerticalAlignment = VerticalAlignment.Top;
                cellStyleNormalYellowRightMiddle.Alignment =HorizontalAlignment.Right;
                cellStyleNormalYellowRightMiddle.WrapText=true;
                cellStyleNormalYellowRightMiddle.FillForegroundColor=13;
                cellStyleNormalYellowRightMiddle.FillPattern=FillPattern.SolidForeground; 


                ICellStyle cellStyleNormalGRAY = workbook.CreateCellStyle();
                cellStyleNormalGRAY.SetFont(fontnormal);
                cellStyleNormalGRAY.BorderLeft = BorderStyle.Thin;
                cellStyleNormalGRAY.BorderTop = BorderStyle.Thin;
                cellStyleNormalGRAY.BorderRight = BorderStyle.Thin;
                cellStyleNormalGRAY.BorderBottom = BorderStyle.Thin;
                cellStyleNormalGRAY.VerticalAlignment = VerticalAlignment.Top;
                cellStyleNormalGRAY.Alignment =HorizontalAlignment.Left;
                cellStyleNormalGRAY.WrapText=true;
                cellStyleNormalGRAY.FillForegroundColor=22;
                cellStyleNormalGRAY.FillPattern=FillPattern.SolidForeground; 

                

                ICellStyle cellStyleNumber = workbook.CreateCellStyle();
                cellStyleNumber.SetFont(fontnormal);
                cellStyleNumber.BorderLeft = BorderStyle.Thin;
                cellStyleNumber.BorderTop = BorderStyle.Thin;
                cellStyleNumber.BorderRight = BorderStyle.Thin;
                cellStyleNumber.BorderBottom = BorderStyle.Thin;
                cellStyleNumber.VerticalAlignment = VerticalAlignment.Top;
                cellStyleNumber.Alignment =HorizontalAlignment.Right;
                cellStyleNumber.WrapText=true;
                cellStyleNumber.FillForegroundColor=26;
                cellStyleNumber.FillPattern=FillPattern.SolidForeground; 

                ICellStyle cellStyleNumberLIGHTGREEN = workbook.CreateCellStyle();
                cellStyleNumberLIGHTGREEN.SetFont(fontnormal);
                cellStyleNumberLIGHTGREEN.BorderLeft = BorderStyle.Thin;
                cellStyleNumberLIGHTGREEN.BorderTop = BorderStyle.Thin;
                cellStyleNumberLIGHTGREEN.BorderRight = BorderStyle.Thin;
                cellStyleNumberLIGHTGREEN.BorderBottom = BorderStyle.Thin;
                cellStyleNumberLIGHTGREEN.VerticalAlignment = VerticalAlignment.Top;
                cellStyleNumberLIGHTGREEN.Alignment =HorizontalAlignment.Right;
                cellStyleNumberLIGHTGREEN.WrapText=true;
                cellStyleNumberLIGHTGREEN.FillForegroundColor=42;
                cellStyleNumberLIGHTGREEN.FillPattern=FillPattern.SolidForeground; 
                


                ISheet worksheet = workbook.GetSheetAt(1);

                int i=1;
                int _countrecords=0;

                double q1total=0;
                double q2total=0;
                double q3total=0;
                double q4total=0;
                double annualtotal=0;
               
                foreach(var record in collection_recs)
                {

                    if(record.WPOutputCostGVM>0)
                    {
                        i=i+1;
                        _countrecords=_countrecords+1;
                        IRow row = worksheet.CreateRow(i);

                        q1total=q1total+record.WPOutputQ1CostGVM;
                        q2total=q2total+record.WPOutputQ2CostGVM;
                        q3total=q3total+record.WPOutputQ3CostGVM;
                        q4total=q4total+record.WPOutputQ4CostGVM;
                        annualtotal=annualtotal+record.WPOutputCostGVM;

                    // CreateCell(row, 0, "Recruit Junior Programming consultant to support in the finalisation of the integrated work plan application", borderedCellStylenormal);
                    

                
                        if(record.WPOutputLinkTypeGVM=="Programme Costs")
                        {
                            ICell Cell0 = row.CreateCell(0);
                            Cell0.SetCellValue("");
                            Cell0.CellStyle = cellStyleNormalGRAY;

                            ICell Cell1 = row.CreateCell(1);
                            Cell1.SetCellValue(record.FiscalYear_NameGVM);
                            Cell1.CellStyle = cellStyleNumber;

                            ICell Cell2 = row.CreateCell(2);
                            Cell2.SetCellValue(record.Strategic_PrioritiesGVM);
                            Cell2.CellStyle = cellStyleNormal;

                            ICell Cell3 = row.CreateCell(3);
                            Cell3.SetCellValue(record.Directorate_NameGVM);
                            Cell3.CellStyle = cellStyleNormal;

                            ICell Cell4 = row.CreateCell(4);
                            Cell4.SetCellValue(record.Division_NameGVM);
                            Cell4.CellStyle = cellStyleNormal;

                            ICell Cell5 = row.CreateCell(5);
                            Cell5.SetCellValue(record.Project_NameGVM);
                            Cell5.CellStyle = cellStyleNormal;

                            ICell Cell6 = row.CreateCell(6);
                            Cell6.SetCellValue(record.WPFundingSourceGVM);
                            Cell6.CellStyle = cellStyleNormal;

                            ICell Cell7 = row.CreateCell(7);
                            Cell7.SetCellValue(record.OutputGVM);
                            Cell7.CellStyle = cellStyleNormal;

                            ICell Cell8 = row.CreateCell(8);
                            Cell8.SetCellValue(record.WPOutputLinkTypeGVM);
                            Cell8.CellStyle = cellStyleNormal;

                        

                            //Q1
                            ICell Cell9 = row.CreateCell(9);
                            Cell9.SetCellValue(ExcelDoubleToStringFormat(record.WPOutputQ1CostGVM));
                            Cell9.CellStyle = cellStyleNumber;

                            ICell Cell10 = row.CreateCell(10);
                            Cell10.SetCellValue("");
                            Cell10.CellStyle = cellStyleNormalRight;

                            //Q2
                            ICell Cell11 = row.CreateCell(11);
                            Cell11.SetCellValue(ExcelDoubleToStringFormat(record.WPOutputQ2CostGVM));
                            Cell11.CellStyle = cellStyleNumber;

                            ICell Cell12 = row.CreateCell(12);
                            Cell12.SetCellValue("");
                            Cell12.CellStyle = cellStyleNormalRight;

                            //Q3
                            ICell Cell13 = row.CreateCell(13);
                            Cell13.SetCellValue(ExcelDoubleToStringFormat(record.WPOutputQ3CostGVM));
                            Cell13.CellStyle = cellStyleNumber;

                            ICell Cell14 = row.CreateCell(14);
                            Cell14.SetCellValue("");
                            Cell14.CellStyle = cellStyleNormalRight;

                            //Q4
                            ICell Cell15 = row.CreateCell(15);
                            Cell15.SetCellValue(ExcelDoubleToStringFormat(record.WPOutputQ4CostGVM));
                            Cell15.CellStyle = cellStyleNumber;

                            ICell Cell16 = row.CreateCell(16);
                            Cell16.SetCellValue("");
                            Cell16.CellStyle = cellStyleNormalRight;

                            //Annual
                            ICell Cell17 = row.CreateCell(17);
                            Cell17.SetCellValue(ExcelDoubleToStringFormat(record.WPOutputCostGVM));
                            Cell17.CellStyle = cellStyleNumber;

                            ICell Cell18 = row.CreateCell(18);
                            Cell18.SetCellValue("");
                            Cell18.CellStyle = cellStyleNormalRight;

                            //GRAY AREA
                            ICell Cell19 = row.CreateCell(19);
                            Cell19.SetCellValue("");
                            Cell19.CellStyle = cellStyleNormalGRAY;

                            ICell Cell20 = row.CreateCell(20);
                            Cell20.SetCellValue("");
                            Cell20.CellStyle = cellStyleNormalGRAY;
                        }
                        else
                        {
                            ICell Cell0 = row.CreateCell(0);
                            Cell0.SetCellValue("");
                            Cell0.CellStyle = cellStyleNormalGRAY;

                            ICell Cell1 = row.CreateCell(1);
                            Cell1.SetCellValue(record.FiscalYear_NameGVM);
                            Cell1.CellStyle = cellStyleNumberLIGHTGREEN;

                            ICell Cell2 = row.CreateCell(2);
                            Cell2.SetCellValue(record.Strategic_PrioritiesGVM);
                            Cell2.CellStyle = cellStyleNormalLIGHTGREEN;

                            ICell Cell3 = row.CreateCell(3);
                            Cell3.SetCellValue(record.Directorate_NameGVM);
                            Cell3.CellStyle = cellStyleNormalLIGHTGREEN;

                            ICell Cell4 = row.CreateCell(4);
                            Cell4.SetCellValue(record.Division_NameGVM);
                            Cell4.CellStyle = cellStyleNormalLIGHTGREEN;

                            ICell Cell5 = row.CreateCell(5);
                            Cell5.SetCellValue(record.Project_NameGVM);
                            Cell5.CellStyle = cellStyleNormalLIGHTGREEN;

                            ICell Cell6 = row.CreateCell(6);
                            Cell6.SetCellValue(record.WPFundingSourceGVM);
                            Cell6.CellStyle = cellStyleNormalLIGHTGREEN;

                            ICell Cell7 = row.CreateCell(7);
                            Cell7.SetCellValue(record.OutputGVM);
                            Cell7.CellStyle = cellStyleNormalLIGHTGREEN;

                            ICell Cell8 = row.CreateCell(8);
                            Cell8.SetCellValue(record.WPOutputLinkTypeGVM);
                            Cell8.CellStyle = cellStyleNormalLIGHTGREEN;

                        

                            //Q1
                            ICell Cell9 = row.CreateCell(9);
                            Cell9.SetCellValue(ExcelDoubleToStringFormat(record.WPOutputQ1CostGVM));
                            Cell9.CellStyle = cellStyleNumberLIGHTGREEN;

                            ICell Cell10 = row.CreateCell(10);
                            Cell10.SetCellValue("");
                            Cell10.CellStyle = cellStyleNormalRightLIGHTGREEN;

                            //Q2
                            ICell Cell11 = row.CreateCell(11);
                            Cell11.SetCellValue(ExcelDoubleToStringFormat(record.WPOutputQ2CostGVM));
                            Cell11.CellStyle = cellStyleNumberLIGHTGREEN;

                            ICell Cell12 = row.CreateCell(12);
                            Cell12.SetCellValue("");
                            Cell12.CellStyle = cellStyleNormalRightLIGHTGREEN;

                            //Q3
                            ICell Cell13 = row.CreateCell(13);
                            Cell13.SetCellValue(ExcelDoubleToStringFormat(record.WPOutputQ3CostGVM));
                            Cell13.CellStyle = cellStyleNumberLIGHTGREEN;

                            ICell Cell14 = row.CreateCell(14);
                            Cell14.SetCellValue("");
                            Cell14.CellStyle = cellStyleNormalRightLIGHTGREEN;

                            //Q4
                            ICell Cell15 = row.CreateCell(15);
                            Cell15.SetCellValue(ExcelDoubleToStringFormat(record.WPOutputQ4CostGVM));
                            Cell15.CellStyle = cellStyleNumberLIGHTGREEN;

                            ICell Cell16 = row.CreateCell(16);
                            Cell16.SetCellValue("");
                            Cell16.CellStyle = cellStyleNormalRightLIGHTGREEN;

                            //Annual
                            ICell Cell17 = row.CreateCell(17);
                            Cell17.SetCellValue(ExcelDoubleToStringFormat(record.WPOutputCostGVM));
                            Cell17.CellStyle = cellStyleNumberLIGHTGREEN;

                            ICell Cell18 = row.CreateCell(18);
                            Cell18.SetCellValue("");
                            Cell18.CellStyle = cellStyleNormalRightLIGHTGREEN;

                            //GRAY AREA
                            ICell Cell19 = row.CreateCell(19);
                            Cell19.SetCellValue("");
                            Cell19.CellStyle = cellStyleNormalGRAY;

                            ICell Cell20 = row.CreateCell(20);
                            Cell20.SetCellValue("");
                            Cell20.CellStyle = cellStyleNormalGRAY;

                        }

                        

                    }
                }

                IRow rowtot = worksheet.CreateRow(_countrecords+2);

                ICell Celltot0 = rowtot.CreateCell(0);
                Celltot0.SetCellValue("");
                Celltot0.CellStyle = cellStyleNormalGRAY;

                ICell Celltot1 = rowtot.CreateCell(1);
                Celltot1.SetCellValue("");
                Celltot1.CellStyle = cellStyleYellowNormalSTART;

                ICell Celltot2 = rowtot.CreateCell(2);
                Celltot2.SetCellValue("");
                Celltot2.CellStyle = cellStyleYellowNormalMiddle;

                ICell Celltot3 = rowtot.CreateCell(3);
                Celltot3.SetCellValue("");
                Celltot3.CellStyle = cellStyleYellowNormalMiddle;

                ICell Celltot4 = rowtot.CreateCell(4);
                Celltot4.SetCellValue("");
                Celltot4.CellStyle = cellStyleYellowNormalMiddle;

                ICell Celltot5 = rowtot.CreateCell(5);
                Celltot5.SetCellValue("");
                Celltot5.CellStyle = cellStyleYellowNormalMiddle;

                ICell Celltot6 = rowtot.CreateCell(6);
                Celltot6.SetCellValue("");
                Celltot6.CellStyle = cellStyleYellowNormalMiddle;

                ICell Celltot7 = rowtot.CreateCell(7);
                Celltot7.SetCellValue("");
                Celltot7.CellStyle = cellStyleYellowNormalMiddle;

                ICell Celltot8 = rowtot.CreateCell(8);
                Celltot8.SetCellValue("TOTALS");
                Celltot8.CellStyle = cellStyleYellowNormalEND;


                //Q1
                ICell Celltot9 = rowtot.CreateCell(9);
                Celltot9.SetCellValue(ExcelDoubleToStringFormat(q1total));
                Celltot9.CellStyle = cellStyleNormalYellowRight;

                ICell Celltot10 = rowtot.CreateCell(10);
                Celltot10.SetCellValue("");
                Celltot10.CellStyle = cellStyleNormalYellowRight;

                //Q2
                ICell Celltot11 = rowtot.CreateCell(11);
                Celltot11.SetCellValue(ExcelDoubleToStringFormat(q2total));
                Celltot11.CellStyle = cellStyleNormalYellowRight;

                ICell Celltot12 = rowtot.CreateCell(12);
                Celltot12.SetCellValue("");
                Celltot12.CellStyle = cellStyleNormalYellowRight;

                //Q3
                ICell Celltot13 = rowtot.CreateCell(13);
                Celltot13.SetCellValue(ExcelDoubleToStringFormat(q3total));
                Celltot13.CellStyle = cellStyleNormalYellowRight;

                ICell Celltot14 = rowtot.CreateCell(14);
                Celltot14.SetCellValue("");
                Celltot14.CellStyle = cellStyleNormalYellowRight;

                //Q4
                ICell Celltot15 = rowtot.CreateCell(15);
                Celltot15.SetCellValue(ExcelDoubleToStringFormat(q4total));
                Celltot15.CellStyle = cellStyleNormalYellowRight;

                ICell Celltot16 = rowtot.CreateCell(16);
                Celltot16.SetCellValue("");
                Celltot16.CellStyle = cellStyleNormalYellowRight;

                //Annual
                ICell Celltot17 = rowtot.CreateCell(17);
                Celltot17.SetCellValue(ExcelDoubleToStringFormat(annualtotal));
                Celltot17.CellStyle = cellStyleNormalYellowRight;

                ICell Celltot18 = rowtot.CreateCell(18);
                Celltot18.SetCellValue("");
                Celltot18.CellStyle = cellStyleNormalYellowRight;

                

                //GRAY AREA
                ICell Celltot19 = rowtot.CreateCell(19);
                Celltot19.SetCellValue("");
                Celltot19.CellStyle = cellStyleNormalGRAY;

                ICell Celltot20 = rowtot.CreateCell(20);
                Celltot20.SetCellValue("");
                Celltot20.CellStyle = cellStyleNormalGRAY;

       
       

                //FIRST WORKSHEET

                ISheet worksheet0 = workbook.GetSheetAt(0);

                i=1;
                _countrecords=0;

                q1total=0;
                q2total=0;
                q3total=0;
                q4total=0;
                annualtotal=0;
               
                foreach(var record in collection_recs_details)
                {

                    if(record.WPOutputCostGVM>0)
                    {
                        i=i+1;
                        _countrecords=_countrecords+1;
                        IRow row = worksheet0.CreateRow(i);

                        q1total=q1total+record.WPOutputQ1CostGVM;
                        q2total=q2total+record.WPOutputQ2CostGVM;
                        q3total=q3total+record.WPOutputQ3CostGVM;
                        q4total=q4total+record.WPOutputQ4CostGVM;
                        annualtotal=annualtotal+record.WPOutputCostGVM;

                    // CreateCell(row, 0, "Recruit Junior Programming consultant to support in the finalisation of the integrated work plan application", borderedCellStylenormal);
                    

                        if(record.WPOutputLinkTypeGVM=="Programme Costs")
                        {

                            ICell Cell0 = row.CreateCell(0);
                            Cell0.SetCellValue("");
                            Cell0.CellStyle = cellStyleNormalGRAY;


                            
                            ICell Cell1 = row.CreateCell(1);
                            Cell1.SetCellValue(record.FiscalYear_NameGVM);
                            Cell1.CellStyle = cellStyleNumber;

                            ICell Cell2 = row.CreateCell(2);
                            Cell2.SetCellValue(record.Strategic_PrioritiesGVM);
                            Cell2.CellStyle = cellStyleNormal;

                            ICell Cell3 = row.CreateCell(3);
                            Cell3.SetCellValue(record.Directorate_NameGVM);
                            Cell3.CellStyle = cellStyleNormal;

                            ICell Cell4 = row.CreateCell(4);
                            Cell4.SetCellValue(record.Division_NameGVM);
                            Cell4.CellStyle = cellStyleNormal;

                            ICell Cell5 = row.CreateCell(5);
                            Cell5.SetCellValue(record.Project_NameGVM);
                            Cell5.CellStyle = cellStyleNormal;

                            ICell Cell6 = row.CreateCell(6);
                            Cell6.SetCellValue(record.WPFundingSourceGVM);
                            Cell6.CellStyle = cellStyleNormal;

                            ICell Cell7 = row.CreateCell(7);
                            Cell7.SetCellValue(record.OutputGVM);
                            Cell7.CellStyle = cellStyleNormal;

                            ICell Cell8 = row.CreateCell(8);
                            Cell8.SetCellValue(record.WPOutputLinkTypeGVM);
                            Cell8.CellStyle = cellStyleNormal;

                        

                            //Q1
                            ICell Cell9 = row.CreateCell(9);
                            Cell9.SetCellValue(ExcelDoubleToStringFormat(record.WPOutputQ1CostGVM));
                            Cell9.CellStyle = cellStyleNumber;

                            ICell Cell10 = row.CreateCell(10);
                            Cell10.SetCellValue("");
                            Cell10.CellStyle = cellStyleNormalRight;

                            //Q2
                            ICell Cell11 = row.CreateCell(11);
                            Cell11.SetCellValue(ExcelDoubleToStringFormat(record.WPOutputQ2CostGVM));
                            Cell11.CellStyle = cellStyleNumber;

                            ICell Cell12 = row.CreateCell(12);
                            Cell12.SetCellValue("");
                            Cell12.CellStyle = cellStyleNormalRight;

                            //Q3
                            ICell Cell13 = row.CreateCell(13);
                            Cell13.SetCellValue(ExcelDoubleToStringFormat(record.WPOutputQ3CostGVM));
                            Cell13.CellStyle = cellStyleNumber;

                            ICell Cell14 = row.CreateCell(14);
                            Cell14.SetCellValue("");
                            Cell14.CellStyle = cellStyleNormalRight;

                            //Q4
                            ICell Cell15 = row.CreateCell(15);
                            Cell15.SetCellValue(ExcelDoubleToStringFormat(record.WPOutputQ4CostGVM));
                            Cell15.CellStyle = cellStyleNumber;

                            ICell Cell16 = row.CreateCell(16);
                            Cell16.SetCellValue("");
                            Cell16.CellStyle = cellStyleNormalRight;

                            //Annual
                            ICell Cell17 = row.CreateCell(17);
                            Cell17.SetCellValue(ExcelDoubleToStringFormat(record.WPOutputCostGVM));
                            Cell17.CellStyle = cellStyleNumber;

                            ICell Cell18 = row.CreateCell(18);
                            Cell18.SetCellValue("");
                            Cell18.CellStyle = cellStyleNormalRight;

                            //GRAY AREA
                            ICell Cell19 = row.CreateCell(19);
                            Cell19.SetCellValue("");
                            Cell19.CellStyle = cellStyleNormalGRAY;

                            ICell Cell20 = row.CreateCell(20);
                            Cell20.SetCellValue("");
                            Cell20.CellStyle = cellStyleNormalGRAY;
                        }
                        else
                        {
                            ICell Cell0 = row.CreateCell(0);
                            Cell0.SetCellValue("");
                            Cell0.CellStyle = cellStyleNormalGRAY;

                            ICell Cell1 = row.CreateCell(1);
                            Cell1.SetCellValue(record.FiscalYear_NameGVM);
                            Cell1.CellStyle = cellStyleNumberLIGHTGREEN;

                            ICell Cell2 = row.CreateCell(2);
                            Cell2.SetCellValue(record.Strategic_PrioritiesGVM);
                            Cell2.CellStyle = cellStyleNormalLIGHTGREEN;

                            ICell Cell3 = row.CreateCell(3);
                            Cell3.SetCellValue(record.Directorate_NameGVM);
                            Cell3.CellStyle = cellStyleNormalLIGHTGREEN;

                            ICell Cell4 = row.CreateCell(4);
                            Cell4.SetCellValue(record.Division_NameGVM);
                            Cell4.CellStyle = cellStyleNormalLIGHTGREEN;

                            ICell Cell5 = row.CreateCell(5);
                            Cell5.SetCellValue(record.Project_NameGVM);
                            Cell5.CellStyle = cellStyleNormalLIGHTGREEN;

                            ICell Cell6 = row.CreateCell(6);
                            Cell6.SetCellValue(record.WPFundingSourceGVM);
                            Cell6.CellStyle = cellStyleNormalLIGHTGREEN;

                            ICell Cell7 = row.CreateCell(7);
                            Cell7.SetCellValue(record.OutputGVM);
                            Cell7.CellStyle = cellStyleNormalLIGHTGREEN;

                            ICell Cell8 = row.CreateCell(8);
                            Cell8.SetCellValue(record.WPOutputLinkTypeGVM);
                            Cell8.CellStyle = cellStyleNormalLIGHTGREEN;

                        

                            //Q1
                            ICell Cell9 = row.CreateCell(9);
                            Cell9.SetCellValue(ExcelDoubleToStringFormat(record.WPOutputQ1CostGVM));
                            Cell9.CellStyle = cellStyleNumberLIGHTGREEN;

                            ICell Cell10 = row.CreateCell(10);
                            Cell10.SetCellValue("");
                            Cell10.CellStyle = cellStyleNormalRightLIGHTGREEN;

                            //Q2
                            ICell Cell11 = row.CreateCell(11);
                            Cell11.SetCellValue(ExcelDoubleToStringFormat(record.WPOutputQ2CostGVM));
                            Cell11.CellStyle = cellStyleNumberLIGHTGREEN;

                            ICell Cell12 = row.CreateCell(12);
                            Cell12.SetCellValue("");
                            Cell12.CellStyle = cellStyleNormalRightLIGHTGREEN;

                            //Q3
                            ICell Cell13 = row.CreateCell(13);
                            Cell13.SetCellValue(ExcelDoubleToStringFormat(record.WPOutputQ3CostGVM));
                            Cell13.CellStyle = cellStyleNumberLIGHTGREEN;

                            ICell Cell14 = row.CreateCell(14);
                            Cell14.SetCellValue("");
                            Cell14.CellStyle = cellStyleNormalRightLIGHTGREEN;

                            //Q4
                            ICell Cell15 = row.CreateCell(15);
                            Cell15.SetCellValue(ExcelDoubleToStringFormat(record.WPOutputQ4CostGVM));
                            Cell15.CellStyle = cellStyleNumberLIGHTGREEN;

                            ICell Cell16 = row.CreateCell(16);
                            Cell16.SetCellValue("");
                            Cell16.CellStyle = cellStyleNormalRightLIGHTGREEN;

                            //Annual
                            ICell Cell17 = row.CreateCell(17);
                            Cell17.SetCellValue(ExcelDoubleToStringFormat(record.WPOutputCostGVM));
                            Cell17.CellStyle = cellStyleNumberLIGHTGREEN;

                            ICell Cell18 = row.CreateCell(18);
                            Cell18.SetCellValue("");
                            Cell18.CellStyle = cellStyleNormalRightLIGHTGREEN;

                            //GRAY AREA
                            ICell Cell19 = row.CreateCell(19);
                            Cell19.SetCellValue("");
                            Cell19.CellStyle = cellStyleNormalGRAY;

                            ICell Cell20 = row.CreateCell(20);
                            Cell20.SetCellValue("");
                            Cell20.CellStyle = cellStyleNormalGRAY;

                        }

                        

                    }
                }

                IRow rowtot0 = worksheet0.CreateRow(_countrecords+2);

                ICell Celltot00 = rowtot0.CreateCell(0);
                Celltot00.SetCellValue("");
                Celltot00.CellStyle = cellStyleNormalGRAY;

                ICell Celltot100 = rowtot0.CreateCell(1);
                Celltot100.SetCellValue("");
                Celltot100.CellStyle = cellStyleYellowNormalSTART;

                ICell Celltot200 = rowtot0.CreateCell(2);
                Celltot200.SetCellValue("");
                Celltot200.CellStyle = cellStyleYellowNormalMiddle;

                ICell Celltot30 = rowtot0.CreateCell(3);
                Celltot30.SetCellValue("");
                Celltot30.CellStyle = cellStyleYellowNormalMiddle;

                ICell Celltot40 = rowtot0.CreateCell(4);
                Celltot40.SetCellValue("");
                Celltot40.CellStyle = cellStyleYellowNormalMiddle;

                ICell Celltot50 = rowtot0.CreateCell(5);
                Celltot50.SetCellValue("");
                Celltot50.CellStyle = cellStyleYellowNormalMiddle;

                ICell Celltot60 = rowtot0.CreateCell(6);
                Celltot60.SetCellValue("");
                Celltot60.CellStyle = cellStyleYellowNormalMiddle;

                ICell Celltot70 = rowtot0.CreateCell(7);
                Celltot70.SetCellValue("");
                Celltot70.CellStyle = cellStyleYellowNormalMiddle;

                ICell Celltot80 = rowtot0.CreateCell(8);
                Celltot80.SetCellValue("TOTALS");
                Celltot80.CellStyle = cellStyleYellowNormalEND;


                //Q1
                ICell Celltot90 = rowtot0.CreateCell(9);
                Celltot90.SetCellValue(ExcelDoubleToStringFormat(q1total));
                Celltot90.CellStyle = cellStyleNormalYellowRight;

                ICell Celltot1000 = rowtot0.CreateCell(10);
                Celltot1000.SetCellValue("");
                Celltot1000.CellStyle = cellStyleNormalYellowRight;

                //Q2
                ICell Celltot110 = rowtot0.CreateCell(11);
                Celltot110.SetCellValue(ExcelDoubleToStringFormat(q2total));
                Celltot110.CellStyle = cellStyleNormalYellowRight;

                ICell Celltot120 = rowtot0.CreateCell(12);
                Celltot120.SetCellValue("");
                Celltot120.CellStyle = cellStyleNormalYellowRight;

                //Q3
                ICell Celltot130 = rowtot0.CreateCell(13);
                Celltot130.SetCellValue(ExcelDoubleToStringFormat(q3total));
                Celltot130.CellStyle = cellStyleNormalYellowRight;

                ICell Celltot140 = rowtot0.CreateCell(14);
                Celltot140.SetCellValue("");
                Celltot140.CellStyle = cellStyleNormalYellowRight;

                //Q4
                ICell Celltot150 = rowtot0.CreateCell(15);
                Celltot150.SetCellValue(ExcelDoubleToStringFormat(q4total));
                Celltot150.CellStyle = cellStyleNormalYellowRight;

                ICell Celltot160 = rowtot0.CreateCell(16);
                Celltot160.SetCellValue("");
                Celltot160.CellStyle = cellStyleNormalYellowRight;

                //Annual
                ICell Celltot170 = rowtot0.CreateCell(17);
                Celltot170.SetCellValue(ExcelDoubleToStringFormat(annualtotal));
                Celltot170.CellStyle = cellStyleNormalYellowRight;

                ICell Celltot180 = rowtot0.CreateCell(18);
                Celltot180.SetCellValue("");
                Celltot180.CellStyle = cellStyleNormalYellowRight;

                

                //GRAY AREA
                ICell Celltot190 = rowtot0.CreateCell(19);
                Celltot190.SetCellValue("");
                Celltot190.CellStyle = cellStyleNormalGRAY;

                ICell Celltot2000 = rowtot0.CreateCell(20);
                Celltot2000.SetCellValue("");
                Celltot2000.CellStyle = cellStyleNormalGRAY;
       


                //EDITING T TEMPLATE ENDS HERE....








                //SAVING TEMPLATE STARTS HERE....

                using (FileStream stream = new FileStream(pathtofile_save, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(stream);
                } 


                //SAVING TEMPLATE ENDS HERE....





            }
            catch (Exception)
            {

            }
           
           
           
           
           
           
            

            



            //Save File Ends Here...


            






            string contentType =  "application/vnd.ms-excel";//"application/pdf"
           // string pathtofile=@"wwwroot/appdirectory/excelreports/institutional/Procurement_Plan_2021.xlsx";
            
            string pathtofile="/appdirectory/excelreports/institutional/finance/Institutional_Workplan_Budget_Lines_" +_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name +"_" +periodname+".xlsx";
           
            




            return File(pathtofile, contentType, "Institutional_Workplan_Budget_Lines_" +_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name +"_" +periodname+".xlsx");

        }


        public FileResult DirectorateWorkplanRangeExcel(string id, string periodid, string dirid)
        {
            IWorkbook workbook;
            string path=@"wwwroot/appdirectory/excelreports/directorate/workplan/Directorate_Level_Workplan_Template.xlsx";


            WP_DispatchCycle cyclerec=_wpDispatchCycleRepository.GetRecord(id);
            string pathtofile_save="";

           
      
            string periodname="";
            if(periodid=="1")
                periodname="Q1";
            else if (periodid=="2")
                periodname="Q2";
            else if (periodid=="3")
                periodname="Q3";
            else if (periodid=="4")
                periodname="Q4"; 
            else if (periodid=="5")
                periodname="Semester_1"; 
            else if (periodid=="6")
                periodname="Semester_2";
            else if (periodid=="7")
                periodname="Annual";
            else
            {
                DateTime pstart=new DateTime(cyclerec.PeriodStartDate.Year, cyclerec.PeriodStartDate.Month, cyclerec.PeriodStartDate.Day);
                DateTime pend=new DateTime(cyclerec.PeriodEndDate.Year, cyclerec.PeriodEndDate.Month, cyclerec.PeriodEndDate.Day);
                periodname=pstart.Date.ToString("MMM d, yyyy") + " - "+ pend.Date.ToString("MMM d, yyyy"); 
                
            }

            Struc_Directorate _directorate=_strucDirectorateRepository.GetRecord(Int32.Parse(dirid));

            pathtofile_save=@"wwwroot/appdirectory/excelreports/directorate/workplan/"+_directorate.AcronymName+"_Workplan_" +_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name +"_" +periodname+".xlsx";

            
            
           


            try
            {
                //OPENING TEMPLATE STARTS HERE....
                    FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                    // Try to read workbook as XLSX:
                    try
                    {
                        workbook = new XSSFWorkbook(fs);
                    }
                    catch
                    {
                        workbook = null;
                    }

                    // If reading fails, try to read workbook as XLS:
                    if (workbook == null)
                    {
                        workbook = new HSSFWorkbook(fs);
                    }
                //OPENING TEMPLATE ENDS HERE....


                //Starts****STYLING*****//

                IFont fontnormal = workbook.CreateFont();
                fontnormal.IsBold = false;
                fontnormal.FontHeightInPoints = 11;
                fontnormal.FontName="Arial";

                IFont fontnormalbold = workbook.CreateFont();
                fontnormalbold.IsBold = true;
                fontnormalbold.FontHeightInPoints = 11;
                fontnormalbold.FontName="Arial";

                ICellStyle cellStyleNormal = workbook.CreateCellStyle();
                cellStyleNormal.SetFont(fontnormal);
                cellStyleNormal.BorderLeft = BorderStyle.Thin;
                cellStyleNormal.BorderTop = BorderStyle.Thin;
                cellStyleNormal.BorderRight = BorderStyle.Thin;
                cellStyleNormal.BorderBottom = BorderStyle.Thin;
                cellStyleNormal.VerticalAlignment = VerticalAlignment.Top;
                cellStyleNormal.Alignment =HorizontalAlignment.Left;
                cellStyleNormal.WrapText=true;
                cellStyleNormal.FillForegroundColor=26;
                cellStyleNormal.FillPattern=FillPattern.SolidForeground; 

                ICellStyle cellStyleNormalWHITE = workbook.CreateCellStyle();
                cellStyleNormalWHITE.SetFont(fontnormal);
                cellStyleNormalWHITE.BorderLeft = BorderStyle.Thin;
                cellStyleNormalWHITE.BorderTop = BorderStyle.Thin;
                cellStyleNormalWHITE.BorderRight = BorderStyle.Thin;
                cellStyleNormalWHITE.BorderBottom = BorderStyle.Thin;
                cellStyleNormalWHITE.VerticalAlignment = VerticalAlignment.Top;
                cellStyleNormalWHITE.Alignment =HorizontalAlignment.Left;
                cellStyleNormalWHITE.WrapText=true;
                cellStyleNormalWHITE.FillForegroundColor=9;
                cellStyleNormalWHITE.FillPattern=FillPattern.SolidForeground; 

                ICellStyle cellStyleNormalWHITERIGHT = workbook.CreateCellStyle();
                cellStyleNormalWHITERIGHT.SetFont(fontnormal);
                cellStyleNormalWHITERIGHT.BorderLeft = BorderStyle.Thin;
                cellStyleNormalWHITERIGHT.BorderTop = BorderStyle.Thin;
                cellStyleNormalWHITERIGHT.BorderRight = BorderStyle.Thin;
                cellStyleNormalWHITERIGHT.BorderBottom = BorderStyle.Thin;
                cellStyleNormalWHITERIGHT.VerticalAlignment = VerticalAlignment.Top;
                cellStyleNormalWHITERIGHT.Alignment =HorizontalAlignment.Right;
                cellStyleNormalWHITERIGHT.WrapText=true;
                cellStyleNormalWHITERIGHT.FillForegroundColor=9;
                cellStyleNormalWHITERIGHT.FillPattern=FillPattern.SolidForeground; 


                ICellStyle cellStyleNormalWHITEMIDDLE = workbook.CreateCellStyle();
                cellStyleNormalWHITEMIDDLE.SetFont(fontnormal);
                cellStyleNormalWHITEMIDDLE.BorderLeft = BorderStyle.None;
                cellStyleNormalWHITEMIDDLE.BorderTop = BorderStyle.Thin;
                cellStyleNormalWHITEMIDDLE.BorderRight = BorderStyle.None;
                cellStyleNormalWHITEMIDDLE.BorderBottom = BorderStyle.Thin;
                cellStyleNormalWHITEMIDDLE.VerticalAlignment = VerticalAlignment.Top;
                cellStyleNormalWHITEMIDDLE.Alignment =HorizontalAlignment.Left;
                cellStyleNormalWHITEMIDDLE.WrapText=true;
                cellStyleNormalWHITEMIDDLE.FillForegroundColor=9;
                cellStyleNormalWHITEMIDDLE.FillPattern=FillPattern.SolidForeground; 

                ICellStyle cellStyleNormalWHITEEND = workbook.CreateCellStyle();
                cellStyleNormalWHITEEND.SetFont(fontnormal);
                cellStyleNormalWHITEEND.BorderLeft = BorderStyle.None;
                cellStyleNormalWHITEEND.BorderTop = BorderStyle.Thin;
                cellStyleNormalWHITEEND.BorderRight = BorderStyle.Thin;
                cellStyleNormalWHITEEND.BorderBottom = BorderStyle.Thin;
                cellStyleNormalWHITEEND.VerticalAlignment = VerticalAlignment.Top;
                cellStyleNormalWHITEEND.Alignment =HorizontalAlignment.Left;
                cellStyleNormalWHITEEND.WrapText=true;
                cellStyleNormalWHITEEND.FillForegroundColor=9;
                cellStyleNormalWHITEEND.FillPattern=FillPattern.SolidForeground; 


                ICellStyle cellStyleNormalLIGHTYELLOW = workbook.CreateCellStyle();
                cellStyleNormalLIGHTYELLOW.SetFont(fontnormal);
                cellStyleNormalLIGHTYELLOW.BorderLeft = BorderStyle.Thin;
                cellStyleNormalLIGHTYELLOW.BorderTop = BorderStyle.Thin;
                cellStyleNormalLIGHTYELLOW.BorderRight = BorderStyle.Thin;
                cellStyleNormalLIGHTYELLOW.BorderBottom = BorderStyle.Thin;
                cellStyleNormalLIGHTYELLOW.VerticalAlignment = VerticalAlignment.Top;
                cellStyleNormalLIGHTYELLOW.Alignment =HorizontalAlignment.Left;
                cellStyleNormalLIGHTYELLOW.WrapText=true;
                cellStyleNormalLIGHTYELLOW.FillForegroundColor=26;
                cellStyleNormalLIGHTYELLOW.FillPattern=FillPattern.SolidForeground; 

                ICellStyle cellStyleNormalBold = workbook.CreateCellStyle();
                cellStyleNormalBold.SetFont(fontnormalbold);
                cellStyleNormalBold.BorderLeft = BorderStyle.Thin;
                cellStyleNormalBold.BorderTop = BorderStyle.Thin;
                cellStyleNormalBold.BorderRight = BorderStyle.Thin;
                cellStyleNormalBold.BorderBottom = BorderStyle.Thin;
                cellStyleNormalBold.VerticalAlignment = VerticalAlignment.Top;
                cellStyleNormalBold.Alignment =HorizontalAlignment.Left;
                cellStyleNormalBold.WrapText=true;
                cellStyleNormalBold.FillForegroundColor=42;
                cellStyleNormalBold.FillPattern=FillPattern.SolidForeground; 

                ICellStyle cellStyleNormalBoldRIGHT = workbook.CreateCellStyle();
                cellStyleNormalBoldRIGHT.SetFont(fontnormalbold);
                cellStyleNormalBoldRIGHT.BorderLeft = BorderStyle.Thin;
                cellStyleNormalBoldRIGHT.BorderTop = BorderStyle.Thin;
                cellStyleNormalBoldRIGHT.BorderRight = BorderStyle.Thin;
                cellStyleNormalBoldRIGHT.BorderBottom = BorderStyle.Thin;
                cellStyleNormalBoldRIGHT.VerticalAlignment = VerticalAlignment.Top;
                cellStyleNormalBoldRIGHT.Alignment =HorizontalAlignment.Right;
                cellStyleNormalBoldRIGHT.WrapText=true;
                cellStyleNormalBoldRIGHT.FillForegroundColor=42;
                cellStyleNormalBoldRIGHT.FillPattern=FillPattern.SolidForeground; 

                ICellStyle cellStyleNormalRight = workbook.CreateCellStyle();
                cellStyleNormalRight.SetFont(fontnormal);
                cellStyleNormalRight.BorderLeft = BorderStyle.Thin;
                cellStyleNormalRight.BorderTop = BorderStyle.Thin;
                cellStyleNormalRight.BorderRight = BorderStyle.Thin;
                cellStyleNormalRight.BorderBottom = BorderStyle.Thin;
                cellStyleNormalRight.VerticalAlignment = VerticalAlignment.Top;
                cellStyleNormalRight.Alignment =HorizontalAlignment.Right;
                cellStyleNormalRight.WrapText=true;
                cellStyleNormalRight.FillForegroundColor=26;
                cellStyleNormalRight.FillPattern=FillPattern.SolidForeground; 


                ICellStyle cellStyleNormalLIGHTGREEN = workbook.CreateCellStyle();
                cellStyleNormalLIGHTGREEN.SetFont(fontnormal);
                cellStyleNormalLIGHTGREEN.BorderLeft = BorderStyle.Thin;
                cellStyleNormalLIGHTGREEN.BorderTop = BorderStyle.Thin;
                cellStyleNormalLIGHTGREEN.BorderRight = BorderStyle.Thin;
                cellStyleNormalLIGHTGREEN.BorderBottom = BorderStyle.Thin;
                cellStyleNormalLIGHTGREEN.VerticalAlignment = VerticalAlignment.Top;
                cellStyleNormalLIGHTGREEN.Alignment =HorizontalAlignment.Left;
                cellStyleNormalLIGHTGREEN.WrapText=true;
                cellStyleNormalLIGHTGREEN.FillForegroundColor=42;
                cellStyleNormalLIGHTGREEN.FillPattern=FillPattern.SolidForeground; 

                ICellStyle cellStyleNormalRightLIGHTGREEN = workbook.CreateCellStyle();
                cellStyleNormalRightLIGHTGREEN.SetFont(fontnormal);
                cellStyleNormalRightLIGHTGREEN.BorderLeft = BorderStyle.Thin;
                cellStyleNormalRightLIGHTGREEN.BorderTop = BorderStyle.Thin;
                cellStyleNormalRightLIGHTGREEN.BorderRight = BorderStyle.Thin;
                cellStyleNormalRightLIGHTGREEN.BorderBottom = BorderStyle.Thin;
                cellStyleNormalRightLIGHTGREEN.VerticalAlignment = VerticalAlignment.Top;
                cellStyleNormalRightLIGHTGREEN.Alignment =HorizontalAlignment.Right;
                cellStyleNormalRightLIGHTGREEN.WrapText=true;
                cellStyleNormalRightLIGHTGREEN.FillForegroundColor=42;
                cellStyleNormalRightLIGHTGREEN.FillPattern=FillPattern.SolidForeground; 

                ICellStyle cellStyleYellowNormalSTART = workbook.CreateCellStyle();
                cellStyleYellowNormalSTART.SetFont(fontnormal);
                cellStyleYellowNormalSTART.BorderLeft = BorderStyle.Thin;
                cellStyleYellowNormalSTART.BorderTop = BorderStyle.Thin;
                cellStyleYellowNormalSTART.BorderRight = BorderStyle.None;
                cellStyleYellowNormalSTART.BorderBottom = BorderStyle.Thin;
                cellStyleYellowNormalSTART.VerticalAlignment = VerticalAlignment.Top;
                cellStyleYellowNormalSTART.Alignment =HorizontalAlignment.Left;
                cellStyleYellowNormalSTART.WrapText=true;
                cellStyleYellowNormalSTART.FillForegroundColor=13;
                cellStyleYellowNormalSTART.FillPattern=FillPattern.SolidForeground; 

                ICellStyle cellStyleYellowNormalEND = workbook.CreateCellStyle();
                cellStyleYellowNormalEND.SetFont(fontnormalbold);
                cellStyleYellowNormalEND.BorderLeft = BorderStyle.None;
                cellStyleYellowNormalEND.BorderTop = BorderStyle.Thin;
                cellStyleYellowNormalEND.BorderRight = BorderStyle.Thin;
                cellStyleYellowNormalEND.BorderBottom = BorderStyle.Thin;
                cellStyleYellowNormalEND.VerticalAlignment = VerticalAlignment.Top;
                cellStyleYellowNormalEND.Alignment =HorizontalAlignment.Right;
                cellStyleYellowNormalEND.WrapText=true;
                cellStyleYellowNormalEND.FillForegroundColor=13;
                cellStyleYellowNormalEND.FillPattern=FillPattern.SolidForeground; 

                ICellStyle cellStyleYellowNormal = workbook.CreateCellStyle();
                cellStyleYellowNormal.SetFont(fontnormalbold);
                cellStyleYellowNormal.BorderLeft = BorderStyle.Thin;
                cellStyleYellowNormal.BorderTop = BorderStyle.Thin;
                cellStyleYellowNormal.BorderRight = BorderStyle.Thin;
                cellStyleYellowNormal.BorderBottom = BorderStyle.Thin;
                cellStyleYellowNormal.VerticalAlignment = VerticalAlignment.Top;
                cellStyleYellowNormal.Alignment =HorizontalAlignment.Left;
                cellStyleYellowNormal.WrapText=true;
                cellStyleYellowNormal.FillForegroundColor=13;
                cellStyleYellowNormal.FillPattern=FillPattern.SolidForeground; 

                ICellStyle cellStyleNormalYellowRight = workbook.CreateCellStyle();
                cellStyleNormalYellowRight.SetFont(fontnormalbold);
                cellStyleNormalYellowRight.BorderLeft = BorderStyle.Thin;
                cellStyleNormalYellowRight.BorderTop = BorderStyle.Thin;
                cellStyleNormalYellowRight.BorderRight = BorderStyle.Thin;
                cellStyleNormalYellowRight.BorderBottom = BorderStyle.Thin;
                cellStyleNormalYellowRight.VerticalAlignment = VerticalAlignment.Top;
                cellStyleNormalYellowRight.Alignment =HorizontalAlignment.Right;
                cellStyleNormalYellowRight.WrapText=true;
                cellStyleNormalYellowRight.FillForegroundColor=13;
                cellStyleNormalYellowRight.FillPattern=FillPattern.SolidForeground; 





                ICellStyle cellStyleYellowNormalMiddle = workbook.CreateCellStyle();
                cellStyleYellowNormalMiddle.SetFont(fontnormalbold);
                cellStyleYellowNormalMiddle.BorderLeft = BorderStyle.None;
                cellStyleYellowNormalMiddle.BorderTop = BorderStyle.Thin;
                cellStyleYellowNormalMiddle.BorderRight = BorderStyle.None;
                cellStyleYellowNormalMiddle.BorderBottom = BorderStyle.Thin;
                cellStyleYellowNormalMiddle.VerticalAlignment = VerticalAlignment.Top;
                cellStyleYellowNormalMiddle.Alignment =HorizontalAlignment.Left;
                cellStyleYellowNormalMiddle.WrapText=true;
                cellStyleYellowNormalMiddle.FillForegroundColor=13;
                cellStyleYellowNormalMiddle.FillPattern=FillPattern.SolidForeground; 

                ICellStyle cellStyleNormalYellowRightMiddle = workbook.CreateCellStyle();
                cellStyleNormalYellowRightMiddle.SetFont(fontnormalbold);
                cellStyleNormalYellowRightMiddle.BorderLeft = BorderStyle.None;
                cellStyleNormalYellowRightMiddle.BorderTop = BorderStyle.Thin;
                cellStyleNormalYellowRightMiddle.BorderRight = BorderStyle.None;
                cellStyleNormalYellowRightMiddle.BorderBottom = BorderStyle.Thin;
                cellStyleNormalYellowRightMiddle.VerticalAlignment = VerticalAlignment.Top;
                cellStyleNormalYellowRightMiddle.Alignment =HorizontalAlignment.Right;
                cellStyleNormalYellowRightMiddle.WrapText=true;
                cellStyleNormalYellowRightMiddle.FillForegroundColor=13;
                cellStyleNormalYellowRightMiddle.FillPattern=FillPattern.SolidForeground; 


                ICellStyle cellStyleNormalGRAY = workbook.CreateCellStyle();
                cellStyleNormalGRAY.SetFont(fontnormal);
                cellStyleNormalGRAY.BorderLeft = BorderStyle.Thin;
                cellStyleNormalGRAY.BorderTop = BorderStyle.Thin;
                cellStyleNormalGRAY.BorderRight = BorderStyle.Thin;
                cellStyleNormalGRAY.BorderBottom = BorderStyle.Thin;
                cellStyleNormalGRAY.VerticalAlignment = VerticalAlignment.Top;
                cellStyleNormalGRAY.Alignment =HorizontalAlignment.Left;
                cellStyleNormalGRAY.WrapText=true;
                cellStyleNormalGRAY.FillForegroundColor=22;
                cellStyleNormalGRAY.FillPattern=FillPattern.SolidForeground; 

                

                ICellStyle cellStyleNumber = workbook.CreateCellStyle();
                cellStyleNumber.SetFont(fontnormal);
                cellStyleNumber.BorderLeft = BorderStyle.Thin;
                cellStyleNumber.BorderTop = BorderStyle.Thin;
                cellStyleNumber.BorderRight = BorderStyle.Thin;
                cellStyleNumber.BorderBottom = BorderStyle.Thin;
                cellStyleNumber.VerticalAlignment = VerticalAlignment.Top;
                cellStyleNumber.Alignment =HorizontalAlignment.Right;
                cellStyleNumber.WrapText=true;
                cellStyleNumber.FillForegroundColor=26;
                cellStyleNumber.FillPattern=FillPattern.SolidForeground; 

                ICellStyle cellStyleNumberLIGHTGREEN = workbook.CreateCellStyle();
                cellStyleNumberLIGHTGREEN.SetFont(fontnormal);
                cellStyleNumberLIGHTGREEN.BorderLeft = BorderStyle.Thin;
                cellStyleNumberLIGHTGREEN.BorderTop = BorderStyle.Thin;
                cellStyleNumberLIGHTGREEN.BorderRight = BorderStyle.Thin;
                cellStyleNumberLIGHTGREEN.BorderBottom = BorderStyle.Thin;
                cellStyleNumberLIGHTGREEN.VerticalAlignment = VerticalAlignment.Top;
                cellStyleNumberLIGHTGREEN.Alignment =HorizontalAlignment.Right;
                cellStyleNumberLIGHTGREEN.WrapText=true;
                cellStyleNumberLIGHTGREEN.FillForegroundColor=42;
                cellStyleNumberLIGHTGREEN.FillPattern=FillPattern.SolidForeground; 


                //Ends****STYLING******//


                //Starts******HEADER********//

                string periodname_full="";
            
                if(cyclerec.Period_Id==8)
                {
                    DateTime pstart=new DateTime(cyclerec.PeriodStartDate.Year, cyclerec.PeriodStartDate.Month, cyclerec.PeriodStartDate.Day);
                    DateTime pend=new DateTime(cyclerec.PeriodEndDate.Year, cyclerec.PeriodEndDate.Month, cyclerec.PeriodEndDate.Day);
                    periodname_full=pstart.Date.ToString("MMM d, yyyy") + " - "+ pend.Date.ToString("MMM d, yyyy"); 
                }
                else
                {
                    periodname_full=_lkupPeriodRepository.GetRecord(cyclerec.Period_Id).Record_Name;
                }

                string periodnameinst="";
               if(periodid=="8")
               {
                    DateTime pstart=new DateTime(cyclerec.PeriodStartDate.Year, cyclerec.PeriodStartDate.Month, cyclerec.PeriodStartDate.Day);
                    DateTime pend=new DateTime(cyclerec.PeriodEndDate.Year, cyclerec.PeriodEndDate.Month, cyclerec.PeriodEndDate.Day);
                    periodnameinst=pstart.Date.ToString("MMM d, yy") + " - "+ pend.Date.ToString("MMM d, yy");

               }
               else
               {
                    periodnameinst=_lkupPeriodRepository.GetRecord(Int32.Parse(periodid)).Record_Name;
               }


                string rangnameinst=periodnameinst+", "+_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name;
                string rangnameinstupper=rangnameinst.ToUpper();

                string rangnameinst_short="";
                if(periodid=="1")
                    rangnameinst_short="Q1";// of "+_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name;
                else if (periodid=="2")
                    rangnameinst_short="Q2";// of "+_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name;
                else if (periodid=="3")
                    rangnameinst_short="Q3";//of "+_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name;
                else if (periodid=="4")
                    rangnameinst_short="Q4"; //of "+_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name;
                else if (periodid=="5")
                    rangnameinst_short="Semester 1"; //of "+_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name;
                else if (periodid=="6")
                    rangnameinst_short="Semester 2";// of "+_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name;
                else if (periodid=="7")
                    rangnameinst_short=_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name+ " (Annual)";
                else
                    rangnameinst_short=_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name+ " ("+periodnameinst+")";

                string rangnameinst_short_tot="";
                if (periodid=="5")
                    rangnameinst_short_tot="S1";
                else if (periodid=="6")
                    rangnameinst_short_tot="S2";
                else
                    rangnameinst_short_tot=rangnameinst_short;


                var DB_Records = _transStrucDirectorateRepository.GetAllRecordsByDirectorateId(Int32.Parse(dirid)).ToList();
                int _countrecs =  DB_Records.Count();
    
                double institutional_dp_budget=0;
                double institutional_ms_budget=0;
                double institutional_total_budget=0;

                // double institutional_dp_budget_act=0;
                // double institutional_ms_budget_act=0;
                // double institutional_diff_budget_act=0;
    
                if(_countrecs>0)
                {



                        foreach (var rec_set in DB_Records)
                        {
                            //**********Compute Total MS and DP Budgets of Institution***********// 
                            var DB_RecordsDivs=_transStrucDivisionRepository.GetAllRecordsByDirectorate(rec_set.Transaction_Id).ToList();


                            //Check if the division have any submission GetRecordsByDivRecs
                            foreach (var rec_div in DB_RecordsDivs)
                            {
                                var DivMainRecs=_wpMainRecordRepository.GetRecordsByDivRecs(rec_div.Division_Id).ToList();
                                //Fetch the Division Records that correspond the cycle 
                                if(cyclerec.Period_Id==8)
                                {
                                    DivMainRecs=_wpMainRecordRepository.GetRecordsByDivisionYearAndPeriodStartEnd(rec_div.Division_Id, cyclerec.FiscalYear_Id,cyclerec.Period_Id, cyclerec.PeriodStartDate, cyclerec.PeriodEndDate).ToList();
                                }
                                else
                                {
                                    DivMainRecs=_wpMainRecordRepository.GetRecordsByDivisionYearAndPeriod(rec_div.Division_Id, cyclerec.FiscalYear_Id,cyclerec.Period_Id).ToList();
                                }




                                foreach (var rec_proj_main in DivMainRecs)
                                {

                                    
                                    var DB_Outpus_for_Project=_wpOutputsRepository.GetRecordsByMainRecordId(rec_proj_main.Transaction_Id).ToList();

                                    foreach (var rec_proj_output in DB_Outpus_for_Project)
                                    {
                                    // bool dpfunding=false;
                                        int ms_count=0;
                                        int dp_count=0;
                                        double output_total_budget=0;

                                        var DB_OutputActivities=_wpOutputActivitiesRepository.GetRecordsByOutputId(rec_proj_output.Transaction_Id).ToList();

                                        foreach (var rec_proj_output_act in DB_OutputActivities)
                                        {
                                            if(rec_proj_output_act.PartnerFunding==true)
                                            {
                                                dp_count=dp_count+1;
                                            }
                                            else
                                            {
                                                ms_count=ms_count+1;
                                            }
                                            output_total_budget=output_total_budget+rec_proj_output_act.ActivityCost;

                                        }

                                        //Get All the Mobility Records that Meet the Period Range Boundry
                                        var DB_Mobilities_Recs=_wpMobilityRepository.GetRecordsByOutputId(rec_proj_output.Transaction_Id).ToList();
                                        var DB_Mobilities_Recs_All=_wpMobilityRepository.GetRecordsByOutputId(rec_proj_output.Transaction_Id).ToList();
                                        if(periodid=="1")
                                        {
                                            DB_Mobilities_Recs=_wpMobilityRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 1, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 3, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 3))).ToList();
                                        }
                                        else if(periodid=="2")
                                        {
                                            DB_Mobilities_Recs=_wpMobilityRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 4, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6))).ToList();
                                        }
                                        else if(periodid=="3")
                                        {
                                            DB_Mobilities_Recs=_wpMobilityRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 7, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 9, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 9))).ToList();
                                        }
                                        else if(periodid=="4")
                                        {
                                            DB_Mobilities_Recs=_wpMobilityRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 10, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12))).ToList();
                                        }
                                        else if(periodid=="5")
                                        {
                                            DB_Mobilities_Recs=_wpMobilityRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 1, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6))).ToList();
                                        }
                                        else if(periodid=="6")
                                        {
                                            DB_Mobilities_Recs=_wpMobilityRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 7, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12))).ToList();
                                        }
                                        else if(periodid=="7")
                                        {
                                            DB_Mobilities_Recs=_wpMobilityRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 1, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12))).ToList();
                                        }
                                        else if(periodid=="8")
                                        {
                                            DB_Mobilities_Recs=_wpMobilityRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, cyclerec.PeriodStartDate, cyclerec.PeriodEndDate).ToList();
                                        }



                                        //Get All the Procurement Records that Meet the Period Range Boundry

                                        var DB_Procurement_Recs=_wpProcurementRepository.GetRecordsByOutputId(rec_proj_output.Transaction_Id).ToList();
                                        var DB_Procurement_Recs_All=_wpProcurementRepository.GetRecordsByOutputId(rec_proj_output.Transaction_Id).ToList();
                                        if(periodid=="1")
                                        {
                                            DB_Procurement_Recs=_wpProcurementRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 1, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 3, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 3))).ToList();
                                        }
                                        else if(periodid=="2")
                                        {
                                            DB_Procurement_Recs=_wpProcurementRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 4, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6))).ToList();
                                        }
                                        else if(periodid=="3")
                                        {
                                            DB_Procurement_Recs=_wpProcurementRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 7, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 9, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 9))).ToList();
                                        }
                                        else if(periodid=="4")
                                        {
                                            DB_Procurement_Recs=_wpProcurementRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 10, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12))).ToList();
                                        }
                                        else if(periodid=="5")
                                        {
                                            DB_Procurement_Recs=_wpProcurementRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 1, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6))).ToList();
                                        }
                                        else if(periodid=="6")
                                        {
                                            DB_Procurement_Recs=_wpProcurementRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 7, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12))).ToList();
                                        }
                                        else if(periodid=="7")
                                        {
                                            DB_Procurement_Recs=_wpProcurementRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 1, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12))).ToList();
                                        }
                                        else if(periodid=="8")
                                        {
                                            DB_Procurement_Recs=_wpProcurementRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, cyclerec.PeriodStartDate, cyclerec.PeriodEndDate).ToList();
                                        }

                                        //Get All the Communication Records that Meet the Period Range Boundry

                                        var DB_Communication_Recs=_wpCommunicationRepository.GetRecordsByOutputId(rec_proj_output.Transaction_Id).ToList();
                                        var DB_Communication_Recs_All=_wpCommunicationRepository.GetRecordsByOutputId(rec_proj_output.Transaction_Id).ToList();
                                        if(periodid=="1")
                                        {
                                            DB_Communication_Recs=_wpCommunicationRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 1, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 3, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 3))).ToList();
                                        }
                                        else if(periodid=="2")
                                        {
                                            DB_Communication_Recs=_wpCommunicationRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 4, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6))).ToList();
                                        }
                                        else if(periodid=="3")
                                        {
                                            DB_Communication_Recs=_wpCommunicationRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 7, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 9, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 9))).ToList();
                                        }
                                        else if(periodid=="4")
                                        {
                                            DB_Communication_Recs=_wpCommunicationRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 10, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12))).ToList();
                                        }
                                        else if(periodid=="5")
                                        {
                                            DB_Communication_Recs=_wpCommunicationRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 1, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6))).ToList();
                                        }
                                        else if(periodid=="6")
                                        {
                                            DB_Communication_Recs=_wpCommunicationRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 7, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12))).ToList();
                                        }
                                        else if(periodid=="7")
                                        {
                                            DB_Communication_Recs=_wpCommunicationRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 1, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12))).ToList();
                                        }
                                        else if(periodid=="8")
                                        {
                                            DB_Communication_Recs=_wpCommunicationRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, cyclerec.PeriodStartDate, cyclerec.PeriodEndDate).ToList();
                                        }

                                        //inner totals
                                        double output_dp_budget=0;
                                        double output_ms_budget=0;
                                        double output_budget_all=0;
                                        




                                        //Sum as DP
                                        if(dp_count>ms_count)
                                        {
                                            foreach (var _innerrec in DB_Mobilities_Recs)
                                            {
                                                output_dp_budget=output_dp_budget+_innerrec.MobilityCost;
                                            }

                                            foreach (var _innerrec in DB_Procurement_Recs)
                                            {
                                                output_dp_budget=output_dp_budget+_innerrec.WPProcurementCost;
                                            }

                                            foreach (var _innerrec in DB_Communication_Recs)
                                            {
                                                output_dp_budget=output_dp_budget+_innerrec.WPCommsCost;
                                            }

                                            //Get the Overall Total for Mobility, Procurement and Communication 
                                            
                                            foreach (var _innerrec in DB_Mobilities_Recs_All)
                                            {
                                                output_budget_all=output_budget_all+_innerrec.MobilityCost;
                                            }

                                            foreach (var _innerrec in DB_Procurement_Recs_All)
                                            {
                                                output_budget_all=output_budget_all+_innerrec.WPProcurementCost;
                                            }

                                            foreach (var _innerrec in DB_Communication_Recs_All)
                                            {
                                                output_budget_all=output_budget_all+_innerrec.WPCommsCost;
                                            }

                                            double remainingfunds=output_total_budget-output_budget_all;

                                            //Add Adjust Cost to DP
                                            if(periodid=="1" || periodid=="2" || periodid=="3" || periodid=="4")
                                            {
                                                if(remainingfunds!=0)
                                                    output_dp_budget=output_dp_budget+(remainingfunds/4.0);
                                            }
                                            else if(periodid=="5" || periodid=="6" )
                                            {
                                                if(remainingfunds!=0)
                                                    output_dp_budget=output_dp_budget+(remainingfunds/2.0);
                                            }
                                            else
                                            {
                                                if(remainingfunds!=0)
                                                    output_dp_budget=output_dp_budget+(remainingfunds/1.0);
                                            }

                                            institutional_dp_budget=institutional_dp_budget+output_dp_budget;
                                                
                                        }
                                        else //Sum as MS
                                        {
                                            foreach (var _innerrec in DB_Mobilities_Recs)
                                            {
                                                output_ms_budget=output_ms_budget+_innerrec.MobilityCost;
                                            }

                                            foreach (var _innerrec in DB_Procurement_Recs)
                                            {
                                                output_ms_budget=output_ms_budget+_innerrec.WPProcurementCost;
                                            }

                                            foreach (var _innerrec in DB_Communication_Recs)
                                            {
                                                output_ms_budget=output_ms_budget+_innerrec.WPCommsCost;
                                            }

                                        //Get the Overall Total for Mobility, Procurement and Communication 
                                            
                                            foreach (var _innerrec in DB_Mobilities_Recs_All)
                                            {
                                                output_budget_all=output_budget_all+_innerrec.MobilityCost;
                                            }

                                            foreach (var _innerrec in DB_Procurement_Recs_All)
                                            {
                                                output_budget_all=output_budget_all+_innerrec.WPProcurementCost;
                                            }

                                            foreach (var _innerrec in DB_Communication_Recs_All)
                                            {
                                                output_budget_all=output_budget_all+_innerrec.WPCommsCost;
                                            }
                                            double remainingfunds=output_total_budget-output_budget_all;

                                            //Add Adjust Cost to DP
                                            if(periodid=="1" || periodid=="2" || periodid=="3" || periodid=="4")
                                            {
                                                if(remainingfunds!=0)
                                                    output_ms_budget=output_ms_budget+(remainingfunds/4.0);
                                            }
                                            else if(periodid=="5" || periodid=="6" )
                                            {
                                                if(remainingfunds!=0)
                                                    output_ms_budget=output_ms_budget+(remainingfunds/2.0);
                                            }
                                            else
                                            {
                                                if(remainingfunds!=0)
                                                    output_ms_budget=output_ms_budget+(remainingfunds/1.0);
                                            }

                                            institutional_ms_budget=institutional_ms_budget+output_ms_budget;

                                        }
                                        
                                        




                                        

                                    }


                                
                                    
                                
                                }






                        

                            }


                        }
                        institutional_total_budget=institutional_ms_budget+institutional_dp_budget;

                }

                ISheet worksheet = workbook.GetSheetAt(0);

                //Row 1
                IRow row1 = worksheet.CreateRow(3);

                ICell CellHeader11 = row1.CreateCell(1);
                CellHeader11.SetCellValue("Directorate");
                CellHeader11.CellStyle = cellStyleNormalBold;

				ICell CellHeader12 = row1.CreateCell(2);
                CellHeader12.SetCellValue(_directorate.Record_Name);
                CellHeader12.CellStyle = cellStyleNormalLIGHTYELLOW;

                ICell CellHeader13 = row1.CreateCell(3);
                CellHeader13.SetCellValue("");
                CellHeader13.CellStyle = cellStyleNormalLIGHTYELLOW;

                ICell CellHeader14 = row1.CreateCell(4);
                CellHeader14.SetCellValue("");
                CellHeader14.CellStyle = cellStyleNormalLIGHTYELLOW;

                ICell CellHeader15 = row1.CreateCell(5);
                CellHeader15.SetCellValue("");
                CellHeader15.CellStyle = cellStyleNormalWHITE;

                ICell CellHeader16 = row1.CreateCell(6);
                CellHeader16.SetCellValue("");
                CellHeader16.CellStyle = cellStyleNormalLIGHTYELLOW;

                var crarow1 = new NPOI.SS.Util.CellRangeAddress(3, 3, 2, 6);
                worksheet.AddMergedRegion(crarow1);


                //Row 2
                IRow row2 = worksheet.CreateRow(4);

                ICell CellHeader21 = row2.CreateCell(1);
                CellHeader21.SetCellValue("Year");
                CellHeader21.CellStyle = cellStyleNormalBold;

				ICell CellHeader22 = row2.CreateCell(2);
                CellHeader22.SetCellValue(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name);
                CellHeader22.CellStyle = cellStyleNormalLIGHTYELLOW;

                ICell CellHeader23 = row2.CreateCell(3);
                CellHeader23.SetCellValue("");
                CellHeader23.CellStyle = cellStyleNormalLIGHTYELLOW;

                ICell CellHeader24 = row2.CreateCell(4);
                CellHeader24.SetCellValue("");
                CellHeader24.CellStyle = cellStyleNormalLIGHTYELLOW;

                ICell CellHeader25 = row2.CreateCell(5);
                CellHeader25.SetCellValue("");
                CellHeader25.CellStyle = cellStyleNormalLIGHTYELLOW;

                ICell CellHeader26 = row2.CreateCell(6);
                CellHeader26.SetCellValue("");
                CellHeader26.CellStyle = cellStyleNormalLIGHTYELLOW;

                var crarow2 = new NPOI.SS.Util.CellRangeAddress(4, 4, 2, 6);
                worksheet.AddMergedRegion(crarow2);



                //Row 3
                IRow row3 = worksheet.CreateRow(5);

                ICell CellHeader31 = row3.CreateCell(1);
                CellHeader31.SetCellValue("Period");
                CellHeader31.CellStyle = cellStyleNormalBold;

				ICell CellHeader32 = row3.CreateCell(2);
                CellHeader32.SetCellValue(periodnameinst);
                CellHeader32.CellStyle = cellStyleNormalLIGHTYELLOW;

                ICell CellHeader33 = row3.CreateCell(3);
                CellHeader33.SetCellValue("");
                CellHeader33.CellStyle = cellStyleNormalLIGHTYELLOW;

                ICell CellHeader34 = row3.CreateCell(4);
                CellHeader34.SetCellValue("");
                CellHeader34.CellStyle = cellStyleNormalLIGHTYELLOW;

                ICell CellHeader35 = row3.CreateCell(5);
                CellHeader35.SetCellValue("");
                CellHeader35.CellStyle = cellStyleNormalLIGHTYELLOW;

                ICell CellHeader36 = row3.CreateCell(6);
                CellHeader36.SetCellValue("");
                CellHeader36.CellStyle = cellStyleNormalLIGHTYELLOW;

                var crarow3 = new NPOI.SS.Util.CellRangeAddress(5, 5, 2, 6);
                worksheet.AddMergedRegion(crarow3);


                //Row 4
                IRow row4 = worksheet.CreateRow(6);

                ICell CellHeader41 = row4.CreateCell(1);
                CellHeader41.SetCellValue("Date Generated");
                CellHeader41.CellStyle = cellStyleNormalBold;

				ICell CellHeader42 = row4.CreateCell(2);
                CellHeader42.SetCellValue(DateTime.Now.Date.ToString("dd/MM/yyyy"));
                CellHeader42.CellStyle = cellStyleNormalLIGHTYELLOW;

                ICell CellHeader43 = row4.CreateCell(3);
                CellHeader43.SetCellValue("");
                CellHeader43.CellStyle = cellStyleNormalLIGHTYELLOW;

                ICell CellHeader44 = row4.CreateCell(4);
                CellHeader44.SetCellValue("");
                CellHeader44.CellStyle = cellStyleNormalLIGHTYELLOW;

                ICell CellHeader45 = row4.CreateCell(5);
                CellHeader45.SetCellValue("");
                CellHeader45.CellStyle = cellStyleNormalLIGHTYELLOW;

                ICell CellHeader46 = row4.CreateCell(6);
                CellHeader46.SetCellValue("");
                CellHeader46.CellStyle = cellStyleNormalLIGHTYELLOW;

                var crarow4 = new NPOI.SS.Util.CellRangeAddress(6, 6, 2, 6);
                worksheet.AddMergedRegion(crarow4);


                //Row 5
                IRow row5 = worksheet.CreateRow(7);

                ICell CellHeader51 = row5.CreateCell(1);
                CellHeader51.SetCellValue("MS Estimated Budget ");
                CellHeader51.CellStyle = cellStyleNormalBold;

				ICell CellHeader52 = row5.CreateCell(2);
                CellHeader52.SetCellValue("US$ "+string.Format("{0:N0}", institutional_ms_budget));
                CellHeader52.CellStyle = cellStyleNormalLIGHTYELLOW;

                ICell CellHeader53 = row5.CreateCell(3);
                CellHeader53.SetCellValue("");
                CellHeader53.CellStyle = cellStyleNormalLIGHTYELLOW;

                ICell CellHeader54 = row5.CreateCell(4);
                CellHeader54.SetCellValue("");
                CellHeader54.CellStyle = cellStyleNormalLIGHTYELLOW;

                ICell CellHeader55 = row5.CreateCell(5);
                CellHeader55.SetCellValue("");
                CellHeader55.CellStyle = cellStyleNormalLIGHTYELLOW;

                ICell CellHeader56 = row5.CreateCell(6);
                CellHeader56.SetCellValue("");
                CellHeader56.CellStyle = cellStyleNormalLIGHTYELLOW;

                var crarow5 = new NPOI.SS.Util.CellRangeAddress(7, 7, 2, 6);
                worksheet.AddMergedRegion(crarow5);



                //Row 6
                IRow row6 = worksheet.CreateRow(8);

                ICell CellHeader61 = row6.CreateCell(1);
                CellHeader61.SetCellValue("DP Estimated Budget ");
                CellHeader61.CellStyle = cellStyleNormalBold;

				ICell CellHeader62 = row6.CreateCell(2);
                CellHeader62.SetCellValue("US$ "+string.Format("{0:N0}", institutional_dp_budget));
                CellHeader62.CellStyle = cellStyleNormalLIGHTYELLOW;

                ICell CellHeader63 = row6.CreateCell(3);
                CellHeader63.SetCellValue("");
                CellHeader63.CellStyle = cellStyleNormalLIGHTYELLOW;

                ICell CellHeader64 = row6.CreateCell(4);
                CellHeader64.SetCellValue("");
                CellHeader64.CellStyle = cellStyleNormalLIGHTYELLOW;

                ICell CellHeader65 = row6.CreateCell(5);
                CellHeader65.SetCellValue("");
                CellHeader65.CellStyle = cellStyleNormalLIGHTYELLOW;

                ICell CellHeader66 = row6.CreateCell(6);
                CellHeader66.SetCellValue("");
                CellHeader66.CellStyle = cellStyleNormalLIGHTYELLOW;

                var crarow6 = new NPOI.SS.Util.CellRangeAddress(8, 8, 2, 6);
                worksheet.AddMergedRegion(crarow6);



                //Row 7
                IRow row7 = worksheet.CreateRow(9);

                ICell CellHeader71 = row7.CreateCell(1);
                CellHeader71.SetCellValue("Total Estimated Budget ");
                CellHeader71.CellStyle = cellStyleNormalBold;

				ICell CellHeader72 = row7.CreateCell(2);
                CellHeader72.SetCellValue("US$ "+string.Format("{0:N0}", institutional_total_budget));
                CellHeader72.CellStyle = cellStyleNormalLIGHTYELLOW;

                ICell CellHeader73 = row7.CreateCell(3);
                CellHeader73.SetCellValue("");
                CellHeader73.CellStyle = cellStyleNormalLIGHTYELLOW;

                ICell CellHeader74 = row7.CreateCell(4);
                CellHeader74.SetCellValue("");
                CellHeader74.CellStyle = cellStyleNormalLIGHTYELLOW;

                ICell CellHeader75 = row7.CreateCell(5);
                CellHeader75.SetCellValue("");
                CellHeader75.CellStyle = cellStyleNormalLIGHTYELLOW;

                ICell CellHeader76 = row7.CreateCell(6);
                CellHeader76.SetCellValue("");
                CellHeader76.CellStyle = cellStyleNormalLIGHTYELLOW;

                var crarow7 = new NPOI.SS.Util.CellRangeAddress(9, 9, 2, 6);
                worksheet.AddMergedRegion(crarow7);


                //Row 8
                IRow row8 = worksheet.CreateRow(10);

                ICell CellHeader81 = row8.CreateCell(1);
                CellHeader81.SetCellValue("Status ");
                CellHeader81.CellStyle = cellStyleNormalBold;

                string approvedstatus="";

                if(periodid=="1" || periodid=="7")
                {
                    approvedstatus="Approved";
                }
                else
                {
                    approvedstatus="Draft";
                }


				ICell CellHeader82 = row8.CreateCell(2);
                CellHeader82.SetCellValue(approvedstatus);
                CellHeader82.CellStyle = cellStyleNormalLIGHTYELLOW;

                ICell CellHeader83 = row8.CreateCell(3);
                CellHeader83.SetCellValue("");
                CellHeader83.CellStyle = cellStyleNormalLIGHTYELLOW;

                ICell CellHeader84 = row8.CreateCell(4);
                CellHeader84.SetCellValue("");
                CellHeader84.CellStyle = cellStyleNormalLIGHTYELLOW;

                ICell CellHeader85 = row8.CreateCell(5);
                CellHeader85.SetCellValue("");
                CellHeader85.CellStyle = cellStyleNormalLIGHTYELLOW;

                ICell CellHeader86 = row8.CreateCell(6);
                CellHeader86.SetCellValue("");
                CellHeader86.CellStyle = cellStyleNormalLIGHTYELLOW;

                var crarow8 = new NPOI.SS.Util.CellRangeAddress(10, 10, 2, 6);
                worksheet.AddMergedRegion(crarow8);

                //Ends********HEADER********//

                


                //Start*****Strategic Priorities Mapping
                int currentrow=13;

                //Stategic Priorities Header
                IRow rowstrahead = worksheet.CreateRow(currentrow);

                ICell CellStraHeader1 = rowstrahead.CreateCell(1);
                CellStraHeader1.SetCellValue("AUDA-NEPAD Strategic Priorities");
                CellStraHeader1.CellStyle = cellStyleNormalBold;

                ICell CellStraHeader2 = rowstrahead.CreateCell(2);
                CellStraHeader2.SetCellValue("");
                CellStraHeader2.CellStyle = cellStyleNormalBold;


                var cra1 = new NPOI.SS.Util.CellRangeAddress(currentrow, currentrow, 1, 2);
                worksheet.AddMergedRegion(cra1);

                ICell CellStraHeader3 = rowstrahead.CreateCell(3);
                CellStraHeader3.SetCellValue("Divisions Contributing to Strategic Priority");
                CellStraHeader3.CellStyle = cellStyleNormalBold;

                ICell CellStraHeader4 = rowstrahead.CreateCell(4);
                CellStraHeader4.SetCellValue("");
                CellStraHeader4.CellStyle = cellStyleNormalBold;

                var cra2 = new NPOI.SS.Util.CellRangeAddress(currentrow, currentrow, 3, 4);
                worksheet.AddMergedRegion(cra2);

                string totalheader="";

                if(periodid=="7" || periodid=="8")
                {
                    totalheader="Total Budget (US$)";
                }
                else
                {
                    totalheader="Total Budget for "+rangnameinst_short_tot+" (US$)";
                }

                ICell CellStraHeader5 = rowstrahead.CreateCell(5);
                CellStraHeader5.SetCellValue(totalheader);
                CellStraHeader5.CellStyle = cellStyleNormalBoldRIGHT;

                ICell CellStraHeader6 = rowstrahead.CreateCell(6);
                CellStraHeader6.SetCellValue("Comments");
                CellStraHeader6.CellStyle = cellStyleNormalBold;


                var DB_RecordsStra = _transStrategyPriorityRepository.GetAllRecords().ToList();
                int _countrecsstra =  DB_RecordsStra.Count();

                int _stracount=0;
                double grand_stra_total_budget=0;
                foreach (var rec_set in DB_RecordsStra)
                {


                    //Get the Divisions Contributing to Strategic Priority AND Total Budgets
                    string rtnstringDirectorates_Stra= string.Empty;
                    var DB_StrategicMainProjs=_wpAUDAPriorityRepository.GetRecordsByYearPeriodAndPriority(cyclerec.FiscalYear_Id, cyclerec.Period_Id, rec_set.Record_Id).GroupBy(x => x.WPMainRecord_id).Select(x => x.First()).ToList();
                    double stra_total_budget=0;

                    if(cyclerec.Period_Id==8)
                    {

                    }
                    else
                    {

                            var dirlist = new List<string>();
            
                            
                            foreach(var stramainproj in DB_StrategicMainProjs)
                            {
                                //Division Names
                                Struc_Directorate rec=_strucDirectorateRepository.GetRecord(_wpMainRecordRepository.GetRecord(stramainproj.WPMainRecord_id).Directorate_Id);
                    
                                if(rec.Record_Id==Int32.Parse(dirid))
                                {
                                    Struc_Division recdiv=_strucDivisionRepository.GetRecord(_wpMainRecordRepository.GetRecord(stramainproj.WPMainRecord_id).Division_Id);
                                    if(!dirlist.Contains(recdiv.AcronymName.TrimEnd()))
                                    {
                                        
                                        rtnstringDirectorates_Stra += recdiv.AcronymName.TrimEnd()+", ";  

                                    
                                        dirlist.Add(recdiv.AcronymName.TrimEnd());
                                    }

                                    //Total Budget for Strategic Priority
                                    double proj_total_budget=0;

                                    var DB_Outpus_for_Project=_wpOutputsRepository.GetRecordsByMainRecordId(stramainproj.WPMainRecord_id).ToList();

                                    foreach (var rec_proj_output in DB_Outpus_for_Project)
                                    {
                                    // bool dpfunding=false;
                                        int ms_count=0;
                                        int dp_count=0;
                                        double output_total_budget=0;

                                        var DB_OutputActivities=_wpOutputActivitiesRepository.GetRecordsByOutputId(rec_proj_output.Transaction_Id).ToList();

                                        foreach (var rec_proj_output_act in DB_OutputActivities)
                                        {
                                            if(rec_proj_output_act.PartnerFunding==true)
                                            {
                                                dp_count=dp_count+1;
                                            }
                                            else
                                            {
                                                ms_count=ms_count+1;
                                            }
                                            output_total_budget=output_total_budget+rec_proj_output_act.ActivityCost;

                                        }

                                        //Get All the Mobility Records that Meet the Period Range Boundry
                                        var DB_Mobilities_Recs=_wpMobilityRepository.GetRecordsByOutputId(rec_proj_output.Transaction_Id).ToList();
                                        var DB_Mobilities_Recs_All=_wpMobilityRepository.GetRecordsByOutputId(rec_proj_output.Transaction_Id).ToList();
                                        if(periodid=="1")
                                        {
                                            DB_Mobilities_Recs=_wpMobilityRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 1, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 3, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 3))).ToList();
                                        }
                                        else if(periodid=="2")
                                        {
                                            DB_Mobilities_Recs=_wpMobilityRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 4, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6))).ToList();
                                        }
                                        else if(periodid=="3")
                                        {
                                            DB_Mobilities_Recs=_wpMobilityRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 7, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 9, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 9))).ToList();
                                        }
                                        else if(periodid=="4")
                                        {
                                            DB_Mobilities_Recs=_wpMobilityRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 10, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12))).ToList();
                                        }
                                        else if(periodid=="5")
                                        {
                                            DB_Mobilities_Recs=_wpMobilityRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 1, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6))).ToList();
                                        }
                                        else if(periodid=="6")
                                        {
                                            DB_Mobilities_Recs=_wpMobilityRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 7, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12))).ToList();
                                        }
                                        else if(periodid=="7")
                                        {
                                            DB_Mobilities_Recs=_wpMobilityRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 1, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12))).ToList();
                                        }
                                        else if(periodid=="8")
                                        {
                                            DB_Mobilities_Recs=_wpMobilityRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, cyclerec.PeriodStartDate, cyclerec.PeriodEndDate).ToList();
                                        }



                                        //Get All the Procurement Records that Meet the Period Range Boundry

                                        var DB_Procurement_Recs=_wpProcurementRepository.GetRecordsByOutputId(rec_proj_output.Transaction_Id).ToList();
                                        var DB_Procurement_Recs_All=_wpProcurementRepository.GetRecordsByOutputId(rec_proj_output.Transaction_Id).ToList();
                                        if(periodid=="1")
                                        {
                                            DB_Procurement_Recs=_wpProcurementRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 1, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 3, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 3))).ToList();
                                        }
                                        else if(periodid=="2")
                                        {
                                            DB_Procurement_Recs=_wpProcurementRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 4, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6))).ToList();
                                        }
                                        else if(periodid=="3")
                                        {
                                            DB_Procurement_Recs=_wpProcurementRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 7, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 9, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 9))).ToList();
                                        }
                                        else if(periodid=="4")
                                        {
                                            DB_Procurement_Recs=_wpProcurementRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 10, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12))).ToList();
                                        }
                                        else if(periodid=="5")
                                        {
                                            DB_Procurement_Recs=_wpProcurementRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 1, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6))).ToList();
                                        }
                                        else if(periodid=="6")
                                        {
                                            DB_Procurement_Recs=_wpProcurementRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 7, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12))).ToList();
                                        }
                                        else if(periodid=="7")
                                        {
                                            DB_Procurement_Recs=_wpProcurementRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 1, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12))).ToList();
                                        }
                                        else if(periodid=="8")
                                        {
                                            DB_Procurement_Recs=_wpProcurementRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, cyclerec.PeriodStartDate, cyclerec.PeriodEndDate).ToList();
                                        }

                                        //Get All the Communication Records that Meet the Period Range Boundry

                                        var DB_Communication_Recs=_wpCommunicationRepository.GetRecordsByOutputId(rec_proj_output.Transaction_Id).ToList();
                                        var DB_Communication_Recs_All=_wpCommunicationRepository.GetRecordsByOutputId(rec_proj_output.Transaction_Id).ToList();
                                        if(periodid=="1")
                                        {
                                            DB_Communication_Recs=_wpCommunicationRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 1, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 3, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 3))).ToList();
                                        }
                                        else if(periodid=="2")
                                        {
                                            DB_Communication_Recs=_wpCommunicationRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 4, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6))).ToList();
                                        }
                                        else if(periodid=="3")
                                        {
                                            DB_Communication_Recs=_wpCommunicationRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 7, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 9, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 9))).ToList();
                                        }
                                        else if(periodid=="4")
                                        {
                                            DB_Communication_Recs=_wpCommunicationRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 10, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12))).ToList();
                                        }
                                        else if(periodid=="5")
                                        {
                                            DB_Communication_Recs=_wpCommunicationRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 1, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6))).ToList();
                                        }
                                        else if(periodid=="6")
                                        {
                                            DB_Communication_Recs=_wpCommunicationRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 7, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12))).ToList();
                                        }
                                        else if(periodid=="7")
                                        {
                                            DB_Communication_Recs=_wpCommunicationRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 1, 1),
                                                                                                                                                    new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12))).ToList();
                                        }
                                        else if(periodid=="8")
                                        {
                                            DB_Communication_Recs=_wpCommunicationRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, cyclerec.PeriodStartDate, cyclerec.PeriodEndDate).ToList();
                                        }

                                        //inner totals
                                        double output_dp_budget=0;
                                        double output_ms_budget=0;
                                        double output_budget_all=0;
                                        




                                        //Sum as DP
                                        if(dp_count>ms_count)
                                        {
                                            foreach (var _innerrec in DB_Mobilities_Recs)
                                            {
                                                output_dp_budget=output_dp_budget+_innerrec.MobilityCost;
                                            }

                                            foreach (var _innerrec in DB_Procurement_Recs)
                                            {
                                                output_dp_budget=output_dp_budget+_innerrec.WPProcurementCost;
                                            }

                                            foreach (var _innerrec in DB_Communication_Recs)
                                            {
                                                output_dp_budget=output_dp_budget+_innerrec.WPCommsCost;
                                            }

                                            //Get the Overall Total for Mobility, Procurement and Communication 
                                            
                                            foreach (var _innerrec in DB_Mobilities_Recs_All)
                                            {
                                                output_budget_all=output_budget_all+_innerrec.MobilityCost;
                                            }

                                            foreach (var _innerrec in DB_Procurement_Recs_All)
                                            {
                                                output_budget_all=output_budget_all+_innerrec.WPProcurementCost;
                                            }

                                            foreach (var _innerrec in DB_Communication_Recs_All)
                                            {
                                                output_budget_all=output_budget_all+_innerrec.WPCommsCost;
                                            }

                                            double remainingfunds=output_total_budget-output_budget_all;

                                            //Add Adjust Cost to DP
                                            if(periodid=="1" || periodid=="2" || periodid=="3" || periodid=="4")
                                            {
                                                if(remainingfunds!=0)
                                                    output_dp_budget=output_dp_budget+(remainingfunds/4.0);
                                            }
                                            else if(periodid=="5" || periodid=="6" )
                                            {
                                                if(remainingfunds!=0)
                                                    output_dp_budget=output_dp_budget+(remainingfunds/2.0);
                                            }
                                            else
                                            {
                                                if(remainingfunds!=0)
                                                    output_dp_budget=output_dp_budget+(remainingfunds/1.0);
                                            }

                                            proj_total_budget=proj_total_budget+output_dp_budget;
                                                
                                        }
                                        else //Sum as MS
                                        {
                                            foreach (var _innerrec in DB_Mobilities_Recs)
                                            {
                                                output_ms_budget=output_ms_budget+_innerrec.MobilityCost;
                                            }

                                            foreach (var _innerrec in DB_Procurement_Recs)
                                            {
                                                output_ms_budget=output_ms_budget+_innerrec.WPProcurementCost;
                                            }

                                            foreach (var _innerrec in DB_Communication_Recs)
                                            {
                                                output_ms_budget=output_ms_budget+_innerrec.WPCommsCost;
                                            }

                                        //Get the Overall Total for Mobility, Procurement and Communication 
                                            
                                            foreach (var _innerrec in DB_Mobilities_Recs_All)
                                            {
                                                output_budget_all=output_budget_all+_innerrec.MobilityCost;
                                            }

                                            foreach (var _innerrec in DB_Procurement_Recs_All)
                                            {
                                                output_budget_all=output_budget_all+_innerrec.WPProcurementCost;
                                            }

                                            foreach (var _innerrec in DB_Communication_Recs_All)
                                            {
                                                output_budget_all=output_budget_all+_innerrec.WPCommsCost;
                                            }
                                            double remainingfunds=output_total_budget-output_budget_all;

                                            //Add Adjust Cost to DP
                                            if(periodid=="1" || periodid=="2" || periodid=="3" || periodid=="4")
                                            {
                                                if(remainingfunds!=0)
                                                    output_ms_budget=output_ms_budget+(remainingfunds/4.0);
                                            }
                                            else if(periodid=="5" || periodid=="6" )
                                            {
                                                if(remainingfunds!=0)
                                                    output_ms_budget=output_ms_budget+(remainingfunds/2.0);
                                            }
                                            else
                                            {
                                                if(remainingfunds!=0)
                                                    output_ms_budget=output_ms_budget+(remainingfunds/1.0);
                                            }

                                            proj_total_budget=proj_total_budget+output_ms_budget;

                                        }
                                        

                                    }

                                    // proj_total_budget=institutional_ms_budget+institutional_dp_budget;










                                    var DB_MainProjsLinks=_wpAUDAPriorityRepository.GetRecordsByMainRecordId(stramainproj.WPMainRecord_id);
                                    stra_total_budget=stra_total_budget+(Convert.ToDouble(proj_total_budget)/Convert.ToDouble(DB_MainProjsLinks.Count()));

                                
                                }


                            }
                            grand_stra_total_budget=grand_stra_total_budget+stra_total_budget;

                            if(rtnstringDirectorates_Stra.Length>=2)
                            {
                                if(rtnstringDirectorates_Stra.Substring(rtnstringDirectorates_Stra.Length-2)==", ")
                                {
                                    rtnstringDirectorates_Stra = rtnstringDirectorates_Stra.Remove(rtnstringDirectorates_Stra.Length - 2, 2);

                                }
                            }
                    



                    }




                    _stracount=_stracount+1;
                    currentrow=currentrow+1;

                    IRow rowstracontent = worksheet.CreateRow(currentrow);

                    ICell CellStraContent1 = rowstracontent.CreateCell(1);
                    CellStraContent1.SetCellValue(_strategyPriorityRepository.GetRecord(rec_set.Record_Id).Record_Name);
                    CellStraContent1.CellStyle = cellStyleNormalWHITE;

                    ICell CellStraContent2 = rowstracontent.CreateCell(2);
                    CellStraContent2.SetCellValue("");
                    CellStraContent2.CellStyle = cellStyleNormalWHITE;

                    var cracontent1 = new NPOI.SS.Util.CellRangeAddress(currentrow, currentrow, 1, 2);
                    worksheet.AddMergedRegion(cracontent1);



                    ICell CellStraContent3 = rowstracontent.CreateCell(3);
                    CellStraContent3.SetCellValue(rtnstringDirectorates_Stra);
                    CellStraContent3.CellStyle = cellStyleNormalWHITE;

                    ICell CellStraContent4 = rowstracontent.CreateCell(4);
                    CellStraContent4.SetCellValue("");
                    CellStraContent4.CellStyle = cellStyleNormalWHITE;

                    var cracontent2 = new NPOI.SS.Util.CellRangeAddress(currentrow, currentrow, 3, 4);
                    worksheet.AddMergedRegion(cracontent2);


                    ICell CellStraContent5 = rowstracontent.CreateCell(5);
                    CellStraContent5.SetCellValue(ExcelDoubleToStringFormat(stra_total_budget));
                    CellStraContent5.CellStyle = cellStyleNormalWHITERIGHT;

                    ICell CellStraContent6 = rowstracontent.CreateCell(6);
                    CellStraContent6.SetCellValue("");
                    CellStraContent6.CellStyle = cellStyleNormalWHITE;



                
                }
                
                //TOTAL ROW
                currentrow=currentrow+1;

                IRow rowstracontenttot = worksheet.CreateRow(currentrow);

                ICell CellStraContentTOT1 = rowstracontenttot.CreateCell(1);
                CellStraContentTOT1.SetCellValue("TOTAL");
                CellStraContentTOT1.CellStyle = cellStyleNormalBold;

                ICell CellStraContentTOT2 = rowstracontenttot.CreateCell(2);
                CellStraContentTOT2.SetCellValue("");
                CellStraContentTOT2.CellStyle = cellStyleNormalBold;

                ICell CellStraContentTOT3 = rowstracontenttot.CreateCell(3);
                CellStraContentTOT3.SetCellValue("");
                CellStraContentTOT3.CellStyle = cellStyleNormalBold;

                ICell CellStraContentTOT4 = rowstracontenttot.CreateCell(4);
                CellStraContentTOT4.SetCellValue("");
                CellStraContentTOT4.CellStyle = cellStyleNormalBold;

                var cracontenttot1 = new NPOI.SS.Util.CellRangeAddress(currentrow, currentrow, 1, 4);
                worksheet.AddMergedRegion(cracontenttot1);

                ICell CellStraContentTOT5 = rowstracontenttot.CreateCell(5);
                CellStraContentTOT5.SetCellValue(ExcelDoubleToStringFormat(grand_stra_total_budget));
                CellStraContentTOT5.CellStyle = cellStyleNormalBoldRIGHT;

                ICell CellStraContentTOT6 = rowstracontenttot.CreateCell(6);
                CellStraContentTOT6.SetCellValue("");
                CellStraContentTOT6.CellStyle = cellStyleNormalBold;



                 //End*****Strategic Priorities Mapping


                 //Start*****MS and DP Budgets
                currentrow=currentrow+3;

                //Stategic Priorities Header
                IRow rowmsdphead = worksheet.CreateRow(currentrow);

                ICell CellMSDPHeader1 = rowmsdphead.CreateCell(1);
                CellMSDPHeader1.SetCellValue("Divisions");
                CellMSDPHeader1.CellStyle = cellStyleNormalBold;

                ICell CellMSDPHeader2 = rowmsdphead.CreateCell(2);
                CellMSDPHeader2.SetCellValue("");
                CellMSDPHeader2.CellStyle = cellStyleNormalBold;


                var cramsdp1 = new NPOI.SS.Util.CellRangeAddress(currentrow, currentrow, 1, 2);
                worksheet.AddMergedRegion(cramsdp1);

                ICell CellMSDPHeader3 = rowmsdphead.CreateCell(3);
                CellMSDPHeader3.SetCellValue("MS Budget for "+rangnameinst_short+" (US$)");
                CellMSDPHeader3.CellStyle = cellStyleNormalBoldRIGHT;

                ICell CellMSDPHeader4 = rowmsdphead.CreateCell(4);
                CellMSDPHeader4.SetCellValue("DP Budget for "+rangnameinst_short+" (US$)");
                CellMSDPHeader4.CellStyle = cellStyleNormalBoldRIGHT;

                ICell CellMSDPHeader5 = rowmsdphead.CreateCell(5);
                CellMSDPHeader5.SetCellValue(totalheader);
                CellMSDPHeader5.CellStyle = cellStyleNormalBoldRIGHT;

                ICell CellMSDPHeader6 = rowmsdphead.CreateCell(6);
                CellMSDPHeader6.SetCellValue("Comments");
                CellMSDPHeader6.CellStyle = cellStyleNormalBold;

                //Rows


                double grand_directorate_ms_budget=0;
                double grand_directorate_dp_budget=0;
                double grand_directorate_total_budget=0;


                foreach (var rec_set in DB_Records)
                {
                    //**********Compute Total MS and DP Budgets of Directorates***********// 

                    Struc_Directorate dir=_strucDirectorateRepository.GetRecord(rec_set.Record_Id);

                    var DB_RecordsDivs=_transStrucDivisionRepository.GetAllRecordsByDirectorate(rec_set.Transaction_Id).OrderByDescending(x => x.Division_Id).ToList();

                    int _countdivrec=DB_RecordsDivs.Count();

                    //Check if the division have any submission GetRecordsByDivRecs
                    foreach (var rec_div in DB_RecordsDivs)
                    {
                        double directorate_dp_budget=0;
                        double directorate_ms_budget=0;
                        double directorate_total_budget=0;

                        var DivMainRecs=_wpMainRecordRepository.GetRecordsByDivRecs(rec_div.Division_Id).ToList();
                                                //Fetch the Division Records that correspond the cycle 
                        if(cyclerec.Period_Id==8)
                        {
                            DivMainRecs=_wpMainRecordRepository.GetRecordsByDivisionYearAndPeriodStartEnd(rec_div.Division_Id, cyclerec.FiscalYear_Id,cyclerec.Period_Id, cyclerec.PeriodStartDate, cyclerec.PeriodEndDate).ToList();
                        }
                        else
                        {
                            DivMainRecs=_wpMainRecordRepository.GetRecordsByDivisionYearAndPeriod(rec_div.Division_Id, cyclerec.FiscalYear_Id,cyclerec.Period_Id).ToList();
                        }
                        


                        foreach (var rec_proj_main in DivMainRecs)
                        {
                            
                            
                            //New for loop for Range
                            var DB_Outpus_for_Project=_wpOutputsRepository.GetRecordsByMainRecordId(rec_proj_main.Transaction_Id).ToList();

                            foreach (var rec_proj_output in DB_Outpus_for_Project)
                            {
                            // bool dpfunding=false;
                                int ms_count=0;
                                int dp_count=0;
                                double output_total_budget=0;

                                var DB_OutputActivities=_wpOutputActivitiesRepository.GetRecordsByOutputId(rec_proj_output.Transaction_Id).ToList();

                                foreach (var rec_proj_output_act in DB_OutputActivities)
                                {
                                    if(rec_proj_output_act.PartnerFunding==true)
                                    {
                                        dp_count=dp_count+1;
                                    }
                                    else
                                    {
                                        ms_count=ms_count+1;
                                    }
                                    output_total_budget=output_total_budget+rec_proj_output_act.ActivityCost;

                                }

                                //Get All the Mobility Records that Meet the Period Range Boundry
                                var DB_Mobilities_Recs=_wpMobilityRepository.GetRecordsByOutputId(rec_proj_output.Transaction_Id).ToList();
                                var DB_Mobilities_Recs_All=_wpMobilityRepository.GetRecordsByOutputId(rec_proj_output.Transaction_Id).ToList();
                                if(periodid=="1")
                                {
                                    DB_Mobilities_Recs=_wpMobilityRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 1, 1),
                                                                                                                                            new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 3, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 3))).ToList();
                                }
                                else if(periodid=="2")
                                {
                                    DB_Mobilities_Recs=_wpMobilityRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 4, 1),
                                                                                                                                            new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6))).ToList();
                                }
                                else if(periodid=="3")
                                {
                                    DB_Mobilities_Recs=_wpMobilityRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 7, 1),
                                                                                                                                            new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 9, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 9))).ToList();
                                }
                                else if(periodid=="4")
                                {
                                    DB_Mobilities_Recs=_wpMobilityRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 10, 1),
                                                                                                                                            new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12))).ToList();
                                }
                                else if(periodid=="5")
                                {
                                    DB_Mobilities_Recs=_wpMobilityRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 1, 1),
                                                                                                                                            new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6))).ToList();
                                }
                                else if(periodid=="6")
                                {
                                    DB_Mobilities_Recs=_wpMobilityRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 7, 1),
                                                                                                                                            new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12))).ToList();
                                }
                                else if(periodid=="7")
                                {
                                    DB_Mobilities_Recs=_wpMobilityRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 1, 1),
                                                                                                                                            new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12))).ToList();
                                }
                                else if(periodid=="8")
                                {
                                    DB_Mobilities_Recs=_wpMobilityRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, cyclerec.PeriodStartDate, cyclerec.PeriodEndDate).ToList();
                                }



                                //Get All the Procurement Records that Meet the Period Range Boundry

                                var DB_Procurement_Recs=_wpProcurementRepository.GetRecordsByOutputId(rec_proj_output.Transaction_Id).ToList();
                                var DB_Procurement_Recs_All=_wpProcurementRepository.GetRecordsByOutputId(rec_proj_output.Transaction_Id).ToList();
                                if(periodid=="1")
                                {
                                    DB_Procurement_Recs=_wpProcurementRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 1, 1),
                                                                                                                                            new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 3, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 3))).ToList();
                                }
                                else if(periodid=="2")
                                {
                                    DB_Procurement_Recs=_wpProcurementRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 4, 1),
                                                                                                                                            new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6))).ToList();
                                }
                                else if(periodid=="3")
                                {
                                    DB_Procurement_Recs=_wpProcurementRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 7, 1),
                                                                                                                                            new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 9, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 9))).ToList();
                                }
                                else if(periodid=="4")
                                {
                                    DB_Procurement_Recs=_wpProcurementRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 10, 1),
                                                                                                                                            new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12))).ToList();
                                }
                                else if(periodid=="5")
                                {
                                    DB_Procurement_Recs=_wpProcurementRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 1, 1),
                                                                                                                                            new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6))).ToList();
                                }
                                else if(periodid=="6")
                                {
                                    DB_Procurement_Recs=_wpProcurementRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 7, 1),
                                                                                                                                            new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12))).ToList();
                                }
                                else if(periodid=="7")
                                {
                                    DB_Procurement_Recs=_wpProcurementRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 1, 1),
                                                                                                                                            new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12))).ToList();
                                }
                                else if(periodid=="8")
                                {
                                    DB_Procurement_Recs=_wpProcurementRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, cyclerec.PeriodStartDate, cyclerec.PeriodEndDate).ToList();
                                }

                                //Get All the Communication Records that Meet the Period Range Boundry

                                var DB_Communication_Recs=_wpCommunicationRepository.GetRecordsByOutputId(rec_proj_output.Transaction_Id).ToList();
                                var DB_Communication_Recs_All=_wpCommunicationRepository.GetRecordsByOutputId(rec_proj_output.Transaction_Id).ToList();
                                if(periodid=="1")
                                {
                                    DB_Communication_Recs=_wpCommunicationRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 1, 1),
                                                                                                                                            new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 3, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 3))).ToList();
                                }
                                else if(periodid=="2")
                                {
                                    DB_Communication_Recs=_wpCommunicationRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 4, 1),
                                                                                                                                            new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6))).ToList();
                                }
                                else if(periodid=="3")
                                {
                                    DB_Communication_Recs=_wpCommunicationRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 7, 1),
                                                                                                                                            new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 9, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 9))).ToList();
                                }
                                else if(periodid=="4")
                                {
                                    DB_Communication_Recs=_wpCommunicationRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 10, 1),
                                                                                                                                            new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12))).ToList();
                                }
                                else if(periodid=="5")
                                {
                                    DB_Communication_Recs=_wpCommunicationRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 1, 1),
                                                                                                                                            new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6))).ToList();
                                }
                                else if(periodid=="6")
                                {
                                    DB_Communication_Recs=_wpCommunicationRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 7, 1),
                                                                                                                                            new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12))).ToList();
                                }
                                else if(periodid=="7")
                                {
                                    DB_Communication_Recs=_wpCommunicationRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 1, 1),
                                                                                                                                            new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12))).ToList();
                                }
                                else if(periodid=="8")
                                {
                                    DB_Communication_Recs=_wpCommunicationRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, cyclerec.PeriodStartDate, cyclerec.PeriodEndDate).ToList();
                                }

                                //inner totals
                                double output_dp_budget=0;
                                double output_ms_budget=0;
                                double output_budget_all=0;
                                




                                //Sum as DP
                                if(dp_count>ms_count)
                                {
                                    foreach (var _innerrec in DB_Mobilities_Recs)
                                    {
                                        output_dp_budget=output_dp_budget+_innerrec.MobilityCost;
                                    }

                                    foreach (var _innerrec in DB_Procurement_Recs)
                                    {
                                        output_dp_budget=output_dp_budget+_innerrec.WPProcurementCost;
                                    }

                                    foreach (var _innerrec in DB_Communication_Recs)
                                    {
                                        output_dp_budget=output_dp_budget+_innerrec.WPCommsCost;
                                    }

                                    //Get the Overall Total for Mobility, Procurement and Communication 
                                    
                                    foreach (var _innerrec in DB_Mobilities_Recs_All)
                                    {
                                        output_budget_all=output_budget_all+_innerrec.MobilityCost;
                                    }

                                    foreach (var _innerrec in DB_Procurement_Recs_All)
                                    {
                                        output_budget_all=output_budget_all+_innerrec.WPProcurementCost;
                                    }

                                    foreach (var _innerrec in DB_Communication_Recs_All)
                                    {
                                        output_budget_all=output_budget_all+_innerrec.WPCommsCost;
                                    }

                                    double remainingfunds=output_total_budget-output_budget_all;

                                    //Add Adjust Cost to DP
                                    if(periodid=="1" || periodid=="2" || periodid=="3" || periodid=="4")
                                    {
                                        if(remainingfunds!=0)
                                            output_dp_budget=output_dp_budget+(remainingfunds/4.0);
                                    }
                                    else if(periodid=="5" || periodid=="6" )
                                    {
                                        if(remainingfunds!=0)
                                            output_dp_budget=output_dp_budget+(remainingfunds/2.0);
                                    }
                                    else
                                    {
                                        if(remainingfunds!=0)
                                            output_dp_budget=output_dp_budget+(remainingfunds/1.0);
                                    }

                                    directorate_dp_budget=directorate_dp_budget+output_dp_budget;
                                    grand_directorate_dp_budget=grand_directorate_dp_budget+output_dp_budget;

                                    directorate_total_budget=directorate_total_budget+output_dp_budget;
                                    grand_directorate_total_budget=grand_directorate_total_budget+output_dp_budget;


                                        
                                }
                                else //Sum as MS
                                {
                                    foreach (var _innerrec in DB_Mobilities_Recs)
                                    {
                                        output_ms_budget=output_ms_budget+_innerrec.MobilityCost;
                                    }

                                    foreach (var _innerrec in DB_Procurement_Recs)
                                    {
                                        output_ms_budget=output_ms_budget+_innerrec.WPProcurementCost;
                                    }

                                    foreach (var _innerrec in DB_Communication_Recs)
                                    {
                                        output_ms_budget=output_ms_budget+_innerrec.WPCommsCost;
                                    }

                                    //Get the Overall Total for Mobility, Procurement and Communication 
                                    
                                    foreach (var _innerrec in DB_Mobilities_Recs_All)
                                    {
                                        output_budget_all=output_budget_all+_innerrec.MobilityCost;
                                    }

                                    foreach (var _innerrec in DB_Procurement_Recs_All)
                                    {
                                        output_budget_all=output_budget_all+_innerrec.WPProcurementCost;
                                    }

                                    foreach (var _innerrec in DB_Communication_Recs_All)
                                    {
                                        output_budget_all=output_budget_all+_innerrec.WPCommsCost;
                                    }
                                    double remainingfunds=output_total_budget-output_budget_all;

                                    //Add Adjust Cost to DP
                                    if(periodid=="1" || periodid=="2" || periodid=="3" || periodid=="4")
                                    {
                                        if(remainingfunds!=0)
                                            output_ms_budget=output_ms_budget+(remainingfunds/4.0);
                                    }
                                    else if(periodid=="5" || periodid=="6" )
                                    {
                                        if(remainingfunds!=0)
                                            output_ms_budget=output_ms_budget+(remainingfunds/2.0);
                                    }
                                    else
                                    {
                                        if(remainingfunds!=0)
                                            output_ms_budget=output_ms_budget+(remainingfunds/1.0);
                                    }

                                    directorate_ms_budget=directorate_ms_budget+output_ms_budget;
                                    grand_directorate_ms_budget=grand_directorate_ms_budget+output_ms_budget;

                                    directorate_total_budget=directorate_total_budget+output_ms_budget;
                                    grand_directorate_total_budget=grand_directorate_total_budget+output_ms_budget;


                                }
                                
                                




                                

                            }
                            
                            
                
                        }

                        currentrow=currentrow+1;
                        Struc_Division div_recordset=_strucDivisionRepository.GetRecord(rec_div.Division_Id);

                        IRow rowmsdpcontent = worksheet.CreateRow(currentrow);

                        ICell CellMSDPContent1 = rowmsdpcontent.CreateCell(1);
                        CellMSDPContent1.SetCellValue(div_recordset.Record_Name + " ("+div_recordset.AcronymName+")");
                        CellMSDPContent1.CellStyle = cellStyleNormalWHITE;

                        ICell CellMSDPContent2 = rowmsdpcontent.CreateCell(2);
                        CellMSDPContent2.SetCellValue("");
                        CellMSDPContent2.CellStyle = cellStyleNormalWHITE;


                        var cramsdpcontent1 = new NPOI.SS.Util.CellRangeAddress(currentrow, currentrow, 1, 2);
                        worksheet.AddMergedRegion(cramsdpcontent1);

                        ICell CellMSDPContent3 = rowmsdpcontent.CreateCell(3);
                        CellMSDPContent3.SetCellValue(ExcelDoubleToStringFormat(directorate_ms_budget));
                        CellMSDPContent3.CellStyle = cellStyleNormalWHITERIGHT;

                        ICell CellMSDPContent4 = rowmsdpcontent.CreateCell(4);
                        CellMSDPContent4.SetCellValue(ExcelDoubleToStringFormat(directorate_dp_budget));
                        CellMSDPContent4.CellStyle = cellStyleNormalWHITERIGHT;

                        ICell CellMSDPContent5 = rowmsdpcontent.CreateCell(5);
                        CellMSDPContent5.SetCellValue(ExcelDoubleToStringFormat(directorate_total_budget));
                        CellMSDPContent5.CellStyle = cellStyleNormalWHITERIGHT;

                        ICell CellMSDPContent6 = rowmsdpcontent.CreateCell(6);
                        CellMSDPContent6.SetCellValue("");
                        CellMSDPContent6.CellStyle = cellStyleNormalWHITE;

                          

                    }

                    //TOTALS
                    grand_directorate_ms_budget=grand_directorate_total_budget-grand_directorate_dp_budget;

                    currentrow=currentrow+1;
                   

                    IRow rowmsdpcontenttot = worksheet.CreateRow(currentrow);

                    ICell CellMSDPContentTOT1 = rowmsdpcontenttot.CreateCell(1);
                    CellMSDPContentTOT1.SetCellValue("TOTAL");
                    CellMSDPContentTOT1.CellStyle = cellStyleNormalBold;

                    ICell CellMSDPContentTOT2 = rowmsdpcontenttot.CreateCell(2);
                    CellMSDPContentTOT2.SetCellValue("");
                    CellMSDPContentTOT2.CellStyle = cellStyleNormalBold;


                    var cramsdpcontenttot1 = new NPOI.SS.Util.CellRangeAddress(currentrow, currentrow, 1, 2);
                    worksheet.AddMergedRegion(cramsdpcontenttot1);

                    ICell CellMSDPContentTOT3 = rowmsdpcontenttot.CreateCell(3);
                    CellMSDPContentTOT3.SetCellValue(ExcelDoubleToStringFormat(grand_directorate_ms_budget));
                    CellMSDPContentTOT3.CellStyle = cellStyleNormalBoldRIGHT;

                    ICell CellMSDPContentTOT4 = rowmsdpcontenttot.CreateCell(4);
                    CellMSDPContentTOT4.SetCellValue(ExcelDoubleToStringFormat(grand_directorate_dp_budget));
                    CellMSDPContentTOT4.CellStyle = cellStyleNormalBoldRIGHT;

                    ICell CellMSDPContentTOT5 = rowmsdpcontenttot.CreateCell(5);
                    CellMSDPContentTOT5.SetCellValue(ExcelDoubleToStringFormat(grand_directorate_total_budget));
                    CellMSDPContentTOT5.CellStyle = cellStyleNormalBoldRIGHT;

                    ICell CellMSDPContentTOT6 = rowmsdpcontenttot.CreateCell(6);
                    CellMSDPContentTOT6.SetCellValue("");
                    CellMSDPContentTOT6.CellStyle = cellStyleNormalBold;


                }

                    




                 //End*****MS and DP Budgets



                //EDITING TEMPLATE STARTS HERE....
                List<WP_OutputsGridVM> collection_recs = new List<WP_OutputsGridVM>();
                List<WP_OutputsGridVM> collection_recs_details = new List<WP_OutputsGridVM>();

            

            

                if (id != null && periodid!=null && dirid!=null)
                {
                    

                   

                    //Sorting Directorate_IdGVM
                    collection_recs=collection_recs.OrderBy(d => d.Directorate_IdGVM).ThenBy(d => d.Division_IdGVM).ThenBy(d => d.Project_NameGVM).ToList();
                    collection_recs_details=collection_recs_details.OrderBy(d => d.Strategic_PriorityIdGVM).ThenBy(d => d.Directorate_IdGVM).ThenBy(d => d.Division_IdGVM).ThenBy(d => d.Project_NameGVM).ToList();


                    
                }










                


               

                








                //SAVING TEMPLATE STARTS HERE....

                using (FileStream stream = new FileStream(pathtofile_save, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(stream);
                } 


                //SAVING TEMPLATE ENDS HERE....





            }
            catch (Exception)
            {

            }
           
           
           
           
           
           
            

            



            //Save File Ends Here...


            






            string contentType =  "application/vnd.ms-excel";//"application/pdf"
           // string pathtofile=@"wwwroot/appdirectory/excelreports/institutional/Procurement_Plan_2021.xlsx";
           //pathtofile_save=@"wwwroot/appdirectory/excelreports/directorate/workplan/"+_directorate.AcronymName+"_Workplan_" +_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name +"_" +periodname+".xlsx";
            
            string pathtofile="/appdirectory/excelreports/directorate/workplan/"+_directorate.AcronymName+"_Workplan_" +_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name +"_" +periodname+".xlsx";
           
            




            return File(pathtofile, contentType, _directorate.AcronymName+"_Workplan_" +_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name +"_" +periodname+".xlsx");

        }





        public FileResult InstitutionalStrategicProjectMappingExcel(string id)
        {
            IWorkbook workbook;
            string path=@"wwwroot/appdirectory/excelreports/institutional/pipd/Strategic_Priorities_Projects_Mapping_Template_Annual.xlsx";


            string periodid="7";
            WP_DispatchCycle cyclerec=_wpDispatchCycleRepository.GetRecord(id);
            string pathtofile_save="";

           
      
            string periodname="";
            if(periodid=="1")
                periodname="Q1";
            else if (periodid=="2")
                periodname="Q2";
            else if (periodid=="3")
                periodname="Q3";
            else if (periodid=="4")
                periodname="Q4"; 
            else if (periodid=="5")
                periodname="Semester_1"; 
            else if (periodid=="6")
                periodname="Semester_2";
            else if (periodid=="7")
                periodname="Annual";
            else
            {
                DateTime pstart=new DateTime(cyclerec.PeriodStartDate.Year, cyclerec.PeriodStartDate.Month, cyclerec.PeriodStartDate.Day);
                DateTime pend=new DateTime(cyclerec.PeriodEndDate.Year, cyclerec.PeriodEndDate.Month, cyclerec.PeriodEndDate.Day);
                periodname=pstart.Date.ToString("MMM d, yyyy") + " - "+ pend.Date.ToString("MMM d, yyyy"); 
                
            }

            pathtofile_save=@"wwwroot/appdirectory/excelreports/institutional/pipd/Strategic_Priorities_Projects_Mapping_" +_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name +"_" +periodname+".xlsx";
           


            try
            {
                //OPENING TEMPLATE STARTS HERE....
                    FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                    // Try to read workbook as XLSX:
                    try
                    {
                        workbook = new XSSFWorkbook(fs);
                    }
                    catch
                    {
                        workbook = null;
                    }

                    // If reading fails, try to read workbook as XLS:
                    if (workbook == null)
                    {
                        workbook = new HSSFWorkbook(fs);
                    }
                //OPENING TEMPLATE ENDS HERE....


                //EDITING TEMPLATE STARTS HERE....
   
                IFont fontnormal = workbook.CreateFont();
                fontnormal.IsBold = false;
                fontnormal.FontHeightInPoints = 11;
                fontnormal.FontName="Arial";

                IFont fontnormalbold = workbook.CreateFont();
                fontnormalbold.IsBold = true;
                fontnormalbold.FontHeightInPoints = 11;
                fontnormalbold.FontName="Arial";

                ICellStyle cellStyleNormal = workbook.CreateCellStyle();
                cellStyleNormal.SetFont(fontnormal);
                cellStyleNormal.BorderLeft = BorderStyle.Thin;
                cellStyleNormal.BorderTop = BorderStyle.Thin;
                cellStyleNormal.BorderRight = BorderStyle.Thin;
                cellStyleNormal.BorderBottom = BorderStyle.Thin;
                cellStyleNormal.VerticalAlignment = VerticalAlignment.Top;
                cellStyleNormal.Alignment =HorizontalAlignment.Left;
                cellStyleNormal.WrapText=true;
                cellStyleNormal.FillForegroundColor=26;
                cellStyleNormal.FillPattern=FillPattern.SolidForeground; 

                ICellStyle cellStyleNormalRight = workbook.CreateCellStyle();
                cellStyleNormalRight.SetFont(fontnormal);
                cellStyleNormalRight.BorderLeft = BorderStyle.Thin;
                cellStyleNormalRight.BorderTop = BorderStyle.Thin;
                cellStyleNormalRight.BorderRight = BorderStyle.Thin;
                cellStyleNormalRight.BorderBottom = BorderStyle.Thin;
                cellStyleNormalRight.VerticalAlignment = VerticalAlignment.Top;
                cellStyleNormalRight.Alignment =HorizontalAlignment.Right;
                cellStyleNormalRight.WrapText=true;
                cellStyleNormalRight.FillForegroundColor=26;
                cellStyleNormalRight.FillPattern=FillPattern.SolidForeground; 

                ICellStyle cellStyleYellowNormalSTART = workbook.CreateCellStyle();
                cellStyleYellowNormalSTART.SetFont(fontnormal);
                cellStyleYellowNormalSTART.BorderLeft = BorderStyle.Thin;
                cellStyleYellowNormalSTART.BorderTop = BorderStyle.Thin;
                cellStyleYellowNormalSTART.BorderRight = BorderStyle.None;
                cellStyleYellowNormalSTART.BorderBottom = BorderStyle.Thin;
                cellStyleYellowNormalSTART.VerticalAlignment = VerticalAlignment.Top;
                cellStyleYellowNormalSTART.Alignment =HorizontalAlignment.Left;
                cellStyleYellowNormalSTART.WrapText=true;
                cellStyleYellowNormalSTART.FillForegroundColor=13;
                cellStyleYellowNormalSTART.FillPattern=FillPattern.SolidForeground; 

                ICellStyle cellStyleYellowNormalEND = workbook.CreateCellStyle();
                cellStyleYellowNormalEND.SetFont(fontnormalbold);
                cellStyleYellowNormalEND.BorderLeft = BorderStyle.None;
                cellStyleYellowNormalEND.BorderTop = BorderStyle.Thin;
                cellStyleYellowNormalEND.BorderRight = BorderStyle.Thin;
                cellStyleYellowNormalEND.BorderBottom = BorderStyle.Thin;
                cellStyleYellowNormalEND.VerticalAlignment = VerticalAlignment.Top;
                cellStyleYellowNormalEND.Alignment =HorizontalAlignment.Right;
                cellStyleYellowNormalEND.WrapText=true;
                cellStyleYellowNormalEND.FillForegroundColor=13;
                cellStyleYellowNormalEND.FillPattern=FillPattern.SolidForeground; 

                ICellStyle cellStyleYellowNormal = workbook.CreateCellStyle();
                cellStyleYellowNormal.SetFont(fontnormalbold);
                cellStyleYellowNormal.BorderLeft = BorderStyle.Thin;
                cellStyleYellowNormal.BorderTop = BorderStyle.Thin;
                cellStyleYellowNormal.BorderRight = BorderStyle.Thin;
                cellStyleYellowNormal.BorderBottom = BorderStyle.Thin;
                cellStyleYellowNormal.VerticalAlignment = VerticalAlignment.Top;
                cellStyleYellowNormal.Alignment =HorizontalAlignment.Left;
                cellStyleYellowNormal.WrapText=true;
                cellStyleYellowNormal.FillForegroundColor=13;
                cellStyleYellowNormal.FillPattern=FillPattern.SolidForeground; 

                ICellStyle cellStyleNormalYellowRight = workbook.CreateCellStyle();
                cellStyleNormalYellowRight.SetFont(fontnormalbold);
                cellStyleNormalYellowRight.BorderLeft = BorderStyle.Thin;
                cellStyleNormalYellowRight.BorderTop = BorderStyle.Thin;
                cellStyleNormalYellowRight.BorderRight = BorderStyle.Thin;
                cellStyleNormalYellowRight.BorderBottom = BorderStyle.Thin;
                cellStyleNormalYellowRight.VerticalAlignment = VerticalAlignment.Top;
                cellStyleNormalYellowRight.Alignment =HorizontalAlignment.Right;
                cellStyleNormalYellowRight.WrapText=true;
                cellStyleNormalYellowRight.FillForegroundColor=13;
                cellStyleNormalYellowRight.FillPattern=FillPattern.SolidForeground; 





                ICellStyle cellStyleYellowNormalMiddle = workbook.CreateCellStyle();
                cellStyleYellowNormalMiddle.SetFont(fontnormalbold);
                cellStyleYellowNormalMiddle.BorderLeft = BorderStyle.None;
                cellStyleYellowNormalMiddle.BorderTop = BorderStyle.Thin;
                cellStyleYellowNormalMiddle.BorderRight = BorderStyle.None;
                cellStyleYellowNormalMiddle.BorderBottom = BorderStyle.Thin;
                cellStyleYellowNormalMiddle.VerticalAlignment = VerticalAlignment.Top;
                cellStyleYellowNormalMiddle.Alignment =HorizontalAlignment.Left;
                cellStyleYellowNormalMiddle.WrapText=true;
                cellStyleYellowNormalMiddle.FillForegroundColor=13;
                cellStyleYellowNormalMiddle.FillPattern=FillPattern.SolidForeground; 

                ICellStyle cellStyleNormalYellowRightMiddle = workbook.CreateCellStyle();
                cellStyleNormalYellowRightMiddle.SetFont(fontnormalbold);
                cellStyleNormalYellowRightMiddle.BorderLeft = BorderStyle.None;
                cellStyleNormalYellowRightMiddle.BorderTop = BorderStyle.Thin;
                cellStyleNormalYellowRightMiddle.BorderRight = BorderStyle.None;
                cellStyleNormalYellowRightMiddle.BorderBottom = BorderStyle.Thin;
                cellStyleNormalYellowRightMiddle.VerticalAlignment = VerticalAlignment.Top;
                cellStyleNormalYellowRightMiddle.Alignment =HorizontalAlignment.Right;
                cellStyleNormalYellowRightMiddle.WrapText=true;
                cellStyleNormalYellowRightMiddle.FillForegroundColor=13;
                cellStyleNormalYellowRightMiddle.FillPattern=FillPattern.SolidForeground; 


                ICellStyle cellStyleNormalGRAY = workbook.CreateCellStyle();
                cellStyleNormalGRAY.SetFont(fontnormal);
                cellStyleNormalGRAY.BorderLeft = BorderStyle.Thin;
                cellStyleNormalGRAY.BorderTop = BorderStyle.Thin;
                cellStyleNormalGRAY.BorderRight = BorderStyle.Thin;
                cellStyleNormalGRAY.BorderBottom = BorderStyle.Thin;
                cellStyleNormalGRAY.VerticalAlignment = VerticalAlignment.Top;
                cellStyleNormalGRAY.Alignment =HorizontalAlignment.Left;
                cellStyleNormalGRAY.WrapText=true;
                cellStyleNormalGRAY.FillForegroundColor=22;
                cellStyleNormalGRAY.FillPattern=FillPattern.SolidForeground; 

                

                ICellStyle cellStyleNumber = workbook.CreateCellStyle();
                cellStyleNumber.SetFont(fontnormal);
                cellStyleNumber.BorderLeft = BorderStyle.Thin;
                cellStyleNumber.BorderTop = BorderStyle.Thin;
                cellStyleNumber.BorderRight = BorderStyle.Thin;
                cellStyleNumber.BorderBottom = BorderStyle.Thin;
                cellStyleNumber.VerticalAlignment = VerticalAlignment.Top;
                cellStyleNumber.Alignment =HorizontalAlignment.Right;
                cellStyleNumber.WrapText=true;
                cellStyleNumber.FillForegroundColor=26;
                cellStyleNumber.FillPattern=FillPattern.SolidForeground; 


                var DB_RecordsStra = _transStrategyPriorityRepository.GetAllRecords().ToList();

                int _iter=0;

                foreach (var rec_set in DB_RecordsStra)
                {
                    var DB_StrategicMainProjs=_wpAUDAPriorityRepository.GetRecordsByYearPeriodAndPriority(cyclerec.FiscalYear_Id, cyclerec.Period_Id, rec_set.Record_Id).GroupBy(x => x.WPMainRecord_id).Select(x => x.First()).ToList();
                    _iter=_iter+1;
                    ISheet current_worksheet = workbook.GetSheetAt(_iter-1);
                    int _rowInter=1;
                    
                    
                    if(cyclerec.Period_Id==8)
                    {

                    }
                    else
                    {

                        var dirlist = new List<string>();

                        
                        foreach(var stramainproj in DB_StrategicMainProjs)
                        {
                            _rowInter=_rowInter+1;
                            IRow row = current_worksheet.CreateRow(_rowInter);

                            WP_MainRecord mainrec=_wpMainRecordRepository.GetRecord(stramainproj.WPMainRecord_id);

                            string fiscalyear=_lkupFiscalYearRepository.GetRecord(mainrec.FiscalYear_Id).Record_Name;
                            string priorityname=_strategyPriorityRepository.GetRecord(rec_set.Record_Id).Record_Name;
                            string directoratename=_strucDirectorateRepository.GetRecord(mainrec.Directorate_Id).AcronymName;
                            string divisionname=_strucDivisionRepository.GetRecord(mainrec.Division_Id).Record_Name;
                            string projectname=_lkupProjectRepository.GetRecord(mainrec.Project_Id).Record_Name;


                            ICell Cell0 = row.CreateCell(0);
                            Cell0.SetCellValue(fiscalyear);
                            Cell0.CellStyle = cellStyleNormalRight;

                            ICell Cell1 = row.CreateCell(1);
                            Cell1.SetCellValue(priorityname);
                            Cell1.CellStyle = cellStyleNormal;

                            ICell Cell2 = row.CreateCell(2);
                            Cell2.SetCellValue(directoratename);
                            Cell2.CellStyle = cellStyleNormal;

                            ICell Cell3 = row.CreateCell(3);
                            Cell3.SetCellValue(divisionname);
                            Cell3.CellStyle = cellStyleNormal;

                            ICell Cell4 = row.CreateCell(4);
                            Cell4.SetCellValue(projectname);
                            Cell4.CellStyle = cellStyleNormal;

                           

                        }

                    }


                }


                

       


                //EDITING T TEMPLATE ENDS HERE....








                //SAVING TEMPLATE STARTS HERE....

                using (FileStream stream = new FileStream(pathtofile_save, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(stream);
                } 


                //SAVING TEMPLATE ENDS HERE....





            }
            catch (Exception)
            {

            }
           
           
           
           
           
           
            

            



            //Save File Ends Here...


            






            string contentType =  "application/vnd.ms-excel";//"application/pdf"
           // string pathtofile=@"wwwroot/appdirectory/excelreports/institutional/Procurement_Plan_2021.xlsx";
            
            string pathtofile="/appdirectory/excelreports/institutional/pipd/Strategic_Priorities_Projects_Mapping_" +_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name +"_" +periodname+".xlsx";
           
            




            return File(pathtofile, contentType, "Strategic_Priorities_Projects_Mapping_" +_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name +"_" +periodname+".xlsx");

        }


        private string ExcelDoubleToStringFormat(double value)
        {
            string rtnval="";

             var f = new NumberFormatInfo {NumberGroupSeparator = " "};
              
            rtnval=value.ToString("N0", f);


            return rtnval;
        }




        private void CreateCell(IRow CurrentRow, int CellIndex, string Value, HSSFCellStyle Style)
        {
            ICell Cell = CurrentRow.CreateCell(CellIndex);
            Cell.SetCellValue(Value);
            Cell.CellStyle = Style;
        }




        
    }
}