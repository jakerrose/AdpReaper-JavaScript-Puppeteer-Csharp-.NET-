using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifewell_Reaper.Classes
{
    public class CheckApiResponse
    {
        public int[] yearOptions { get; set; }
        public Pagedata[] pageData { get; set; }
    }

    public class Pagedata
    {
        public int id { get; set; }
        public int payrollId { get; set; }
        public bool isPrintable { get; set; }
        public bool showEmployerTaxes { get; set; }        
        public Header header { get; set; }
        public Employeeinfo employeeInfo { get; set; }
        
        /*
        public Earning[] earnings { get; set; }
        public Deduction[] deductions { get; set; }
        public Employeetax[] employeeTaxes { get; set; }
        public Employertax[] employerTaxes { get; set; }
        public Directdeposit[] directDeposits { get; set; }
        public Accrual[] accruals { get; set; }
        public string[] accrualColumns { get; set; }
        */
    }

    public class Header
    {
        public bool isPriorEmployeeCheck { get; set; }
        public DateTime checkDate { get; set; }
        public DateTime periodBeginDate { get; set; }
        public DateTime periodEndDate { get; set; }
        public string checkNumber { get; set; }
        public string voucherNumber { get; set; }
        /*
        public float grossPay { get; set; }
        public float grossWage { get; set; }
        public float totalHours { get; set; }
        public float netPay { get; set; }        
        public float checkAmount { get; set; }
        public string description { get; set; }
        public int runNumber { get; set; }
        public string legalName { get; set; }
        public float directDepositAmount { get; set; }
        public int fedExemptions { get; set; }
        public string fedAdditionalLabel { get; set; }
        public string fedAdditionalAmount { get; set; }
        public int stateExemptions { get; set; }
        public string stateAdditionalLabel { get; set; }
        public string stateAdditionalAmount { get; set; }
        public string stateExemptionLabel { get; set; }
        public string stateExemptionAmount { get; set; }
        public object localExemptions { get; set; }
        public string localAdditionalLabel { get; set; }
        public string localAdditionalAmount { get; set; }
        public bool hasLocal { get; set; }
        public bool isFedBlocked { get; set; }
        public bool isStateBlocked { get; set; }
        public bool isFedMultipleJobs { get; set; }
        public bool isStateMultipleJobs { get; set; }
        public string dependentExemption { get; set; }
        public string deductionExemption { get; set; }
        public string otherIncome { get; set; }
        */
    }

    public class Employeeinfo
    {
        public string fullName { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string cityStateZip { get; set; }
        public string employeeNumber { get; set; }
        public string ssn { get; set; }
        public string fedFilingStatus { get; set; }
        public object stateFilingStatus { get; set; }
        public object localFilingStatus { get; set; }
        public string org1Name { get; set; }
        public string org1Value { get; set; }
        public string org2Name { get; set; }
        public string org2Value { get; set; }
        public string residenceState { get; set; }
        public object residentLocation { get; set; }
    }

    public class Earning
    {
        public string description { get; set; }
        public float? currentDollars { get; set; }
        public float? currentHours { get; set; }
        public object currentWages { get; set; }
        public float ytdDollars { get; set; }
        public object ytdWages { get; set; }
        public float ytdHours { get; set; }
        public bool hasAmount { get; set; }
    }

    public class Deduction
    {
        public string description { get; set; }
        public float? currentDollars { get; set; }
        public object currentHours { get; set; }
        public object currentWages { get; set; }
        public float ytdDollars { get; set; }
        public object ytdWages { get; set; }
        public object ytdHours { get; set; }
        public bool hasAmount { get; set; }
    }

    public class Employeetax
    {
        public string description { get; set; }
        public float currentDollars { get; set; }
        public object currentHours { get; set; }
        public float currentWages { get; set; }
        public float ytdDollars { get; set; }
        public float ytdWages { get; set; }
        public object ytdHours { get; set; }
        public bool hasAmount { get; set; }
    }

    public class Employertax
    {
        public string description { get; set; }
        public float currentDollars { get; set; }
        public object currentHours { get; set; }
        public float currentWages { get; set; }
        public float ytdDollars { get; set; }
        public float ytdWages { get; set; }
        public object ytdHours { get; set; }
        public bool hasAmount { get; set; }
    }

    public class Directdeposit
    {
        public string description { get; set; }
        public string accountNumber { get; set; }
        public float depositAmount { get; set; }
    }

    public class Accrual
    {
        public string description { get; set; }
        public string[] columnValues { get; set; }
    }


}
