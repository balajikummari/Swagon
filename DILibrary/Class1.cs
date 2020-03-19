using System;
using System.Collections.Generic;
using System.Text;
using Swagon.DomainModel;
using Swagon.DataBase.DataModel;
using Swagon.DataBase.Repositories;
using Swagon.ConsoleView;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Swagon.Services.DI

{
    public class DIContainer
    { /*
        public ServiceCollection services = new ServiceCollection();

        ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
        public DIContainer()
        {
            //configurationBuilder.AddJsonFile("dI.json",optional:true);
            var configuration = configurationBuilder.Build();
            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton(new  SwagonContext());
            services.AddSingleton<Startup, Startup>();
            services.AddSingleton<LoginOrSignup, LoginOrSignup>();
            services.AddSingleton<IUserReopository, EFUserRepository>();
            services.AddSingleton<IUserService, UserService>();

        }*/

    }
}
