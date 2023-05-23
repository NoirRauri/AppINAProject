using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DetalleFacturaData : IData<TbDetalleFactura>
    {
        private readonly DbProyectoInaContext _context;

        public DetalleFacturaData(DbProyectoInaContext context)
        {
            _context = context;
        }
        public Task<bool> actualizar(TbDetalleFactura entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> eliminar(TbDetalleFactura entity)
        {
            throw new NotImplementedException();
        }

        public Task<TbDetalleFactura> guardar(TbDetalleFactura entity)
        {
            throw new NotImplementedException();
        }

        public async Task<TbDetalleFactura> obtenerPorId(TbDetalleFactura entity)
        {
            try
            {
                return await _context.TbDetalleFacturas.Where(x => x.IdDetalleFactura == entity.IdDetalleFactura).AsNoTracking().SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<TbDetalleFactura>> obtenerTodos()
        {
            try
            {
                return await _context.TbDetalleFacturas.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
