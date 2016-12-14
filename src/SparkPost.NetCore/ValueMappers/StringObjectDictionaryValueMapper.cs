using System;
using System.Collections.Generic;
using System.Linq;
using SparkPost.Utilities;

namespace SparkPost.ValueMappers
{
    public class StringObjectDictionaryValueMapper : IValueMapper
    {
        private readonly IDataMapper dataMapper;

        public StringObjectDictionaryValueMapper(IDataMapper dataMapper)
        {
            this.dataMapper = dataMapper;
        }

        public bool CanMap(Type propertyType, object value)
        {
            return value is IDictionary<string, object>;
        }

        public object Map(Type propertyType, object value)
        {
            var original = (IDictionary<string, object>) value;
            var dictionary = new Dictionary<string, object>();
            foreach (var item in original.Where(i => i.Value != null))
            {
                var itemKey = SnakeCase.Convert(item.Key);
                var itemValue = item.Value;
                dictionary[itemKey] = dataMapper.GetTheValue(itemValue.GetType(), itemValue);
            }
            return dictionary.Count > 0 ? dictionary : null;
        }
    }
}