using Application.Common.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var mapFromType = typeof(IMapFrom<>);
            var mapFromMappingMethodName = nameof(IMapFrom<object>.Mapping);

            var mapToType = typeof(IMapTo<>);
            var mapToMappingMethodName = nameof(IMapTo<object>.Mapping);

            ApplyMappingsFromAssembly(mapFromType, mapFromMappingMethodName, assembly);
            ApplyMappingsFromAssembly(mapToType, mapToMappingMethodName, assembly);
        }

        private void ApplyMappingsFromAssembly(Type mappingType, string mappingMethodName, Assembly assembly)
        {
            Func<Type, bool> mappingFilter = type => type.IsGenericType && type.GetGenericTypeDefinition() == mappingType.GetGenericTypeDefinition();

            var types = assembly.GetExportedTypes().Where(type => type.GetInterfaces().Any(i => mappingFilter(i)));

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod(mappingMethodName);

                if (methodInfo != null)
                    methodInfo.Invoke(instance, new object[] { this });
                else
                {
                    var interfaces = type.GetInterfaces().Where(i => mappingFilter(i));

                    foreach (var interfaceType in interfaces)
                    {
                        var interfaceMethodInfo = interfaceType.GetMethod(mappingMethodName);

                        interfaceMethodInfo?.Invoke(instance, new object[] { this });
                    }
                }
            }
        }
    }
}