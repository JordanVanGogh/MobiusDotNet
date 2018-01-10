using System;

namespace MobiusDotNet
{
    /// <summary>
    ///     Represents errors that occur during client operations.
    /// </summary>
    public class MobiusException : Exception
    {
        /// <summary>
        ///     Gets the HTTP status code.
        /// </summary>
        public int HttpStatusCode { get; }

        /// <summary>
        ///     Gets the HTTP reason.
        /// </summary>
        public string HttpReason { get; }

        /// <summary>
        ///     Gets the message.
        /// </summary>
        public string Message { get; }

        /// <summary>
        ///     Gets the friendly description.
        /// </summary>
        public string Description
        {
            get
            {
                switch (HttpStatusCode)
                {
                    case 400: return @"Parameters are incorrect.";
                    case 401: return @"Your API key is wrong.";
                    case 403: return @"You do not have access.";
                    case 404: return @"Bad URL and/or HTTP Method.";
                    case 429: return @"Slow down!";
                    case 500: return @"We had a problem with our server. Try again and if it keeps happening email support@mobius.network";
                    case 503: return @"We're temporarily offline for maintenance. Please try again later.";
                    default: return @"Unknown error";
                }
            }
        }
        
        /// <summary>
        ///     Initializes a new instance of this class.
        /// </summary>
        /// <param name="httpStatusCode">The HTTP status code.</param>
        /// <param name="httpReason">The HTTP reason.</param>
        /// <param name="message">The message.</param>
        public MobiusException(int httpStatusCode, String httpReason, String message)
        {
            HttpStatusCode = httpStatusCode;
            HttpReason = httpReason;
            Message = message;
        }
    }
}
