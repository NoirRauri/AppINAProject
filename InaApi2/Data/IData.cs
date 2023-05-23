using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IData<entity>
    {
        Task<List<entity>> obtenerTodos();
        Task<entity> obtenerPorId(entity entity);
        Task<entity> guardar(entity entity);
        Task<bool> actualizar(entity entity);
        Task<bool> eliminar(entity entity);

    }
}
