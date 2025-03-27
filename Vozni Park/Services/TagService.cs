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
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService()
        {
            _tagRepository = new TagRepository();
        }
        public async Task<List<TagTableViewDTO>> GetAllTagsForTableView()
        {
            return await _tagRepository.GetAllTagsForTableViewAsync();
        }

        public async Task<TagDTO> GetTagIdByRegistration(string registration)
        {
            return await _tagRepository.GetTagIdByRegistrationAsync(registration);
        }
        public async Task InsertTag(TagDTO tag)
        {
            await _tagRepository.InsertTagAsync(tag);
        }
        public async Task UpdateTag(TagDTO tag)
        {
            await _tagRepository.UpdateTagAsync(tag);
        }
        public async Task DeleteTag(int id)
        {
            await _tagRepository.DeleteAllConnectedWithTagAsync(id);
            await _tagRepository.DeleteTagAsync(id);
        }
    }
}
