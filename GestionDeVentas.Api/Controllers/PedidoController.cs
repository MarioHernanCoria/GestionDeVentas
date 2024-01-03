using AutoMapper;
using GestionDeVentas.Application.Dtos;
using GestionDeVentas.Application.Interfaces.IUnitOfWork;
using GestionDeVentas.Domain.Entities;
using GestionDeVentas.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeVentas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PedidoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerPedidos()
        {
            var pedidos = await _unitOfWork.PedidoRepository.GetAll();

            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPedidoPorId(int id)
        {
            try
            {
                var pedido = await _unitOfWork.PedidoRepository.GetById(id);

                if (pedido == null)
                {
                    return NotFound();
                }

                return Ok(pedido);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CrearPedido([FromBody] Pedido pedido)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _unitOfWork.PedidoRepository.Insert(pedido);
                var saveChangesResult = await _unitOfWork.Complete();

                if (saveChangesResult > 0)
                {
                    var pedidoDTO = _mapper.Map<PedidoDto>(pedido);
                    return Ok(pedidoDTO);
                }
                else
                {
                    return ResponseFactory.CreateSuccessResponse(201, "Trabajo registrado con exito!");
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return ResponseFactory.CreateErrorResponse(500, "No se pudo actualizar el trabajo");
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarPedido(int id, [FromBody] PedidoDto pedidoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pedidoExistente = await _unitOfWork.PedidoRepository.GetById(id);
            if (pedidoExistente == null)
            {
                return NotFound();
            }

            _mapper.Map(pedidoDto, pedidoExistente);
            _unitOfWork.PedidoRepository.Update(pedidoExistente);
            _unitOfWork.Complete();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarPedido(int id)
        {
            var result = await _unitOfWork.PedidoRepository.Delete(id);
            if (!result)
            {
                return ResponseFactory.CreateErrorResponse(500, "No se pudo eliminar el trabajo");
            }
            else
            {
                await _unitOfWork.Complete();
                return ResponseFactory.CreateSuccessResponse(200, "Eliminado");
            };
        }
    }
}
