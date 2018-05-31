using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Easy.Core;
using Easy.Data;
using Easy.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Easy.Controllers
{
    [Route("api/[controller]")]
    public class CandidateController : Controller
    {
        IRepository Repository { get; }
        public CandidateController(IRepository repository)
        {
            Repository = repository;
        }

        // GET: api/<controller>
        [HttpGet]
        public object Get()
        {
            var result = Repository.Candidates
                    .Include(p => p.Account)
                    .Include(p => p.Skills)
                    .Include(p => p.Address)
                    .Include(p => p.Phones)
                    .ToArray();

            return new {
                Model = result,
                Success = true
            };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public JsonResult Post([FromBody]Candidate candidate)
        {
            Repository.Save(candidate);
            return this.AsSuccessJsonResult(candidate);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var candidate = Repository.Candidates
                .Include(p => p.Account)
                .Include(p => p.Address)
                .Include(p => p.Skills)
                .Include(p => p.Phones)
                .FirstOrDefault(s => s.Id == id);
            if (candidate == null)
                return NotFound("The candidate was not found");
            Repository.Delete(candidate);
            return Ok();
        }
    }
}
