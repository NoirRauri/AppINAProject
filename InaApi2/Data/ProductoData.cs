using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ProductoData:IData<TbProducto>
    {
        public readonly DbProyectoInaContext _context;

        public ProductoData(DbProyectoInaContext context)
        {
            _context = context;
        }

        public async Task<bool> actualizar(TbProducto entity)
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

        public async Task<bool> eliminar(TbProducto entity)
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

        public async Task<TbProducto> guardar(TbProducto entity)
        {
            try
            {
                _context.TbProductos.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TbProducto> obtenerPorId(TbProducto entity)
        {
            try
            {
                return await _context.TbProductos
                        .Where(x => x.IdProducto == entity.IdProducto && x.Estado == true).SingleOrDefaultAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<TbProducto>> obtenerTodos()
        {
            try
            {
                return await _context.TbProductos.Where(x => x.Estado == true).ToListAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
