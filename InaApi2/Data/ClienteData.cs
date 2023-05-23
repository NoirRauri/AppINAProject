using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ClienteData : IData<TbCliente>
    {
        private readonly DbProyectoInaContext _context;
        public ClienteData(DbProyectoInaContext context) 
        {
            _context= context;
        }
        public async Task<bool> actualizar(TbCliente entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.Entry(entity.CedulaNavigation).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> eliminar(TbCliente entity)
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

        public async Task<TbCliente> guardar(TbCliente entity)
        {
            try
            {
                _context.TbClientes.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<TbCliente> obtenerPorId(TbCliente endidad)
        {
            try
            {
                return await _context.TbClientes.Include("CedulaNavigation")
                        .Where(x => x.Cedula.Trim() == endidad.Cedula.Trim() && x.Estado == true).SingleOrDefaultAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        async Task<List<TbCliente>> IData<TbCliente>.obtenerTodos()
        {
            try
            {
                return await _context.TbClientes.Include("CedulaNavigation").Where(x=>x.Estado==true).ToListAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }


    
}
