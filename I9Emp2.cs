using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifewell
{
	// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
	public class Record
	{
		public string ei9MainOid { get; set; }
		public string employeeOid { get; set; }
		public string statusOid { get; set; }
		public string employeeFullName { get; set; }
		public string section1FullName { get; set; }
		public string systemLastName { get; set; }
		public string systemFirstName { get; set; }
		public string caseNumber { get; set; }
		public string hireDate { get; set; }
		public string section1SubmitDate { get; set; }
		public string section1StatusOid { get; set; }
		public string section2SubmitDate { get; set; }
		public string employeeAoid { get; set; }
		public string postionProdLocale { get; set; }
		public string managerName { get; set; }
		public string managerFirstName { get; set; }
		public string managerLastName { get; set; }
		public string managerAoid { get; set; }
		public string companyCode { get; set; }
		public string fileNo { get; set; }
		public string citizenshipStatusCode { get; set; }
		public string currentStateCode { get; set; }
		public string message { get; set; }
		public string hiringSiteCode { get; set; }
		public string hiringSiteDescription { get; set; }
		public string companyName { get; set; }
		public string previousStatusOid { get; set; }
		public string newhireDefaultHiringSiteOid { get; set; }
		public string managerPfid { get; set; }
		public string i9FormLocale { get; set; }
		public string i9FormVersion { get; set; }
		public string statusDescription { get; set; }
		public string status { get; set; }
		public string statusCode { get; set; }
		public List<string> furthurActions { get; set; }
		public string section2SubmitDateTimeStr { get; set; }
		public string orgoid { get; set; }
		public string archiveComment { get; set; }
		public string messageCode { get; set; }
		public string resubmitPrevStatusOid { get; set; }
		public string street1 { get; set; }
		public string city { get; set; }
		public string state { get; set; }
		public string zipCode { get; set; }
		public string resubmitPrevStatusCode { get; set; }
	}

	public class I9EmpRoot
	{
		public List<Record> records { get; set; }
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
		public string everifyVersion { get; set; }
		public bool isReadOnly { get; set; }
		public string requestResponseId { get; set; }
		public string serverTimeTaken { get; set; }
	}


}
