using accesscontrol.Data;
using accesscontrol.Model;
using accesscontrol.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace accesscontrol.Service
{
    public class AuthService : IAuthService
    {
        private readonly IOptions<AuthConfig> config;
        private readonly IHttpContextAccessor httpContextAccessor;

        public AuthService(IOptions<AuthConfig> config, IHttpContextAccessor httpContextAccessor)
        {
            this.config = config;
            this.httpContextAccessor = httpContextAccessor;
        }

        public SecurityModel GenerateToken(User entity, DateTime expirate)
        {
            var email = entity.Email;
            var permissions = entity.UserGroups.Select(x => x.Group).SelectMany(x => x.RoleGroups).Select(x => x.Role).Select(x => x.Code).ToList();

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, entity.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti, System.Guid.NewGuid().ToString()),
            };

            claims.AddRange(permissions.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));

            var creds = new SigningCredentials(this.config.Value.SymmetricSigningKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: this.config.Value.Issuer,
              audience: this.config.Value.Audience,
                claims: claims,
                expires: expirate,
                signingCredentials: creds);

            var tokenEncoded = new JwtSecurityTokenHandler().WriteToken(token);
            var security = new SecurityModel()
            {
                Token = tokenEncoded,
                ExpirateIn = expirate,
                Email = email,
                Permissions = permissions
            };

            return security;
        }

        public string GetEmail()
        {
            return this.ReadJwt(JwtRegisteredClaimNames.Email);
        }

        public int GetUserId()
        {
            var userId = this.ReadJwt(JwtRegisteredClaimNames.Sub);
            return string.IsNullOrEmpty(userId) ? 0 : int.Parse(userId);
        }

        private string ReadJwt(string read)
        {
            var token = this.ValidToken();
            if (token is null)
            {
                return null;
            }

            var header = new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;
            return header.Payload[read].ToString();
        }

        private string ValidToken()
        {
            if (this.httpContextAccessor.HttpContext is null)
            {
                return null;
            }

            var bearer = this.httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(bearer))
            {
                return null;
            }

            TokenValidationParameters validationParameters = new TokenValidationParameters()
            {
                IssuerSigningKey = this.config.Value.SymmetricSigningKey,
                ValidAudience = this.config.Value.Audience,
                ValidIssuer = this.config.Value.Issuer,
                ValidateLifetime = true,
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true
            };

            string securityToken = bearer.ToString().Replace("Bearer ", string.Empty);

            JwtSecurityTokenHandler securityTokenHandler = new JwtSecurityTokenHandler();
            SecurityToken validatedToken;

            securityTokenHandler.ValidateToken(securityToken, validationParameters, out validatedToken);
            return securityToken;
        }
    }
}