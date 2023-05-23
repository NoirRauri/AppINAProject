using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TipoPagoService : IService<TbTipoPago>
    {
        private readonly IData<TbTipoPago> _tbTipoPagos;

        public TipoPagoService(IData<TbTipoPago> tbTipoPagos)
        {
            _tbTipoPagos = tbTipoPagos;
        }

        public async Task<bool> actualizar(TbTipoPago entity)
        {
            return await _tbTipoPagos.actualizar(entity);
        }

        public async Task<bool> eliminar(TbTipoPago entity)
        {
            return await _tbTipoPagos.eliminar(entity);
        }

        public async Task<TbTipoPago> guardar(TbTipoPago entity)
        {
            return await _tbTipoPagos.guardar(entity);
        }

        public async Task<TbTipoPago> obtenerPorId(TbTipoPago endidad)
        {
            return await _tbTipoPagos.obtenerPorId(endidad);
        }

        public async Task<List<TbTipoPago>> obtenerTodos()
        {
            return await _tbTipoPagos.obtenerTodos();
        }
    }
}
