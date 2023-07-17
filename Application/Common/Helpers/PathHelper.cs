using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Helpers
{
    public static class PathHelper
    {
        public static string GetFullPath(string relativePath)
        {
            var mainRootPath = Directory.GetCurrentDirectory();
            mainRootPath = mainRootPath.Remove(mainRootPath.LastIndexOf("\\"));

            return Path.Combine(mainRootPath, relativePath);
        }
    }
}
