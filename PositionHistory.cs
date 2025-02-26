using Lifewell_Reaper.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TryItADP;

namespace TryItADP
{
	public class PositionHistory
	{
		public int positionHistoryId { get; set; }
		public string companyId { get; set; }
		public string assignmentId { get; set; }
		public string effectiveDate { get; set; }
		public string beginCheckDate { get; set; }
		public string type { get; set; }
		public string changeReason { get; set; }
		public Employment employment { get; set; }
		public string jobTitle { get; set; }
		public float bonusTarget { get; set; }
		public bool otExempt { get; set; }
		public bool minimumWageExempt { get; set; }
		public bool unionInitiationCollected { get; set; }
		public bool unionDuesCollected { get; set; }
		public string recordId { get; set; }
		public bool wasEditedWithEaf { get; set; }
		public string supervisorFirstName { get; set; }
		public string supervisorLastName { get; set; }
		public string reviewerFirstName { get; set; }
		public string reviewerLastName { get; set; }
		public bool isSupervisorReviewer { get; set; }
		public bool positionChanged { get; set; }
		public bool jobTitleChanged { get; set; }
		public Costcenter[] costCenters { get; set; }
		public bool hasPendingEaf { get; set; }
		public Experienceedit experienceEdit { get; set; }
	}

	public class Employment
	{
		public string code { get; set; }
		public string description { get; set; }
	}

	public class Costcenter
	{
		public string companyId { get; set; }
		public int level { get; set; }
		public string code { get; set; }
		public string label { get; set; }
		public string description { get; set; }
	}

	public class PositionHistorySummaryADP
	{
		public Lists[] futureList { get; set; }
		public Lists[] currentList { get; set; }
		public Lists[] historyList { get; set; }
		public bool isReadOnly { get; set; }
		public string requestResponseId { get; set; }
		public string serverTimeTaken { get; set; }
	}

	public class Lists
	{
		public string oid { get; set; }
		public string statusDesc { get; set; }
		public string workedInCountry { get; set; }
		public string effDate { get; set; }
		public string jobTitleDesc { get; set; }
		public string homeDeptDesc { get; set; }
		public string homeCostDesc { get; set; }
		public string locationDesc { get; set; }
		public string payGradeDesc { get; set; }
		public string benefitEligibiityDesc { get; set; }
		public bool showDeleteIcon { get; set; }
		public bool showDeleteInfoIcon { get; set; }
		public string companyCode { get; set; }
		public bool includeTimeForPayroll { get; set; }
		public bool isReadOnly { get; set; }
	}

	public class PositionDetailADP
	{
		public EmployeePositionADP employeePosition { get; set; }
		public string reportsTo { get; set; }
		public string workedInCountry { get; set; }
		public EmployeeEeocJob eeocJob { get; set; }
		public string companyCode { get; set; }
		public string fileNumber { get; set; }
		public string reportsToWithPosition { get; set; }
		public string reportsToJobTitle { get; set; }
		public bool reportsToInWorkflowProcess { get; set; }
		public bool showFLSA { get; set; }
		public bool reportsToEditable { get; set; }
		public bool quickAddJobTitle { get; set; }
		public bool quickAddJobFunction { get; set; }
		public bool quickAddJobChangeReason { get; set; }
		public bool quickAddPayGrade { get; set; }
		public bool isStreamlineCompany { get; set; }
		public bool quickAddWorkersComp { get; set; }
		public bool quickAddEEOEstablishment { get; set; }
		public bool quickAddStreamlinePayGroup { get; set; }
		public bool quickAddEmployeeType { get; set; }
		public bool isCurrentRecord { get; set; }
		public EmployeePositionAttributes Attributes { get; set; }
		public string effDate { get; set; }
		public string endDate { get; set; }
		public string[] effDateList { get; set; }
		public bool quickAddAllOtherRemaining { get; set; }
		public bool isReadOnly { get; set; }
		public EmployeePositionInfo[] info { get; set; }
		public EmployeePositionWarning[] warning { get; set; }
		public string requestResponseId { get; set; }
		public string serverTimeTaken { get; set; }
	}

