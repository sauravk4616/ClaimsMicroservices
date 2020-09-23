using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClaimsMicroservice.Models;
using ClaimsMicroservice.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClaimsMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Member_ClaimController : ControllerBase
    {
        readonly log4net.ILog _log4net;
        IClaimRepo db;
        public Member_ClaimController(IClaimRepo _db)
        {
            db = _db;
            _log4net = log4net.LogManager.GetLogger(typeof(Member_ClaimController));
        }

        // GET: api/<Member_ClaimController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{cid}/{pid}/{mid}")]
        public IActionResult Get1(int cid, string pid ,string mid)
        {
            _log4net.Info("Member_ClaimController getClaimStatus called");
            try
            {
                List<string> chain = db.getClaimStatus(cid,pid,mid);
                if (chain.Count == 0)
                    return NotFound();
                return Ok(chain);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        // POST: api/Member_Claim
        [HttpPost]
        public IActionResult Post([FromBody] Member_Claim obj)
        {
            _log4net.Info("Member_ClaimController submitClaim called");
            if (ModelState.IsValid)
            {
                try
                {
                    var res = db.submitClaim(obj);
                    if (res != 0)
                        return Ok(res);

                    return NotFound();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
    }
}
