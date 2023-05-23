using AutoMapper;
using Entities;
using InaApi2.Models;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace InaApi2.Controllers
{
    [ApiController]
    [Route("api/tipocliente")]
    public class TipoClienteController : ControllerBase
    {
        private readonly IService<TbTipoCliente> _TipoClienteService;
        //inyeccion para el mapeo
        private readonly IMapper _mapper;

        public TipoClienteController(IService<TbTipoCliente> tipoClienteService, IMapper mapper)
        {
            _TipoClienteService = tipoClienteService;
            _mapper = mapper;
        }

        // GET all
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<TipoClientesDTO>>> get()
        {
            try
            {
                List<TbTipoCliente> lista = await _TipoClienteService.obtenerTodos();
                //Destino     Origen
                var listaDTO = _mapper.Map<List<TipoClientesDTO>>(lista);
                if (listaDTO == null)
                {
                    return NotFound("No hay datos de tipo cliente");
                }
                return Ok(listaDTO);
            }
            catch (Exception)
            {
                return BadRequest("Surgio un error");
            }
        }

        // GET for ID
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoClientesDTO>> getById(int id)
        {
            try
            {
                TbTipoCliente tipoCliente = new TbTipoCliente();

                tipoCliente.Id = id;
                tipoCliente = await _TipoClienteService.obtenerPorId(tipoCliente);
                if (tipoCliente == null)
                {
                    return NotFound("No existe el tipo cliente con ese ID");
                }
                TipoClientesDTO tipoClienteDTO = _mapper.Map<TipoClientesDTO>(tipoCliente);
                return Ok(tipoClienteDTO);
            }
            catch (Exception)
            {
                return BadRequest("No existe el tipo cliente con ese ID");
            }

        }

        // POST
        [HttpPost]
        public async Task<ActionResult<ClienteDTO>> post([FromBody] TipoClientesDTO tipoClienteDTO)
        {
            try
            {
                TbTipoCliente tipoCliente = new TbTipoCliente();

                tipoCliente.Id = tipoClienteDTO.Id;
                tipoCliente = await _TipoClienteService.obtenerPorId(tipoCliente);

                if (tipoCliente != null)
                {
                    return NotFound("El tipo cliente ya existe");
                }

                tipoCliente = _mapper.Map<TbTipoCliente>(tipoClienteDTO);
                tipoCliente.Id = tipoClienteDTO.Id;
                // validar
                tipoCliente = await _TipoClienteService.guardar(tipoCliente);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("No se pudo crear el tipo cliente");
            }
        }

        // PATCH
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> patch(int id, [FromBody] TipoClientesDTO tipoClienteDTO)
        {

            try
            {
                TbTipoCliente tipoCliente = new TbTipoCliente();

                tipoCliente.Id = id;
                tipoCliente = await _TipoClienteService.obtenerPorId(tipoCliente);

                if (tipoCliente == null)
                {
                    return NotFound("Se encontro el tipo cliente");
                }

                tipoCliente = _mapper.Map<TbTipoCliente>(tipoClienteDTO);
                tipoCliente.Id = id;
                // validar

                var resp = _TipoClienteService.actualizar(tipoCliente);
                if (resp.Result)// por estar en un task
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("El tipo cliente no se modifico");
                }
            }
            catch (Exception)
            {

                return BadRequest("Surgio un error");

            }

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> delete(int id)
        {
            try
            {
                TbTipoCliente tipoCliente = new TbTipoCliente();
                tipoCliente.Id = id;
                tipoCliente = await _TipoClienteService.obtenerPorId(tipoCliente);
                if (tipoCliente == null)
                {
                    return NotFound("Cliente no existe");
                }

                tipoCliente = _mapper.Map<TbTipoCliente>(tipoCliente);
                tipoCliente.Estado = false;
                // validar

                var resp = _TipoClienteService.actualizar(tipoCliente);
                if (resp.Result)// por estar en un task
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("El cliente no se eliminado");
                }
            }
            catch (Exception)
            {

                return BadRequest("No se pudo eliminado el cliente");

            }

        }
    }
}
