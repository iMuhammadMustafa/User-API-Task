namespace User_API.UserApi.Shared.Helpers
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            // Add services to the container.
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // Add Auto Mapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Add Database Context
            //services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SaqayaUserApiDB")));
            //services.AddDatabaseDeveloperPageExceptionFilter();


            //Register Services
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
