using Library_Management_System.Repositories.AuthorRepository;
using Library_Management_System.Repositories.BookRepository;
using Library_Management_System.Repositories.PublisherRepository;
using Library_Management_System.Repositories.SubscriptionCardRepository;
using Library_Management_System.Repositories.UserRepository;
using System.Runtime.CompilerServices;

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

            return services;
        }
    }
}
