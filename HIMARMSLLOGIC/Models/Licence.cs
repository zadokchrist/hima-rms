using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMARMSLLOGIC.Models
{
    public class Licence
    {
        public string RecordId { get; set; }
        public string leasetype { get; set; }
        public string referencenum { get; set; }
        public string issuingauthority { get; set; }
        public string technicalscope { get; set; }
        public string geographicalscope { get; set; }
        public string issuedate { get; set; }
        public string dateofexpiry { get; set; }
        public string LicenceAcquisitionCost { get; set; }
        public string RenewalCost { get; set; }
        public string OtherRelatedCost { get; set; }
        public string ResponsibleDepartment { get; set; }
        public string ImpactedDepartments { get; set; }
        public string averagerenewal { get; set; }
        public string TermsAndConditions { get; set; }
        public string AverageRenewalTime { get; set; }
        public string RemarksAndComments { get; set; }
        public string RecordDate { get; set; }
    }
}
