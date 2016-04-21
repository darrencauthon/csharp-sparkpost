using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace SparkPost
{
    public interface IDataMapper
    {
        IDictionary<string, object> ToDictionary(Transmission transmission);
        IDictionary<string, object> ToDictionary(Recipient recipient);
        IDictionary<string, object> ToDictionary(Address address);
        IDictionary<string, object> ToDictionary(Options options);
        IDictionary<string, object> ToDictionary(Content content);
        IDictionary<string, object> ToDictionary(Attachment attachment);
        IDictionary<string, object> ToDictionary(InlineImage inlineImage);
        IDictionary<string, object> ToDictionary(File file);
        IDictionary<string, object> ToDictionary(Suppression suppression);
        IDictionary<string, object> ToDictionary(Template template);
        IDictionary<string, object> ToDictionary(TemplateContent templateContent);
        IDictionary<string, object> ToDictionary(TemplateOptions templateOptions);
    }

    public class DataMapper : IDataMapper
    {
        private readonly Dictionary<Type, MethodInfo> converters;

        public DataMapper(string version = "v1")
        {
            converters = GetTheConverters();
        }

        public virtual IDictionary<string, object> ToDictionary(Transmission transmission)
        {
            var result = WithCommonConventions(transmission, new Dictionary<string, object>
            {
                ["recipients"] = transmission.ListId != null
                    ? (object) new Dictionary<string, object> {["list_id"] = transmission.ListId}
                    : transmission.Recipients.Select(ToDictionary)
            });

            CcHandling.SetAnyCCsInTheHeader(transmission, result);

            return result;
        }

        public virtual IDictionary<string, object> ToDictionary(Recipient recipient)
        {
            return WithCommonConventions(recipient, new Dictionary<string, object>()
            {
                ["type"] = null,
            });
        }

        public virtual IDictionary<string, object> ToDictionary(Suppression suppression)
        {
            return WithCommonConventions(suppression);
        }

        public virtual IDictionary<string, object> ToDictionary(Address address)
        {
            return WithCommonConventions(address);
        }

        public virtual IDictionary<string, object> ToDictionary(Options options)
        {
            return AnyValuesWereSetOn(options) ? WithCommonConventions(options) : null;
        }

        public virtual IDictionary<string, object> ToDictionary(Content content)
        {
            return WithCommonConventions(content);
        }

        public virtual IDictionary<string, object> ToDictionary(Attachment attachment)
        {
            return ToDictionary(attachment as File);
        }

        public virtual IDictionary<string, object> ToDictionary(InlineImage inlineImage)
        {
            return ToDictionary(inlineImage as File);
        }

        public virtual IDictionary<string, object> ToDictionary(File file)
        {
            return WithCommonConventions(file);
        }

        public virtual IDictionary<string, object> ToDictionary(Template template)
        {
            return WithCommonConventions(template);
        }

        public virtual IDictionary<string, object> ToDictionary(TemplateContent templateContent)
        {
            return WithCommonConventions(templateContent);
        }

        public virtual IDictionary<string, object> ToDictionary(TemplateOptions templateOptions)
        {
            return WithCommonConventions(templateOptions);
        }

        private static bool AnyValuesWereSetOn(object target)
        {
            return target.GetType()
                .GetProperties()
                .Any(x => x.GetValue(target) != null);
        }

        private static IDictionary<string, object> RemoveNulls(IDictionary<string, object> dictionary)
        {
            var newDictionary = new Dictionary<string, object>();
            foreach (var key in dictionary.Keys.Where(k => dictionary[k] != null))
                newDictionary[key] = dictionary[key];
            return newDictionary;
        }

        private IDictionary<string, object> WithCommonConventions(object target, IDictionary<string, object> results = null)
        {

            if (results == null) results = new Dictionary<string, object>();
            foreach (var property in target.GetType().GetProperties())
            {
                var name = ToSnakeCase(property.Name);
                if (results.ContainsKey(name)) continue;

                results[name] = GetTheValue(property.PropertyType, property.GetValue(target));
            }
            return RemoveNulls(results);
        }

        private object GetTheValue(Type propertyType, object value)
        {
            if (propertyType != typeof(int) && converters.ContainsKey(propertyType))
                value = converters[propertyType].Invoke(this, BindingFlags.Default, null,
                    new[] {value}, CultureInfo.CurrentCulture);
            else if (value != null && propertyType.Name.EndsWith("List`1") &&
                     propertyType.GetGenericArguments().Count() == 1 &&
                     converters.ContainsKey(propertyType.GetGenericArguments().First()))
            {
                var converter = converters[propertyType.GetGenericArguments().First()];

                var list = (value as IEnumerable<object>).ToList();

                if (list.Any())
                    value = list.Select(x => converter.Invoke(this, BindingFlags.Default, null,
                        new[] {x}, CultureInfo.CurrentCulture)).ToList();
                else
                    value = null;
            }
            else if (value is bool?)
                value = value as bool? == true;
            else if (value is DateTimeOffset?)
                value = string.Format("{0:s}{0:zzz}", (DateTimeOffset?)value);
            else if (value is IDictionary<string, object>)
            {
                var dictionary = (IDictionary<string, object>) value;
                value = dictionary.Count > 0 ? dictionary : null;
            }
            else if (value is IDictionary<string, string>)
            {
                var dictionary = (IDictionary<string, string>) value;
                value = dictionary.Count > 0 ? dictionary : null;
            }
            else if (value != null && value.GetType() != typeof(string) && value is IEnumerable)
            {
                var things = (from object thing in (IEnumerable) value
                    select GetTheValue(thing.GetType(), thing)).ToList();
                value = things.Count > 0 ? things : null;
            }
            return value;
        }

        public static string ToSnakeCase(string input)
        {
            var regex = new Regex("[A-Z]");

            var matches = regex.Matches(input);

            for (var i = 0; i < matches.Count; i++)
                input = input.Replace(matches[i].Value, "_" + matches[i].Value.ToLower());

            if (input.StartsWith("_"))
                input = input.Substring(1, input.Length - 1);

            return input;
        }

        private static Dictionary<Type, MethodInfo> GetTheConverters()
        {
            return typeof (DataMapper).GetMethods()
                .Where(x => x.Name == "ToDictionary")
                .Where(x => x.GetParameters().Length == 1)
                .Select(x => new
                {
                    TheType = x.GetParameters().First().ParameterType,
                    TheMethod = x
                }).ToList()
                .ToDictionary(x => x.TheType, x => x.TheMethod);
        }
    }
}