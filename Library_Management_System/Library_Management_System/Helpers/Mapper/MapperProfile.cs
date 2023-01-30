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
            CreateMap<User, UserInfoDTO>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(source => source.Id))
                .ForMember(dest => dest.FirstName, opts => opts.MapFrom(source => source.FirstName))
                .ForMember(dest => dest.LastName, opts => opts.MapFrom(source => source.LastName))
                .ForMember(dest => dest.Email, opts => opts.MapFrom(source => source.Email))
                .ForMember(dest => dest.UserName, opts => opts.MapFrom(source => source.UserName))
                .ForMember(dest => dest.Age, opts => opts.MapFrom(source => source.Age))
                .ForMember(dest => dest.PhoneNumber, opts => opts.MapFrom(source => source.PhoneNumber))
                .ForMember(dest => dest.City, opts => opts.MapFrom(source => source.City))
                .ForMember(dest => dest.Role, opts => opts.MapFrom(source => source.Role))
                .ReverseMap();





            //CreateMap<Student, StudentDTO>()
            //   .ForMember(dest => dest.StudentId,
            //   opts => opts.MapFrom(source => source.Id));
        }
    }
}
