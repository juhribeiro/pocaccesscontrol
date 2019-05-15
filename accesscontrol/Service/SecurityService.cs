using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using accesscontrol.Model;
using accesscontrol.Repository;
using accesscontrol.Util;
using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace accesscontrol.Service
{
    public class SecurityService : ISecurityService
    {
        private readonly IMapper mapper;
        private readonly IUserGroupRepository repository;
        private readonly IOptions<AuthConfig> config;

        public SecurityService(IMapper mapper, IUserGroupRepository repository, IOptions<AuthConfig> config)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.config = config;
        }

        public async Task<SecurityModel> LoginAsync(LoginModel model)
        {
            var usergroups = await this.repository.GetUserGroupByEmailAsync(model.Email);
            if (usergroups.User.Password != model.Password)
            {

            }

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, model.Email),
                new Claim(JwtRegisteredClaimNames.Jti, System.Guid.NewGuid().ToString()),
            };

            claims.AddRange(usergroups.Group.RoleGroups.Select(x => x.Role).Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role.Name)));

            var creds = new SigningCredentials(this.config.Value.SymmetricSigningKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(this.config.Value.Issuer,
                this.config.Value.Audience,
                claims,
                expires: System.DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            var tokenEncoded = new JwtSecurityTokenHandler().WriteToken(token);
            var security = new SecurityModel()
            {
                Token = tokenEncoded,
                ExpirateIn = System.DateTime.Now.AddMinutes(30)
            };

            return security;
        }
    }
}