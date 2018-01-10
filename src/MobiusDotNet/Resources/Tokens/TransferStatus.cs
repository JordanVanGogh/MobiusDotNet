using System.Runtime.Serialization;

namespace MobiusDotNet.Resources.Tokens
{
    /// <summary>
    ///     Represents the transfer status.
    /// </summary>
    public enum TransferStatus
    {
        [EnumMember(Value = "error")]
        Error,
        [EnumMember(Value = "pending")]
        Pending,
        [EnumMember(Value = "sent")]
        Sent,
        [EnumMember(Value = "complete")]
        Complete
    }
}