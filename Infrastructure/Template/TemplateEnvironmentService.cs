using Application.Common.Interfaces.Templates;
using Infrastructure.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Constants
{
    public class TemplateEnvironmentService: ITemplateEnvironment
    {
        public  string EmailConfirmedTemplate => TemplateConstants.EmailConfirmedTemplate;
        public string EmailConfirmationTemplate => TemplateConstants.EmailConfirmationTemplate;
    }
}
