using Newtonsoft.Json;

namespace MobiusDotNet.Resources
{
    /// <summary>
    ///     Base class for responses.
    /// </summary>
    public abstract class ResponseBase
    {
        /// <inheritdoc />
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}