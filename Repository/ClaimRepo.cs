using ClaimsMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ClaimsMicroservice.Repository
{
    public class ClaimRepo : IClaimRepo
    {

       
        private static List<Member_Claim> NewList = new List<Member_Claim>
        {
          new Member_Claim{ ClaimNumber = 1,Status = "Sanctioned",Remarks = "Dummy1",PolicyID = "P1",MemberID="M10",HospitalID = "H1",AmbulanceCharges=11000,MedicineCharges=2500,OperationCharges=150000,StayingCharges=20000, Amountclaimed = 110000,AmountBilled=183500 },
          new Member_Claim{ ClaimNumber = 2,Status = "In Process",Remarks = "Dummy2",PolicyID = "P2",MemberID="M20",HospitalID = "H2",AmbulanceCharges=12000,MedicineCharges=3500,OperationCharges=250000,StayingCharges=30000, Amountclaimed = 150000,AmountBilled=295500 },
          new Member_Claim{ ClaimNumber = 3,Status = "Rejected",Remarks = "Dummy3",PolicyID = "P3",MemberID="M30",HospitalID = "H3",AmbulanceCharges=13000,MedicineCharges=4500,OperationCharges=350000,StayingCharges=40000, Amountclaimed = 210000,AmountBilled=403750 }
        };

        public List<string> getClaimStatus(int cid, string pid, string mid)
        {
            
            var im = from p in NewList where p.ClaimNumber == cid select p;
            var ik = from i in im where i.PolicyID == pid select i;
            var result = from j in ik where j.MemberID == mid select j;
            List<string> ls = new List<string>();
            foreach (var id in result)
            {
                ls.Add(id.Status);
                ls.Add(id.Remarks);
                
            }
            return ls;
        }

        public int submitClaim(Member_Claim obj)
        {
            NewList.Add(obj);

            return 1;
        }
    }
}
