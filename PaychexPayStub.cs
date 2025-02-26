using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifewell
{
	internal class PaychexPayStub
	{
		public string eeId { get; set; }
		public string stubId { get; set; }
		public bool isHro { get; set; }
		public string payDate { get; set; }
		public string runDate { get; set; }
		public float netPay { get; set; }
	}
}
