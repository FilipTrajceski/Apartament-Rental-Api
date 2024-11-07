using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using S_T.Apartaments.Application.Common.Interfaces;
using S_T.Apartaments.Infrastructure.DataLayer;
using S_T.Apartaments.Infrastructure.TokenService;
using S_T.Apartaments.Infrastructure.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_T.Apartaments.Helpers.DiContainer
{
    public static class DiHelper
    {
        public static void InjectDbContext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<S_TDbContext>(x => x.UseSqlServer(connectionString));
        }

        public static void InjectRepositories(IServiceCollection services)
        {

        }

        public static void InjectService (IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITokenService, TokenService>();
        }
    }
}
