using AutoMapper;
using PersonelProject.DTOS;
using PersonelProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelProject.Mappers
{
    public class MapperProfiles:Profile
    {
        public MapperProfiles()
        {
            CreateMap<Sehir, SehirDTO>().
                ForMember(des => des.sehirAd, opt => opt.MapFrom(src => src.SehirAd)).
                ForMember(des => des.sehirId, opt => opt.MapFrom(src => src.SehirId)).
                ForMember(des => des.resimYol, opt => opt.MapFrom(src => src.SehirResim));
            CreateMap<SehirDTO, Sehir>().
               ForMember(des => des.SehirAd, opt => opt.MapFrom(src => src.sehirAd)).
               ForMember(des => des.SehirId, opt => opt.MapFrom(src => src.sehirId)).
               ForMember(des => des.SehirResim, opt => opt.MapFrom(src => src.resimYol));

        }
    }
}
