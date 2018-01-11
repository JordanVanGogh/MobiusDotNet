using System;
using MobiusDotNet.Resources;
using MobiusDotNet.Resources.AppStore.Webhooks;
using MobiusDotNet.Resources.Tokens.Webhooks;
using Xunit;

namespace MobiusDotNet.Tests.Resources
{
    public class WebhookTests
    {
        [Fact]
        public void BindsAppStoreDeposit()
        {
            const string json = @"
            {
                ""action_type"": ""app_store/deposit"",
                ""app_uid"": ""7e542152-4264-417d-8cc4-08cc062a96b9"",
                ""email"": ""user@gmail.com"",
                ""num_credits"": 500,
                ""total_num_credits"": 1000 
            }
            ";

            var model = Webhook.Bind(json);
            
            Assert.IsType<Deposit>(model);
            var typedModel = model as Deposit;
            Assert.Equal("app_store/deposit", model.ActionType);
            Assert.Equal(Guid.Parse("7e542152-4264-417d-8cc4-08cc062a96b9"), typedModel.AppUID);
            Assert.Equal("user@gmail.com", typedModel.Email);
            Assert.Equal(500, typedModel.NumberOfCredits);
            Assert.Equal(1000, typedModel.TotalNumberOfCredits);
        }

        [Fact]
        public void BindsTokensTransfer()
        {
            const string json = @"
            {
              ""action_type"": ""token/transfer"",
              ""token_uid"": ""7e542152-4264-417d-8cc4-08cc062a96b9"",
              ""from"": ""from address"",
              ""to"": ""to address"",
              ""num_tokens"": 500,
              ""total_num_tokens"": 1000,
              ""tx_hash"": ""hash of transaction""
            }
            ";

            var model = Webhook.Bind(json);

            Assert.IsType<Transfer>(model);
            var typedModel = model as Transfer;
            Assert.Equal("token/transfer", model.ActionType);
            Assert.Equal(Guid.Parse("7e542152-4264-417d-8cc4-08cc062a96b9"), typedModel.TokenUID);
            Assert.Equal("from address", typedModel.FromAddress);
            Assert.Equal("to address", typedModel.ToAddress);
            Assert.Equal(500, typedModel.NumberOfTokens);
            Assert.Equal(1000, typedModel.TotalNumberOfTokens);
            Assert.Equal("hash of transaction", typedModel.TransactionHash);
        }
    }
}
