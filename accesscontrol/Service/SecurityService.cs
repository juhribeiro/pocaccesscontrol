using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using accesscontrol.Enums;
using accesscontrol.ExceptionMiddleware;
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
        private readonly IAuthService service;

        public SecurityService(IMapper mapper, IUserGroupRepository repository, IAuthService service)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.service = service;
        }

        public async Task<SecurityModel> LoginAsync(LoginModel model)
        {
            var usergroups = await this.repository.GetByEmailAsync(model.Email);
            if (usergroups is null)
            {
                throw new CustomException(new MessageDetails(MessageType.Warning, "usuário não cadastrado ou não pertence a nenhum grupo"));
            }

            var expiratedate = System.DateTime.Now.AddMinutes(30);
            if (usergroups.User.Password != model.Password)
            {
                usergroups.User.NumberLoginErros++;
                if (usergroups.User.NumberLoginErros > 3)
                {
                    usergroups.User.Active = false;
                    var message = "Quantidade de tentativa de logins excedida, Tente recuperar sua senha para desbloquear seu usuário";
                    throw new CustomException(new MessageDetails(MessageType.Warning, message));
                }

                await this.repository.UpdateAsync(usergroups);
                throw new CustomException(new MessageDetails(MessageType.Warning, "Login ou senha inválida"));
            }
            else
            {
                usergroups.User.NumberLoginErros = 0;
                usergroups.User.ExpirationDate = expiratedate;
                await this.repository.UpdateAsync(usergroups);
            }

            var security = this.service.GenerateToken(usergroups, expiratedate);
            return security;
        }
    }
}