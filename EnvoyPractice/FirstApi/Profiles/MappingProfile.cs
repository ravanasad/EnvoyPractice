using AutoMapper;
using FirstApi.Data.Entities;
using FirstApi.Dtos;

namespace FirstApi.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ReservationDto, Reservation>().ReverseMap();
            CreateMap<Reservation, CreateReservationDto>().ReverseMap();
            CreateMap<Reservation, UpdateReservationDto>().ReverseMap();
        }
    }
}
