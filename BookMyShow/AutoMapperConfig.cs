using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Models.CoreModels;
using Models.Enums;
using connString;
namespace BookMyShow
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration Initialize()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<int, SeatStatus>().ConvertUsing(new SeatStatusTypeConverter());
                cfg.CreateMap<Address, AddressDTO>();
                cfg.CreateMap<City, CityDTO>();
                cfg.CreateMap<Movie, MovieDTO>();
                cfg.CreateMap<MovieTicket, MovieTicketDTO>();
                cfg.CreateMap<Screen, ScreenDTO>();
                cfg.CreateMap<Seat, SeatDTO>();
                cfg.CreateMap<Show, ShowDTO>();
                cfg.CreateMap<Theatre, TheatreDTO>();
                cfg.CreateMap<User, UserDTO>();
            });
            config.AssertConfigurationIsValid();
            return config;
        }
    }
    public class SeatStatusTypeConverter : ITypeConverter<int, SeatStatus>
    {
        public SeatStatus Convert(int source, SeatStatus destination, ResolutionContext context)
        {
            return (SeatStatus) source;
        }
    }
}