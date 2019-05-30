using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using accesscontrol.Data;
using accesscontrol.ExceptionMiddleware;
using accesscontrol.Mapping;
using accesscontrol.Repository;
using accesscontrol.Service;
using accesscontrol.Util;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace accesscontrol
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            .AddJsonOptions(options =>
            {
                options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            });

            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ACContext>
                  (options => options.UseSqlServer(connection));

            services.AddOptions();
            services.AddHttpContextAccessor();
            services.Configure<AuthConfig>(Configuration.GetSection("AuthConfig"));
            var authconfig = this.Configuration.GetSection("AuthConfig").Get<AuthConfig>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            services.AddScoped<IApplicationService, ApplicationService>();

            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleService, RoleService>();

            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IGroupService, GroupService>();

            services.AddScoped<IUserGroupService, UserGroupService>();
            services.AddScoped<ISecurityService, SecurityService>();
            services.AddScoped<IUserGroupRepository, UserGroupRepository>();

            services.AddScoped<IUserApplicationService, UserApplicationService>();
            services.AddScoped<IUserApplicationRepository, UserApplicationRepository>();

            services.AddScoped<IRoleGroupService, RoleGroupService>();
            services.AddScoped<IRoleGroupRepository, RoleGroupRepository>();

            services.AddScoped<IAuthService, AuthService>();

            services.AddAuthorization(auth =>
                   {
                       auth.AddPolicy(JwtBearerDefaults.AuthenticationScheme, new AuthorizationPolicyBuilder()
                           .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                           .RequireAuthenticatedUser().Build());
                   });

            services.AddCors(o => o.AddPolicy("AccessControl", builder =>
                       {
                           builder.AllowAnyOrigin()
                                  .AllowAnyMethod()
                                  .AllowAnyHeader();
                       }
                   ));

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = authconfig.SymmetricSigningKey,
                    ValidateIssuer = true,
                    ValidIssuer = authconfig.Issuer, // site that makes the token
                    ValidateAudience = true,
                    ValidAudience = authconfig.Audience, // site that consumes the token
                    ValidateLifetime = true, //validate the expiration 
                    ClockSkew = System.TimeSpan.FromMinutes(5) //
                };
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "accesscontrol api",
                    Version = "v1"
                });

                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {
                        JwtBearerDefaults.AuthenticationScheme, new string[]
                    {                    }
                    },
                };


                c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });

                c.AddSecurityRequirement(security);
            });

            AutoMapperConfiguration.Configure();
            services.AddAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile(Configuration.GetSection("Serilog"));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
           {
               c.SwaggerEndpoint("/swagger/v1/swagger.json", "acesscontrol V1");
               c.RoutePrefix = string.Empty;
               c.DocumentTitle = "Access Control API";
               c.DocExpansion(DocExpansion.None);
           });

            app.UseCors("AccessControl");
            app.ConfigureCustomExceptionMiddleware();
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
