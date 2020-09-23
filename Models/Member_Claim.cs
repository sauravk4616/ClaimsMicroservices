using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimsMicroservice.Models
{
    public class Member_Claim
    {
        public int ClaimNumber { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public string PolicyID { get; set; }
        public string HospitalID { get; set; }
        public int AmbulanceCharges { get; set; }
        public int MedicineCharges { get; set; }
        public int OperationCharges { get; set; }
        public int StayingCharges { get; set; }
        public int Amountclaimed { get; set; }
        public int AmountBilled { get; set; }
        public string MemberID { get; set; }
    }
}
