using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vozni_Park.DTOs;

namespace Vozni_Park.Repository.Interfaces
{
    public interface ITagRepository
    {
        Task<List<TagTableViewDTO>> GetAllTagsForTableViewAsync();
        Task<TagDTO> GetTagIdByRegistrationAsync(string registration);
        Task InsertTagAsync(TagDTO tag);
        Task UpdateTagAsync(TagDTO tag);
        Task DeleteTagAsync(int id);
        Task DeleteAllConnectedWithTagAsync(int id);
    }
}
