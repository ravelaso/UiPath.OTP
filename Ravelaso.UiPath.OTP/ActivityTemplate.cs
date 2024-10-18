using System.Activities;
using System.ComponentModel;
using OtpNet;

namespace Ravelaso.UiPath.OTP
{
    [DisplayName("Generate TOTP")]
    [Description("Generates a Time-based One-Time Password (TOTP) based on a provided secret.")]
    public class ActivityTemplate : CodeActivity<string> // This base class exposes an OutArgument named Result
    {
        [RequiredArgument]
        public InArgument<string> Secret { get; set; }

        protected override string Execute(CodeActivityContext context)
        {
            return ExecuteInternal(context);
        }

        private string ExecuteInternal(CodeActivityContext context)
        {
            var secret = Secret.Get(context);
            if (string.IsNullOrEmpty(secret))
            {
                throw new ArgumentException("Secret cannot be null or empty");
            }

            try
            {
                // Convert the secret to bytes
                var secretBytes = Base32Encoding.ToBytes(secret);

                // Create a TOTP generator
                var totp = new Totp(secretBytes);

                // Generate the TOTP code
                var code = totp.ComputeTotp();

                return code;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error generating TOTP: {ex.Message}");
            }
        }
    }
}