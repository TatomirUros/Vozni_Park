using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vozni_Park.DTOs;

namespace Vozni_Park.Services.Interfaces
{
    public interface ITagService
    {
        Task<List<TagTableViewDTO>> GetAllTagsForTableView();
        Task<TagDTO> GetTagIdByRegistration(string registration);
        Task InsertTag(TagDTO tag);
        Task UpdateTag(TagDTO tag);
        Task DeleteTag(int id);
    }
}
