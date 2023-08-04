using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class FileDTO
    {
        public string PhysicalPath { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
    }
}
