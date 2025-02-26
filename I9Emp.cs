using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifewell
{
	// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
	// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
	public class Ei9Main
	{
		public string oid { get; set; }
		public string employeeOid { get; set; }
		public string employmentDate { get; set; }
		public string section1SubmitDate { get; set; }
		public string section1StatusOid { get; set; }
		public string section1ConfirmationNo { get; set; }
		public string section2SubmitDate { get; set; }
		public string section2Status { get; set; }
		public string statusOid { get; set; }
		public string hiringSiteOid { get; set; }
		public string previousStatusOid { get; set; }
		public string i9FormLocale { get; set; }
		public string i9FormVersion { get; set; }
		public string modifiedOn { get; set; }
		public string modifiedByUser { get; set; }
		public int remoteVerification { get; set; }
		public int hireDateMatched { get; set; }
		public bool isEmployeeAuthorized { get; set; }
		public bool isPaperForm { get; set; }
	}

	public class EmployerInfo
	{
		public string oid { get; set; }
		public string ei9MainOid { get; set; }
		public string modifiedByUser { get; set; }
		public string employmentDate { get; set; }
	}

	public class I9Root
	{
		public Ei9Main ei9Main { get; set; }
		public Section1Info section1Info { get; set; }
		public EmployerInfo employerInfo { get; set; }
		public string employmentStartDate { get; set; }
		public string workLocationOid { get; set; }
		public bool isDoc1ReceiptToOriginal { get; set; }
		public bool isDoc2ReceiptToOriginal { get; set; }
		public bool isNewCaseGenerated { get; set; }
		public string mssPfid { get; set; }
		public string employeeFullName { get; set; }
		public string hireDate { get; set; }
		public string mouidEffectiveDate { get; set; }
		public bool isStateMandatory { get; set; }
		public bool isStateSettingConfigured { get; set; }
		public bool doNotSubmitToEverifyForCorrection { get; set; }
		public string employeeOid { get; set; }
		public string ei9MainOid { get; set; }
		public string employeeAoid { get; set; }
		public bool disableEverifyIntegration { get; set; }
		public bool atLeastOneEnrollmentActive { get; set; }
		public string ssnMaskType { get; set; }
		public bool revealSsn { get; set; }
		public string dobMaskType { get; set; }
		public bool revealDob { get; set; }
		public bool uaMode { get; set; }
		public bool isReadOnly { get; set; }
		public string requestResponseId { get; set; }
		public string serverTimeTaken { get; set; }
	}

	public class Section1
	{
		public string oid { get; set; }
		public string ei9MainOid { get; set; }
		public string firstName { get; set; }
		public string lastName { get; set; }
		public string street1 { get; set; }
		public string city { get; set; }
		public string state { get; set; }
		public string zipCode { get; set; }
		public string ssn { get; set; }
		public string birthDate { get; set; }
		public string citizenStatusCode { get; set; }
		public string authorizedExpDate { get; set; }
		public string alienNumber { get; set; }
		public string foreignCountryDescription { get; set; }
		public bool usedPreparer { get; set; }
		public string alienOrUscis { get; set; }
		public string signatureName { get; set; }
		public string signaturePin { get; set; }
		public string signatureDate { get; set; }
		public string modifiedByUser { get; set; }
		public string specialConsiderationCode { get; set; }
		public string section1SubmitDate { get; set; }
		public string fullName { get; set; }
		public string maskedSSN { get; set; }
		public string section1SumbitDateTimeStr { get; set; }
		public bool isReadOnly { get; set; }
	}

	public class Section1Info
	{
		public Section1 section1 { get; set; }
		public List<object> preparerList { get; set; }
		public string confirmationNumber { get; set; }
		public bool readOnly { get; set; }
		public bool noAccess { get; set; }
		public bool ssaCorrection { get; set; }
		public bool returnedBackCorrection { get; set; }
		public bool isPaperForm { get; set; }
		public string employeeOid { get; set; }
		public string ei9MainOid { get; set; }
		public bool disableEverifyIntegration { get; set; }
		public bool atLeastOneEnrollmentActive { get; set; }
		public string ssnMaskType { get; set; }
		public bool revealSsn { get; set; }
		public string dobMaskType { get; set; }
		public bool revealDob { get; set; }
		public bool uaMode { get; set; }
		public bool isReadOnly { get; set; }
	}




}
