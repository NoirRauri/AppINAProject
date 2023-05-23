using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IService<entity>
    {
        Task<List<entity>> obtenerTodos();
        Task<entity> obtenerPorId(entity endidad);
        Task<entity> guardar(entity entity);
        Task<bool> actualizar(entity entity);
        Task<bool> eliminar(entity entity);

    }
}
