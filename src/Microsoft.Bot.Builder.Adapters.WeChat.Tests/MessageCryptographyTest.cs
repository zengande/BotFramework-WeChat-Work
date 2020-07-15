// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Bot.Builder.Adapters.WeChat.Work;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Bot.Builder.Adapters.WeChat.Work.Tests
{
    public class MessageCryptographyTest
    {
        [Fact]
        public void DecryptMsgTest()
        {
            var postData = MockDataUtility.XmlEncrypt;
            var result = MockDataUtility.TestDecryptMsg.DecryptMessage(postData);

            // Need to remove "/r" created by editor
            var decryptString = MockDataUtility.XmlDecrypt.Replace("\r", string.Empty);
            Assert.Equal(decryptString, result);
        }

        [Fact]
        public async Task EncodingAESKeyTest()
        {
            var result = await Assert.ThrowsAsync<ArgumentException>(() => Task.FromResult(new MessageCryptography(MockDataUtility.SecretInfoAesKeyError, MockDataUtility.WeChatSettingsAesKeyError)));
            Assert.Equal("Invalid EncodingAESKey.\r\nParameter name: secretInfo", result.Message);
        }

        [Fact]
        public async Task VerifySignatureTest()
        {
            var postData = MockDataUtility.XmlEncrypt;
            var result = await Assert.ThrowsAsync<UnauthorizedAccessException>(() => Task.FromResult(MockDataUtility.TestSignature.DecryptMessage(postData)));
            Assert.Equal("Signature verification failed.", result.Message);
        }
    }
}
