using System;
#if NETSTANDARD1_6
using System.Reflection;
#endif

namespace SparkPost.ValueMappers
{
    public class EnumValueMapper : IValueMapper
    {
        public bool CanMap(Type propertyType, object value)
        {
#if NETSTANDARD1_6
            return propertyType.GetTypeInfo().IsEnum;
#else
            return propertyType.IsEnum;
#endif
        }

        public object Map(Type propertyType, object value)
        {
            return value.ToString().ToLowerInvariant();
        }
    }
}