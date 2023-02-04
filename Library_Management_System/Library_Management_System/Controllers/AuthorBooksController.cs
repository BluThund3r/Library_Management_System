using Library_Management_System.Models.DTOs;
using Library_Management_System.Services.AuthorService;
using Library_Management_System.Services.AuthorsWriteBooksService;
using Library_Management_System.Services.BookService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorBooksController : ControllerBase
    {
        public readonly IAuthorService authorService;
        public readonly IAuthorsWriteBooksService awbService;
        public readonly IBookService bookService;

        public AuthorBooksController(IAuthorService authorService, IAuthorsWriteBooksService awbService, IBookService bookService)
        {
            this.authorService = authorService;
            this.awbService = awbService;
            this.bookService = bookService;
        }

        // GET

        [HttpGet("getAllAuthors")]
        public async Task<IActionResult> GetAllAuthors()
        {
            return Ok(await authorService.GetAllAsync());
        }

        [HttpGet("getAuthorById/{authorId}")]
        public async Task<IActionResult> GetAuthorById([FromRoute] Guid authorId)
        {
            return Ok(await authorService.GetByIdAsync(authorId));
        }

        [HttpGet("getBooksFromAuthor/{authorId}")]
        public IActionResult GetBooksFromAuthor([FromRoute] Guid authorId)
        {
            var authorBooks = awbService.GetAllByAuthorId(authorId);
            if (authorBooks.Count() == 0)
                return NoContent();
            var resultList = new List<BookDTO>();
            foreach(var elem in authorBooks)
            {
                resultList.Add(bookService.GetById(elem.BookId));
            }

            return Ok(resultList);
        }

        // POST

        [HttpPost("addAuthor")]
        public IActionResult AddAuthor([FromBody] AuthorDTO authorDto)
        {
            authorDto.Id = Guid.Empty;
            authorService.Create(authorDto);
            return Ok("Author added successfully");
        }

        [HttpPost("updateAuthor")]
        public IActionResult UpdateAuthor([FromBody] AuthorDTO authorDto)
        {
            var authorToUpdate = authorService.GetById(authorDto.Id);
            if (authorToUpdate == null)
                return NoContent();
            authorService.Update(authorDto);
            return Ok("Author updated successfully");
        }

        [HttpPost("addBookToAuthor/{bookId}/{authorId}")]
        public IActionResult AddBookToAuthor([FromRoute] Guid bookId, [FromRoute] Guid authorId)
        {
            if (bookId == Guid.Empty || authorId == Guid.Empty)
                return BadRequest();
            var book = bookService.GetById(bookId);
            var author = authorService.GetById(authorId);
            if (book == null || author == null)
                return NoContent();
            var objectToCreate = new AuthorsWriteBooksDTO { BookId = bookId, AuthorId = authorId };
            awbService.Create(objectToCreate);
            return Ok("Book successfully added to author");
        }

        // DELETE
        [HttpDelete("deleteAuthor/{authorId}")]
        public IActionResult DeleteAuthor([FromRoute] Guid authorId)
        {
            var authorToDelete = authorService.GetById(authorId);
            if(authorToDelete == null)
                return NoContent();
            var booksByAuthor = awbService.GetAllByAuthorId(authorId);
            var okDelete = true;
            foreach(var elem in booksByAuthor)
            {
                if (bookService.BookHasCopiesBorrowed(elem.BookId))
                {
                    okDelete = false;
                    break;
                }
            }

            if (!okDelete)
                return Forbid("You are not allowed to delete an author which wrote books that have copies borrowed");

            foreach(var elem in booksByAuthor)
            {
                var bookToDelete = bookService.GetById(elem.BookId);
                bookService.Delete(bookToDelete);
            }

            authorService.Delete(authorToDelete);
            return Ok("Author deleted successfully (along with all the books associated to them)");
        }
    }
}
