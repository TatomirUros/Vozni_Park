using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vozni_Park.Services.Interfaces
{
    internal interface ICertificateService
    {
        Task UpdatePicture(string path, int id);
    }
}
