using System;

namespace MobiusDotNet.Resources
{
    /// <summary>
    ///     When decorating a property in a request class,
    ///     the alternate name provided by this attribute will
    ///     be used in outgoing HTTP messages.
    /// </summary>
    public class ParameterNameAttribute : Attribute
    {
        /// <summary>
        ///     Alternate name of the request parameter.
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///     Instantiates a new instance of this class.
        /// </summary>
        /// <param name="name">Alternate name of the request parameter</param>
        public ParameterNameAttribute(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
