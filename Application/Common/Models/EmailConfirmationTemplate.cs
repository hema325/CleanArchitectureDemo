using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class EmailConfirmationTemplate
    {
        public const string TemplateName = "EmailConfirmationTemplate";
        public string Url { get; set; }
    }
}
