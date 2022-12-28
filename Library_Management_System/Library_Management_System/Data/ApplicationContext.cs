using Library_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System.Data
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorsWriteBooks> AuthorsWriteBooks { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCopy> BookCopies { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<SubscriptionCard> SubscriptionCards { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserBorrowsCopy> UsersBorrowCopies { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ONE TO MANY

            // Books -> Publisher
            modelBuilder.Entity<Book>()
                .HasOne<Publisher>(b => b.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.PublisherId);

            // BookCopies -> Book
            modelBuilder.Entity<BookCopy>()
                .HasOne<Book>(bc => bc.Book)
                .WithMany(b => b.BookCopies)
                .HasForeignKey(bc => bc.BookId);


            // MANY TO MANY

            // Authors <- AuthorsWriteBooks -> Books
            modelBuilder.Entity<AuthorsWriteBooks>()
                .HasKey(awb => new { awb.AuthorId, awb.BookId });

            modelBuilder.Entity<AuthorsWriteBooks>()
                .HasOne<Author>(awb => awb.Author)
                .WithMany(a => a.AuthorsWriteBooks)
                .HasForeignKey(awb => awb.AuthorId);

            modelBuilder.Entity<AuthorsWriteBooks>()
                .HasOne<Book>(awb => awb.Book)
                .WithMany(b => b.AuthorsWriteBooks)
                .HasForeignKey(awb => awb.BookId);


            // BookCopies <- UsersBorrowCopies -> Users
            modelBuilder.Entity<UserBorrowsCopy>()
                .HasKey(ubc => new { ubc.UserId, ubc.CopyId });

            modelBuilder.Entity<UserBorrowsCopy>()
                .HasOne<User>(ubc => ubc.User)
                .WithMany(u => u.UsersBorrowCopies)
                .HasForeignKey(ubc => ubc.UserId);

            modelBuilder.Entity<UserBorrowsCopy>()
                .HasOne<BookCopy>(ubc => ubc.Copy)
                .WithMany(c => c.UsersBorrowCopies)
                .HasForeignKey(ubc => ubc.CopyId);


            // ONE TO ONE

            // SubscriptionCards -> Users
            modelBuilder.Entity<SubscriptionCard>()
                .HasOne(sc => sc.User)
                .WithOne(u => u.Card)
                .HasForeignKey<User>(u => u.Id);   

            base.OnModelCreating(modelBuilder);
        }
    }
}
