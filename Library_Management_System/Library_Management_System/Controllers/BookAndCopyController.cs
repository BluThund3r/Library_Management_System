using AutoMapper;
using Library_Management_System.Models.DTOs;
using Library_Management_System.Models.Enums;
using Library_Management_System.Services.BookCopyService;
using Library_Management_System.Services.BookService;
using Library_Management_System.Services.PublisherService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Library_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookAndCopyController : ControllerBase
    {
        public readonly IBookService bookService;
        public readonly IBookCopyService bookCopyService;
        public readonly IPublisherService publisherService;

        public BookAndCopyController(IBookService bookService, IBookCopyService bookCopyService, IPublisherService publisherService)
        {
            this.bookService = bookService;
            this.bookCopyService = bookCopyService;
            this.publisherService = publisherService;
        }

        //GET

        [HttpGet("getAllBooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            return Ok(await bookService.GetAllAsync());
        }

        [HttpGet("getAllBooksOrderedByTitle")]
        public IActionResult GetAlBooksOrderedByTitle()
        {
            return Ok(bookService.GetBooksOrderedByTitleAsc());
        }

        [HttpGet("getAllBooksOrderedByTitleDesc")]
        public IActionResult GetAlBooksOrderedByTitleDesc()
        {
            return Ok(bookService.GetBooksOrderedByTitleDesc());
        }

        [HttpGet("getBookByTitle/{title}")]
        public IActionResult GetBookByTitle([FromRoute] string title)
        {
            var result = bookService.GetBooksByTitle(title);
            if (result == null)
                return NoContent();
            return Ok(result);
        }

        [HttpGet("getBooksFromPublisher/{publisherName}")]
        public IActionResult GetBooksFromPublisher([FromRoute] string publisherName)
        {
            var publisherDto = publisherService.GetPublisherByName(publisherName);
            if(publisherDto == null) 
                return NotFound($"There is no publisher with name {publisherName}");
            var booksFromPublisher = bookService.GetBooksFromPublisher(publisherDto.Id);
            if (booksFromPublisher == null)
                return NoContent();
            return Ok(booksFromPublisher);
        }

        [HttpGet("getBooksByGenre/{genre}")]
        public IActionResult GetBooksByGenre([FromRoute] string genre)
        {
            Genre gr;
            if (!Enum.TryParse<Genre>(genre, true, out gr))
                return Forbid($"There is no such genre as {genre}");
            var books = bookService.GetBooksByGenreIncludeBookCopy(genre);
            return Ok(books);
        }

        [HttpGet("getAllPublishers")]
        public async Task<IActionResult> GetAllPublishers()
        {
            return Ok(await publisherService.GetAllAsync());
        }

        [HttpGet("getNoCopiesAvailableOfBook/{bookId}")]
        public IActionResult GetNoCopiesAvailableOfBook([FromRoute] Guid bookId)
        {
            return Ok(bookCopyService.GetAvailableNoCopiesOfBook(bookId));
        }


        // POST

        [HttpPost("addBook")]
        public IActionResult CreateBook([FromBody] BookDTO bookDto)
        {
            bookDto.Id = Guid.Empty;

            if (bookDto.PublisherId == Guid.Empty)
                return BadRequest("The id of the publisher can't be empty");

            if (publisherService.GetById(bookDto.PublisherId) == null)
                return NotFound($"There is no publisher with id {bookDto.PublisherId}");

            bookService.Create(bookDto);
            return Ok("Book added successfully");
        }

        [HttpPost("addPublisher")]
        public IActionResult CreatePublisher([FromBody] PublisherDTO publisherDto)
        {
            publisherDto.Id = Guid.Empty;
            publisherService.Create(publisherDto);
            return Ok("Publisher added successfully");
        }

        // Problema de tracking
        [HttpPost("updateBook")] 
        public IActionResult UpdateBook([FromBody] BookDTO bookDTO)
        {
            var bookResult = bookService.GetById(bookDTO.Id);
            if (bookResult == null)
                return NoContent();
            bookService.Update(bookDTO);
            return Ok("Book updated successfully");
        }

        [HttpPost("updatePublisher")]
        public IActionResult UpdatePublisher([FromBody] PublisherDTO publisherDTO)
        {
            var bookResult = publisherService.GetById(publisherDTO.Id);
            if (bookResult == null)
                return NoContent();
            publisherService.Update(publisherDTO);
            return Ok("Book updated successfully");
        }

        [HttpPost("addBookCopy")]
        public IActionResult CreateBookCopy([FromBody] BookCopyDTO bcDto)
        {
            bcDto.Id = Guid.Empty;
            if (bcDto.BookId == Guid.Empty)
                return BadRequest("The book id can't be empty");

            if (bookService.GetById(bcDto.BookId) == null)
                return NotFound($"There is no book with id {bcDto.BookId}");

            bookCopyService.Create(bcDto);
            return Ok("Book Copy created successfully");
        }

        [HttpPost("updateBookCopy")]
        public IActionResult UpdateBookCopy([FromBody] BookCopyDTO bcDto)
        {
            var bookCopySearch = bookCopyService.GetById(bcDto.Id);
            if (bookCopySearch == null)
                return NoContent();

            bookCopyService.Update(bcDto);
            return Ok("Book copy updated successfully");
        }


        // DELETE

        [HttpDelete("deleteBook/{bookId}")]
        public IActionResult DeleteBook([FromRoute] Guid bookId)
        {
            var bookToDelete = bookService.GetById(bookId);
            if (bookCopyService.GetCountByBookId(bookId) == 0)
                return NoContent();

            if (bookService.BookHasCopiesBorrowed(bookId))
                return Forbid("You can't delete a book that has copies that are currently borrowed");

            bookService.Delete(bookToDelete);
            return Ok("Book deleted successfully");
        }

        [HttpDelete("deletePublisher/{publisherId}")]
        public IActionResult DeletePublisher([FromRoute] Guid publisherId)
        {
            var publisherToDelete = publisherService.GetById(publisherId);
            var booksByPublisher = bookService.GetBooksFromPublisher(publisherId);
            bool okDelete = true;
            foreach(var book in booksByPublisher)
            {
                if (bookService.BookHasCopiesBorrowed(book.Id))
                {
                    okDelete = false;
                    break;
                }
            }

            if (!okDelete)
                return Forbid("You can't delete a publisher that currently has book copies borrowed");

            publisherService.Delete(publisherToDelete);
            return Ok("Publisher deleted successfully");
        }

        [HttpDelete("deleteBookCopy/{copyId}")]
        public async Task<IActionResult> DeleteBookCopy([FromRoute] Guid copyId)
        {
            if (await bookCopyService.IsCopyBorrowed(copyId))
                return Forbid("You can't delete a copy that is currently borrowed");
            var bookToDelete = bookCopyService.GetById(copyId);
            if (bookToDelete == null)
                return NoContent();
            
            bookCopyService.Delete(bookToDelete);
            return Ok("Book copy deleted successfully");
        }
        
    }
}
