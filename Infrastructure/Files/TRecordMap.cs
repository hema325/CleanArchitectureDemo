using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Files
{
    public class TRecordMap<TDestination>: ClassMap<TDestination>
    {
        public TRecordMap()
        {
            AutoMap(CultureInfo.CurrentCulture);
        }
    }
}
