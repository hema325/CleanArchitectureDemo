using Application.Common.Interfaces.Services;
using CsvHelper;
using System.Globalization;

namespace Infrastructure.Common.Services
{
    internal class CsvFileBuilderService<TRecord> : ICsvFileBuilder<TRecord> where TRecord : class
    {
        public async Task<byte[]> BuildAsync(IEnumerable<TRecord> records)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter, CultureInfo.CurrentCulture);
                await csvWriter.WriteRecordsAsync(records);
            }

            return memoryStream.ToArray();
        }
    }
}
