using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class TipoVentaData : IData<TbTipoVenta>
    {
        public readonly DbProyectoInaContext _context;

        public TipoVentaData(DbProyectoInaContext context)
        {
            _context = context;
        }
        public Task<bool> actualizar(TbTipoVenta entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> eliminar(TbTipoVenta entity)
        {
            throw new NotImplementedException();
        }

        public Task<TbTipoVenta> guardar(TbTipoVenta entity)
        {
            throw new NotImplementedException();
        }

        public async Task<TbTipoVenta> obtenerPorId(TbTipoVenta entity)
        {
            try
            {
                return await _context.TbTipoVentas
                        .Where(x => x.Id == entity.Id && x.Estado == true).SingleOrDefaultAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<TbTipoVenta>> obtenerTodos()
        {
            try
            {
                return await _context.TbTipoVentas.Where(x => x.Estado == true).ToListAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
