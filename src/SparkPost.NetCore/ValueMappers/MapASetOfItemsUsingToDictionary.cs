using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using SparkPost.Utilities;

namespace SparkPost.ValueMappers
{
    public class MapASetOfItemsUsingToDictionary : IValueMapper
    {
        private readonly IDictionary<Type, MethodInfo> converters;
        private readonly IDataMapper dataMapper;

        public MapASetOfItemsUsingToDictionary(IDataMapper dataMapper)
        {
            this.dataMapper = dataMapper;
            converters = dataMapper.ToDictionaryMethods();
        }

        public bool CanMap(Type propertyType, object value)
        {
            return value != null && propertyType.Name.EndsWith("List`1") &&
                   propertyType.GetGenericArguments().Count() == 1 &&
                   converters.ContainsKey(propertyType.GetGenericArguments().First());
        }

        public object Map(Type propertyType, object value)
        {
            var converter = converters[propertyType.GetGenericArguments().First()];

            var list = (value as IEnumerable<object>).ToList();

            if (list.Any())
#if FRAMEWORK
                value = list.Select(x => converter.Invoke(dataMapper, BindingFlags.Default, null,
                    new[] {x}, CultureInfo.CurrentCulture)).ToList();
#else
                value = list.Select(x => converter.Invoke(dataMapper, new[] { x })).ToList();
#endif
            else
                value = null;

            return value;
        }
    }
}