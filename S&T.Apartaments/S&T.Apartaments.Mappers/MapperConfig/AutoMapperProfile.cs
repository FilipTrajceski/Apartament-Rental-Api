using AutoMapper;
using S_T.Apartaments.Application.Common.DTOs.ApartmentDto;
using S_T.Apartaments.Application.Common.DTOs.UserDto;
using S_T.Apartaments.Entities.Entities;

namespace S_T.Apartaments.Mappers.MapperConfig
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region UserMapping
            CreateMap<User, LogInUserDto>().ReverseMap();
            CreateMap<User, RegisterUserDto>().ReverseMap();   
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, ChangeUserRoleDto>().ReverseMap();
            #endregion

            #region ApartmentMapping
            CreateMap<Apartment, BaseApartmentDto>().ReverseMap();
            CreateMap<Apartment, ApartmentDto>().ReverseMap();
            CreateMap<Apartment, UpdateApartmentDto>().ReverseMap();
            #endregion
        }
    }
}
