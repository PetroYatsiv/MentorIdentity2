using MentorIdentity2.BLL.Contracts;
using MentorIdentity2.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentorIdentity2.BLL
{
    public class SectionService : ISectionService
    {
        private ApplicationDbContext _context;
        public SectionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResult<List<Section>>> GetSections()
        {
            ServiceResult<List<Section>> result = new ServiceResult<List<Section>>();
            var sections = await _context.Sections.ToListAsync();
            if (sections != null)
            {
                result.Data = sections;
                result.Status = ServiceResultStatus.Success;
            }
            else
            {
                result.Status = ServiceResultStatus.NotFound;
            }
            return result;
        }

        public async Task<ServiceResult<Section>> GetSection(int? id)
        {
            ServiceResult<Section> result = new ServiceResult<Section>();
            var section = await _context.Sections.FirstOrDefaultAsync(x => x.Id == id);
            if (section != null)
            {
                result.Data = section;
                result.Status = ServiceResultStatus.Success;
            }
            else
            {
                result.Status = ServiceResultStatus.NotFound;
            }
            return result;
        }

        public async Task<ServiceResult<Section>> AddSection(Section section)
        {
            ServiceResult<Section> result = new ServiceResult<Section>();
            _context.Add(section);
            await _context.SaveChangesAsync();
            result.Data = section;
            result.Status = ServiceResultStatus.Success;
            return result;
        }


        public async Task<ServiceResult<Section>> UpdateSection(Section section)
        {
            ServiceResult<Section> result = new ServiceResult<Section>();
            try
            {
                _context.Update(section);
                await _context.SaveChangesAsync();
                result.Data = section;
                result.Status = ServiceResultStatus.Success;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SectionExist(section.Id))
                {
                    result.Status = ServiceResultStatus.NotFound;
                }
                else
                {
                    throw;
                }
            }
            return result;
        }

        private bool SectionExist(int id)
        {
            var result = _context.Sections.Any(x => x.Id == id);
            return result;
        }


    }
}
