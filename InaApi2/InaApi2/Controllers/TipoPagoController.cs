using AutoMapper;
using Entities;
using InaApi2.Models;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace InaApi2.Controllers
{
    [ApiController]
    [Route("api/tipopago")]
    public class TipoPagoController : ControllerBase
    {
        private readonly IService<TbTipoPago> _TipoPagoService;
        private readonly IMapper _mapper;

        public TipoPagoController(IService<TbTipoPago> tipoPagoService, IMapper mapper)
        {
            _TipoPagoService = tipoPagoService;
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
                List<TbTipoPago> lista = await _TipoPagoService.obtenerTodos();

                var listaDTO = _mapper.Map<List<TipoPagoDTO>>(lista);
                if (listaDTO == null)
                {
                    return NotFound("No hay datos de tipo Pago");
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
