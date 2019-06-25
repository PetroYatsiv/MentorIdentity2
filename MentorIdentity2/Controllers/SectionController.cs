using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MentorIdentity2.BLL;
using MentorIdentity2.BLL.Contracts;
using MentorIdentity2.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MentorIdentity2.Controllers
{
    public class SectionController : Controller
    {
        private ISectionService _sectionService;
        public SectionController(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var sections = await _sectionService.GetSections();
            return View(sections);
        }


        public async Task<IActionResult> Section(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var section = await _sectionService.GetSection(id);

            if (section.Status == ServiceResultStatus.NotFound)
            {
                return NotFound();
            }
            return View(section.Data);
        }

        public async Task<IActionResult> CreateSection()
        {
            var sections = await _sectionService.GetSections();
            ViewData["SectionId"] = new SelectList(sections.Data, "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Section section)
        {
            if (ModelState.IsValid)
            {
                var result = await _sectionService.AddSection(section);
                if (result.Status == ServiceResultStatus.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(section);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var section = await _sectionService.GetSection(id);
            if (section.Status == ServiceResultStatus.NotFound)
            {
                return NotFound();
            }
            return View(section.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Section section)
        {
            if (id != section.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var result = await _sectionService.UpdateSection(section);
                if (result.Status == ServiceResultStatus.NotFound)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(section);
        }



    }
}
