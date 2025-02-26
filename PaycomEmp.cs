using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paycom_Uploader
{
	internal class PMesa
	{
		public string EmployeeId { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }
	}

	internal class PaycomEmpData
	{

		//public string Employee_Name { get; set; }
		public string Employee_Code { get; set; }
		public string SS_Number { get; set; }
		public string Legal_Lastname { get; set; }
		public string Legal_Firstname { get; set; }
		public string Birth_Date { get; set; }
		public string ClockSeq { get; set; }
		//public string Rehire_Date { get; set; }
		public string Hire_Date { get; set; }
		public string Termination_Date { get; set; }
	}

	internal class PaycomDocType
	{
		public string Doc_Type { get; set; }
		public string Doc_TypeId { get; set; }
		public string Doc_FolderId { get; set; }
	}

	internal class AdpPaycomEmpXOverData
	{
		public string AdpCo { get; set; }
		public string PaycomCo { get; set; }
		public string Employee_Name_ADP { get; set; }
		public string Employee_Name_PC { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string AdpId { get; set; }
		public string PaycomId { get; set; }
		public string SS_Number { get; set; }
		public string Last4 { get; set; }
		public string PositionId { get; set; }
		public string FileNo { get; set; }
		public string ClockSeq_Num { get; set; }

	}

}
