using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MentorIdentity2.DAL.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MentorIdentity2.Controllers
{
    public class SectionController : Controller
    {
        private ApplicationDbContext _context;
        public SectionController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var section = _context.Sections.Select(x => x.User).ToList();

            return View();
        }




    }
}
