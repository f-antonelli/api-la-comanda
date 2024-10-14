﻿using Microsoft.AspNetCore.Mvc;
using Restaurante.Dto.Pedido;
using Restaurante.DTo;
using Restaurante.Entities;
using Restaurante.Repository;
using Restaurante.Services;
using Restaurante.Services.Interfaces;

namespace Restaurante.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidosService _pedidosService;

        public PedidosController(IPedidosService pedidosService)
        {
            _pedidosService = pedidosService;
        }

       [HttpGet("{id}")]
        public async Task<ActionResult<Pedidos>> GetPedidoById(string id)
        {
            try
            {
                var pedido = await _pedidosService.GetById(id);

                if (pedido == null)
                {
                    return NotFound();
                }
                return Ok(pedido);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpPut("update/{id}")]
        public async Task<ActionResult<Productos>> update(string id, PedidoResponseDto pedidoDto)
        {
            try
            {
                await _pedidosService.Update(id, pedidoDto);
                return Ok(true);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("add")]
        public async Task<ActionResult<PedidoResponseDto>> CreatePedido(PedidoCreateRequestDto pedidoCreateDto)
        {
            try
            {
                var result = await _pedidosService.Create(pedidoCreateDto);

                if (result != null)
                    return Ok(result);

                return BadRequest(false);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<PedidoResponseDto>> Delete(string id)
        {
            try
            {
                await _pedidosService.Delete(id);

            
                    return Ok(true);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [HttpGet("getAll")]
        public async Task<ActionResult<Productos>> GetAll()
        {
            var productos = await _pedidosService.GetAll();

            if (productos == null)
            {
                return NotFound();
            }

            return Ok(productos);
        }

        [HttpPatch("ActualizarAPreparación")]
        public async Task<ActionResult<PedidoResponseDto>> ActualizarAPreparación(string codigoPedido, int tiempoEstimado)
        {
            var pedido = await _pedidosService.ActualizarAPreparación(codigoPedido, tiempoEstimado);

           

            return Ok(pedido);
        }
        [HttpPatch("ActualizarAListoParaServir")]
        public async Task<ActionResult<PedidoResponseDto>> ActualizarAListoParaServir(int idPedido)
        {
            var pedido = await _pedidosService.ActualizarAListoParaServir(idPedido, 1);

            return Ok(pedido);
        }
        [HttpGet("ClienteMiraPedido")]
        public async Task<ActionResult<TimeSpan>> ClienteMiraPedido(string codigoPedido, string codigoMesa)
        {
            var pedido = await _pedidosService.ClienteMiraPedido(codigoPedido,codigoMesa);



            return Ok(pedido);
        }

        //actualiza el estado del pedido y de la mesa
        [HttpPatch("ServirPedidos")]
        public async Task ServirPedidos()
        {
             await _pedidosService.ServirPedidos();

         }

        [HttpGet("PedidosPendientesPorSector")]
        public async Task<ActionResult<List<PedidoResponseDto>>> PedidosPendientesPorSector(int idSector)
        {
            return await _pedidosService.PedidosPendientesPorSector(idSector);

        }

    }
}
