using System;
using System.Collections.Generic;

namespace SparkPost.ValueMappers
{
    public class StringStringDictionaryValueMapper : IValueMapper
    {
        public bool CanMap(Type propertyType, object value)
        {
            return value is IDictionary<string, string>;
        }

        public object Map(Type propertyType, object value)
        {
            var dictionary = (IDictionary<string, string>) value;
            return dictionary.Count > 0 ? dictionary : null;
        }
    }
}