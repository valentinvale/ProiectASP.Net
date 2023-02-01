

using ProiectASPNET.Repositories.AuthorInBookRepository;
using ProiectASPNET.Repositories.AuthorRepository;
using ProiectASPNET.Repositories.BookRepository;
using ProiectASPNET.Repositories.LeaderboardRepository;
using ProiectASPNET.Repositories.QuoteOfTheMonthRepository;
using ProiectASPNET.Repositories.QuoteRepository;
using ProiectASPNET.Repositories.ReviewRepository;
using ProiectASPNET.Services.AuthorService;
using ProiectASPNET.Services.BookService;
using ProiectASPNET.Services.LeaderboardService;
using ProiectASPNET.Services.QuoteOfTheMonthService;
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
            services.AddTransient<IQuoteOfTheMonthRepository, QuoteOfTheMonthRepository>();
            services.AddTransient<ILeaderboardRepository, LeaderboardRepository>();


            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IQuoteService, QuoteService>();
            services.AddTransient<IReviewService, ReviewService>();
            services.AddTransient<IQuoteOfTheMonthService, QuoteOfTheMonthService>();
            services.AddTransient<ILeaderboardService, LeaderboardService>();


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
