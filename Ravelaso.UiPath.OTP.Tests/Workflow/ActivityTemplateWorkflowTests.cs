using System;
using System.Activities;
using System.Collections.Generic;
using OtpNet;
using Xunit;

namespace Ravelaso.UiPath.OTP.Tests.Workflow
{
    public class ActivityTemplateWorkflowTests
    {
        [Fact]
        public void GenerateTotp_ShouldReturnExpectedCode()
        {
            // Arrange
            var activity = new ActivityTemplate();
            var secret = GenerateRandomBase32Secret();
            const int expectedTotpLength = 6; // Typical length of TOTP
            
            // Act
            var result = WorkflowInvoker.Invoke(activity, new Dictionary<string, object>
            {
                { "Secret", secret }
            });
            
            // Assert
            Assert.NotNull(result);
            var totpCode = result as string;
            Assert.NotNull(totpCode);
            Assert.Equal(expectedTotpLength, totpCode.Length);

            // Output the generated TOTP for manual verification
            Console.WriteLine($"Generated TOTP: {totpCode}");
        }

        private string GenerateRandomBase32Secret(int length = 16)
        {
            var secret = KeyGeneration.GenerateRandomKey(32); // 32 bytes = 256 bits
            return Base32Encoding.ToString(secret);
        }
    }
}