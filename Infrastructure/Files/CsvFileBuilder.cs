using Application.Common.Interfaces;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Files
{
    public class CsvFileBuilder<TRecord>:ICsvFileBuilder<TRecord> where TRecord : class
    {
        public async Task<byte[]> BuildAsync(IEnumerable<TRecord> records)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter, CultureInfo.CurrentCulture);
                csvWriter.Context.RegisterClassMap<TRecordMap<TRecord>>();
                await csvWriter.WriteRecordsAsync(records);
            }

            return memoryStream.ToArray();
        }
    }
}
