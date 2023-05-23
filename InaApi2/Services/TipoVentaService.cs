using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TipoVentaService : IService<TbTipoVenta>
    {
        private readonly IData<TbTipoVenta> _tbTipoVenta;

        public TipoVentaService(IData<TbTipoVenta> tbTipoVenta)
        {
            _tbTipoVenta = tbTipoVenta;
        }

        public async Task<bool> actualizar(TbTipoVenta entity)
        {
            return await _tbTipoVenta.actualizar(entity);
        }

        public async Task<bool> eliminar(TbTipoVenta entity)
        {
            return await _tbTipoVenta.eliminar(entity);
        }

        public async Task<TbTipoVenta> guardar(TbTipoVenta entity)
        {
            return await _tbTipoVenta.guardar(entity);
        }

        public async Task<TbTipoVenta> obtenerPorId(TbTipoVenta endidad)
        {
            return await _tbTipoVenta.obtenerPorId(endidad);
        }

        public async Task<List<TbTipoVenta>> obtenerTodos()
        {
            return await _tbTipoVenta.obtenerTodos();
        }
    }
}
