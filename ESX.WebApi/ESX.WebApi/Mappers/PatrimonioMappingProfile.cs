using AutoMapper;
using ESX.Domain.Entities;
using ESX.WebApi.Models;

namespace ESX.WebApi.Mappers
{
    public class PatrimonioMappingProfile : Profile
    {
        public PatrimonioMappingProfile()
        {
            CreateMap<Patrimonio, PatrimonioObterModel>()
                .ForMember(dest => dest.Marca, opt => opt.MapFrom(x => Mapper.Map<MarcaObterModel>(x.Marca)));
        }
    }
}