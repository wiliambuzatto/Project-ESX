using AutoMapper;
using ESX.Domain.Entities;
using ESX.WebApi.Models;

namespace ESX.WebApi.Mappers
{
    public class MarcaMappingProfile : Profile
    {
        public MarcaMappingProfile()
        {
            CreateMap<Marca, MarcaObterModel>();
        }
    }
}