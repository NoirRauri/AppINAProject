using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class TipoPagoData : IData<TbTipoPago>
    {
        public readonly DbProyectoInaContext _context;

        public TipoPagoData(DbProyectoInaContext context)
        {
            _context = context;
        }

        public Task<bool> actualizar(TbTipoPago entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> eliminar(TbTipoPago entity)
        {
            throw new NotImplementedException();
        }

        public Task<TbTipoPago> guardar(TbTipoPago entity)
        {
            throw new NotImplementedException();
        }

        public async Task<TbTipoPago> obtenerPorId(TbTipoPago entity)
        {
            try
            {
                return await _context.TbTipoPagos
                        .Where(x => x.Id == entity.Id && x.Estado == true).SingleOrDefaultAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<TbTipoPago>> obtenerTodos()
        {
            try
            {
                return await _context.TbTipoPagos.Where(x => x.Estado == true).ToListAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
