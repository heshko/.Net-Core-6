using AutoMapper;
using HeshkoBookWeb.Models.Dto;
using HeshkoBookWeb.Models.Entity;

namespace HeshkoBookWeb.Mapping
{
    public class Mapper :Profile
    {
        public Mapper()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}
