using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class Result
    {
        public bool Succeeded { get; init; }
        public string[] Errors { get; init; }
        
        public static Result Success => new Result { Succeeded = true, Errors = Array.Empty<string>() };
        public static Result Failure => new Result { Succeeded = false, Errors = Array.Empty<string>() };
    }
}
