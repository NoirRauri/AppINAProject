
using AutoMapper;
using Entities;
using InaApi2.Models;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace InaApi2.Controllers
{
    [ApiController]
    [Route("api/producto")]
    public class ProductosController: ControllerBase
    {
        public readonly IService<TbProducto> _IProductoService;
        private readonly IMapper _mapper;

        public ProductosController(IService<TbProducto> iProductoService, IMapper mapper)
        {
            _IProductoService = iProductoService;
            _mapper = mapper;
        }

        // GET_ALL
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ProductoDTO>>> get()
        {
            try
            {
                List<TbProducto> lista = await _IProductoService.obtenerTodos();

                var listaDTO = _mapper.Map<List<TbProducto>>(lista);
                if (listaDTO == null)
                {
                    return NotFound("No hay datos que mostrar de Productos");
                }
                return Ok(listaDTO);
            }
            catch (Exception)
            {
                return BadRequest("Surgio un error al mostar datos de Productos");
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
                TbProducto producto = new TbProducto();
                producto.IdProducto = id;
                producto = await _IProductoService.obtenerPorId(producto);
                if (producto == null)
                {
                    return NotFound("No existe un producto con ese ID");
                }
                var productoDTO = _mapper.Map<TbProducto>(producto);
                return Ok(productoDTO);
            }
            catch (Exception)
            {
                return BadRequest("Surgio un error al mostar datos del Producto");
            }
        }

    }
}
