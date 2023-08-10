using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Cors
{
    internal class CorsSettings
    {
        public const string SectionName = "Cors";
        public string[] Origins { get; init; }
        public string[] Methods { get; init; }
        public string[] Headers { get; set; }
    }
}
