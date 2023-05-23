using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    //La clase clienteservice implemente la interfaz iservice con un parametro de entidad

    public class ClienteService : IService<TbCliente>
    {
        private readonly IData<TbCliente> _clientesData;

        public ClienteService(IData<TbCliente> clientesData)
        {
            _clientesData = clientesData;
        }

        public async Task<bool> actualizar(TbCliente entity)
        {
            return await _clientesData.actualizar(entity);
        }

        public async Task<bool> eliminar(TbCliente entity)
        {
            return await _clientesData.eliminar(entity);
        }

        public async Task<TbCliente> guardar(TbCliente entity)
        {
            return await _clientesData.guardar(entity);
        }

        public async Task<TbCliente> obtenerPorId(TbCliente endidad)
        {
            return await _clientesData.obtenerPorId(endidad); 
        }

        async Task<List<TbCliente>> IService<TbCliente>.obtenerTodos()
        {
            return await _clientesData.obtenerTodos();
        }
    }
}
