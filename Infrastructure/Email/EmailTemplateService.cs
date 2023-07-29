using Application.Common.Email.Interfaces;
using Application.Common.Helpers;
using RazorEngineCore;


namespace Infrastructure.Email
{
    internal class EmailTemplateService : IEmailTemplate
    {
        public async Task<string> GetTemplateByName<T>(string templateName, T model)
        {
            var template = GetTemplate(templateName);

            var razorEngine = new RazorEngine();
            var compiledTemplate = await razorEngine.CompileAsync(template); //generates a type that can be reused to render the same template with different data models

            return await compiledTemplate.RunAsync(model); //generates the output text for a specific data model instance
        }

        private string GetTemplate(string templateName)
        {
            var templateRelativePath = $"Infrastructure\\Email\\Templates\\{templateName}.cshtml";
            var templateAbsolutePath = PathHelper.GetAbsolutePath(templateRelativePath);

            return File.ReadAllText(templateAbsolutePath);
        }
    }
}
