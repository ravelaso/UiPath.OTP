using OtpNet;

namespace Ravelaso.UiPath.OTP;

public static class OtpHelper
{
    public static string GenerateTotp(string secret)
    {
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