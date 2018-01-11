using MobiusDotNet.Resources.AppStore.Webhooks;
using MobiusDotNet.Resources.Tokens.Webhooks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MobiusDotNet.Resources
{
    /// <summary>
    ///     Base class for webhook models.
    /// </summary>
    public abstract class Webhook
    {
        /// <summary>
        ///     Gets or set the action type of this webhook.
        /// </summary>
        [JsonProperty("action_type")]
        public string ActionType { get; set; }
        
        /// <inheritdoc />
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
        
        /// <summary>
        ///    Binds the provided json to a Webhook sub class instance.
        /// </summary>
        /// <param name="json">Json.</param>
        /// <returns>A Webhook sub class instance, or null if binding was unsuccessful.</returns>
        public static Webhook Bind(string json)
        {
            try
            {
                var jObject = JObject.Parse(json);
                var actionType = jObject?.GetValue("action_type");
                if (actionType == null)
                    return null;

                var actionTypeValue = actionType.Value<string>();
                if (Deposit.IsOfActionType(actionTypeValue))
                    return jObject.ToObject<Deposit>();
                if (Transfer.IsOfActionType(actionTypeValue))
                    return jObject.ToObject<Transfer>();
            }
            catch
            {
                /* pass */
            }
            return null;
        }
    }
}
