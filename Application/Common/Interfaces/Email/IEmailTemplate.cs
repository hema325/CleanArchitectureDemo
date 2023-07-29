using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Email.Interfaces
{
    public interface IEmailTemplate
    {
        Task<string> GetTemplateByName<T>(string name, T model);
    }
}
