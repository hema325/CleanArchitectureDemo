using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IMapTo<T>
    {
        public void Mapping(Profile profile) => profile.CreateMap(GetType(), typeof(T));
    }
}
