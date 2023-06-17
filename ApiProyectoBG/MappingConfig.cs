using ApiBalance.Modelo;
using ApiBalance.Modelo.Dto;
using AutoMapper;

namespace ApiBalance
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<CuentasI, CuentasDto>();
            CreateMap<CuentasDto, CuentasI>();

            CreateMap<Entradas, EntradasDto>();
            CreateMap<EntradasDto, Entradas>();

            CreateMap<Salidas, SalidasDto>();
            CreateMap<SalidasDto, Salidas>();

            CreateMap<CuentasI,CuentasDto>().ReverseMap();
            CreateMap<CuentasI, CuentasDtoCreateOrUpdate>().ReverseMap();
            CreateMap<Entradas, EntradasDto>().ReverseMap();
            CreateMap<Salidas, SalidasDto>().ReverseMap();
        }
    }
}
