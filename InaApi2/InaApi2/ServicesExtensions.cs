using Data;
using Entities;
using Services;

namespace Microsoft.Extensions.DependencyInjection
    // clase estatica para agregar las inicializaciones de las inyecciones de independencias
{
    public static class ServicesExtensions
    {
        //metodo estatico
        public static IServiceCollection addServices(this IServiceCollection services) 
        {
            //capa negocios
            services.AddTransient<IService<TbCliente>,ClienteService>();
            services.AddTransient<IService<TbTipoCliente>, TipoClienteService>();
            services.AddTransient<IService<TbFactura>, FacturaServices>();
            services.AddTransient<IService<TbProducto>, ProductoService>();
            services.AddTransient<IService<TbTipoPago>,TipoPagoService> ();
            services.AddTransient<IService<TbTipoVenta>,TipoVentaService>();
            services.AddTransient<IService<TbDetalleFactura>,DetalleFacturaService>();


            //capa de datos
            services.AddTransient<IData<TbCliente>,ClienteData>();
            services.AddTransient<IData<TbTipoCliente>,tipoClienteData>();
            services.AddTransient<IData<TbFactura>,FacturaData>();
            services.AddTransient<IData<TbProducto>,ProductoData>();
            services.AddTransient<IData<TbTipoPago>,TipoPagoData>();
            services.AddTransient<IData<TbTipoVenta>,TipoVentaData>();
            services.AddTransient<IData<TbDetalleFactura>,DetalleFacturaData>();

            //antes del return agregamos las inyecciones de dependencias
            return services;
        }
    }
}
