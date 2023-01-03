

using ProiectASPNET.Repositories.AuthorRepository;
using ProiectASPNET.Services.AuthorService;

namespace Lab4_13.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IAuthorService, AuthorService>();

            return services;
        }

        public static IServiceCollection AddSeeders(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddUtils(this IServiceCollection services)
        {
            return services;
        }
    }
}
