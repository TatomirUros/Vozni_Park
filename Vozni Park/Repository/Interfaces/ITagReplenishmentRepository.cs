using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vozni_Park.DTOs;

namespace Vozni_Park.Repository.Interfaces
{
    public interface ITagReplenishmentRepository
    {
        Task<List<TagReplenishmentTableViewDTO>> GetAllTagReplenishmentsForTableViewAsync(int tag);
        Task InsertTagReplenishmentAsync(TagReplenishmentDTO tag);
        Task DeleteTagReplenishmentAsync(int id);
    }
}
