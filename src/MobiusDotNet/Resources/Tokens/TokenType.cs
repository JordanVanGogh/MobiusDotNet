using System.Runtime.Serialization;

namespace MobiusDotNet.Resources.Tokens
{
    /// <summary>
    ///     Represents a token type.
    /// </summary>
    public enum TokenType
    {
        [EnumMember(Value = "erc20")]
        Erc20,
        [EnumMember(Value = "stellar")]
        Stellar
    }
}
