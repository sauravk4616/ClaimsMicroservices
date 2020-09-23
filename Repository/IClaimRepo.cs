using ClaimsMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ClaimsMicroservice.Repository
{
    public interface IClaimRepo
    {
        public List<string> getClaimStatus(int cid,string pid,string mid);

        public int submitClaim(Member_Claim obj);
    }
}