	public class EmployeePositionADP
	{
		public Key key { get; set; }
		public string endDate { get; set; }
		public EmployeeADP employee { get; set; }
		public EmployeeTypeADP employeeType { get; set; }
		public bool payroll { get; set; }
		public bool globallyPaid { get; set; }
		public string paid { get; set; }
		public string positionId { get; set; }
		public string bypassGeoLocation { get; set; }
		public string allowBadge { get; set; }
		public EmployeePayrollAgreement payrollAgreement { get; set; }
		public EmployeeOCDCALCPLCV assignedShift { get; set; }
		public string statusOid { get; set; }
		public string statusActionOid { get; set; }
		public bool retired { get; set; }
		public EmployeeCTOCDCALCPLCV FLSA { get; set; }
		public EmployeeOCDCALCPLCV homeCostNoType { get; set; }
		public EmployeeHomeDeptType homeDeptType { get; set; }
		public EmployeeOCDCALCPLCV streamlinePayGroup { get; set; }
		public bool isManager { get; set; }
		public EmployeeOCDCALCPLCV jobClass { get; set; }
		public EmployeeJobChangeReason jobChangeReason { get; set; }
		public EmployeeOCDCALCPLCV jobFunctionType { get; set; }
		public EmployeeOCDAV job { get; set; }
		public EmployeeOCDAV locationType { get; set; }
		public string locationTypeOid { get; set; }
		public EmployeeOCDCALCPLCV NAICSWorkersComp { get; set; }
		public EmployeeOCDCALCPLCV rehireStatus { get; set; }
		public string startDate { get; set; }
		public EmployeeOCDCARCORAOULCCOV terminationReason { get; set; }
		public EmployeeOCDCARCORAOULCCOV leaveReason { get; set; }
		public EmployeeOCDCARCORAOULCCOV rehireReason { get; set; }
		public EmployeeOCDCARCORAOULCCOV loaReturnReason { get; set; }
		public EmployeeOCDACNV unionCodeType { get; set; }
		public EmployeeOCDAV unionLocalCodeType { get; set; }
		public EmployeeOCDACNV businessUnit { get; set; }
		public string payGroupOid { get; set; }
		public EmployeeOCDAV benefitsEligibilityClass { get; set; }
		public EmployeeCTOCDCALCPLCV corpGroupChangeReason { get; set; }
		public string eeocJobOid { get; set; }
		public EmployeePayGrade payGrade { get; set; }
		public EmployeePayGrade payGradeObject { get; set; }
		public string payGradeOid { get; set; }
		public bool loaPaid { get; set; }
		public bool dbLoad { get; set; }
		public bool rehireabilityStatus { get; set; }
		public string currencyCode { get; set; }
		public string productLocaleCode { get; set; }
		public bool enableROEClearingProcess { get; set; }
		public bool validateEzlmFieldsBeforeSaving { get; set; }
		public bool nonResident { get; set; }
		public string ezlmSupervisorFlag { get; set; }
		public string ezlmTlmEmpStatus { get; set; }
		public string ezlmTransferToPayroll { get; set; }
		public string ezlmTlmDepartmentId { get; set; }
		public string ezlmLocationId { get; set; }
		public string ezlmPayGroupId { get; set; }
		public string ezlmPayCycleId { get; set; }
		public string ezlmOverrideToDefault { get; set; }
		public string ezlmTlmTerminationCodeId { get; set; }
		public string ezlmTerminationFlag { get; set; }
		public string ezlmInheritanceKey { get; set; }
		public string ezlmTlmPositionCode { get; set; }
		public string ezlmUserId { get; set; }
		public string companyCode { get; set; }
		public string ezlmPayrollId { get; set; }
		public string ezlmSor { get; set; }
		public string ezlmIsTime { get; set; }
		public string ezlmEmployeeId { get; set; }
		public string ezlmObjectId { get; set; }
		public bool specialUnpaidLeave { get; set; }
		public bool enableTrackingChange { get; set; }
		public bool newWCCRequested { get; set; }
		public bool workWeekSun { get; set; }
		public bool workWeekMon { get; set; }
		public bool workWeekTue { get; set; }
		public bool workWeekWed { get; set; }
		public bool workWeekThu { get; set; }
		public bool workWeekFri { get; set; }
		public bool workWeekSat { get; set; }
		public EmployeeEeoEstablishment eeoEstablishment { get; set; }
		public int version { get; set; }
	}

