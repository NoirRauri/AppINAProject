using AutoMapper;
using Entities;
using InaApi2.Models;

namespace InaApi2
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<TbCliente, ClienteDTO>()
                .ForMember(dest => dest.Cedula, opt => opt.MapFrom(src => src.CedulaNavigation.Cedula))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.CedulaNavigation.Nombre))
                .ForMember(dest => dest.Apellido1, opt => opt.MapFrom(src => src.CedulaNavigation.Apellido1))
                .ForMember(dest => dest.Apellido2, opt => opt.MapFrom(src => src.CedulaNavigation.Apellido2))
                .ForMember(dest => dest.Genero, opt => opt.MapFrom(src => src.CedulaNavigation.Genero))
                .ForMember(dest => dest.FechaNac, opt => opt.MapFrom(src => src.CedulaNavigation.FechaNac)).ReverseMap();

            CreateMap<TbFactura, FacturaDTO>().ReverseMap();

            CreateMap<TbDetalleFactura, DetalleFacturaDTO>().ReverseMap();

            CreateMap<TbProducto, ProductoDTO>().ReverseMap();

            CreateMap<TbTipoCliente, TipoClientesDTO>().ReverseMap();

            CreateMap<TbTipoPago, TipoPagoDTO>().ReverseMap();

            CreateMap<TbTipoVenta, TipoVentaDTO>().ReverseMap();

        }
    }
}
