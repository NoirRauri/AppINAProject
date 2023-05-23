using AutoMapper;
using Entities;
using InaApi2.Models;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace InaApi2.Controllers
{
    [ApiController]
    [Route("api/tipoventa")]
    public class TipoVentaController : ControllerBase
    {
        private readonly IService<TbTipoVenta> _TipoVentaService;
        private readonly IMapper _mapper;

        public TipoVentaController(IService<TbTipoVenta> tipoVentaService, IMapper mapper)
        {
            _TipoVentaService = tipoVentaService;
            _mapper = mapper;
        }


        // GET all
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<TbTipoPago>>> get()
        {
            try
            {
                List<TbTipoVenta> lista = await _TipoVentaService.obtenerTodos();

                var listaDTO = _mapper.Map<List<TbTipoVenta>>(lista);
                if (listaDTO == null)
                {
                    return NotFound("No hay datos de tipo Venta");
                }
                return Ok(listaDTO);
            }
            catch (Exception)
            {
                return BadRequest("Surgio un error");
            }
        }
    }
}
