using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifewell
{
		// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
		public class CrosswalkRoot
		{
			public string Employee_Code { get; set; }
			//public int SS_Number { get; set; }
			public string Legal_Lastname { get; set; }
			public string Legal_Firstname { get; set; }

			//[JsonProperty("Birth_Date_(MM/DD/YYYY)")]
			//public long Birth_Date_MMDDYYYY { get; set; }
			public string ClockSeq { get; set; }
			//public object Position_Title { get; set; }
			//public long Hire_Date { get; set; }
			//public long Termination_Date { get; set; }
			//public string Employee_Status { get; set; }
			//public object PayType { get; set; }
		}

	
}
