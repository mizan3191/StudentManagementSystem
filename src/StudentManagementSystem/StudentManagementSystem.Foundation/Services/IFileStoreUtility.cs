using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Foundation.Services
{
    public interface IFileStoreUtility
    {
        public (string path, string name) GetFile(IFormFile file);
    }
}
