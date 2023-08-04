using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.FilesStorage
{
    public interface IFileStorage
    {
        void Delete(string relativePath);
        Task<string> SaveAsync(IFormFile file);
    }
}
