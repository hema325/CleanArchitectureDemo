using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Items.Queries.GetItemsInCsvFile
{
    public class GetItemsInCsvFileDTO
    {
        public string FileName { get; init; }
        public string ContentType { get; init; }
        public byte[] Content { get; init; }
    }
}
