using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifewell
{
	internal class TaxDoc
	{
		public string branch { get; set; }
		public string runDate { get; set; }
		public string docType { get; set; }
		public string title { get; set; }
		public string eeId { get; set; }
		public bool pdfFlag { get; set; }
	}
}
