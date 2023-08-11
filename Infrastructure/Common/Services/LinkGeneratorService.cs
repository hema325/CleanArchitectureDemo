using Application.Common.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace WebApi.Services
{
    public class LinkGeneratorService : ILinkGenerator
    {
        private readonly HttpContext _httpContext;
        private readonly LinkGenerator _linkGenerator;

        public LinkGeneratorService(LinkGenerator linkGenerator, IHttpContextAccessor contextAccessor)
        {
            _linkGenerator = linkGenerator;
            _httpContext = contextAccessor.HttpContext;
        }

        public string? GetUriByAction(string action, string controller, object values)
        {
            return _linkGenerator.GetUriByAction(_httpContext, action, controller, values);
        }

        public string? GetUriByName(string routeName,object values)
        {
            return _linkGenerator.GetUriByName(_httpContext, routeName, values);
        }
    }
}
