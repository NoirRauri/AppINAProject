using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductoService : IService<TbProducto>
    {
        private readonly IData<TbProducto> _productoData;

        public ProductoService(IData<TbProducto> productoData)
        {
            _productoData = productoData;
        }

        public async Task<bool> actualizar(TbProducto entity)
        {
            try
            {
                return await _productoData.actualizar(entity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> eliminar(TbProducto entity)
        {
            try
            {
                return await _productoData.eliminar(entity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<TbProducto> guardar(TbProducto entity)
        {
            try
            {
                return await _productoData.guardar(entity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<TbProducto> obtenerPorId(TbProducto endidad)
        {
            try
            {
                return await _productoData.obtenerPorId(endidad);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<TbProducto>> obtenerTodos()
        {
            try
            {
                return await _productoData.obtenerTodos();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
