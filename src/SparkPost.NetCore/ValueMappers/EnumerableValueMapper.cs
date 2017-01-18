using System;
using System.Collections;
using System.Linq;

namespace SparkPost.ValueMappers
{
    public class EnumerableValueMapper : IValueMapper
    {
        private readonly IDataMapper mapper;

        public EnumerableValueMapper(IDataMapper mapper)
        {
            this.mapper = mapper;
        }

        public bool CanMap(Type propertyType, object value)
        {
            return value != null && value.GetType() != typeof (string) && value is IEnumerable;
        }

        public object Map(Type propertyType, object value)
        {
            var things = (from object thing in (IEnumerable) value
                select mapper.GetTheValue(thing.GetType(), thing)).ToList();
            return things.Count > 0 ? things : null;
        }
    }
}