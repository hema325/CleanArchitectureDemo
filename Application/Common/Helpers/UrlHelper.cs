using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Application.Common.Helpers
{
    public static class UrlHelper
    {
        public static string AddLinkToQuery(string link, object values) 
        {
            return link + GenerateQuery(values); 
        }

        private static string GenerateQuery(object values)
        {
            var queryProps = values.GetType().GetProperties();
            return "?" + string.Join("&", queryProps.Select(p => $"{p.Name}={HttpUtility.UrlEncode(p.GetValue(values)?.ToString())}"));
        }
    }
}
