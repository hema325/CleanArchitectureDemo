using Domain.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public sealed class Permission:EntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<RolePermissions> RolePermissions { get; set; }
    }
}
