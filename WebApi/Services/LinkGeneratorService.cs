using Application.Common.Interfaces;

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
    }
}