	public class Key
	{
		public string oid { get; set; }
		public string effDate { get; set; }
	}

	public class Position
	{
		public string oid { get; set; }
		public string effDate { get; set; }
		public string firstName { get; set; }
		public string lastName { get; set; }
		public string preferredFirstName { get; set; }
		public string preferredMiddleName { get; set; }
		public string preferredLastName { get; set; }
		public string generationSuffixCode { get; set; }
		public string uniqueID { get; set; }
		public string uniqueIdTypeCode { get; set; }
		public string employeeOID { get; set; }
		public int index { get; set; }
		public int currentPositionIndex { get; set; }
		public bool displayInTheList { get; set; }
		public Positions[] positions { get; set; }
		public bool supervisor { get; set; }
		public bool multiplePositions { get; set; }
		public int rowNumber { get; set; }
		public string employeeTypeOid { get; set; }
		public bool archived { get; set; }
		public bool directoryResult { get; set; }
		public string encAoid { get; set; }
		public string encAssociateId { get; set; }
		public string encEmployeeOID { get; set; }
		public int totalEmpCount { get; set; }
		public int eligibleEmpCount { get; set; }
	}

	public class EmployeePayrollAgreement
	{
		public string pAID { get; set; }
		public string employeeOid { get; set; }
		public string companyCode { get; set; }
		public string fileNumber { get; set; }
		public string recordTransmissionStatusOid { get; set; }
		public bool active { get; set; }
		public bool transfer { get; set; }
		public bool cancelAutomaticPay { get; set; }
		public bool schedulePayment { get; set; }
		public string payGroupOid { get; set; }
		public int version { get; set; }
	}

	public class EmployeeOCDCALCPLCV
	{
		public string oid { get; set; }
		public string code { get; set; }
		public string description { get; set; }
		public string category { get; set; }
		public bool active { get; set; }
		public string localeCode { get; set; }
		public string productLocaleCode { get; set; }
		public int version { get; set; }
	}

	public class EmployeeOCDAV
	{
		public string oid { get; set; }
		public string code { get; set; }
		public string description { get; set; }
		public bool active { get; set; }
		public string extendDescription { get; set; }
		public int version { get; set; }
	}

	public class EmployeeCTOCDCALCPLCV
	{
		public bool clientType { get; set; }
		public string oid { get; set; }
		public string code { get; set; }
		public string description { get; set; }
		public string category { get; set; }
		public bool active { get; set; }
		public string localeCode { get; set; }
		public string productLocaleCode { get; set; }
		public int version { get; set; }
	}

	public class EmployeeHomeCostNoType
	{
		public string oid { get; set; }
		public string code { get; set; }
		public string description { get; set; }
		public string category { get; set; }
		public bool active { get; set; }
		public string localeCode { get; set; }
		public string productLocaleCode { get; set; }
		public int version { get; set; }
	}

	public class EmployeeHomeDeptType
	{
		public string oid { get; set; }
		public string code { get; set; }
		public string description { get; set; }
		public string category { get; set; }
		public string companyCode { get; set; }
		public bool active { get; set; }
		public string localeCode { get; set; }
		public string productLocaleCode { get; set; }
		public string abbrev { get; set; }
		public int version { get; set; }
	}

	public class EmployeeJobChangeReason
	{
		public bool clientType { get; set; }
		public string oid { get; set; }
		public string code { get; set; }
		public string description { get; set; }
		public string category { get; set; }
		public bool active { get; set; }
		public string localeCode { get; set; }
		public string productLocaleCode { get; set; }
		public string abbrev { get; set; }
		public int version { get; set; }
	}

	public class EmployeeOCDCARCORAOULCCOV
	{
		public string oid { get; set; }
		public string code { get; set; }
		public string description { get; set; }
		public string category { get; set; }
		public bool active { get; set; }
		public string reasonCategoryOid { get; set; }
		public string reasonActionOid { get; set; }
		public string userLocaleCode { get; set; }
		public bool clientOwned { get; set; }
		public int version { get; set; }
	}

