using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vozni_Park.DTOs;

namespace Vozni_Park.Services.Interfaces
{
    public interface ITagReplenishmentService
    {
        Task<List<TagReplenishmentTableViewDTO>> GetAllTagReplenishmentsForTableView(int idTag);
        Task InsertTagReplenishment(TagReplenishmentDTO tagReplenishment);
        Task DeleteTagReplenishment(int id);
    }
}
