using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Klik.Dtos;
using Klik.Models;

namespace Klik.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<GameSession, GameSessionDto>();
            Mapper.CreateMap<GameSessionDto, GameSession>();
        }
    }
}