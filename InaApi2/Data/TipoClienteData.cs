using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class tipoClienteData : IData<TbTipoCliente>
    {
        public readonly DbProyectoInaContext _context;

        public tipoClienteData(DbProyectoInaContext context)
        {
            _context = context;
        }

        public async Task<bool> actualizar(TbTipoCliente entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> eliminar(TbTipoCliente entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<TbTipoCliente> guardar(TbTipoCliente entity)
        {
            try
            {
                _context.TbTipoClientes.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TbTipoCliente> obtenerPorId(TbTipoCliente entity)
        {
            try
            {
                return await _context.TbTipoClientes
                        .Where(x => x.Id == entity.Id && x.Estado == true).AsNoTracking().SingleOrDefaultAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<TbTipoCliente>> obtenerTodos()
        {
            try
            {
                return await _context.TbTipoClientes.Where(x => x.Estado == true).AsNoTracking().ToListAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
