using AutoMapper;
using TodoAppEFCore.Model;
using TodoAppEFCore.ViewModels;

namespace TodoAppEFCore.Settings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Todo, TodoViewModel>().ReverseMap();
        }
    }
}
