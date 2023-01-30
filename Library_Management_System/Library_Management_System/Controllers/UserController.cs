using AutoMapper;
using Library_Management_System.Models;
using Library_Management_System.Models.DTOs;
using Library_Management_System.Models.DTOs.UserDTO;
using Library_Management_System.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService userService;
        public IMapper mapper;

        public UserController(IUserService _userService, IMapper mapper)
        {
            userService = _userService;
            this.mapper = mapper;
        }


        [HttpGet("getAllUsersAsync")]
        public async Task<List<UserInfoDTO>> GetAllAsync()
        {
            return await userService.GetAllUsersAsync();
        }


        [HttpGet("testSubscriptionCard")]
        public IActionResult getSubscriptionCard()
        {
            SubscriptionCard s = new SubscriptionCard { EndDate = DateTime.Now.AddDays(10), UserId = new Guid(), StartDate = DateTime.Now };
            return Ok(mapper.Map<SubscriptionCardDTO>(s));
        }


        [HttpGet("testAuthor")]
        public IActionResult getAuthor()
        {
            Author a = new Author { FirstName = "Sandu", LastName = "CIORBA" };
            return Ok(mapper.Map<AuthorDTO>(a));
        }

        [HttpGet("testAuthorsWriteBooks")]
        public IActionResult getAuthorWriteBooks()
        {
            AuthorsWriteBooks a = new AuthorsWriteBooks { AuthorId = new Guid(), BookId = new Guid() };
            return Ok(mapper.Map<AuthorsWriteBooksDTO>(a));
        }

        [HttpGet("testBook")]
        public IActionResult getBook()
        {
            Book a = new Book
            {
                Title = "Red Rising",
                PublisherId = new Guid(),
                ReleaseDate = new DateTime(2014, 1, 28),
                Genre = Models.Enums.Genre.SF,
                Language = Models.Enums.Language.English,
                NoPages = 512
            };

            return Ok(mapper.Map<BookDTO>(a));
        }

        [HttpGet("testBookCopy")]
        public IActionResult getBookCopy()
        {
            BookCopy a = new BookCopy
            {
                BookId = new Guid(),
                CoverType = Models.Enums.CoverType.HardCover,
                Price = 51.5
            };

            return Ok(mapper.Map<BookCopyDTO>(a));
        }

        [HttpGet("testPublisher")]
        public IActionResult getPublisher()
        {
            Publisher a = new Publisher
            {
                Name = "Paladin",
                Address = "UK, London, Short Street 123"
            };

            return Ok(mapper.Map<PublisherDTO>(a));
        }


        [HttpGet("testUserBorrowsCopy")]
        public IActionResult getUserBorrowsCopy()
        {
            UserBorrowsCopy a = new UserBorrowsCopy
            {
                UserId = new Guid(),
                CopyId = new Guid(),
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(14)
            };

            return Ok(mapper.Map<UserBorrowsCopyDTO>(a));
        }

        [HttpGet("testUser")]
        public IActionResult getUser()
        {
            User a = new User
            {
                UserName = "user1",
                FirstName = "user1FN",
                LastName = "user1LN",
                Age = 25,
                Email = "something1@gmail.com",
                PhoneNumber = "0846541",
                City = "London",
                Role = Models.Enums.Role.BasicUser,
                PasswordHash = "$2b$10$oXP/MIqoIsQwqCFM0KuVGOZyi5wo4ptRpfyoUwmt/p0gaqqaBLHF."
            };

            return Ok(mapper.Map<UserInfoDTO>(a));
        }
    }
}
