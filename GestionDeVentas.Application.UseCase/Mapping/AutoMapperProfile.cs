using AutoMapper;
using GestionDeVentas.Application.Dtos;
using GestionDeVentas.Domain.Entities;

namespace GestionDeVentas.Application.UseCase.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Cliente, ClienteDto>()
                .ForMember(dest => dest.NombreCompleto, opt => opt.MapFrom(src => $"{src.Nombre} {src.Apellido1} {src.Apellido2}"))
                .ReverseMap();
            CreateMap<Comercial, ComercialDto>()
                .ForMember(dest => dest.NombreCompleto, opt => opt.MapFrom(src => $"{src.Nombre} {src.Apellido1} {src.Apellido2}"))
                .ReverseMap();
            CreateMap<Pedido, PedidoDto>();
        }
    }
}
