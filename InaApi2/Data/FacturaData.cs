using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class FacturaData : IData<TbFactura>
    {
        private readonly IData<TbProducto> _productoData;
        private readonly IData<TbDetalleFactura> _DetalleFacturaData;
        private readonly DbProyectoInaContext _context;
        public FacturaData(IData<TbProducto> productoData, IData<TbDetalleFactura> detalleFacturaData, DbProyectoInaContext context)
        {
            _productoData = productoData;
            _DetalleFacturaData = detalleFacturaData;
            _context = context;
        }

        public async Task<bool> actualizar(TbFactura entity)
        {
            try
            {
                TbProducto producto;
                var detallesConProductos = await _context.TbDetalleFacturas
                                            .Where(df => df.IdFactura == entity.IdFactura)
                                            .AsNoTracking()
                                            .ToListAsync();

                foreach (var detalle in entity.TbDetalleFacturas)
                {
                    var actualice = false;
                    producto = await _context.TbProductos
                                .Where(x => x.IdProducto == detalle.IdProducto && x.Estado == true)
                                .SingleOrDefaultAsync();

                    var detalleExistente = detallesConProductos.FirstOrDefault(df => df.IdDetalleFactura == detalle.IdDetalleFactura);

                    if (detalleExistente != null)
                    {
                        if (detalleExistente.Cant > detalle.Cant)
                        {
                            producto.Stock += detalleExistente.Cant - detalle.Cant;
                            actualice = true;
                        }
                        else if (detalleExistente.Cant < detalle.Cant)
                        {
                            producto.Stock -= detalle.Cant - detalleExistente.Cant;
                            actualice = true;
                        }

                        _context.Entry(detalle).State = EntityState.Modified;
                    }
                    else
                    {
                        _context.Entry(detalle).State = EntityState.Added;
                        producto.Stock -= detalle.Cant;
                        actualice = true;
                    }

                    if (actualice)
                    {
                        _context.Entry(producto).State = EntityState.Modified;
                    }
                }

                foreach (var detalle in detallesConProductos)
                {
                    producto = detalle.IdProductoNavigation;
                    if (entity.TbDetalleFacturas.FirstOrDefault(x => x.IdDetalleFactura == detalle.IdDetalleFactura) == null)
                    {
                        producto.Stock += detalle.Cant;
                        _context.Entry(producto).State = EntityState.Modified;
                        _context.Entry(detalle).State = EntityState.Deleted;
                    }
                }
                // modifica en el contexto la factura y manda a guarda todos los cambios
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> eliminar(TbFactura entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TbFactura> guardar(TbFactura entity)
        {
            try
            {
                _context.TbFacturas.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<TbFactura> obtenerPorId(TbFactura entity)
        {
            try
            {
                return await _context.TbFacturas.Include("TbDetalleFacturas").Where(x => x.IdFactura == entity.IdFactura && x.Estado==true).AsNoTracking().SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<TbFactura>> obtenerTodos()
        {
            try
            {
                return await _context.TbFacturas.Include("TbDetalleFacturas").Where(x=>x.Estado==true).AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
