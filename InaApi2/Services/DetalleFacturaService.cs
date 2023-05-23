using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DetalleFacturaService : IService<TbDetalleFactura>
    {
        private readonly IData<TbDetalleFactura> _DetalleFactura;

        public DetalleFacturaService(IData<TbDetalleFactura> DetalleFactura)
        {
            _DetalleFactura = DetalleFactura;
        }
        public Task<bool> actualizar(TbDetalleFactura entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> eliminar(TbDetalleFactura entity)
        {
            throw new NotImplementedException();
        }

        public Task<TbDetalleFactura> guardar(TbDetalleFactura entity)
        {
            throw new NotImplementedException();
        }

        public async Task<TbDetalleFactura> obtenerPorId(TbDetalleFactura endidad)
        {
            try
            {
                return await _DetalleFactura.obtenerPorId(endidad);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<TbDetalleFactura>> obtenerTodos()
        {
            try
            {
                return await _DetalleFactura.obtenerTodos();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
