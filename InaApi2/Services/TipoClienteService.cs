using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TipoClienteService : IService<TbTipoCliente>
    {
        private readonly IData<TbTipoCliente> _tbTipoCliente;

        public TipoClienteService(IData<TbTipoCliente> tbTipoCliente)
        {
            _tbTipoCliente = tbTipoCliente;
        }

        public async Task<bool> actualizar(TbTipoCliente entity)
        {
            return await _tbTipoCliente.actualizar(entity);
        }

        public async Task<bool> eliminar(TbTipoCliente entity)
        {
            return await _tbTipoCliente.eliminar(entity);
        }

        public async Task<TbTipoCliente> guardar(TbTipoCliente entity)
        {
            return await _tbTipoCliente.guardar(entity);
        }

        public async Task<TbTipoCliente> obtenerPorId(TbTipoCliente endidad)
        {
            return await _tbTipoCliente.obtenerPorId(endidad);
        }

        public async Task<List<TbTipoCliente>> obtenerTodos()
        {
            return await _tbTipoCliente.obtenerTodos();
        }
    }
}
