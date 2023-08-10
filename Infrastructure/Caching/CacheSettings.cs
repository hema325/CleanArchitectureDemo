using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Caching
{
    internal class CacheSettings
    {
        public const string SectionName = "CacheSettings";
        public bool UseRedis { get; set; }
        public string RedisConnecting { get; set; }
    }
}
