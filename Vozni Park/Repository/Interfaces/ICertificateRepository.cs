using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vozni_Park.Repository.Interfaces
{
    public interface ICertificateRepository
    {
        Task UpdatePictureAsync(string path, int id);
    }
}
