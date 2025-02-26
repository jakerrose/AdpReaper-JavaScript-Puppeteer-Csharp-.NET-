using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifewell_Reaper.Classes
{
    public class W2Response
    {
        public string companyId { get; set; }
        public string assignmentId { get; set; }
        public int taxYear { get; set; }
        public float grossWages { get; set; }
        public float federalWithholding { get; set; }
        public float stateWithholding { get; set; }
    }
}
