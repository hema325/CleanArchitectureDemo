using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Services
{
    public interface ILinkGenerator
    {
        string GetUriByAction(string action, string controller, object values);
        string? GetUriByName(string routeName, object values);
    }
}
