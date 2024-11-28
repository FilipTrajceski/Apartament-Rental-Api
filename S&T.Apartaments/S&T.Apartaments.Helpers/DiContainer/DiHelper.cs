using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using S_T.Apartaments.Application.Common.Interfaces;
using S_T.Apartaments.Application.Repositories;
using S_T.Apartaments.Infrastructure.DataLayer;
using S_T.Apartaments.Infrastructure.Services.TokenService;
using S_T.Apartaments.Infrastructure.Services.UserService;

namespace S_T.Apartaments.Helpers.DiContainer
{
    public static class DiHelper
    {
        public static void InjectDbContext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<RentalDbContext>(x => x.UseSqlServer(connectionString));
        }

        public static void InjectRepositories(IServiceCollection services)
        {
         
        }

        public static void InjectService (IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddScoped<IApartmentService, ApartmentService>();
        }
    }
}
