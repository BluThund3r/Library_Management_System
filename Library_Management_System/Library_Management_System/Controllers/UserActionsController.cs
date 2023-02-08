using AutoMapper;
using Library_Management_System.Helpers.Attributes;
using Library_Management_System.Models;
using Library_Management_System.Models.DTOs;
using Library_Management_System.Models.DTOs.UserDTO;
using Library_Management_System.Models.Enums;
using Library_Management_System.Services.BookCopyService;
using Library_Management_System.Services.SubscriptionCardService;
using Library_Management_System.Services.UserBorrowsCopyService;
using Library_Management_System.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserActionsController : ControllerBase
    {
        public readonly IUserService userService;
        public readonly IBookCopyService bookCopyService;
        public readonly IUserBorrowsCopyService userBorrowsCopyService;
        public readonly ISubscriptionCardService subscriptionCardService;
        public IMapper mapper;

        public UserActionsController(IUserService _userService, IMapper mapper, IBookCopyService bcs, IUserBorrowsCopyService ubcs, ISubscriptionCardService scs)
        {
            userService = _userService;
            this.mapper = mapper;
            bookCopyService = bcs;
            userBorrowsCopyService = ubcs;
            subscriptionCardService = scs;
        }

        [HttpPost("createAccount")]
        public IActionResult CreateAccount([FromBody] UserInfoDTO userDto)
        {
            userDto.Id = Guid.Empty;
            var userByUserName = userService.GetByUserName(userDto.UserName);
            if (userByUserName != null)
                return BadRequest($"The Username {userDto.UserName} is already taken");
            var userByEmail = userService.GetByEmail(userDto.Email);
            if (userByEmail != null)
                return BadRequest($"There is another account linked to the e-mail address {userDto.Email}");
            userDto.Role = Role.BasicUser;  // sa ma asigur ca nu am surprize
            userService.CreateUser(userDto);
            return Ok();

        }

        [Authorization(Role.Admin)]
        [HttpDelete("deleteCertainUser/{userId}")]
        public IActionResult DeleteCertainUser([FromRoute] Guid userId)
        {
            if (userService.GetById(userId) == null)
                return Forbid($"There is no user with id {userId}");

            var userToDelete = new UserInfoDTO { Id = userId, Email = "random_email@gmail.com", UserName = "randomUserName" };
            userService.DeleteUser(userToDelete);
            return Ok("User successfully deleted");
        }

        [Authorization(Role.Admin)]
        [HttpPost("giveRoleToUser")]
        public IActionResult SetRoleToUser([FromQuery] Guid userId, [FromQuery] Role role)
        {
            var user = userService.GetById(userId);
            if (user == null)
                return NoContent();         // nu exita user-ul in baza de date
            if (user.Role == role)
                return Ok("User already has that role");
            var userDto = mapper.Map<UserInfoDTO>(user);
            userDto.Role = role;
            userService.UpdateUser(userDto);
            return Ok($"Granted role to user");
        }

        [HttpDelete("deleteMyAccount")]
        public IActionResult DeleteMyAccount()
        {
            var user = ((Task<User>)HttpContext.Items["User"]).Result;
            var userDto = mapper.Map<UserInfoDTO>(user);
            userService.DeleteUser(userDto);
            HttpContext.Items.Remove("User");
            return Ok("Account deleted!");
        }


        [Authorization(Role.Admin)]
        [HttpGet("getUserById/{userId}")]
        public IActionResult GetUserByIdAsync([FromRoute] Guid userId)
        {
            return Ok(userService.GetById(userId));
        }

        [Authorization(Role.Admin)]
        [HttpGet("getAllUsersAsync")]
        public async Task<List<UserInfoDTO>> GetAllAsync()
        {
            return await userService.GetAllUsersAsync();
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(UserRequestDTO userRequestDto)
        {
            var response = userService.Authenticate(userRequestDto);
            if (response == null)
            {
                return BadRequest("Username or password are invalid");
            }
            return Ok(response);
        }

        [Authorization(Role.BasicUser)]
        [HttpPost("borrowBook")]
        public IActionResult BorrowBook([FromQuery] Guid bookId)
        {
            var user = ((Task<User>)HttpContext.Items["User"]).Result;
            if (subscriptionCardService.GetByUserId(user.Id) == null)
                return Forbid($"User {user.UserName} must create a Subscription Card first");
            if (userBorrowsCopyService.UserAlreadyBorrowedBook(user.Id, bookId))
                return Forbid($"User {user.UserName} has already borrowed a copy of the book with id {bookId}");
            var copy = bookCopyService.GetCopyOfBookIfAnyAvailable(bookId);
            if (copy == null)
                return NoContent();     // nu mai sunt copii disponibile ale cartii cu id bookId    
            var ubcDto = new UserBorrowsCopyDTO { CopyId = copy.Id, UserId = user.Id };
            userBorrowsCopyService.Create(ubcDto);
            return Ok($"The Copy with Id {copy.Id} was borrowed by user {user.UserName}");
        }

        [Authorization(Role.BasicUser)]
        [HttpDelete("returnBook")]  // sterge o inregistrare din UserBorrowsCopy
        public IActionResult ReturnBook([FromQuery] Guid copyId)
        {
            var user = ((Task<User>)HttpContext.Items["User"]).Result;
            if(subscriptionCardService.GetByUserId(user.Id) == null)
                return Forbid("This user must create a Subscription Card first");
            var deleteObj = userBorrowsCopyService.GetByUserIdAndCopyId(user.Id, copyId);
            if (deleteObj == null)
                return NotFound($"The user didn't borrow the copy with id {copyId}");
            userBorrowsCopyService.Delete(deleteObj);
            return Ok($"User {user.UserName} has returned the copy with id {copyId}");
        }

        [Authorization(Role.BasicUser)]
        [HttpPost("generateSubscriptionCard")]
        public IActionResult GenerateSubscriptionCard()
        {
            var user = ((Task<User>)HttpContext.Items["User"]).Result;
            if (subscriptionCardService.GetByUserId(user.Id) != null)
                return Forbid($"User {user.UserName} already has a Subscription Card");
            var sCardDto = new SubscriptionCardDTO
            { 
                UserId = user.Id, 
                StartDate = DateTime.UtcNow, 
                EndDate = DateTime.UtcNow.AddYears(1) 
            };

            subscriptionCardService.Create(sCardDto);
            return Ok($"Generated Subscription Card for user {user.UserName}");
        }

        [Authorization(Role.BasicUser)]
        [HttpDelete("deleteSubscriptionCard")]
        public IActionResult DeleteSubscriptionCard()
        {
            var user = ((Task<User>)HttpContext.Items["User"]).Result;
            var sCard = subscriptionCardService.GetByUserId(user.Id);
            if (sCard == null)
                return Forbid($"User {user.UserName} doesn't have a Subscription Card");

            subscriptionCardService.Delete(sCard);
            return Ok($"Deleted Subscription Card for user {user.UserName}");
        }
    }
}
