using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Interface
{
     public interface IstorageFile
    {
        Task<string> SaveFile(byte[] content, string extension, string
container, string contentType);
        Task<string> EditFile(byte[] content, string extension, string
container, string router, string contentType);

        Task DeleteFile(string router, string
container);


    }
}
