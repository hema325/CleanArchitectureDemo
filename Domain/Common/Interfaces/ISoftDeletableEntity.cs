using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Interfaces
{
    public interface ISoftDeletableEntity
    {
        DateTime? DeletedOn { get; set; }
        string? DeletedBy { get; set; }
    }
}
