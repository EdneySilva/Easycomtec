using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Easy.Core;
using Easy.Data;
using Easy.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Easy.Controllers
{
    public class HomeController : Controller
    {
        IRepository Repository { get; }

        public HomeController(IRepository repository)
        {
            Repository = repository;
        }

        public IActionResult Index()
        {
            var lista = Repository.Candidates.ToList();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        // POST: /<controller>/AddPhone
        [HttpPost]
        public JsonResult AddPhone([FromBody]Phone phone)
        {
            if (ModelState.IsValid && phone.CandidateId > 0)
                Repository.Save(phone);


            return this.AsSuccessJsonResult(phone);
        }

        // POST: /<controller>/RemovePhone
        [HttpPost]
        public JsonResult RemovePhone([FromBody]Phone phone)
        {
            if (phone.Id > 0)
                Repository.Delete(phone);
            return this.AsSuccessJsonResult(phone);
        }

        // POST: /<controller>/AddSkill
        [HttpPost]
        public JsonResult AddSkill([FromBody]Skill skill)
        {
            if (skill.CandidateId > 0)
                Repository.Save(skill);
            return this.AsSuccessJsonResult(skill);
        }

        // POST: /<controller>/RemoveSkill
        [HttpPost]
        public JsonResult RemoveSkill([FromBody]Skill skill)
        {
            if (skill.Id > 0)
                Repository.Delete(skill);
            return this.AsSuccessJsonResult(skill);
        }

        // POST: /<controller>/Save
        [HttpPost]
        public JsonResult Save([FromBody]Candidate candidate)
        {
            Repository.Save(candidate);            
            return this.AsSuccessJsonResult(candidate);
        }
    }
}
