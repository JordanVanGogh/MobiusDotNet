
namespace MobiusDotNet.Resources.Tokens.Parameters
{
    /// <summary>
    ///     The parameters that must be provided for a register token request.  
    /// </summary>
    public class RegisterTokenParameters : ParametersBase
    {
        /// <summary>
        ///     Gets or sets the token type.
        /// </summary>
        [ParameterName("token_type")]
        public TokenType TokenType { get; set; }
        
        /// <summary>
        ///     Gets or sets the name of the token.
        /// </summary>
        [ParameterName("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the symbol of the token.
        /// </summary>
        [ParameterName("symbol")]
        public string Symbol { get; set; }

        /// <summary>
        ///     Gets or sets the issuer of the token.
        /// </summary>
        [ParameterName("issuer")]
        public string Issuer { get; set; }
    }
}
