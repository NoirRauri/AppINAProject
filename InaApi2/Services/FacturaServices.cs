using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class FacturaServices : IService<TbFactura>
    {
        private readonly IData<TbFactura> _facturaData;

        public FacturaServices(IData<TbFactura> facturaData)
        {
            _facturaData = facturaData;
        }

        public async Task<bool> actualizar(TbFactura entity)
        {
            try
            {
                return await _facturaData.actualizar(entity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> eliminar(TbFactura entity)
        {
            try
            {
                return await _facturaData.eliminar(entity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<TbFactura> guardar(TbFactura entity)
        {
            try
            {
                return await _facturaData.guardar(entity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<TbFactura> obtenerPorId(TbFactura endidad)
        {
            try
            {
                return await _facturaData.obtenerPorId(endidad);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<TbFactura>> obtenerTodos()
        {
            try
            {
                return await _facturaData.obtenerTodos();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
