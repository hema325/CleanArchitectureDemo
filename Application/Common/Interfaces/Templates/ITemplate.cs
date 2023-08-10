using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Templates
{
    public interface ITemplate
    {
        Task<string> GetTemplateByNameAsync<T>(string name, T model);
    }
}
