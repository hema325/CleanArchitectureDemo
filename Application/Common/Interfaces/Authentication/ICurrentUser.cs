﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Identity
{
    public interface ICurrentUser
    {
        string? Id { get; }
        string? UserName { get; }
        bool IsAuthenticated { get; }
    }
}
