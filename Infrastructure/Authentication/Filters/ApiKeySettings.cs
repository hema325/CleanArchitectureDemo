using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Authentication.Filters
{
    internal class ApiKeySettings
    {
        public const string SectionName = "ApiKey";
        public string Key { get; set; }
    }
}
