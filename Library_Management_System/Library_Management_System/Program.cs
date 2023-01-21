using Microsoft.EntityFrameworkCore;
using Library_Management_System.Data;
using Library_Management_System.Repositories.AuthorRepository;
using Library_Management_System.Helpers.Extensions;
using Library_Management_System.Helpers.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API", Version = "v1" });
});
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddSeeders();

// AddUtils
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();


void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<AuthorSeeder>();
        service.SeedInitialAuthors();

        var service1 = scope.ServiceProvider.GetService<PublisherSeeder>();
        service1.SeedInitialPublishers();

        var service2 = scope.ServiceProvider.GetService<BookSeeder>();
        service2.SeedInitialBooks();

        var service3 = scope.ServiceProvider.GetService<AuthorsWriteBooksSeeder>();
        service3.SeedInitialAuthorsWriteBooks();

        var service4 = scope.ServiceProvider.GetService<BookCopySeeder>();
        service4.SeedInitialBookCopies();

        var service5 = scope.ServiceProvider.GetService<UserSeeder>();
        service5.SeedInitialUsers();

        var service6 = scope.ServiceProvider.GetService<UserBorrowsCopySeeder>();
        service6.SeedInitialUserBorrowsCopies();

        var service7 = scope.ServiceProvider.GetService<SubscriptionCardSeeder>();
        service7.SeedInitialSubscriptionCards();
    }
}