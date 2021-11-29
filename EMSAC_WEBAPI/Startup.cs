using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization.JwtBearer;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Security.Claims;
using NSwag;
using NSwag.Generation.Processors.Security;
using RESTAuth.Controllers;
using System.IdentityModel.Tokens.Jwt;

namespace EMSAC_WEBAPI
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
            services.AddControllers();

            var tokenKey = Configuration["Jwt:Key"];        //definida em appsettings.json
            var key = Encoding.ASCII.GetBytes(tokenKey);    //codifica string

            services.AddAuthentication(JwtBearer.JwtBearerDefaults.AuthenticationScheme)
            //2º - Configurar JwtBearer - Valida JWT recebido no Header
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                            //options.Audience = "https://localhost:44348/";
                            //options.Authority = "https://localhost:44348/";
                            options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ClockSkew = TimeSpan.Zero,
                };
            });

            //Registar a classe que gere JWT   
            services.AddSingleton<IJWTAuthManager>(new JWTAuthManager(tokenKey));
            //Caso interesse partir apenas dos dados que estão no appsetttings.json para definir o JWT           
            services.AddSingleton<IConfiguration>(Configuration);

            //Authorization Request: Middleware para Autorização
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Autorizado", policy =>
                {
                    policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
                    policy.RequireAuthenticatedUser();
                    policy.Requirements.Add(new AuthorizedRequirement());
                });
                options.AddPolicy("EmployeeOnly", policy => policy.RequireClaim("EmployeeNumber"));
            });

            //Registar o gestor de Autorizações
            services.AddSingleton<IAuthorizationHandler, AuthorizedRequirementHandler>();

            services.AddSwaggerDocument(o =>
            {
                o.DocumentName = "EMSAC API";

                //Configura Header
                o.PostProcess = document =>
                {
                    document.Info.Title = "EMSAC API";
                    document.Info.Version = "1.0.0";
                    document.Info.Description = "EMSAC API";
                    document.Info.Contact = new NSwag.OpenApiContact()   //está a ser usado o gestor NSwag              
                    {
                        Name = "ISI",
                        Email = "",
                        Url = "https://www.ipca.pt"
                    };
                    document.Info.License = new NSwag.OpenApiLicense
                    {
                        Name = "Use under IPCA rights",
                        Url = "https://www.ipca.pt/license"
                    };
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
