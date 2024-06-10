using EMS.Core.Commons;
using EMS.Core.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static EMS.Core.Commons.CommonEnums;

namespace EMS.Core.Business
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly AppSettings _settings;

        public AuthService(AppDbContext context, IOptions<AppSettings> settings)
        {
            _context = context;
            _settings = settings.Value;
        }

        public string Login(string username, string password)
        {
            var user = _context.Accounts
                .Where(record => record.IsActive
                    && !record.IsDeleted
                    && record.Username == username)
                .FirstOrDefault();
            if (user == null)
            {
                throw new ItemNotFoundException();
            }
            return GenerateToken(username, user.TenantId, new List<FeatureCode> { FeatureCode.Common, FeatureCode.SuperAdmin });
        }

        public bool CheckRefreshTokenIsValid(Guid refreshToken)
        {
            try
            {
                var tokenInfo = _context.RefreshTokens
                    .Where(record => record.Token == refreshToken)
                    .FirstOrDefault();
                if (tokenInfo == null)
                {
                    throw new ItemNotFoundException();
                }
                if (tokenInfo.ExpireDate >= DateTime.Now)
                {
                    return false;
                }
                tokenInfo.ExpireDate = tokenInfo.ExpireDate.AddHours(CommonConstants.DefaultValue.DEFAULT_REFRESH_TOKEN_EXPIRED_TIME_IN_HOUR);
                _context.RefreshTokens.Update(tokenInfo);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GenerateToken(string email, long tenantId, List<FeatureCode> roles)
        {
            try
            {
                List<Claim> claims = new List<Claim>() {
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.Role, string.Join(",", roles)) ,
                    new Claim(ClaimTypes.System, tenantId.ToString())
                };

                SymmetricSecurityKey secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Jwt.SecretKey));

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

        public string GenerateToken()
        {
            return GenerateToken("asd", 1, new List<FeatureCode> { FeatureCode.Common, FeatureCode.SuperAdmin });
        }
    }
}
