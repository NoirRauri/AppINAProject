using AutoMapper;
using Entities;
using InaApi2.Models;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace InaApi2.Controllers
{
    [ApiController]
    [Route("api/cliente")]
    public class ClienteController : ControllerBase

    {
        public readonly IService<TbCliente> _IClienteService;   
        private readonly IService<TbTipoCliente> _TipoClienteService;   
        //inyeccion para el mapeo
        private readonly IMapper _mapper;


        //instancio en un constructor la  instancia que me llega
        public ClienteController(IService<TbCliente> IClienteService, IMapper mapper, IService<TbTipoCliente> tipoClienteService)
        {
            this._IClienteService = IClienteService;
            _mapper = mapper;
            _TipoClienteService = tipoClienteService;
        }

        // GET all
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ClienteDTO>>> get()
        {
            try
            {
                List<TbCliente> lista = await _IClienteService.obtenerTodos();
                //Destino     Origen
                var listaDTO = _mapper.Map<List<ClienteDTO>>(lista);
                if (listaDTO==null)
                {
                    return NotFound("No existe el cliente con ese ID");
                }
                return Ok(listaDTO);
            }
            catch (Exception)
            {
                return BadRequest("No existe el cliente con ese ID");
            }
        }

        // GET for ID
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClienteDTO>> getById(string id) 
        {
            try
            {
                TbCliente cliente = new TbCliente();

                cliente.Cedula = id;
                cliente = await _IClienteService.obtenerPorId(cliente);
                if (cliente == null)
                {
                    return NotFound("No existe el cliente con ese ID");
                }
                ClienteDTO clienteDTO = _mapper.Map<ClienteDTO>(cliente);
                return Ok(clienteDTO);
            }
            catch (Exception)
            {
                return BadRequest("No existe el cliente con ese ID");
            }

        }

        // POST
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClienteDTO>> post([FromBody] ClienteDTO clienteDTO)
        {
            try
            {
                TbCliente clienteEnt = new TbCliente();

                clienteEnt.Cedula = clienteDTO.Cedula;
                clienteEnt = await _IClienteService.obtenerPorId(clienteEnt);

                if (clienteEnt != null)
                {
                    return NotFound("Cliente existe");
                }

                TbTipoCliente tipoCliente = new TbTipoCliente();

                tipoCliente.Id = clienteDTO.TipoCliente;
                tipoCliente = await _TipoClienteService.obtenerPorId(tipoCliente);

                clienteEnt = _mapper.Map<TbCliente>(clienteDTO);
                clienteEnt.Cedula = clienteDTO.Cedula;
                clienteEnt.CedulaNavigation.Cedula = clienteDTO.Cedula;
                // validar
                TbCliente cliente = _mapper.Map<TbCliente>(clienteDTO);
                await _IClienteService.guardar(cliente);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("No se pudo crear el cliente");
            }
        }

        // PATCH
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> patch(string id,[FromBody] ClienteDTO clienteDTO)
        {

            try
            {
                TbCliente clienteEnt = new TbCliente();

                clienteEnt.Cedula = id;
                clienteEnt = await _IClienteService.obtenerPorId(clienteEnt);

                if (clienteEnt == null)
                {
                    return NotFound("Cliente modificado");
                }

                TbTipoCliente tipoCliente = new TbTipoCliente();

                tipoCliente.Id = clienteDTO.TipoCliente;
                tipoCliente = await _TipoClienteService.obtenerPorId(tipoCliente);

                clienteEnt = _mapper.Map<TbCliente>(clienteDTO);
                clienteEnt.Cedula = id;
                clienteEnt.CedulaNavigation.Cedula = id;
                // validar

                var resp = _IClienteService.actualizar(clienteEnt);
                if (resp.Result)// por estar en un task
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("El cliente no se modifico");
                }
            }
            catch (Exception)
            {

                return BadRequest("No se pudo crear el cliente");

            }

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> delete(string id)
        {
            try
            {
                TbCliente clienteEnt = new TbCliente();
                clienteEnt.Cedula = id;
                clienteEnt = await _IClienteService.obtenerPorId(clienteEnt);
                if (clienteEnt == null)
                {
                    return NotFound("Cliente no existe");
                }

                clienteEnt = _mapper.Map<TbCliente>(clienteEnt);
                clienteEnt.Estado = false;
                // validar

                var resp = _IClienteService.actualizar(clienteEnt);
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
