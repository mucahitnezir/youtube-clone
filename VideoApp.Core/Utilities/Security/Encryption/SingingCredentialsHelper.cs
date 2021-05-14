using Microsoft.IdentityModel.Tokens;

namespace VideoApp.Core.Utilities.Security.Encryption
{
    public static class SingingCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredential(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}