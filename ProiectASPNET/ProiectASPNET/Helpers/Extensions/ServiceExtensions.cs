

using ProiectASPNET.Helpers.JwtUtils;
using ProiectASPNET.Repositories.AuthorInBookRepository;
using ProiectASPNET.Repositories.AuthorRepository;
using ProiectASPNET.Repositories.BookRepository;
using ProiectASPNET.Repositories.QuoteRepository;
using ProiectASPNET.Repositories.ReviewRepository;
using ProiectASPNET.Services.AuthorService;
using ProiectASPNET.Services.BookService;
using ProiectASPNET.Services.QuoteService;
using ProiectASPNET.Services.ReviewService;


namespace Lab4_13.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IQuoteRepository, QuoteRepository>();
            services.AddTransient<IReviewRepository, ReviewRepository>();
            services.AddTransient<IAuthorInBookRepository, AuthorInBookRepository>();


            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IQuoteService, QuoteService>();
            services.AddTransient<IReviewService, ReviewService>();

            return services;
        }

        public static IServiceCollection AddSeeders(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddUtils(this IServiceCollection services)
        {
            services.AddScoped<IJwtUtils, JwtUtils>();
            return services;
        }
    }
}
