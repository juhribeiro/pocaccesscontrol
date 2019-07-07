using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using accesscontrol.Data;
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
        private readonly IUserRepository repository;
        private readonly IAuthService service;
        private readonly IEmailSender sender;

        public SecurityService(IMapper mapper, IUserRepository repository, IAuthService service, IEmailSender sender)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.service = service;
            this.sender = sender;
        }

        public async Task ChangePasswordAsync(ChangePasswordModel model)
        {
            var usergroups = await this.repository.GetByNumberGenerateAsync(model.Code);
            if (usergroups is null)
            {
                throw new CustomException(new MessageDetails(MessageType.Warning, "codigo inválido"));
            }

            usergroups.Password = Criptografy.EncriptPassword(usergroups.Email, model.NewPassword);
            usergroups.NumberGenerate = null;
            await this.repository.UpdateAsync(usergroups);
        }

        public async Task<SecurityModel> LoginAsync(LoginModel model)
        {
            var usergroups = await this.repository.GetByEmailAsync(model.Email);
            if (usergroups is null)
            {
                throw new CustomException(new MessageDetails(MessageType.Warning, "usuário não cadastrado ou não pertence a nenhum grupo"));
            }

            var expiratedate = System.DateTime.Now.AddMinutes(1440);
            if (usergroups.Password != model.Password)
            {
                usergroups.NumberLoginErros++;
                if (usergroups.NumberLoginErros > 3)
                {
                    usergroups.Active = false;
                    var message = "Quantidade de tentativa de logins excedida, Tente recuperar sua senha para desbloquear seu usuário";
                    throw new CustomException(new MessageDetails(MessageType.Warning, message));
                }

                await this.repository.UpdateAsync(usergroups);
                throw new CustomException(new MessageDetails(MessageType.Warning, "Login ou senha inválida"));
            }
            else
            {
                usergroups.NumberLoginErros = 0;
                usergroups.ExpirationDate = expiratedate;
                await this.repository.UpdateAsync(usergroups);
            }

            var security = this.service.GenerateToken(usergroups, expiratedate);
            return security;
        }

        public async Task ResetPasswordAsync(ResetPasswordModel model)
        {
            var usergroups = await this.repository.GetByEmailAsync(model.Email);
            if (usergroups is null)
            {
                throw new CustomException(new MessageDetails(MessageType.Warning, "usuário não cadastrado ou não pertence a nenhum grupo"));
            }

            var num = await this.ValidRandom();
            usergroups.NumberGenerate = num;
            await this.repository.UpdateAsync(usergroups);
            sender.SendEmail($"Code {num}", usergroups.Email);
        }

        private async Task<int> ValidRandom()
        {
            Random random = new Random();

            int num = 0;
            User user = null;

            do
            {
                num = random.Next(1000, 9999);
                user = await this.repository.GetByNumberGenerateAsync(num);

            } while (user != null);

            return num;
        }
    }
}