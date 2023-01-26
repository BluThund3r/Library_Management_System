using Library_Management_System.Helpers.JwtUtils;
using Library_Management_System.Helpers.Seeders;
using Library_Management_System.Repositories.AuthorRepository;
using Library_Management_System.Repositories.BookRepository;
using Library_Management_System.Repositories.PublisherRepository;
using Library_Management_System.Repositories.SubscriptionCardRepository;
using Library_Management_System.Repositories.UserRepository;
using Library_Management_System.Services.UserService;

namespace Library_Management_System.Helpers.Extensions
{
    public static class ServiceExtentions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IPublisherRepository, PublisherRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ISubscriptionCardRepository, SubscriptionCardRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            return services;
        }

        public static IServiceCollection AddSeeders(this IServiceCollection services)
        {
            services.AddScoped<AuthorSeeder>();
            services.AddScoped<AuthorsWriteBooksSeeder>();
            services.AddScoped<BookSeeder>();
            services.AddScoped<PublisherSeeder>();
            services.AddScoped<BookCopySeeder>();
            services.AddScoped<UserBorrowsCopySeeder>();
            services.AddScoped<UserSeeder>();
            services.AddScoped<SubscriptionCardSeeder>();

            return services;
        }

        public static IServiceCollection AddUtils(this IServiceCollection services)
        {
            services.AddTransient<IJwtUtils, JwtUtils.JwtUtils>();
            return services;
        }
    }
}
