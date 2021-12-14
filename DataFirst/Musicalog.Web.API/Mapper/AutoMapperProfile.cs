using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Musicalog.Domain.Models;
using Musicalog.Web.API.DTO;

namespace Musicalog.Web.API.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Album, AlbumDTO>();
            CreateMap<Artist, ArtistDTO>();
        }
    }
}
