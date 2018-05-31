using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Easy.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Easy.Controllers
{
    public class ResumeController : Controller
    {
        IRepository Repository { get; }
        public ResumeController(IRepository repository)
        {
            Repository = repository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [Route("/[controller]/{id}")]
        [Route("/[controller]/edit/{id}")]
        public IActionResult Edit(int id)
        {
            if (id == 0 || !Repository.Candidates.Any(a => a.Id == id))
                return NotFound();
            var candidate = Repository.Candidates
                    .Include(i => i.Address)
                    .Include(i => i.Account)
                    .Include(i => i.Phones)
                    .Include(i => i.Skills)
                    .First(item => item.Id == id);            
            return View(candidate);
        }

        public JsonResult Get()
        {
            var result = Repository.Candidates
                    .Include(p => p.Account)
                    .Include(p => p.Skills)
                    .Include(p => p.Address)
                    .Include(p => p.Phones)
                    .ToArray();
            return Json(result);
        }
    }
}
