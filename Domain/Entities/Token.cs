using Domain.Common.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Token : EntityBase
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public TokenTypes Type { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? RevokedOn { get; set; }
        public DateTime ExpiresOn { get; set; }
        public string UserId { get; set; }
    }
}
