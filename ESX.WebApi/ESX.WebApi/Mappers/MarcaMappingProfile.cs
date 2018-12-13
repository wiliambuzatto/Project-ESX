using AutoMapper;
using ESX.Domain.Entities;
using ESX.WebApi.Models;
using System.Collections.Generic;

namespace ESX.WebApi.Mappers
{
    public class MarcaMappingProfile : Profile
    {
        public MarcaMappingProfile()
        {
            CreateMap<Marca, MarcaObterModel>();

            CreateMap<Marca, MarcaPatrimoniosObterModel>()
                .ForMember(dest => dest.Patrimonios, opt => opt.MapFrom(x => Mapper.Map<List<MarcaPatrimoniosModel>>(x.Patrimonios)));
        }
    }
}