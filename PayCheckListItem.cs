using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifewell_Reaper.Classes
{
    internal class PayCheckListItem
    {          
        public int recordId { get; set; }
        public int transNumber { get; set; }
        public string checkDate { get; set; }
        public float netEarnings { get; set; }
        public float grossEarnings { get; set; }
        public string checkLabel { get; set; }
        public string checkType { get; set; }
    }
}