	public class EmployeeOCDACNV
	{
		public string oid { get; set; }
		public string code { get; set; }
		public string description { get; set; }
		public bool active { get; set; }
		public string contactName { get; set; }
		public int version { get; set; }
	}

	public class EmployeePayGrade
	{
		public string oid { get; set; }
		public Key key { get; set; }
		public string code { get; set; }
		public string description { get; set; }
		public bool active { get; set; }
		public bool autoCalcMidpoint { get; set; }
		public string localeCode { get; set; }
		public string productLocaleCode { get; set; }
		public int version { get; set; }
	}

	public class EmployeeEeoEstablishment
	{
		public string oid { get; set; }
		public string code { get; set; }
		public bool Headquarters { get; set; }
		public bool active { get; set; }
		public int version { get; set; }
	}

	public class EmployeePositionAttributes
	{
		public bool ReadOnly { get; set; }
		public string checkForPendingWCCForEmpPosition { get; set; }
		public bool isPaidPosition { get; set; }
		public bool isUSPosition { get; set; }
		public bool PendingWorkflow { get; set; }
		public bool isGloballyPaidPosition { get; set; }
		public bool isInternationalPosition { get; set; }
		public bool isCAPosition { get; set; }
	}

	public class EmployeeEeocJob
	{
		public string oid { get; set; }
		public string code { get; set; }
		public string description { get; set; }
		public string category { get; set; }
		public string abbrev { get; set; }
		public bool taxable { get; set; }
		public string subClass { get; set; }
		public string userLocaleCode { get; set; }
		public string prodLocaleCode { get; set; }
		public int version { get; set; }
	}

	public class EmployeePositionInfo
	{
		public string message { get; set; }
		public string messageType { get; set; }
		public string contextType { get; set; }
	}

	public class EmployeePositionWarning
	{
		public string message { get; set; }
		public string messageType { get; set; }
		public string contextType { get; set; }
	}


	public class PosHistDetailJobTitleADP
	{
		public JobTitle data { get; set; }
		public bool isReadOnly { get; set; }
		public string requestResponseId { get; set; }
		public string serverTimeTaken { get; set; }
	}

	public class JobTitle
	{
		public string oid { get; set; }
		public string code { get; set; }
		public string description { get; set; }
		public bool paid { get; set; }
		public bool manager { get; set; }
		public bool active { get; set; }
		public FlsaCode flsaCode { get; set; }
		public JobFunction jobFunction { get; set; }
		public string eeocJobOid { get; set; }
		public SalaryStructure salaryStructure { get; set; }
		public DefaultPayGrade defaultPayGrade { get; set; }
		public string payGradeOid { get; set; }
		public bool assignedCompetencies { get; set; }
		public int version { get; set; }
	}

	public class FlsaCode
	{
		public bool clientType { get; set; }
		public string oid { get; set; }
		public string code { get; set; }
		public string description { get; set; }
		public string category { get; set; }
		public bool active { get; set; }
		public string localeCode { get; set; }
		public string productLocaleCode { get; set; }
		public int version { get; set; }
	}

	public class JobFunction
	{
		public string oid { get; set; }
		public string code { get; set; }
		public string description { get; set; }
		public string category { get; set; }
		public bool active { get; set; }
		public string localeCode { get; set; }
		public string productLocaleCode { get; set; }
		public int version { get; set; }
	}

	public class SalaryStructure
	{
		public string oid { get; set; }
		public string code { get; set; }
		public string description { get; set; }
		public bool active { get; set; }
		public string category { get; set; }
		public string subClass { get; set; }
		public int version { get; set; }
	}

	public class DefaultPayGrade
	{
		public string oid { get; set; }
		public JobTitleKey key { get; set; }
		public string code { get; set; }
		public string description { get; set; }
		public float minimum { get; set; }
		public float maximum { get; set; }
		public float midpoint { get; set; }
		public string periodOid { get; set; }
		public bool active { get; set; }
		public bool autocalcMidpoint { get; set; }
		public bool useBroadband { get; set; }
		public string prodLocaleCode { get; set; }
		public int version { get; set; }
	}

	public class JobTitleKey
	{
		public string oid { get; set; }
		public string localeCode { get; set; }
	}
}
