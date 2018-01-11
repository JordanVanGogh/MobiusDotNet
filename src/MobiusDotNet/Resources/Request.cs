using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace MobiusDotNet.Resources
{
    /// <summary>
    ///     Base class for requests.
    /// </summary>
    public abstract class Request
    {
        /// <summary>
        ///     Serializes this instance to a dictionary.
        /// </summary>
        /// <returns>A dictionary instance.</returns>
        public IDictionary<string, string> ToDictionary()
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var property in TypeDescriptor.GetProperties(this))
                AddPropertyToDictionary((PropertyDescriptor)property, this, dictionary);
            return dictionary;
        }

        private string ToInvariantString(object obj)
        {
            return obj is IConvertible ? ((IConvertible)obj).ToString(CultureInfo.InvariantCulture)
                : obj is IFormattable ? ((IFormattable)obj).ToString(null, CultureInfo.InvariantCulture)
                    : obj.ToString();
        }
        
        private void AddPropertyToDictionary(PropertyDescriptor property, object source, Dictionary<string, string> dictionary)
        {
            object value = property.GetValue(source);
            if (value != null)
                value = ToInvariantString(value);

            var parameterNameAttribute = property.Attributes.OfType<ParameterNameAttribute>().FirstOrDefault();
            dictionary.Add(parameterNameAttribute?.Name ?? property.Name, (string) value);
        }
    }
}