using System;

namespace SparkPost.ValueMappers
{
    public class DateTimeOffsetValueMapper : IValueMapper
    {
        public bool CanMap(Type propertyType, object value)
        {
            return value is DateTimeOffset?;
        }

        public object Map(Type propertyType, object value)
        {
            return string.Format("{0:s}{0:zzz}", (DateTimeOffset?) value);
        }
    }
}