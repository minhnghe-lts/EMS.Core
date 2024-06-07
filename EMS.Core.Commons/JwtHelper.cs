using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static EMS.Core.Commons.CommonEnums;

namespace EMS.Core.Commons
{
    public class JwtHelper
    {
        public static string GenerateToken(string email, List<FeatureCode> roles, string authSecret)
        {
            try
            {
                if (!roles.Contains(FeatureCode.Common))
                {
                    roles.Add(FeatureCode.Common);
                }
                List<Claim> claims = new List<Claim>() { new Claim(ClaimTypes.Email, email), new Claim(ClaimTypes.Role, string.Join(",", roles)) };

                SymmetricSecurityKey secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSecret));

                SigningCredentials credential = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);

                JwtSecurityToken token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(CommonConstants.DefaultValue.DEFAULT_TOKEN_EXPIRED_TIME_IN_MINUTE),
                    signingCredentials: credential);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
