using AutoMapper;
using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Helpers
{
    public class AutoMapperProfiles: AutoMapper.Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserListDto>();
            CreateMap<Company, CompanyListDto>().ForMember(dest=>dest.UserEmail, opt => {
                opt.MapFrom(src => src.User.Email);
            });
            CreateMap<Advert, AdvertListDto>().ForMember(dest => dest.CategoryTitle, opt =>
               {
                   opt.MapFrom(src => src.Category.Title);
               }).ForMember(dest=>dest.CompanyTitle, opt=> {
                   opt.MapFrom(src => src.User.Company.Title);
               }).ForMember(dest => dest.CompanyId, opt => {
                   opt.MapFrom(src => src.User.Company.Id);
               });
            CreateMap<Recourse, RecourseUserListDto>().ForMember(dest => dest.AdvertTitle, opt => { opt.MapFrom(src => src.Advert.Title); });
            CreateMap<Advert, AdvertUpdateDto>();
            CreateMap<AdvertUpdateDto, Advert>();
        }
    }
}
