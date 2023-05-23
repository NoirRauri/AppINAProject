using AutoMapper;
using Data;
using Entities;
using InaApi2.Models;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace InaApi2.Controllers
{
    [ApiController]
    [Route("api/factura")]
    public class FacturaController : ControllerBase
    {
        public readonly IService<TbFactura> _IFacturaService;
        public readonly IService<TbProducto> _IProductoService;
        public readonly IService<TbCliente> _IClienteService;
        public readonly IService<TbTipoPago> _ITpPagoService;
        public readonly IService<TbTipoVenta> _ITpVentaService;
        public readonly IService<TbDetalleFactura> _IDetalleFacturaService;

        private readonly IMapper _mapper;

        public FacturaController(IService<TbFactura> iFacturaService, IService<TbProducto> iProductoService, 
                                IService<TbCliente> iClienteService, IService<TbTipoPago> iTpPagoService, 
                                IService<TbTipoVenta> iTpVentaService, IService<TbDetalleFactura> iDetalleFacturaService, IMapper mapper)
        {
            _IFacturaService = iFacturaService;
            _IProductoService = iProductoService;
            _IClienteService = iClienteService;
            _ITpPagoService = iTpPagoService;
            _ITpVentaService = iTpVentaService;
            _IDetalleFacturaService = iDetalleFacturaService;
            _mapper = mapper;
        }




        // GET_ALL
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ClienteDTO>>> get()
        {
            try
            {
                List<TbFactura> lista = await _IFacturaService.obtenerTodos();

                var listaDTO = _mapper.Map<List<TbFactura>>(lista);
                if (listaDTO == null)
                {
                    return NotFound("No hay datos que mostrar de facturas");
                }
                return Ok(listaDTO);
            }
            catch (Exception)
            {
                return BadRequest("Surgio un error al mostar datos de facturas");
            }
        }

        // GET_BY_ID
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> getById(string id)
        {
            try
            {
                TbFactura factura = new TbFactura();
                factura.IdFactura = Int32.Parse(id);
                factura = await _IFacturaService.obtenerPorId(factura);
                if (factura == null)
                {
                    return NotFound("No existe el factura con ese ID");
                }
                var facturaDTO = _mapper.Map<TbFactura>(factura);
                return Ok(facturaDTO);
            }
            catch (Exception)
            {
                return BadRequest("Surgio un error al mostar datos de la factura");
            }
        }

        // POST
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FacturaDTO>> post([FromBody] FacturaDTO facturaDTO)
        {
            try
            {
                // Verificacion de datos 
                if (!validarDatos(facturaDTO))
                {
                    return NotFound("Los datos estan incompletos");
                }

                // Instancia la factura y se mapea
                TbFactura factura = new TbFactura();
                factura = _mapper.Map<TbFactura>(facturaDTO);

                // Verifica el id Cliente
                TbCliente cliente = new TbCliente();
                cliente.Cedula = factura.IdCliente;
                cliente= await _IClienteService.obtenerPorId(cliente);
                if (cliente == null)
                {
                    return NotFound("El id del cliente no existe");
                }

                // Verifica el Id tipo Cliente
                TbTipoPago tipoPago = new TbTipoPago();
                tipoPago.Id = facturaDTO.TipoVenta;
                tipoPago = await _ITpPagoService.obtenerPorId(tipoPago);
                if (tipoPago == null)
                {
                    return NotFound("El id del tipo Pago no existe");
                }

                // Verifica el Id tipo Cliente
                TbTipoVenta tipoVenta = new TbTipoVenta();
                tipoVenta.Id = facturaDTO.TipoVenta;
                tipoVenta = await _ITpVentaService.obtenerPorId(tipoVenta);
                if (tipoVenta == null)
                {
                    return NotFound("El id del Tipo Venta no existe");
                }

                // Ciclo que almacena los detalles de la factura en lista
                foreach (var list in factura.TbDetalleFacturas)
                {
                    TbProducto producto = new TbProducto();
                    producto.IdProducto = list.IdProducto;
                    producto = await _IProductoService.obtenerPorId(producto);
                    if (producto == null)
                    {
                        return NotFound("El id producto no existe");
                    }
                    if (producto.Stock < list.Cant)
                    {
                        return NotFound("El stock del prodcuto es mayor al que hay");
                    }
                    producto.Stock = producto.Stock - list.Cant;
                    await _IProductoService.actualizar(producto);
                    //if (facturaDTO.TbDetalleFacturas.Where(x=>x.IdDetalleFactura==list.IdDetalleFactura).Count()>1)
                    //{
                    //    return NotFound("El stock del prodcuto es mayor al que hay");
                    //}
                }

                await _IFacturaService.guardar(factura);
                return Ok();

            }
            catch (Exception)
            {
                return BadRequest("Surgio un error al guardar datos de la factura");
            }

        }

        private bool validarDatos(FacturaDTO facturaDTO)
        {
            if (facturaDTO.IdFactura == null)
            {
                return false;
            }else if (facturaDTO.TipoPago == null)
            {
                return false;
            }
            else if (facturaDTO.TipoVenta == null)
            {
                return false;
            }else if (facturaDTO.IdCliente == null)
            {
                return false;
            }
            return true;
        }

        // PATCH
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FacturaDTO>> patch(int id,[FromBody] FacturaDTO facturaDTO)
        {
            try
            {
                // Instancio la factura,verifico si existe y se mapea
                TbFactura factura = new TbFactura();
                factura.IdFactura = id;
                factura = await _IFacturaService.obtenerPorId(factura);
                if (factura == null)
                {
                    return NotFound("El id de la factura no existe");
                }

                // Verifica el id Cliente
                TbCliente cliente = new TbCliente();
                cliente.Cedula = facturaDTO.IdCliente;
                cliente = await _IClienteService.obtenerPorId(cliente);
                if (cliente == null)
                {
                    return NotFound("El id del cliente no existe");
                }

                // Verifica el Id tipo Cliente
                TbTipoPago tipoPago = new TbTipoPago();
                tipoPago.Id = facturaDTO.TipoVenta;
                tipoPago = await _ITpPagoService.obtenerPorId(tipoPago);
                if (tipoPago == null)
                {
                    return NotFound("El id del tipo Pago no existe");
                }

                // Verifica el Id tipo Cliente
                TbTipoVenta tipoVenta = new TbTipoVenta();
                tipoVenta.Id = facturaDTO.TipoVenta;
                tipoVenta = await _ITpVentaService.obtenerPorId(tipoVenta);
                if (tipoVenta == null)
                {
                    return NotFound("El id del Tipo Venta no existe");
                }

                // Ciclo que almacena los detalles de la factura en lista
                foreach (var list in facturaDTO.TbDetalleFacturas)
                {
                    TbProducto producto = new TbProducto();
                    producto.IdProducto = list.IdProducto;
                    producto = await _IProductoService.obtenerPorId(producto);

                    if (producto == null)
                    {
                        return NotFound("El id producto no existe");
                    }
                    if (producto.Stock< list.Cant)
                    {
                        return NotFound("El stock del prodcuto es mayor al que hay");
                    }
                    if (facturaDTO.TbDetalleFacturas.Where(x => x.IdDetalleFactura == list.IdDetalleFactura).Count() > 1)
                    {
                        return NotFound("El stock del prodcuto es mayor al que hay");
                    }

                }

                factura = _mapper.Map<FacturaDTO, TbFactura>(facturaDTO, factura);
                factura.IdFactura = id;
                var resp = _IFacturaService.actualizar(factura);
                if (resp.Result)// por estar en un task
                {
                    return Ok("La factura a sido modificado");
                }
                else
                {
                    return BadRequest("La Factura no se modifico");
                }

            }
            catch (Exception)
            {
                return BadRequest("Surgio un error al guardar datos de la factura");
            }

        }

        // DELETE
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> delete(string id)
        {
            try
            {
                TbFactura factura = new TbFactura();
                factura.IdFactura = Int32.Parse(id);
                factura = await _IFacturaService.obtenerPorId(factura);
                if (factura == null)
                {
                    return NotFound("No existe el factura con ese ID");
                }
                factura = _mapper.Map<TbFactura>(factura);
                factura.Estado= false;
                var resp = _IFacturaService.eliminar(factura);
                if (resp.Result)
                {
                    return Ok("La factura se a eliminado correctamente");
                }
                else
                {
                    return BadRequest("La factura no se eliminado");
                }
            }
            catch (Exception)
            {
                return BadRequest("Surgio un error al eliminar la factura");
            }
        }

    }
}
