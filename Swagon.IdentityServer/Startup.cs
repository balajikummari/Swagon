using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;




namespace Swagon.IdentityServer
{
    public class Startup
    {
        private readonly IConfiguration Config;
        public Startup(IConfiguration configuration)
        {
            Config = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            {
                var connectionString = "Data Source=DESKTOP-SMGQ7OC;Initial Catalog=Swagon;Integrated Security=True";
                services.AddDbContext<AppDbContext>(config =>
                {
                    config.UseSqlServer(connectionString);
                });
                // AddIdentity registers the services
                services.AddIdentity<IdentityUser, IdentityRole>(config =>
                {
                    config.Password.RequiredLength = 4;
                    config.Password.RequireDigit = false;
                    config.Password.RequireNonAlphanumeric = false;
                    config.Password.RequireUppercase = false;
                    config.SignIn.RequireConfirmedEmail = false;
                })
                    .AddEntityFrameworkStores<AppDbContext>()
                    .AddDefaultTokenProviders();
                services.ConfigureApplicationCookie(config =>
                {
                    config.Cookie.Name = "IdentityServer.Cookie";
                    config.LoginPath = "/Auth/Login";
                    config.LogoutPath = "/Auth/Logout";
                });
                var assembly = typeof(Startup).Assembly.GetName().Name;
                services.AddIdentityServer()
                        .AddAspNetIdentity<IdentityUser>()
                        .AddConfigurationStore(options =>
                        {
                            options.ConfigureDbContext = b => b.UseSqlServer(connectionString,
                                sql => sql.MigrationsAssembly(assembly));
                        })
                        .AddOperationalStore(options =>
                        {
                            options.ConfigureDbContext = b => b.UseSqlServer(connectionString,
                                sql => sql.MigrationsAssembly(assembly));
                        })
                    .AddDeveloperSigningCredential();
            } // everything


            services.AddAuthentication()
                .AddFacebook(config =>
                {
                    config.AppId = "532748900691340";
                    config.AppSecret = "ac472b992554624cec0accdaf076ffc7";
                    config.TokenEndpoint = "https://localhost:44376/signin-facebook";
                })
                .AddGoogle(config =>
                {
                    config.ClientId = "600596568117-he2o4idfvb2lkn3nnb34ssi1fdpagmpg.apps.googleusercontent.com";
                    config.ClientSecret = "QDKNEQn12JjhTJVU_5GvRQXP";
                })
                .AddGitHub(options =>
                {
                    options.ClientId = "ab01cac21291bbc5ca17";
                    options.ClientSecret = "ea5d296b640000b45f9565c9e0273ff69c509cf8";
                }).AddMicrosoftAccount(microsoftOptions =>
                {
                    microsoftOptions.ClientId = "a1b266ca-6cd6-4883-8330-fbb95743e6c1";
                    microsoftOptions.ClientSecret = "xU4uEa?VS4=L7IMMw?yh2kV-APH3eNlD";
                });

            services.AddControllersWithViews();
            {
                //.AddInMemoryIdentityResources(Configuration.GetIdentityResources())
                //.AddInMemoryApiResources(Configuration.GetApis())
                //.AddInMemoryClients(Configuration.GetClients())
            } // in memorDyb
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseIdentityServer();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}

