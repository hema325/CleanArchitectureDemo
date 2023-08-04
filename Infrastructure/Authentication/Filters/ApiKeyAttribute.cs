using Infrastructure.Authentication.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infrastructure.Authentication.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAttribute : Attribute, IAuthorizationFilter //filter specific things on the othehand IAuthorizationHandler its being applied with any authorization attribute
    {

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!IsApiKeyValid(context.HttpContext))
                context.Result = new UnauthorizedResult();
        }

        private bool IsApiKeyValid(HttpContext httpContext)
        {
            var apiKeySettings = httpContext.RequestServices.GetRequiredService<IOptions<ApiKeySettings>>().Value;
            var givenApiKey = httpContext.Request.Headers[SecurityHeaders.ApiKeyHeaderName];

            if (apiKeySettings.Key == givenApiKey)
                return true;

            return false;
        }
    }
}
