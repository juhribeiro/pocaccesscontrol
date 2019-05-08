using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using accesscontrol.Model;
using accesscontrol.Repository;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;

namespace accesscontrol.Service
{
    public class SecurityService : ISecurityService
    {
        private readonly IMapper mapper;
        private readonly IUserRepository repository;

        public SecurityService(IMapper mapper, IUserRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<SecurityModel> LoginAsync(LoginModel model)
        {
            var user = this.repository.FindByConditionAsync(x => x.Email.Equals(model.Email) && x.Password.Equals(model.Password));
            var claims = new List<Claim>
            {
            new Claim(JwtRegisteredClaimNames.Sub, model.Email),
            new Claim(JwtRegisteredClaimNames.Jti, System.Guid.NewGuid().ToString()),
            };

            var roles = new List<string>{
                "Teste",
                "Matematica"
            };

             claims.AddRange(roles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));


            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("0123456789ABCDEF"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken("http://localhost:5001", //issued by
                "http://localhost:5000", //issued for
                claims, //payload
                expires: System.DateTime.Now.AddMinutes(30), // valid for 1/2 hour
                signingCredentials: creds); // signature

            try
            {
                var tokenEncoded = new JwtSecurityTokenHandler().WriteToken(token);
                var security = new SecurityModel()
                {
                    Token = tokenEncoded,
                    ExpirateIn = System.DateTime.Now.AddMinutes(30)
                };
                return security;
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                return null;
            }
        }
    }
}