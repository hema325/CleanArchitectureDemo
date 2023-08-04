using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Interfaces
{
    public interface IAuditableEntity
    {
        DateTime? CreatedOn { get; set; }
        string? CreatedBy { get; set; }
        DateTime? ModifiedOn { get; set; }
        string? ModifiedBy { get; set; }
    }
}
