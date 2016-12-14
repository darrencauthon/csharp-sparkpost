using System;

namespace SparkPost.ValueMappers
{
    public class BooleanValueMapper : IValueMapper
    {
        public bool CanMap(Type propertyType, object value)
        {
            return value is bool?;
        }

        public object Map(Type propertyType, object value)
        {
            return value as bool? == true;
        }
    }
}