﻿using Library_Management_System.Models;
using Library_Management_System.Models.Enums;
using Microsoft.Extensions.Primitives;

namespace Library_Management_System.Repositories.BookCopyRepository
{
    public interface IBookCopyRepository
    {
        public List<BookCopy> GetBookCopiesOrderedByPriceAsc();
        public List<BookCopy> GetBookCopiesOrderedByPriceDesc();
        public List<BookCopy> GetBookCopiesByCoverType(string coverType);
        public List<BookCopy> GetBookCopiesByBookTitle(string title);
        public List<BookCopy> GetBookCopiesByBookTitleOrderByPriceAsc(string title);
        public List<BookCopy> GetBookCopiesByBookTitleOrderByPriceDesc(string title);
        public List<BookCopy> GetBookCopiesByBookTitleAndCoverType(string title, string coverType);

    }
}