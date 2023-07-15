using Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class LinkGenerator: ILinkGenerator
    {
        private readonly HttpContext _httpContext;

        public LinkGenerator(IHttpContextAccessor accessor)
        {
            _httpContext = accessor.HttpContext;
        }

        public string Generate(string path, object queryString)
        {
            var scheme = _httpContext.Request.Scheme;
            var host = _httpContext.Request.Host;
            var pathBase = _httpContext.Request.Path;
            var query = ExtractQueryString(queryString);
           
            return $"{scheme}://{host}{path}{query}";
        }

        private string? ExtractQueryString(object queryString)
        {
            var queryStringProps = queryString.GetType().GetProperties();
            
            var query = "?" + string.Join("&", queryStringProps.Select(prop=> $"{prop.Name}={prop.GetValue(queryString)}"));
            return query;
        }

    }
}
