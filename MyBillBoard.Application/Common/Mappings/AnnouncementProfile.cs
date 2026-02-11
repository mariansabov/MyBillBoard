using AutoMapper;
using MyBillBoard.Application.Features.Announcements.Dtos;
using MyBillBoard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBillBoard.Application.Common.Mappings
{
    public class AnnouncementProfile : Profile
    {
        public AnnouncementProfile()
        {
            CreateMap<Announcement, AnnouncementDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status ? "Active" : "Inactive"))
                .ForMember(dest => dest.CategorySubCategoryTitle, opt => opt.MapFrom(src => $"{src.Category.Title} / {src.SubCategory.Title}"));
        }
    }
}
