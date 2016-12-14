using System;

namespace SparkPost.ValueMappers
{
    public class DateTimeValueMapper : IValueMapper
    {
        public bool CanMap(Type propertyType, object value)
        {
            return value is DateTime;
        }

        public object Map(Type propertyType, object value)
        {
            return ((DateTime) value).ToString("yyyy-MM-ddTHH:mm");
        }
    }
}