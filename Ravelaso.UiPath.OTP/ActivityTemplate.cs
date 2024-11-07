using System.Activities;
using System.ComponentModel;

namespace Ravelaso.UiPath.OTP
{
    [DisplayName("Generate TOTP")]
    [Description("Generates a Time-based One-Time Password (TOTP) based on a provided secret.")]
    public class GenerateTotp : CodeActivity // This base class exposes an OutArgument named Result
    {
        [RequiredArgument]
        [Category("Input")]
        [Description("The totp token")]
        public InArgument<string> Token { get; set; }
        
        [RequiredArgument]
        [Category("Output")]
        [Description("The TOTP generated code")]
        public OutArgument<string> Output { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            Output.Set(context, OtpHelper.GenerateTotp(context.GetValue(Token)));
        }
    }
}