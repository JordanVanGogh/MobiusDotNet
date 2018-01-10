using System;

namespace MobiusDotNet.Resources
{
    /// <summary>
    ///     When decorating a property in a parameters class,
    ///     the alternate name provided by this attribute will
    ///     be used in outgoing HTTP messages.
    /// </summary>
    public class ParameterNameAttribute : Attribute
    {
        /// <summary>
        ///     Alternate name of the parameter.
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///     Instantiates a new instance of this class.
        /// </summary>
        /// <param name="name">Alternate name of the parameter</param>
        public ParameterNameAttribute(String name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
