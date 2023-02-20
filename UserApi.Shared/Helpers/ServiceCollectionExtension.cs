using Microsoft.EntityFrameworkCore;
using User_API.Domain;
using User_API.UserApi.Repository;
using User_API.UserApi.Services;

namespace User_API.UserApi.Shared.Helpers
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add services to the container.
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // Add Auto Mapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Add Database Context
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("SaqayaUserApiDB")));
            //services.AddDatabaseDeveloperPageExceptionFilter();


            //Register Services
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
