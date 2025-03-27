using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vozni_Park.DTOs;
using Vozni_Park.Repository.Interfaces;
using Vozni_Park.Repository;
using Vozni_Park.Services.Interfaces;

namespace Vozni_Park.Services
{
    internal class TagReplenishmentService : ITagReplenishmentService
    {
        private readonly ITagReplenishmentRepository _tagReplenishmentRepository;

        public TagReplenishmentService()
        {
            _tagReplenishmentRepository = new TagReplenishmentRepository();
        }
        public async Task DeleteTagReplenishment(int id)
        {
            await _tagReplenishmentRepository.DeleteTagReplenishmentAsync(id);
        }

        public async Task<List<TagReplenishmentTableViewDTO>> GetAllTagReplenishmentsForTableView(int idTag)
        {
            return await _tagReplenishmentRepository.GetAllTagReplenishmentsForTableViewAsync(idTag);
        }

        public async Task InsertTagReplenishment(TagReplenishmentDTO tagReplenishment)
        {
            await _tagReplenishmentRepository.InsertTagReplenishmentAsync(tagReplenishment);
        }
    }
}
