using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Mapping
{
    internal class MappingProfile: Profile
    {
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var mapFromType = typeof(IMapFrom<>);
            var mapFromMappingMethodName = nameof(IMapFrom<object>.Mapping);


            Func<Type, bool> mappingFilter = type => type.IsGenericType && type.GetGenericTypeDefinition() == mapFromType.GetGenericTypeDefinition();

            var types = assembly.GetExportedTypes().Where(type => type.GetInterfaces().Any(i => mappingFilter(i)));

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod(mapFromMappingMethodName);

                if (methodInfo != null)
                    methodInfo.Invoke(instance, new object[] { this });
                else
                {
                    var interfaces = type.GetInterfaces().Where(i => mappingFilter(i));

                    foreach (var interfaceType in interfaces)
                    {
                        var interfaceMethodInfo = interfaceType.GetMethod(mapFromMappingMethodName);

                        interfaceMethodInfo?.Invoke(instance, new object[] { this });
                    }
                }
            }
        }
    }
}