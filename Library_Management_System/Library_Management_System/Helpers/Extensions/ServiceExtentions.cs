using Library_Management_System.Helpers.JwtUtils;
using Library_Management_System.Helpers.Seeders;
using Library_Management_System.Repositories.AuthorRepository;
using Library_Management_System.Repositories.AuthorsWriteBooksRepository;
using Library_Management_System.Repositories.BookCopyRepository;
using Library_Management_System.Repositories.BookRepository;
using Library_Management_System.Repositories.PublisherRepository;
using Library_Management_System.Repositories.SubscriptionCardRepository;
using Library_Management_System.Repositories.UserBorrowsCopyRepository;
using Library_Management_System.Repositories.UserRepository;
using Library_Management_System.Services.AuthorService;
using Library_Management_System.Services.AuthorsWriteBooksService;
using Library_Management_System.Services.BookCopyService;
using Library_Management_System.Services.BookService;
using Library_Management_System.Services.PublisherService;
using Library_Management_System.Services.SubscriptionCardService;
using Library_Management_System.Services.UserBorrowsCopyService;
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
            services.AddTransient<IAuthorsWriteBooksRepository, AuthorsWriteBooksRepository>();
            services.AddTransient<IUserBorrowsCopyRepository, UserBorrowsCopyRepository>();
            services.AddTransient<IBookCopyRepository, BookCopyRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IAuthorsWriteBooksService, AuthorsWriteBooksService>();
            services.AddTransient<IBookCopyService, BookCopyService>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IPublisherService, PublisherService>();
            services.AddTransient<ISubscriptionCardService, SubscriptionCardService>();
            services.AddTransient<IUserBorrowsCopyService, UserBorrowsCopyService>();
            return services;
        }

        public static IServiceCollection AddSeeders(this IServiceCollection services)
        {
            services.AddTransient<AuthorSeeder>();
            services.AddTransient<AuthorsWriteBooksSeeder>();
            services.AddTransient<BookSeeder>();
            services.AddTransient<PublisherSeeder>();
            services.AddTransient<BookCopySeeder>();
            services.AddTransient<UserBorrowsCopySeeder>();
            services.AddTransient<UserSeeder>();
            services.AddTransient<SubscriptionCardSeeder>();

            return services;
        }

        public static IServiceCollection AddUtils(this IServiceCollection services)
        {
            services.AddScoped<IJwtUtils, JwtUtils.JwtUtils>();
            return services;
        }
    }
}
