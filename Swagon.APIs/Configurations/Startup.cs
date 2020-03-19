using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using Swagon.APIs.Controllers;
using System.Collections.Generic;


namespace Swagon.APIs
{
    public class Startup
    {
        private readonly Container container = new Container();
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(container));
            services.UseSimpleInjectorAspNetRequestScoping(container);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("MySwagApi", new OpenApiInfo { Title = "SwaggerAPI", Version = "1.0" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description =
                    "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
                //services.AddAuthentication(x =>
                //{
                //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                //})
                //.AddJwtBearer(x =>
                //{
                //   x.RequireHttpsMetadata = false;
                //   x.SaveToken = true;
                //   x.TokenValidationParameters = new TokenValidationParameters
                //   {
                //       ValidateIssuerSigningKey = true,
                //       IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["Jwt:Key"])),
                //       ValidateIssuer = false,
                //       ValidateAudience = false,

                //   };
                //});
            });
            services.AddAuthentication("Bearer")
                 .AddJwtBearer("Bearer", config =>
                 {
                     config.Authority = "https://localhost:44376/";
                     config.Audience = "SwagonResourceApi";
                 });
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            { app.UseDeveloperExceptionPage(); }
            app.UseCors("MyPolicy");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseEndpoints(endpoints =>
            { endpoints.MapControllers(); });
            app.UseSwaggerUI(c =>
            { c.SwaggerEndpoint("/swagger/MySwagApi/swagger.json", "SwaggerAPI"); });
            DIContainer.AddDevDeps(container);
            container.RegisterMvcControllers(app);
            container.Verify();
        }
    }
}
