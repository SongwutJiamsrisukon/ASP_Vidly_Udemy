using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AutoMapper;
using ASP_Vidly_Udemy.Dtos;
using ASP_Vidly_Udemy.Models;


namespace ASP_Vidly_Udemy.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // API -> Outbound
            Mapper.CreateMap<Customer, CustomerDto>(); //Generic <Source,Target> //ใช้ตอน GET จะสน Id เพราะต้องเอาไปแสดงค่าใน HiddenField
            // API <- Inbound
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());//ใช้ตอน POST,PUT จะไม่สนใจ Id เพราะ Id จะ gen จาก DB ของ customer

            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>().ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<MembershipTypeDto, MembershipType>();

            Mapper.CreateMap<Genre, GenreDto>();
            Mapper.CreateMap<GenreDto, Genre>();
        }
            
    }
}