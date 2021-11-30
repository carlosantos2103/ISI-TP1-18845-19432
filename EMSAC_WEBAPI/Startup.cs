/*
 * <copyright file="Startup.cs" Company = "IPCA - Instituto Politecnico do Cavado e do Ave">
 *      Copyright IPCA-EST. All rights reserved.
 * </copyright>
 * <version>0.2</version>
 *  <user> Joao Ricardo / Carlos Santos </users>
 * <number> 18845 / 19432 <number>                                     
 * <email> a18845@alunos.ipca.pt / a19432@alunos.ipca.pt<email>
 */

using EMSAC_WEBAPI.Controllers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using NSwag;
using NSwag.Generation.Processors.Security;
using System;
using System.Linq;
using System.Text;

namespace EMSAC_WEBAPI
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Definida em appsettings.json
            var tokenKey = Configuration["Jwt:Key"];
            var key = Encoding.ASCII.GetBytes(tokenKey);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)

            // Configuração do JwtBearer
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
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

            // Classe que JWT   
            services.AddSingleton<IJWTAuthManager>(new JWTAuthManager(tokenKey));
        
            services.AddSingleton<IConfiguration>(Configuration);

            // Middleware para Autorização
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Autorizado", policy =>
                {
                    policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
                    policy.RequireAuthenticatedUser();
                });
                options.AddPolicy("EmployeeOnly", policy => policy.RequireClaim("EmployeeNumber"));
            });

            services.AddSwaggerDocument(o =>
            {
                o.DocumentName = "EMSAC API";

                o.OperationProcessors.Add(new OperationSecurityScopeProcessor("JWT"));
                o.AddSecurity("JWT", Enumerable.Empty<string>(),
                    new NSwag.OpenApiSecurityScheme()
                    {
                        Type = OpenApiSecuritySchemeType.ApiKey,
                        Name = "Authorization",
                        In = OpenApiSecurityApiKeyLocation.Header,
                        Description = "Type into the value field: Bearer {token}"
                    });

                // Header do Swagger
                o.PostProcess = document =>
                {
                    document.Info.Title = "EMSAC API";
                    document.Info.Version = "1.0.0";
                    document.Info.Description = "EMSAC API";
                    document.Info.Contact = new OpenApiContact()         
                    {
                        Name = "18845/19432 - ISI 2021 - LESI",
                        Email = "",
                        Url = "https://www.ipca.pt"
                    };
                    document.Info.License = new OpenApiLicense
                    {
                        Name = "Use under IPCA rights",
                        Url = "https://www.ipca.pt/license"
                    };
                };
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // NSwag
            app.UseOpenApi();
            app.UseSwaggerUi3();

            // OAuth
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
