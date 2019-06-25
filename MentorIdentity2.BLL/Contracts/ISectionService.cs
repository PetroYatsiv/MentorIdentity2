using MentorIdentity2.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MentorIdentity2.BLL.Contracts
{
    public interface ISectionService
    {
        Task<ServiceResult<List<Section>>> GetSections();
        Task<ServiceResult<Section>> GetSection(int? id);
        Task<ServiceResult<Section>> AddSection(Section section);
        Task<ServiceResult<Section>> UpdateSection(Section section);
    }
}
