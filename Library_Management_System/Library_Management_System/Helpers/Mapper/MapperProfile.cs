using AutoMapper;
using Library_Management_System.Models;
using Library_Management_System.Models.DTOs;
using Library_Management_System.Models.DTOs.UserDTO;

namespace Library_Management_System.Helpers.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Author, AuthorDTO>().ReverseMap();
            CreateMap<AuthorsWriteBooks, AuthorsWriteBooksDTO>().ReverseMap();
            CreateMap<BookCopy, BookCopyDTO>().ReverseMap();
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<Publisher, PublisherDTO>().ReverseMap();
            CreateMap<SubscriptionCard, SubscriptionCardDTO>().ReverseMap();
            CreateMap<UserBorrowsCopy, UserBorrowsCopyDTO>().ReverseMap();
        }
    }
}
