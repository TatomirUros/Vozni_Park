using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vozni_Park.Repository;
using Vozni_Park.Repository.Interfaces;
using Vozni_Park.Services.Interfaces;

namespace Vozni_Park.Services
{
    public class CertificateService : ICertificateService
    {
        private readonly ICertificateRepository _certificateRepository;
        public CertificateService() 
        {
            _certificateRepository = new CertificateRepository();
        }
        public async Task UpdatePicture(string path, int id)
        {
            await _certificateRepository.UpdatePictureAsync(path, id);
        }
    }
}
