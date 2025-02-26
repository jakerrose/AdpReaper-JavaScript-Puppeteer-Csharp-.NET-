using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifewell_Reaper.Classes
{
	internal class CrosswalkEmp
	{
		public string Employee_Code { get; set; }
		public string ClockSeq { get; set; }
		public string Legal_Lastname { get; set; }
		public string Legal_Firstname { get; set; }
	}
	internal class EmployeeSearchResponse
    {
        public string status { get; set; }
        public EmployeeDataResponse data { get; set; }
        public string requestResponseId { get; set; }
        public string serverTimeTaken { get; set; }
        public int totalRecords { get; set; }
    }

    public class EmployeeDataResponse
    {
        public int totalRecords { get; set; }
        public List<EmployeeIndivResponse> uiList { get; set; }
        public bool futureNewHireFilter { get; set; }
    }

    public class ADPEmpData
    {
        public string Client_Code { get; set; }
        public string PositionID { get; set; }
        public string Employee_Name { get; set; }
        public string AssociateID { get; set; }
        public string JobTitle { get; set; }
        public string BusinessUnit { get; set; }
        public string File_Num { get; set; }
        public string HomeDept { get; set; }
        public string Hire_Date { get; set; }
        public string Status { get; set; }
        public string SS_Number { get; set; }
    }

    public class ADPEmpDataBHH
    {
        public string Client_Code { get; set; }
        public string Employee_Name { get; set; }
        public string AssociateID { get; set; }
        public string PositionID { get; set; }
        public string File_Num { get; set; }
        public string Status { get; set; }
        public string Hire_Date { get; set; }
        public string JobTitle { get; set; }
        public string SS_Number { get; set; }
    }

    public class EmployeeDataADP
    {
        public int totalRecords { get; set; }
        public EmployeeRecordADP[] list { get; set; }
        public int pageNumber { get; set; }
        public int indexInPage { get; set; }
        public bool isReadOnly { get; set; }
        public string requestResponseId { get; set; }
        public string serverTimeTaken { get; set; }
    }

    public class EmployeeIndivResponse
    {
        public int id { get; set; }
        public string name { get; set; }
        public string displayId { get; set; }
        public string pfId { get; set; }
        public string code { get; set; }
        public string desc { get; set; }
        public string preferredName { get; set; }
    }

    public class EmployeeRecordADP
    {
        public string aOid { get; set; }
        public string associateId { get; set; }
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

    public class EmployeeRecord
    {
        public string co { get; set; }
        public int eInfoId { get; set; }
        public string firstName { get; set; }
        public string preferredFirstName { get; set; }
        public string displayName { get; set; }
        public string lastName { get; set; }
        public string id { get; set; }
        public string ssn { get; set; }
        public string empStatus { get; set; }
        public object payFrequency { get; set; }
        public string supervisorId { get; set; }
        public string supervisorCo { get; set; }
        public string cc1 { get; set; }
        public string cc2 { get; set; }
        public string cc3 { get; set; }
        public string Disabled { get; set; }
        public int pendingState { get; set; }
        public bool IsHrLink { get; set; }
        public int AccessRights { get; set; }
        public bool checkViewOnly { get; set; }
        public string cc1Code { get; set; }
        public object cc2Code { get; set; }
        public object cc3Code { get; set; }
        public string supervisorDisplayName { get; set; }
        public string IdentityKey { get; set; }
        public object PayAssignments { get; set; }
        public string EncryptedId { get; set; }
        public string EncryptedCo { get; set; }
        public bool ShowPortalLink { get; set; }
        public bool HasAccessToEmployeeActionForms { get; set; }
        public bool HasPendingStatusChange { get; set; }
        public bool CanViewPendingStatusChange { get; set; }
        public object ExperienceDesignType { get; set; }
    }

    public class Positions
    {
        public string pfID { get; set; }
        public string coCode { get; set; }
        public string fileNumber { get; set; }
        public string homeDepartment { get; set; }
        public string jobTitle { get; set; }
        public string statusOid { get; set; }
        public string status { get; set; }
        public string positionId { get; set; }
        public int inxex { get; set; }
        public string currentPositionIndex { get; set; }
        public bool newHire { get; set; }
        public bool futureNewHire { get; set; }
        public int archived { get; set; }
        public bool primaryPosition { get; set; }
        public bool displayInTheList { get; set; }
        public bool paidPosition { get; set; }
        public bool retired { get; set; }
        public bool viewOnly { get; set; }
        public bool directReport { get; set; }
        public bool indirectReport { get; set; }
        public int rptRole { get; set; }
        public string prodLocaleCode { get; set; }
        public int wfvInclusionMode { get; set; }
        public bool isUsingTimeAttendance { get; set; }
        public string hireDate { get; set; }
        public string encPfid { get; set; }
        public string encPositionId { get; set; }
        public bool isManagementPosition { get; set; }
        public bool isIntegrationIdImportFeatureEnabled { get; set; }
    }

    public class EmployeeADP
    {
        public string oid { get; set; }
        public string AOID { get; set; }
        public string givenName { get; set; }
        public string familyName { get; set; }
        public string middleFirstName { get; set; }
        public string genderOid { get; set; }
        public string employeeId { get; set; }
        public string legalFirstName { get; set; }
        public string legalLastName { get; set; }
        public bool archived { get; set; }
        public bool temporaryUNI { get; set; }
        public string hireDate { get; set; }
        public string reasonForHire { get; set; }
        public bool employeeUser { get; set; }
        public string userId { get; set; }
        public string productLocaleCode { get; set; }
        public string adminFlag { get; set; }
        public bool autoEnrollAssociate { get; set; }
        public bool ACAFullTime { get; set; }
        public string businessEmailAddress { get; set; }
        public string personalEmailAddress { get; set; }
        public bool usePersonalEmailForNotification { get; set; }
        public bool useBusinessEmailForNotification { get; set; }
        public bool homeShored { get; set; }
        public bool alertsEmailPreference { get; set; }
        public bool alertsMessageCenterPreference { get; set; }
        public bool sinNotProvided { get; set; }
        public int version { get; set; }
    }

    public class EmployeeTypeADP
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

    public class EmployeeI9ADP
    {
        public EmpI9ADP data { get; set; }
        public bool isReadOnly { get; set; }
        public string requestResponseId { get; set; }
        public string serverTimeTaken { get; set; }
    }

    public class EmpI9ADP
    {
        public string oid { get; set; }
        public string employeeOid { get; set; }
        public bool Receipt_A { get; set; }
        public string DocumentName_B { get; set; }
        public string ExpDate_DocumentB { get; set; }
        public string DocumentNo_B { get; set; }
        public string IssuingAuth_B { get; set; }
        public bool Receipt_B { get; set; }
        public string DocumentName_C { get; set; }
        public string DocumentNo_C { get; set; }
        public string IssuingAuth_C { get; set; }
        public bool Receipt_C { get; set; }
        public string WorkAuthStatus { get; set; }
        public string I9ReviewDate { get; set; }
        public string usWorkAuthStatus { get; set; }
        public string iRCAlistCDocumentName { get; set; }
        public string iRCAlistBDocumentName { get; set; }
        public bool isWNFEI9VerifyAvailable { get; set; }
        public string i9EligibilityDateFormat { get; set; }
        public bool isReadOnly { get; set; }
    }

    public class ADPBillGOEmployeeI9Response
    {
        public ADPBillGOEmployeeI9Results[] Data { get; set; }
    }

    public class ADPBillGOEmployeeI9Results
    {
        public ADPBillGOEmployeeI9Record[] result { get; set; }
        public int totalRecords { get; set; }
        public int activeListSize { get; set; }
        public int closeListSize { get; set; }
        public int completedListSize { get; set; }
        public int archiveListSize { get; set; }
        public int expiringListSize { get; set; }
        public int eVerifySubmitPendingListSize { get; set; }
        public bool disableEverifyIntegration { get; set; }
        public bool atLeastOneEnrollmentActive { get; set; }
        public bool revealSsn { get; set; }
        public bool revealDob { get; set; }
        public bool uaMode { get; set; }
        public int everifyVersion { get; set; }
        public bool isReadOnly { get; set; }
        public string requestResponseId { get; set; }
        public int serverTimeTaken { get; set; }
    }

    public class ADPBillGOEmployeeI9Record
    {
        public string ei9MainOid { get; set; }
        public string employeeOid { get; set; }
        public string statusOid { get; set; }
        public string employeeFullName { get; set; }
        public string section1FullName { get; set; }
        public string hireDate { get; set; }
        public string section1SubmitDate { get; set; }
        public string eventId { get; set; }
        public string section1StatusOid { get; set; }
        public string section2SubmitDate { get; set; }
        public string employeeAoid { get; set; }
        public string postionProdLocale { get; set; }
        public string companyCode { get; set; }
        public string fileNo { get; set; }
        public string citizenshipStatusCode { get; set; }
        public string street1 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipCode { get; set; }
        public string companyName { get; set; }
        public string previousStatusOid { get; set; }
        public string i9FormLocale { get; set; }
        public string i9FormVersion { get; set; }
        public string statusDescription { get; set; }
        public string status { get; set; }
        public string statusCode { get; set; }
        public string[] furthurActions { get; set; }
        public string section2SubmitDateTimeStr { get; set; }
        public string orgoid { get; set; }
    }

    public class AdpEmpDataABM
    {
        public string Client_Code { get; set; }
        public string PositionID { get; set; }
        public string Employee_Name { get; set; }
        public string AssociateID { get; set; }
        public string File_Num { get; set; }
        public string HomeDept { get; set; }
        public string Hire_Date { get; set; }
        public string Status { get; set; }
        public string SS_Number { get; set; }
    }

    public class AdpEmpRosterTryIt
    {
        public string Client_Code { get; set; }
        public string Employee_Name { get; set; }
        public string AssociateID { get; set; }
        public string PositionID { get; set; }
        public string FileNo { get; set; }
        public string Status { get; set; }
        public string Hire_Date { get; set; }
        public string PrimaryPosition { get; set; }
        public string JobTitle { get; set; }
        public string HomeDept { get; set; }
        public string Location { get; set; }
        public string SS_Number { get; set; }
    }

    public class AdpEmpInformationTryIt
    {
        public string Client_Code { get; set; }
        public string PositionID { get; set; }
        public string Employee_Name { get; set; }
        public string AssociateID { get; set; }
        public string Preferred_Name { get; set; }
        public string JobTitle { get; set; }
        public string BusinessUnit { get; set; }
        public string FileNo { get; set; }
        public string HomeDept { get; set; }
        public string Location { get; set; }
        public string Hire_Date { get; set; }
        public string Status { get; set; }
        public string SS_Number { get; set; }
    }
}
